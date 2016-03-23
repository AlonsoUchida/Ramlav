using System;
using System.Collections.Generic;
using Bonus.BusinessEntities.DTO;
using Bonus.BusinessServices.Interfaces;

namespace Bonus.BusinessServices.Providers
{
    public class DistritoServices : IDistritoServices
    {
        public List<DistritoEntity> ObtenerDistritos(string dptoCod, string provCod)
        {
            WsBonusDistritos.wslisdisSoapPortClient ws = new WsBonusDistritos.wslisdisSoapPortClient();
            WsBonusDistritos.LisdisLisdisItem[] lisdisLisdisItem = ws.Execute(dptoCod, provCod);
            List<DistritoEntity> distritos = new List<DistritoEntity>();
            if (lisdisLisdisItem != null)
            {
                for (int i = 0; i < lisdisLisdisItem.Length; i++)
                {
                    DistritoEntity distrito = new DistritoEntity();
                    distrito.DistCod = lisdisLisdisItem[i].DistCod;
                    distrito.DistCodPos = lisdisLisdisItem[i].DistCodPos;
                    distrito.DistDes = lisdisLisdisItem[i].DistDes;
                    distritos.Add(distrito);
                }
            }

            return distritos;
        }

    }
}
