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
	[Table(Schema = "core",Name = "document")]
	[CoreData]
	public partial class Document : Ressource {

		private IEnumerable<Paragraph> _paragraphs;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Paragraphs",OtherKey = "DocumentId")]
		public IEnumerable <Paragraph> Paragraphs{
			get{
				if( _paragraphs == null ){
					_paragraphs = LoadFromJointure<Paragraph,DocumentToParagraph_Paragraphs>(false);
				}
				return _paragraphs;
			}
			set{
				SaveToJointure<Paragraph, DocumentToParagraph_Paragraphs> (_paragraphs, value,false);
				_paragraphs = value;
			}
		}

		private IEnumerable<Document> _subDocs;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "SubDocs",OtherKey = "DocumentSubDocsId")]
		public IEnumerable <Document> SubDocs{
			get{
				if( _subDocs == null ){
					_subDocs = LoadFromJointure<Document,DocumentToDocument_SubDocs>(false);
				}
				return _subDocs;
			}
			set{
				SaveToJointure<Document, DocumentToDocument_SubDocs> (_subDocs, value,false);
				_subDocs = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<Document,DocumentToParagraph_Paragraphs>(true);
			DeleteJoins<Document,DocumentToDocument_SubDocs>(true);
			base.DeleteObject();
		}
	}
}
