using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus.BusinessEntities.DTO
{
    public class CarritoCoEntity
    {
        public string PrsMaiCod { get; set; }
        public string PrsMai { get; set; }
        public string PrsFlgMErr { get; set; }
    }

    public class CarritoTeEntity
    {
        public string PrsTlfCod { get; set; }
        public int PrsPreTlf { get; set; }
        public string PrsNroTlf { get; set; }
        public int PrsAnxTlf { get; set; }
        public string PrsFlgMov { get; set; }
        public string PrsRedPrv { get; set; }
        public int TlfRefCod { get; set; }
        public int OtfCod { get; set; }
        public string PrsFlgTErr { get; set; }
    }

    public class CarritoHij
    {
        public int PrsHijEda { get; set; }
        public string PrsHijSex { get; set; }
    }
}
