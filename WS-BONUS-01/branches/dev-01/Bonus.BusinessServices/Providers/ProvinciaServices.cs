using System;
using System.Collections.Generic;
using Bonus.BusinessEntities.DTO;
using Bonus.BusinessServices.Interfaces;

namespace Bonus.BusinessServices.Providers
{
    public class ProvinciaServices : IProvinciaServices
    {
        public List<ProvinciaEntity> ObtenerProvincias(string dptoCod)
        {
            WsBonusProvincias.wslisproSoapPortClient ws = new WsBonusProvincias.wslisproSoapPortClient();
            WsBonusProvincias.LisproLisproItem[] lisproLisproItem = ws.Execute(dptoCod);
            List<ProvinciaEntity> provincias = new List<ProvinciaEntity>();
            if (lisproLisproItem != null)
            {
                for (int i = 0; i < lisproLisproItem.Length; i++)
                {
                    ProvinciaEntity provincia = new ProvinciaEntity();
                    provincia.ProvCod = lisproLisproItem[i].ProvCod;
                    provincia.ProvDes = lisproLisproItem[i].ProvDes;
                    provincias.Add(provincia);
                }
            }

            return provincias;
        }
    }
}
