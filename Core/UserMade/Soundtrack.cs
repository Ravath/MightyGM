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
	public partial class Soundtrack{
		public static Soundtrack[] Cast(FileInfo[] files)
		{
			Soundtrack[] ret = new Soundtrack[files.Length];
			for (int i = 0; i < files.Length; i++)
			{
				FileInfo fi = files[i];
				ret[i] = new Soundtrack() {
					Name = fi.Name.Remove(fi.Name.Length - fi.Extension.Length, fi.Extension.Length),
					FilePath = fi.FullName
				};
			}
			return ret;
		}
	}
}
