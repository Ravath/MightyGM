using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public interface IGlobalContext {
		Database Data { get; }
		ILocalContext LocalContext { get; }
	}
}
