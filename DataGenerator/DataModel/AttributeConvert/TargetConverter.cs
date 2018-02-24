using DataGenerator.DataModel.Model;
using DataGenerator.Parser;
using System;

namespace DataGenerator.DataModel.AttributeConvert
{
	/// <summary>
	/// Base class of the attribute target converters.
	/// </summary>
	public abstract class AbsTargetConverter : AbsAttributeConverter
	{
		public static NoTargetConverter NoTarget = new NoTargetConverter();
		public static StructTargetConverter StructTarget = new StructTargetConverter();
		public static DataObjectTargetConverter DataObjetTarget = new DataObjectTargetConverter();

		public abstract void Convert(DatabaseModel dm, DataEntity entity, RawTable tab);

		protected void NoTargetProp(DataEntity entity, RawAttribute raw)
		{
			CheckAttributePresence(entity.Name, raw.Name, raw.Target, false, "Target");
		}
	}

	/// <summary>
	/// Check there isn't a Target value in the RawTable, which is therefore not used.
	/// </summary>
	public class NoTargetConverter : AbsTargetConverter
	{
		public override void Convert(DatabaseModel dm, DataEntity entity, RawTable tab)
		{
			foreach (RawAttribute raw in tab.Attributes)
			{
				NoTargetProp(entity, raw);
			}
		}
	}

	public abstract class AbsStructTargetConverter : AbsTargetConverter
	{
		public void CheckTarget(DataObjectReferenceAttribute att, AbsDataStruct reference, string targetName)
		{
			AbsDataStructAttribute doa = null;
			//Find the Target.
			if (att is DataObjectModelRefAttribute dra)
			{
				if(reference is DataObject objReference)
				{
					doa = objReference.ModelAttributes.GetByName(targetName);
				}
				else if (reference is DataStruct structReference)
				{
					doa = structReference.Attributes.GetByName(targetName);
				}
			}
			else if(att is DataObjectExemplarRefAttribute)
			{
				doa = ((DataObject)reference).ExemplarAttributes.GetByName(targetName);
			}
			else
			{
				//ROBUSTNESS
				throw new ArgumentException("The argument is of not managed type");
			}

			//Must exist and be a reflexive reference
			if (doa == null)
			{
				ErrorManager.ErrorRef("ATT_REF_NOT_FOUND", att.Parent.Name, att.Name, targetName, reference.Name);
			}
			else if (doa is DataObjectModelRefAttribute || doa is DataObjectExemplarRefAttribute)
			{
				att.Reflexive = doa;
			}
			else
			{
				ErrorManager.ErrorRef("ATT_REF_NOT_REF", att.Parent.Name, att.Name, targetName, reference.Name);
			}
		}
		/// <summary>
		/// Reference to a table. May use the target.
		/// </summary>
		/// <param name="dm"></param>
		/// <param name="att"></param>
		/// <param name="raw"></param>
		public void LinkReference(DatabaseModel dm, DataObjectReferenceAttribute att, RawAttribute raw)
		{
			//Get Data reference
			AbsDataStruct dataEntity = (AbsDataStruct)dm.GetDataStruct(raw.TypeTag) ?? dm.GetDataObject(raw.TypeTag);
			if (dataEntity == null)
			{
				ErrorManager.ErrorRef("ATT_TABLE_NOT_FOUND", att.Parent.Name, att.Name, raw.TypeTag);
			}
			else
			{
				att.Reference = dataEntity;

				//Special error case : a refex can't reference a struct
				if (att is DataObjectExemplarRefAttribute && dataEntity is DataStruct)
				{
					ErrorManager.ErrorRef("ATT_REFEX_TO_STRUCT_ERROR", att.Parent.Name, att.Name);
				}
				else
				{
					//If have a Target : check link
					if (!string.IsNullOrWhiteSpace(raw.Target))
					{
						CheckTarget(att, dataEntity, raw.Target);
					}
				}
			}
		}
		/// <summary>
		/// Enum reference. Target is not used, but have to link to the enum.
		/// </summary>
		/// <param name="dm"></param>
		/// <param name="att"></param>
		/// <param name="raw"></param>
		public void LinkReference(DatabaseModel dm, DataObjectEnumAttribute att, RawAttribute raw)
		{
			//Get Enum reference
			DataEnum enumEntity = dm.GetDataEnum(raw.TypeTag);
			if (enumEntity == null)
			{
				ErrorManager.ErrorRef("ATT_ENUM_NOT_FOUND", att.Parent.Name, att.Name, raw.TypeTag);
			}
			else
			{
				att.Enum = enumEntity;
			}
			//The Target field is not used
			NoTargetProp(att.Parent, raw);
		}
		/// <summary>
		/// Basic value. The Target is not used.
		/// </summary>
		/// <param name="dm"></param>
		/// <param name="att"></param>
		/// <param name="raw"></param>
		public void LinkReference(DatabaseModel dm, AbsDataStructAttribute att, RawAttribute raw)
		{
			//If not a reference must not have a Target
			NoTargetProp(att.Parent, raw);
		}

	}

	public class StructTargetConverter : AbsStructTargetConverter
	{
		public override void Convert(DatabaseModel dm, DataEntity entity, RawTable tab)
		{
			DataStruct dataStruct = (DataStruct)entity;

			foreach (AbsDataStructAttribute datt in dataStruct.Attributes.Attributes)
			{
				//Get the rawDefinition
				RawAttribute raw = tab.FindRawAttributeByName(datt.Name);

				//Work depends on the type
				if (datt is DataObjectReferenceAttribute dr)
				{
					LinkReference(dm, dr, raw);
				}
				else if (datt is DataObjectEnumAttribute de)
				{
					if(de.Enum == null)//some specific units will already be referenced
						LinkReference(dm, de, raw);
				}
				else
				{
					LinkReference(dm, datt, raw);
				}
			}
		}
	}

	public class DataObjectTargetConverter : AbsStructTargetConverter
	{
		public override void Convert(DatabaseModel dm, DataEntity entity, RawTable tab)
		{
			DataObject dataObject = (DataObject)entity;

			foreach (AbsDataStructAttribute datt in dataObject.Attributes)
			{
				//Get the rawDefinition
				RawAttribute raw = tab.FindRawAttributeByName(datt.Name);

				//Work depends on the type
				if (datt is DataObjectReferenceAttribute dr)
				{
					LinkReference(dm, dr, raw);
				}
				else if (datt is DataObjectEnumAttribute de)
				{
					LinkReference(dm, de, raw);
				}
				else
				{
					LinkReference(dm, datt, raw);
				}
			}
		}
	}
}
 