using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Linq;
using Core.Types;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace Pathfinder.Data {
	[Table(Schema = "pathfinder",Name = "objetintelligent")]
	[CoreData]
	public partial class ObjetIntelligent : DataObject {

		private int _intelligence;
		[Column(Storage = "Intelligence",Name = "intelligence")]
		public int Intelligence{
			get{ return _intelligence;}
			set{_intelligence = value;}
		}

		private int _sagesse;
		[Column(Storage = "Sagesse",Name = "sagesse")]
		public int Sagesse{
			get{ return _sagesse;}
			set{_sagesse = value;}
		}

		private int _charisme;
		[Column(Storage = "Charisme",Name = "charisme")]
		public int Charisme{
			get{ return _charisme;}
			set{_charisme = value;}
		}

		private int _ego;
		[Column(Storage = "Ego",Name = "ego")]
		public int Ego{
			get{ return _ego;}
			set{_ego = value;}
		}

		private AlignementLoi _alignementLoi;
		[Column(Storage = "AlignementLoi",Name = "alignementloi")]
		public AlignementLoi AlignementLoi{
			get{ return _alignementLoi;}
			set{_alignementLoi = value;}
		}

		private AlignementBien _alignementBien;
		[Column(Storage = "AlignementBien",Name = "alignementbien")]
		public AlignementBien AlignementBien{
			get{ return _alignementBien;}
			set{_alignementBien = value;}
		}

		private IEnumerable<LangueModel> _languesConnues;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "LanguesConnues",OtherKey = "ObjetIntelligentId")]
		public IEnumerable <LangueModel> LanguesConnues{
			get{
				if( _languesConnues == null ){
					_languesConnues = LoadFromJointure<LangueModel,ObjetIntelligentToLangueModel_LanguesConnues>(false);
				}
				return _languesConnues;
			}
			set{
				SaveToJointure<LangueModel, ObjetIntelligentToLangueModel_LanguesConnues> (_languesConnues, value,false);
				_languesConnues = value;
			}
		}

		private bool _empathie;
		[Column(Storage = "Empathie",Name = "empathie")]
		public bool Empathie{
			get{ return _empathie;}
			set{_empathie = value;}
		}

		private bool _telepathie;
		[Column(Storage = "Telepathie",Name = "telepathie")]
		public bool Telepathie{
			get{ return _telepathie;}
			set{_telepathie = value;}
		}

		private bool _parole;
		[Column(Storage = "Parole",Name = "parole")]
		public bool Parole{
			get{ return _parole;}
			set{_parole = value;}
		}

		private int _sens;
		[Column(Storage = "Sens",Name = "sens")]
		public int Sens{
			get{ return _sens;}
			set{_sens = value;}
		}

		private bool _visioDansLeNoir;
		[Column(Storage = "VisioDansLeNoir",Name = "visiodanslenoir")]
		public bool VisioDansLeNoir{
			get{ return _visioDansLeNoir;}
			set{_visioDansLeNoir = value;}
		}

		private bool _visionAveugle;
		[Column(Storage = "VisionAveugle",Name = "visionaveugle")]
		public bool VisionAveugle{
			get{ return _visionAveugle;}
			set{_visionAveugle = value;}
		}

		private bool _lectureDesLangues;
		[Column(Storage = "LectureDesLangues",Name = "lecturedeslangues")]
		public bool LectureDesLangues{
			get{ return _lectureDesLangues;}
			set{_lectureDesLangues = value;}
		}

		private bool _lectureDeLaMagie;
		[Column(Storage = "LectureDeLaMagie",Name = "lecturedelamagie")]
		public bool LectureDeLaMagie{
			get{ return _lectureDeLaMagie;}
			set{_lectureDeLaMagie = value;}
		}
		public override void DeleteObject() {
			DeleteJoins<ObjetIntelligent,ObjetIntelligentToLangueModel_LanguesConnues>(true);
			base.DeleteObject();
		}
	}
}
