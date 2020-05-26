using Core.Data;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MightyGmCtrl.Controleurs
{
	/// <summary>
	/// Class for managing the DB Ressources.
	///	It preloads the DBs and the Tags.
	/// </summary>
	public class CoreDataControl : Controleur
	{

		private List<Tag> _tags;
		private List<RessourceBase> _dbs;
		private IEnumerable<RawRessource> _staticSet;

		// The Types filters of the research
		public bool GetPictures { get; set; }
		public bool GetSounds { get; set; }
		public bool GetTexts { get; set; }
		public bool GetMiscs { get; set; }

		public CoreDataControl(Context context) : base(context)
		{
		}

		#region Tags management
		public List<Tag> GetTags()
		{
			if (_tags == null)
			{
				_tags = GlobalContext.Data.GetTable<Tag>().ToList();
			}
			return _tags;
		}
		public Tag GetTagOrCreateOne(string tagName, bool isFolder)
		{
			foreach (Tag tag in GetTags())
			{
				if (tag.Label == tagName)
				{
					return tag;
				}
			}
			// no tag found : add new one
			Tag newTag = new Tag() {
				Label = tagName,
				IsFolder = isFolder
			};

			newTag.SaveObject();
			_tags.Add(newTag);

			return newTag;
		}
		public bool AddNewTag(string tagName, bool isFolder, out string errorMessage)
		{
			// Check if valid
			if (String.IsNullOrWhiteSpace(tagName))
			{
				errorMessage = "Tag Name is compulsory";
				return false;
			}

			// Check if already in DB
			if (GetTags().Exists(t => t.Label == tagName))
			{
				errorMessage = "This Tag Name Already Exists";
				return false;
			}

			// Tag integration
			try
			{
				Tag newTag = new Tag() { Label = tagName, IsFolder = isFolder };
				newTag.SaveObject();
				_tags.Add(newTag);
			}
			catch (Exception e)
			{
				errorMessage = e.Message;
				return false;
			}

			// Went well
			errorMessage = "Tag Created";
			return true;
		}
		#endregion

		#region DB management
		public List<RessourceBase> GetDBs()
		{
			if (_dbs == null)
			{
				_dbs = GlobalContext.Data.GetTable<RessourceBase>().ToList();
			}
			return _dbs;
		}
		public RessourceBase GetDBOrCreateOne(string dbPath)
		{
			foreach (RessourceBase db in GetDBs())
			{
				if (db.Path == dbPath)
				{
					return db;
				}
			}
			// no db found : add new one
			RessourceBase newDb = new RessourceBase()
			{
				Path = dbPath,
				DefaultMiscPath = ".",
				DefaultTextPath = ".",
				DefaultImagePath = ".",
				DefaultSoundtrackPath = "."
			};
			newDb.SaveObject();
			_dbs.Add(newDb);

			return newDb;
		}
		/// <summary>
		/// Check if the given directory is already contained by at least one of the DB,
		/// or if already one of the DB.
		/// </summary>
		/// <param name="testedDir">The direcotry to check.</param>
		/// <returns>True is contained or equal to another DB.</returns>
		public bool IsContainedByAlreadyExistingDB(DirectoryInfo testedDir)
		{
			foreach (RessourceBase db in GetDBs())
			{
				if (testedDir.FullName.StartsWith(db.Info.FullName))
				{
					return true;
				}
			}
			return false;
		}
		#endregion

		/// <summary>
		/// Add the given directory to the ressources data as a new DB.
		/// </summary>
		/// <param name="directory">The directory to add.</param>
		/// <returns>The new imported ressources. Null if had already imported.</returns>
		public IEnumerable<RawRessource> ImportNewDb(DirectoryInfo directory)
		{
			if (IsContainedByAlreadyExistingDB(directory))
			{
				return null;
			}
			/*
			 * else, even if intersects another DB
			 * (e.g : contains another one),
			 * it simply keeps the previous one.
			 * TODO : maybe change the previous one for the new one?
			 */

			// Get a new DB
			RessourceBase db = GetDBOrCreateOne(directory.FullName);
			int dirNameLength = directory.FullName.Length + 1/* for the slash*/;

			List<RawRessource> newRessources = new List<RawRessource>();

			// Parse every file in the directory
			foreach (var item in directory.EnumerateFiles("*", SearchOption.AllDirectories))
			{
				// Get the ressource's directory relative to the DB
				string relativeDirectoryPath = ".";
				if (item.Directory.FullName != db.Info.FullName) {
					relativeDirectoryPath = item.DirectoryName.Remove(0, dirNameLength);
				}

				// If doesn't exist
				if (RessourceAlreadyInDB(item)) continue;

				// Instanciate with adequate 'RessourceType'
				RawRessource ressource = new RawRessource()
				{
					Name = item.Name,
					RessourceType = GetRessourceType(item),
					DB = db,
					Path = relativeDirectoryPath,
				};
				ressource.SaveObject();

				// tag gestion
				List<Tag> resTags = new List<Tag>();
				foreach (var repName in relativeDirectoryPath.Split('\\'))
				{
					if (repName == ".") continue;
					resTags.Add(GetTagOrCreateOne(repName, true));
				}
				ressource.Tags = resTags;

				// Add to result list
				newRessources.Add(ressource);
			}

			//Return result list
			return newRessources;
		}

		/// <summary>
		/// Checks if the ressource already exists in the DB.
		/// </summary>
		/// <param name="item">The file to check.</param>
		/// <returns>True is already exists.</returns>
		public bool RessourceAlreadyInDB(FileInfo item)
		{
			var q = from t in GlobalContext.Data.GetTable<RawRessource>()
					where t.Name == item.Name
					select t;
			//The 'toArray' here is necessary because linq can't interpret the 'Info' property;
			return q.ToArray().Where(t => t.Info.FullName == item.FullName).Count() >= 1;
		}

		/// <summary>
		/// use the File extension to determine the appropiate ressource type.
		/// </summary>
		/// <param name="file">The file to check.</param>
		/// <returns>The RessourceType of the given File.</returns>
		public RawRessourceType GetRessourceType(FileInfo file)
		{
			RawRessourceType ret;
			if (GlobalContext.Files.IsCompatibleImage(file.Extension))
			{
				ret = RawRessourceType.Picture;
			}
			else if (GlobalContext.Files.IsCompatibleSoundtrack(file.Extension))
			{
				ret = RawRessourceType.Soundtrack;
			}
			else if (GlobalContext.Files.IsCompatibleText(file.Extension))
			{
				ret = RawRessourceType.Text;
			}
			else
			{
				ret = RawRessourceType.Misc;
			}
			return ret;
		}

		/// <summary>
		/// Sets a static set of ressources to search from instead of the DB.
		/// </summary>
		/// <param name="staticSet">Null for remove.</param>
		public void SetStaticSet(IEnumerable<RawRessource> staticSet)
		{
			_staticSet = staticSet;
		}

		/// <summary>
		/// Get the ressources filtered per the property setted criterias.
		/// </summary>
		/// <returns>Search result.</returns>
		public IEnumerable<RawRessource> GetRessources()
		{
			// Use static set if any
			IEnumerable<RawRessource> setToUse = _staticSet ?? GlobalContext.Data.GetTable<RawRessource>();
			
			// Get research Result
			var q = from t in setToUse
					where
					 GetPictures && t.RessourceType == RawRessourceType.Picture
					|| GetSounds && t.RessourceType == RawRessourceType.Soundtrack
					|| GetTexts  && t.RessourceType == RawRessourceType.Text
					|| GetMiscs  && t.RessourceType == RawRessourceType.Misc
				select t;
			return q.OrderBy(t=>t.Id);
		}
	}
}
