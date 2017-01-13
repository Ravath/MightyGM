using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data {
	/// <summary>
	/// Object de la database servant de modèle, et identifié par un nom unique.
	/// </summary>
	public abstract class DataModel : DataObject {
		/// <summary>
		/// Nom de l'objet.
		/// </summary>
		[Category("Id")]
		[DisplayName("Nom")]
		[Description("Nom de l'objet, unique en base de donnée.")]
		[Column(Name = "name")]
		public string Name { get; set; }

		public override string ToString() {
			return String.Format("{0}-{1}",Id,Name);
		}
		/// <summary>
		/// Specific Method in order to get classes such as DataDescription or DataExemplaire
		/// </summary>
		/// <typeparam name="RO"></typeparam>
		/// <returns></returns>
		public IEnumerable<RO> GetModelReferencer<RO>() where RO : class, IReferencesModel{
			return LoadByForeignKey<RO>(o => o.ModelID, Id);
		}

		public abstract IDataDescription Description { get; }

		public override void SaveObject() {
			base.SaveObject();
			Description.SaveObject();
		}

		public override void DeleteObject() {
			Description.DeleteObject();
			base.DeleteObject();
		}
	}
}
