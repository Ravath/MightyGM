using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Types;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace Core.Data {
	[Table(Schema = "core",Name = "playlist")]
	[CoreData]
	public partial class Playlist : Ressource {

		private int _trackId;
		[Column(Storage = "TrackId",Name = "fk_filteredtrack_track")]
		[HiddenProperty]
		public int TrackId{
			get{ return _trackId;}
			set{_trackId = value;}
		}

		private FilteredTrack _track;
		public FilteredTrack Track{
			get{
				if( _track == null)
					_track = LoadById<FilteredTrack>(TrackId);
				return _track;
			} set {
				if(_track == value){return;}
				_track = value;
				if( value != null)
					TrackId = value.Id;
			}
		}
	}
}
