﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MvcAppRest.Controllers
{
    public class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var req = base.GetWebRequest(address);
            req.Timeout = 15000;
            return req;
        }
    }

    //[Authorize]
    public class UploadController : Controller
    {
        //LOCAL
       /* const string pathToSaveNotas = @"C:\Archivos\Notas\{0}\{1}";
        const string pathToUpdateNotas = @"http://www.ausa.com.pe/SOL3ARCHIVOS/Notas/{0}/{1}";
        const string pathToSaveFotos = @"C:\Archivos\ordenes\{0}\{1}";
        const string pathToUpdateFotos = @"http://www.ausa.com.pe/SOL3ARCHIVOS/ordenes/{0}/{1}";
        const string pathToSaveDocumentos = @"C:\Archivos\ordenes\{0}\{1}";
        const string pathToUpdateDocumentos = @"http://www.ausa.com.pe/SOL3ARCHIVOS/ordenes/{0}/{1}";
        */
        //AMAZON
        /*const string pathToSaveNotas = @"C:\Inetpub\wwwroot\Archivos\Notas\{0}\{1}";
        const string pathToUpdateNotas = @"http://www.ausa.com.pe/SOL3ARCHIVOS/Notas/{0}/{1}";
        const string pathToSaveFotos = @"C:\Inetpub\wwwroot\Archivos\ordenes\{0}\{1}";
        const string pathToUpdateFotos = @"http://www.ausa.com.pe/SOL3ARCHIVOS/ordenes/{0}/{1}";
        const string pathToSaveDocumentos = @"C:\Inetpub\wwwroot\ordenes\{0}\{1}";
        const string pathToUpdateDocumentos = @"http://www.ausa.com.pe/SOL3ARCHIVOS/ordenes/{0}/{1}";*/
        
        //PROD
        const string pathToSaveNotas = @"\\192.168.0.51\Archivos\Notas\{0}\{1}";
        const string pathToUpdateNotas = @"http://www.ausa.com.pe/SOL3ARCHIVOS/Notas/{0}/{1}";
        const string pathToSaveFotos = @"\\192.168.0.51\Archivos\Ordenes\{0}\{1}";
        const string pathToUpdateFotos = @"http://www.ausa.com.pe/SOL3ARCHIVOS/Ordenes/{0}/{1}";
        const string pathToSaveDocumentos = @"\\192.168.0.51\Archivos\Ordenes\{0}\{1}";
        const string pathToUpdateDocumentos = @"http://www.ausa.com.pe/SOL3ARCHIVOS/Ordenes/{0}/{1}";
        
         
        //Upload/UploadUrl
        [AcceptVerbs(HttpVerbs.Post)]
        public string UploadUrl(string id, string url, string tipo, string subPath)
        {
            string newPath = "";
            string newPathPublic = "";

            string pathToUpdate = "";
            string finalPath = "";
            int tipoFormato = Int32.Parse(tipo);
            string storedProcedured = "";

            string param1 = "";
            string param2 = "";
            string paramValue1 = "";
            string paramValue2 = "";

            string[] words; 
            try
            {
                switch (tipoFormato)
                {
                    case 1:
                        finalPath = String.Format(pathToSaveNotas, DateTime.Now.Year.ToString(), subPath);
                        pathToUpdate = String.Format(pathToUpdateNotas, DateTime.Now.Year.ToString(), subPath);
                        storedProcedured = "PA_MOV_NOTA_UPDATE_2";
                        param1 = "not_str_archivo";
                        param2 = "new_str_archivo";
                        break;
                    case 2:
                    case 3:
                        words = subPath.Split('-');
                        string year = words[0];
                        subPath = words[1];
                        finalPath = String.Format(pathToSaveFotos, year, subPath);
                        pathToUpdate = String.Format(pathToUpdateFotos, year, subPath);
                        storedProcedured = "PA_MOV_OPERACION_FOTO_UPDATE_2";
                        param1 = "dig_int_id";
                        param2 = "dig_str_archivo";
 
                        break;
                }

                // Determine whether the directory exists.
                if (!Directory.Exists(finalPath))
                {
                    Directory.CreateDirectory(finalPath);
                }

                using (var client = new WebClient())
                {

                    switch (tipoFormato)
                    {
                        case 1:
                            paramValue1 = url;                            
                            finalPath += "\\Audio{0}.wav";
                            pathToUpdate += "/Audio{0}.wav";
                            break;
                        case 2:
                            //Nombre del archivo para la foto
                            paramValue1 = id;
                            paramValue2 = String.Format("Foto{0}.jpg", id);
                            finalPath += "\\Foto{0}.jpg";
                            pathToUpdate += "/Foto{0}.jpg";
                            break;
                        case 3:
                            paramValue1 = id;
                            paramValue2 = String.Format("Docs{0}.jpg", id);
                            finalPath += "\\Docs{0}.jpg";
                            pathToUpdate += "/Docs{0}.jpg";
                            break;
                    }

                    newPath = String.Format(finalPath, id);
                    newPathPublic = String.Format(pathToUpdate, id);

                    if(tipoFormato==1)
                        paramValue2 = newPathPublic;

                    byte[] file = client.DownloadData(url);
                    System.IO.File.WriteAllBytes(newPath, file);
                }

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedured, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue(param1, paramValue1);
                        cmd.Parameters.AddWithValue(param2, paramValue2);
                        cmd.ExecuteNonQuery();

                        return "0"; //succeded
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        //Upload/UploadUrl
        [AcceptVerbs(HttpVerbs.Post)]
        public string UploadUrlWithBytes(string id, byte[] buffer, string tipo, string subPath)
        {
            string newPath = "";
            string newPathPublic = "";

            string pathToUpdate = "";
            string finalPath = "";
            int tipoFormato = Int32.Parse(tipo);

            string[] words;
            try
            {
                switch (tipoFormato)
                {
                    case 1:
                        finalPath = String.Format(pathToSaveNotas, DateTime.Now.Year.ToString(), subPath);
                        pathToUpdate = String.Format(pathToUpdateNotas, DateTime.Now.Year.ToString(), subPath);
                        break;
                    case 2:
                        words = subPath.Split('-');
                        string year = words[0];
                        subPath = words[1];
                        finalPath = String.Format(pathToSaveFotos, year, subPath);
                        pathToUpdate = String.Format(pathToUpdateFotos, year, subPath);

                        break;
                    case 3:
                        finalPath = String.Format(pathToSaveDocumentos, DateTime.Now.Year.ToString(), subPath);
                        pathToUpdate = String.Format(pathToUpdateDocumentos, DateTime.Now.Year.ToString(), subPath);
                        break;
                }

                // Determine whether the directory exists.
                if (!Directory.Exists(finalPath))
                {
                    Directory.CreateDirectory(finalPath);
                }

                switch (tipoFormato)
                {
                    case 1:
                        finalPath += "\\Audio{0}.wav";
                        pathToUpdate += "/Audio{0}.wav";
                        break;
                    case 2:
                        finalPath += "\\Foto{0}.jpg";
                        pathToUpdate += "/Foto{0}.jpg";
                        break;
                    case 3:
                        break;
                }

                newPath = String.Format(finalPath, id);
                newPathPublic = String.Format(pathToUpdate, id);

                System.IO.File.WriteAllBytes(newPath, buffer);
                return "0"; 

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

    }
}
