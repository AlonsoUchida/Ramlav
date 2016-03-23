using System;
using System.Collections.Generic;
using Bonus.BusinessEntities.DTO;
using Bonus.BusinessServices.Interfaces;

namespace Bonus.BusinessServices.Providers
{
    public class DocumentoServices : IDocumentoServices
    {
        public List<DocumentoEntity> ObtenerDocumentos()
        {
            WsBonusDocumentos.wslistipdoSoapPortClient ws = new WsBonusDocumentos.wslistipdoSoapPortClient();
            WsBonusDocumentos.ListipdocListipdocItem[] listipdocListipdocItem = ws.Execute();
            List<DocumentoEntity> documentos = new List<DocumentoEntity>();
            if (listipdocListipdocItem != null)
            {
                for (int i = 0; i < listipdocListipdocItem.Length; i++)
                {
                    DocumentoEntity documento = new DocumentoEntity();
                    documento.TipDocCod = listipdocListipdocItem[i].TipDocCod;
                    documento.TipDocNom = listipdocListipdocItem[i].TipDocNom;
                    documentos.Add(documento);
                }
            }

            return documentos;
        }
    }
}
