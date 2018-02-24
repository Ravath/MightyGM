using DataGenerator.CSharp;
using DataGenerator.DataModel.Model;
using DataGenerator.SQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator.DataModel
{
	/// <summary>
	/// Utility used to generate CS files and a Postgres SQL database from a DataModel.
	/// </summary>
	public class Generation
	{
		#region Members - Folders
		SQLSchema _sql = new SQLSchema();
		CSNamespace _csNamespace = new CSNamespace();
		SQLSchema _schema = new SQLSchema();
		Repertory _repRoot, _repGenerated, _repUser, _repSql;
		CsFile _enumFile, _relFile;
		SqlFile _sqlFile;
		#endregion

		#region Members - Collections
		private List<Tuple<CSReferenceAttribute, DataObjectReferenceAttribute>> _creationReferencesStep = new List<Tuple<CSReferenceAttribute, DataObjectReferenceAttribute>>();
		private Dictionary<DataEntity, CSClass> _structs = new Dictionary<DataEntity, CSClass>();
		private Dictionary<DataEntity, CSEnum> _enums = new Dictionary<DataEntity, CSEnum>();
		private Dictionary<DataEntity, CSClass> _models = new Dictionary<DataEntity, CSClass>();
		private Dictionary<DataEntity, CSClass> _exemplars = new Dictionary<DataEntity, CSClass>();
		private Dictionary<DataEntity, CSClass> _descriptions = new Dictionary<DataEntity, CSClass>();
		#endregion


		#region SQL
		public SQLSchema SchemaSql { get { return _schema; } }

		public void AddToSql(SQLTable ts)
		{
			_sqlFile.Database.AddTable(ts);
		} 
		#endregion

		#region CsFiles
		public CsFile JoinFile { get { return _relFile; } }
		
		public void AddPartialCsFile(CsFile file)
		{
			_repUser.AddFile(file);
			file.Namespace = _csNamespace;
			AddUsings(file);
		}
		public void AddCsFile(CsFile file)
		{
			_repGenerated.AddFile(file);
			file.Namespace = _csNamespace;
			AddUsings(file);
		}

		private void AddUsings(CsFile file)
		{
			file.AddUsing("System");
			file.AddUsing("System.Collections");
			file.AddUsing("System.Collections.Generic");
			file.AddUsing("System.IO");
			file.AddUsing("System.Linq");
			file.AddUsing("System.Data.Linq");
			file.AddUsing("Core.Types");
			file.AddUsing("Core.Data");
			file.AddUsing("Core.Data.Schema");
			file.AddUsing("LinqToDB.Mapping");
		}
		#endregion

		#region DataEntities
		/// <summary>
		/// Stores a DataStruct CsClass for later use in generation steps
		/// </summary>
		/// <param name="dataStruct"></param>
		/// <param name="cs"></param>
		public void AddStruct(DataStruct dataStruct, CSStruct cs)
		{
			_structs.Add(dataStruct, cs);
		}
		public CSClass GetStruct(DataStruct dataStruct)
		{
			return _structs[dataStruct];
		}
		/// <summary>
		/// Stores a DataObject CsClasses for later use in generation steps
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="csMod"></param>
		/// <param name="csEx"></param>
		/// <param name="csDesc"></param>
		public void AddDataObject(DataEntity entity, CSClass csMod, CSClass csEx, CSClass csDesc)
		{
			_models.Add(entity, csMod);
			_exemplars.Add(entity, csEx);
			_descriptions.Add(entity, csDesc);
		}
		public CSClass GetModelClass(DataEntity entity)
		{
			return _models[entity];
		}
		public CSClass GetExemplarClass(DataEntity entity)
		{
			return _exemplars[entity];
		}
		public CSClass GetDescriptionClass(DataEntity entity)
		{
			return _descriptions[entity];
		}
		/// <summary>
		/// Stores a DataEnum CsClasses for later use in generation steps
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="et"></param>
		public void AddEnum(DataEntity entity, CSEnum et)
		{
			_enumFile.AddClasse(et);
			_enums.Add(entity, et);
		}
		public CSEnum GetEnum(DataEntity entity)
		{
			return _enums[entity];
		}
		#endregion

		#region Temporary store of reference attributes
		/// <summary>
		/// Stores ReferenceAttributes in order to match the last links later.
		/// </summary>
		/// <param name="ra">The Reference that has to be linked.</param>
		/// <param name="va">It's model definition.</param>
		public void RegisterReference(CSReferenceAttribute ra, DataObjectReferenceAttribute va)
		{
			_creationReferencesStep.Add(new Tuple<CSReferenceAttribute, DataObjectReferenceAttribute>(ra, va));
		} 
		#endregion

		/// <summary>
		/// Generate Cs and Sql files in folder named by the Database Name.
		/// </summary>
		/// <param name="dm"></param>
		public void Generate(DatabaseModel dm)
		{
			//Create Folders&Files
			OrganiseFolders(dm);

			//Generation
			IEnumerable<DataEntity> entities = dm.Enums.Cast<DataEntity>().Union(dm.Dices).Union(dm.Structs).Union(dm.Objects);
			foreach (DataEntity entity in entities) { entity.Generate(this); }
			foreach (DataEntity entity in entities) { entity.LinkParents(this); }
			foreach (DataEntity entity in entities) { entity.CreateAttributes(this); }

			//Joint tables
			foreach (var item in _creationReferencesStep)
			{
				LinkReferences(item.Item1, item.Item2);
			}

			//Write
			_repRoot.GenerateRepertory();
		}

		/// <summary>
		/// Create the folders where the files will be written.
		/// </summary>
		/// <param name="dm"></param>
		private void OrganiseFolders(DatabaseModel dm)
		{
			// Create Folders
			_repRoot = new Repertory() { Name = dm.Name };
			_repGenerated = new Repertory() { Name = "Generated" };
			_repUser = new Repertory() { Name = "UserMade" };
			_repSql = new Repertory() { Name = "SQL" };
			_repRoot.AddRepertory(_repGenerated);
			_repRoot.AddRepertory(_repUser);
			_repRoot.AddRepertory(_repSql);
			// Create Namespace
			_csNamespace.Name = dm.Name + ".Data";
			_schema.Name = dm.Name;
			// Add Generic Files
			_enumFile = new CsFile("Enum", _csNamespace);
			_relFile = new CsFile("Jointures", _csNamespace);
			_relFile.AddUsing("Core.Data");
			_relFile.AddUsing("Core.Data.Schema");
			_relFile.AddUsing("LinqToDB.Mapping");
			_repGenerated.AddFile(_enumFile);
			_repGenerated.AddFile(_relFile);
			_sqlFile = new SqlFile("SqlGeneration", _schema);
			_sqlFile.Database.AddTable(CSDataObject.sqlDataObject);
			_repSql.AddFile(_sqlFile);
		}

		/// <summary>
		/// Link the reflexive references between two reference attributes.
		/// </summary>
		/// <param name="csAtt">The attribute to womplete the link.</param>
		/// <param name="va">Description of the attribute.</param>
		private void LinkReferences(CSReferenceAttribute csAtt, DataObjectReferenceAttribute va)
		{
			//Check if already done
			if (csAtt.ReferencedAttribute != null) { return; }

			//Find Referenced Attribute
			CSReferenceAttribute refer = csAtt.ReferencedClass.Attributes.OfType<CSReferenceAttribute>().SingleOrDefault(a => a.Name == va.Reflexive.Name);

			//Link
			if (csAtt is CSOneToOne && refer is CSOneToOne
				|| csAtt is CSManyToOne && refer is CSOneToMany
				|| csAtt is CSOneToMany && refer is CSManyToOne)
			{
				csAtt.ReferencedAttribute = refer;
			}
			else if (csAtt is CSOneToMany && refer is CSOneToMany)
			{
				CSClass joint = CreateJointTable((CSOneToMany)csAtt, (CSOneToMany)refer);
				csAtt.Class.AddJoint((CSOneToManyJoint)csAtt, joint);
				refer.Class.AddJoint((CSOneToManyJoint)refer, joint);
			}
			else
			{
				ErrorManager.ErrorRef("GEN_REL_TYPES", csAtt.Class.Name, csAtt.Name, csAtt.GetType().Name, refer.GetType().Name);
			}
		}

		/// <summary>
		/// Create a Joint table between two properties.
		/// </summary>
		/// <param name="ra">First reference.</param>
		/// <param name="rb">Second reference.</param>
		/// <returns></returns>
		private CSClass CreateJointTable(CSOneToMany ra, CSOneToMany rb)
		{
			CSRelationClass csRel = new CSRelationClass(ra.Class, rb.Class, SchemaSql, ra.Name, rb.Name);
			JoinFile.AddClasse(csRel);
			AddToSql(csRel.SQLTable);
			CSOneToManyJoint left = ra as CSOneToManyJoint;
			CSOneToManyJoint right = rb as CSOneToManyJoint;
			left.FromLeft = true;
			right.FromLeft = false;
			left.Joint = csRel;
			right.Joint = csRel;
			return csRel;
		}
	}
}
