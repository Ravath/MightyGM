using Core.Data.Schema;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data {
	public interface IReferencesModel  : IDataObject{
		int ModelId { get; }
		DataModel Model { get; set; }
	}
	public interface IDataExemplaire : IDataObject, IReferencesModel { }
	public class DataExemplaire<Ref> : DataObject, IDataExemplaire where Ref : DataModel {
		private int _modelId;
		/// <summary>
		/// L'id associé au modèle associé à cet exemplaire.
		/// </summary>
		[Column(Name = "fk_model_id")]
		[Category("Exemplaire")]//TODO : trouver un attribut pour ne pas l'afficher
		[HiddenProperty]
		public int ModelId { get { return _modelId; } set { _modelId = value; } }

		private Ref _model;
		/// <summary>
		/// Le modèle associé à cet exemplaire.
		/// </summary>
		[Category("Exemplaire")]
		[Association(ThisKey = "fk_model_id", OtherKey = "id", CanBeNull = false)]
		public Ref Model {
			get {
				if(_model == null) {
					_model = LoadById<Ref>(ModelId);
				}
				return _model;
			}
			set {
				if(value == _model) { return; }
				_model = value;
				if(_model != null) {
					_modelId = _model.Id;
				}
			}
		}

		DataModel IReferencesModel.Model {
			get {
				return Model;
			}
			set {
				Model = (Ref)value;
			}
		}

		public override string ToString() {
			return String.Format("{0}-Ex({1})", Id, Model?.Name);
		}
	}
}
