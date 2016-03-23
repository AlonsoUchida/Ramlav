using System.Collections.Generic;

namespace Bonus.BusinessEntities.DTO
{
    public class MovFideEntity
    {
        public int NroTrn { get; set; }
        public List<Transaccion> Transacciones { get; set; }
    }

    public class Transaccion
    {
        public string FchHor { get; set; }
        public string HorProc { get; set; }
        public string FchProc { get; set; }
        public string FchAsig { get; set; }
        public string Descrip { get; set; }
        public double? PtosAsig { get; set; }
        public double? PtosCanj { get; set; }
        public string EsCanje { get; set; }
    }
}
