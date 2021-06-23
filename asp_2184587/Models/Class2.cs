using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_2184587.Models
{
	public class ReporteCompra
	{
		public string nombreCliente { get; set; }
		public string documentoCliente { get; set; }
		
		public Nullable<System.DateTime> fechaCompra { get; set; }
		
		public int? totalCompra { get; set; }
	}
}