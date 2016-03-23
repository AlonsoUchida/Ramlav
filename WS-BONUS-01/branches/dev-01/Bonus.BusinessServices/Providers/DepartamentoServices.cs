using System;
using System.Collections.Generic;
using Bonus.BusinessEntities.DTO;
using Bonus.BusinessServices.Interfaces;


namespace Bonus.BusinessServices.Providers
{
    public class DepartamentoServices : IDepartamentoServices
    {
        public List<DepartamentoEntity> ObtenerDepartamentos()
        {
            WsBonusDepartamentos.wslisdepSoapPortClient ws = new WsBonusDepartamentos.wslisdepSoapPortClient();
            WsBonusDepartamentos.LisdepLisdepItem[] lisdepLisdepItem = ws.Execute();
            List<DepartamentoEntity> departamentos = new List<DepartamentoEntity>();
            if (lisdepLisdepItem != null)
            {
                for (int i = 0; i < lisdepLisdepItem.Length; i++)
                {
                    DepartamentoEntity departamento = new DepartamentoEntity();
                    departamento.DptoCod = lisdepLisdepItem[i].DptoCod;
                    departamento.DptoDes = lisdepLisdepItem[i].DptoDes;
                    departamentos.Add(departamento);
                }
            }
            
            return departamentos;
        }
    }
}
