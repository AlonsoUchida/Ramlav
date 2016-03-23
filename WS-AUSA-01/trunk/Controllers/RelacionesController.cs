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
    public class RelacionesController : Controller
    {
        //
        // GET: /Relaciones/

        public ActionResult Index()
        {
            return View();
        }

        // /Relaciones/clistar/       tarea -> cliente
        public String clistar()
        {
            NameValueCollection nvc = Request.Form;
            int id = int.Parse(nvc["txtid"]);
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_RELACION_CLIENTE_TAREA_SELECT", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@tar_int_id", id));
                    da.Fill(dt);
                    return Serialization(dt);
                }
            }

        }

        // /Relaciones/cdelete/       tarea -> cliente 
        public String cdelete()
        {
            NameValueCollection nvc = Request.Form;
            int idt = int.Parse(nvc["txtidt"]);
            int idc = int.Parse(nvc["txtidc"]);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString());
            SqlCommand cmd = new SqlCommand("PA_MOV_RELACION_CLIENTE_TAREA_DELETE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tar_int_id", idt);
            cmd.Parameters.AddWithValue("@cli_int_id", idc);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            string retorno;
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

        // /Relaciones/cinsert/               tarea -> cliente
        public string cinsert()
        {
            NameValueCollection nvc = Request.Form;
            int idt = int.Parse(nvc["txtid"]);
            int idc = int.Parse(nvc["txtidc"]);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString());
            SqlCommand cmd = new SqlCommand("PA_MOV_RELACION_CLIENTE_TAREA_INSERT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("tar_int_id", idt);
            cmd.Parameters.AddWithValue("cli_int_id", idc);
            String retorno = "";
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

        // /Relaciones/nlistar/      idTarea        tarea -> nota
        public String nlistar()
        {
            NameValueCollection nvc = Request.Form;
            int id = int.Parse(nvc["txtid"]);
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_RELACION_NOTA_TAREA_SELECT", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@tar_int_id", id));
                    da.Fill(dt);
                    return Serialization(dt);
                }
            }
        }

        // /Relaciones/ninsert/             tarea -> nota
        public string ninsert()
        {
            NameValueCollection nvc = Request.Form;
            string idnota = nvc["txtidnota"];
            string idtarea = nvc["txtidtarea"];

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString());
            SqlCommand cmd = new SqlCommand("PA_MOV_RELACION_NOTA_TAREA_INSERT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("tar_int_id", idtarea);
            cmd.Parameters.AddWithValue("not_int_id", idnota);
            String retorno = "";
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

        // /Relaciones/ndelete/          tarea -> nota

        [AcceptVerbs(HttpVerbs.Post)]
        public String ndelete(string txttarea, string txtnota)
        {
            int idtarea = int.Parse(txttarea);
            int idnota = int.Parse(txtnota);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString());
            SqlCommand cmd = new SqlCommand("PA_MOV_RELACION_NOTA_TAREA_DELETE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tar_int_id", idtarea);
            cmd.Parameters.AddWithValue("@not_int_id", idnota);
            string retorno;
            try
            {   //exitoso
                conn.Open();
                cmd.ExecuteNonQuery();
                retorno = "[{\"Ejecucion\":0}]";
            }
            catch (System.Exception excep)
            {
                retorno = excep.Message;
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
