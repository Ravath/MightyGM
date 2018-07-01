using System;
using System.Collections;
using System.Collections.Generic;
using LinqToDB.Mapping;
namespace Core.Data {
	[Table(Schema = "core",Name = "filteredtrack")]
	[CoreData]
	public partial class FilteredTrack : Soundtrack {

		private bool _repeat;
		[Column(Storage = "Repeat",Name = "repeat")]
		public bool Repeat{
			get{ return _repeat;}
			set{_repeat = value;}
		}

		private IEnumerable<SoundFilter> _filters;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Filters",OtherKey = "FilteredTrackId")]
		public IEnumerable <SoundFilter> Filters{
			get{
				if( _filters == null ){
					_filters = LoadFromJointure<SoundFilter,FilteredTrackToSoundFilter_Filters>(false);
				}
				return _filters;
			}
			set{
				SaveToJointure<SoundFilter, FilteredTrackToSoundFilter_Filters> (_filters, value,false);
				_filters = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<FilteredTrack,FilteredTrackToSoundFilter_Filters>(true);
			base.DeleteObject();
		}
	}
}
