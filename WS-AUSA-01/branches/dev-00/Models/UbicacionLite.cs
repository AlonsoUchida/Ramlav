using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAppRest.Models
{
    public class UbicacionLite
    {
        public decimal[] LatLong { get; set; }
        public string Fecha { get; set; }
        public string Operacion { get; set; }
        public string Info { get; set; }
    }
}