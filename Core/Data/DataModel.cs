using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Core.Data {
	/// <summary>
	/// Object de la database servant de modèle, et identifié par un nom unique.
	/// </summary>
	public abstract class DataModel : DataObject, IDataModel
	{
		/// <summary>
		/// Nom de l'objet.
		/// </summary>
		[Category("Id")]
		[DisplayName("Nom")]
		[Description("Nom de l'objet, unique en base de donnée.")]
		[Column(Name = "name")]
		public string Name { get; set; }
		/// <summary>
		/// To string par défaut, affichant l'identifiant et le nom de l'objet.
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return String.Format("{0}-{1}",Id,Name);
		}
		/// <summary>
		/// 7 Caractères permettant d'identifier un élément de manière unique.
		/// Invariant pour toute base de donnée.
		/// Privilégier à l'Id pour communiquer entre le code et la BD, car l'id est variable et fixé par la base, tandis que le tag est décidé par le concepteur.
		/// </summary>
		[Category("Id")]
		[DisplayName("Tag")]
		[Description("Le tag permettant d'identifier l'objet dans le code.")]
		[Column(Name = "tag")]
		public string Tag { get; set; }

		/// <summary>
		/// Specific Method in order to get classes such as DataDescription or DataExemplaire
		/// </summary>
		/// <typeparam name="RO"></typeparam>
		/// <returns></returns>
		public IEnumerable<RO> GetModelReferencer<RO>() where RO : class, IReferencesModel{
			return LoadByForeignKey<RO>(o => o.ModelId, Id);
		}
		/// <summary>
		/// La description de l'objet.
		/// </summary>
		public abstract IDataDescription Description { get; }
		/// <summary>
		/// Sauvegarde les données de l'objet et de sa description dans la database.
		/// </summary>
		public override void SaveObject() {
			base.SaveObject();
			Description.Model = this;
			Description.SaveObject();
		}
		/// <summary>
		/// Supprime l'objet de la database.
		/// Supprime aussi la description, et tous les exemplaires qui lui sont associés.
		/// </summary>
		public override void DeleteObject() {
			Description.DeleteObject();
			Type t = GetType();
			/* pour tous les types exemplaires qui référencent des modèles du type supprimé */
			foreach(Type et in t.Assembly.GetTypes().
				Where(it => typeof(IDataExemplaire).IsAssignableFrom(it))) {
				if(et.GetProperty("Model").PropertyType.IsAssignableFrom(t)) {
					foreach(IDataExemplaire ide in Data.GetDataTable(et).ToArray()) {
						/* Supprimer l'exemplaire si il référence l'objet supprimé */
						if(ide.ModelId == this.Id)
							ide.DeleteObject();
					}
				}
			}
			/* supprimer l'objet */
			base.DeleteObject();
		}
	}
}
