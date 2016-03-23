using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Specialized;
using System.Globalization;

namespace MvcAppRest.Controllers
{
    //[Authorize]
    public class NotasController : Controller
    {
        //
        // GET: /Notas/

        public ActionResult Index()
        {
            return View();
        }

     
        // /Notas/listar/id
        /*public String listar(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_NOTA_SELECT", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@not_int_id", id));
                    da.Fill(dt);
                    return Serialization(dt);
                }
            }
        }*/
        
       // /Notas/insert/              
       public string insert()
       {
           NameValueCollection nvc = Request.Form;
           string ruta = nvc["txtruta"];
           DataTable dt = new DataTable();
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString());
           SqlCommand cmd = new SqlCommand("PA_MOV_NOTA_INSERT", conn);
           cmd.CommandType = CommandType.StoredProcedure; 
           cmd.Parameters.AddWithValue("not_str_archivo", ruta);
           String retorno = "";
           try
           {
               conn.Open();
               cmd.CommandType = CommandType.StoredProcedure;
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               da.Fill(dt);
               retorno = Serialization(dt);
           }
           catch
           {
               //error
               retorno = "[{\"Column1\":0}]";
           }
           return retorno;
       }

        // /Notas/delete/                       
        public string delete()
        {
            NameValueCollection nvc = Request.Form;
            int id = int.Parse(nvc["txtid"]);
            string retorno;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString());
            SqlCommand cmd = new SqlCommand("PA_MOV_NOTA_DELETE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("not_int_id", id);
            try
            {   //exitoso
                conn.Open();
                cmd.ExecuteNonQuery();
                retorno = "[{\"Ejecucion\":0}]";
            }
            catch
            {
                //error
                retorno = "[{\"Ejecucion\":1}]";
            }
            return retorno;
        }


        private String Serialization(DataTable dt)
       {
           System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
           List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
           Dictionary<string, object> row;
           foreach (DataRow dr in dt.Rows)
           {
               row = new Dictionary<string, object>();
               foreach (DataColumn col in dt.Columns)
               {
                   row.Add(col.ColumnName, dr[col]);
               }
               rows.Add(row);
           }
           return serializer.Serialize(rows);
       }
         
    }
}
