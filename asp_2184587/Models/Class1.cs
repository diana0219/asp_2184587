using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_2184587.Models
{
	public class Reporte
	{
		public string nombreProvedor { get; set; }
		public string direccionProvedor { get; set; }
		public string telefonoProvedor { get; set; }
		public string nombreProducto { get; set; }
		public int? precioProducto { get; set; }
	}
}