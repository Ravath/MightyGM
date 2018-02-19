using Core.Data.Schema;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data {
	public interface IDataDescription : IDataObject , IReferencesModel {
		string Description { get; set; }
	}
	/// <summary>
	/// Objet de database en décrivant un autre.
	/// </summary>
	/// <typeparam name="Ref">Type de l'objet décrit.</typeparam>
	public abstract class DataDescription<Ref> : DataObject, IDataDescription where Ref : DataModel {
		private int _modelId;
		/// <summary>
		/// L'id associé au modèle associé à cette description.
		/// </summary>
		[Category("Description")]//TODO : trouver un attribut pour ne pas l'afficher
		[Column(Name = "fk_model_id")]
		[HiddenProperty]
		public int ModelId { get { return _modelId; } set { _modelId = value; } }

		/// <summary>
		/// Le modèle associé à cette description.
		/// </summary>
		[Association(ThisKey = "fk_model_id", OtherKey = "id", CanBeNull = false)]
		private Ref _model;
		[HiddenProperty]
		public Ref Model {
			get {
				if(_model == null) {
					_model = LoadById<Ref>(ModelId);
				}
				return _model;
			}
			set {
				ModelId = value.Id;
				_model = value;
			}
		}

		private string _description = "";
		/// <summary>
		/// Nom de l'objet.
		/// </summary>
		[Category("Description")]
		[DisplayName("Description")]
		[Description("Description générale de l'objet.")]
		[Column(Name = "description")]
		[LargeText]
		public string Description {
			get { return _description; }
			set { _description = value; }
		}

		[HiddenProperty]
		DataModel IReferencesModel.Model {
			get {
				return Model;
			}
			set {
				Model = (Ref)value;
			}
		}

		public override string ToString() {
			return String.Format("{0}-Desc({1})", Id, Model.Name);
		}

		public override void SaveObject() {
			ModelId = Model.Id;//has to be updated in case it changed during insertion.
			base.SaveObject();
		}
	}
}
