using DataGenerator.CSharp;
using DataGenerator.DataModel2;
using DataGenerator.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
	public class Generation
	{
		private SQLSchema _schema = new SQLSchema();
		private CSNamespace _namespace = new CSNamespace();

		public void SetDatabaseName(string name)
		{
			_schema.Name = name;
			_namespace.Name = name;
		}


		#region EnumTables
		private Dictionary<string, CSEnum> _enums = new Dictionary<string, CSEnum>();

		public void AddEnum(DataEnum dataEnum)
		{
			CSEnum csenum = new CSEnum(dataEnum.Name);
			foreach (DataAttribute att in dataEnum.Attributes)
			{
				csenum.AddTag(att.Name);
			}
			_enums.Add(dataEnum.Name, csenum);
		}
		public CSEnum GetEnumClass(string name)
		{
			return _enums[name];
		}
		#endregion

		#region DiceTables
		private Dictionary<string, CSClass> _diceClasses = new Dictionary<string, CSClass>();

		public void AddDice(DataDice dataDice)
		{
			_diceClasses.Add(dataDice.Name, new CSClass(dataDice.Name+"Dice"));
		}
		public CSClass GetDiceClass(string name)
		{
			return _diceClasses[name];
		}
		#endregion


		#region DataTables
		private Dictionary<string, CSClass> _modelClasses = new Dictionary<string, CSClass>();
		private Dictionary<string, CSClass> _exemplarClasses = new Dictionary<string, CSClass>();
		private Dictionary<string, CSClass> _descriptionClasses = new Dictionary<string, CSClass>();
		private Dictionary<string, SQLTable> _modelTables = new Dictionary<string, SQLTable>();
		private Dictionary<string, SQLTable> _exemplarTables = new Dictionary<string, SQLTable>();
		private Dictionary<string, SQLTable> _descriptionTables = new Dictionary<string, SQLTable>();

		public void AddDataObject(DataObject dataClasse)
		{
			_modelClasses.Add(dataClasse.Name, new CSClass(dataClasse.Name + "Model"));
			_exemplarClasses.Add(dataClasse.Name, new CSClass(dataClasse.Name + "Exemplar"));
			_descriptionClasses.Add(dataClasse.Name, new CSClass(dataClasse.Name + "Description"));
			_modelTables.Add(dataClasse.Name, new SQLTable(dataClasse.Name + "_model"));
			_exemplarTables.Add(dataClasse.Name, new SQLTable(dataClasse.Name + "_exemplar"));
			_descriptionTables.Add(dataClasse.Name, new SQLTable(dataClasse.Name + "_description"));
		}
		public CSClass GetModelClass(string name)
		{
			return _modelClasses[name];
		}
		public CSClass GetExemplarClass(string name)
		{
			return _exemplarClasses[name];
		}
		public CSClass GetDescriptionClass(string name)
		{
			return _descriptionClasses[name];
		}
		public SQLTable GetModelTable(string name)
		{
			return _modelTables[name];
		}
		public SQLTable GetExemplarTable(string name)
		{
			return _exemplarTables[name];
		}
		public SQLTable GetDescriptionTable(string name)
		{
			return _descriptionTables[name];
		}
		#endregion

		#region StructTables
		private Dictionary<string, CSClass> _structClasses = new Dictionary<string, CSClass>();
		private Dictionary<string, SQLTable> _structTables = new Dictionary<string, SQLTable>();

		public void AddStruct(DataStruct dataStruct)
		{
			_structClasses.Add(dataStruct.Name, new CSClass(dataStruct.Name));
			_structTables.Add(dataStruct.Name, new SQLTable(dataStruct.Name));
		}
		public CSClass GetStructClass(string name)
		{
			return _structClasses[name];
		}
		public SQLTable GetStructTable(string name)
		{
			return _structTables[name];
		}
		#endregion
	}
}
