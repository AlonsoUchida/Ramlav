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
    public class TareasController : Controller
    {
        //
        // GET: /Tareas/
        public ActionResult Index()
        {
            return View();
        }

        // /Tareas/tipoInsert
        public string tipoInsert()
        {
            NameValueCollection nvc = Request.Form;
            string nombre = nvc["txtnombre"]; 
            string descripcion = nvc["txtdescripcion"];
            int userid = int.Parse(nvc["txtuserid"]);        

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString());
            SqlCommand cmd = new SqlCommand("PA_MOV_TAREAS_TIPO_INSERT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("tiptar_str_nombre", nombre);
            cmd.Parameters.AddWithValue("tiptar_str_descripcion", descripcion);
            cmd.Parameters.AddWithValue("tiptar_int_estado", 1);
            cmd.Parameters.AddWithValue("tiptar_int_usrcreacion", userid);            
            cmd.Parameters.AddWithValue("tiptar_int_usrmodif", userid);

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

        // /Tareas/tipoDelete
        public String tipoDelete()
        {
            NameValueCollection nvc = Request.Form;
            int id = int.Parse(nvc["txtid"]);
            int user = int.Parse(nvc["txtuserid"]);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString());
            SqlCommand cmd = new SqlCommand("PA_MOV_TAREAS_TIPO_DELETE", conn); 
            cmd.CommandType = CommandType.StoredProcedure;  
            cmd.Parameters.AddWithValue("@tiptar_int_id", id);
            cmd.Parameters.AddWithValue("@tiptar_int_usrcreacion", user);   

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

        // /Tareas/tipoListar
        public String tipoListar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_TAREA_TIPO_SELECT", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd); 
                    da.Fill(dt);
                    return Serialization(dt);
                }
            }
        }

        // /Tareas/tipoUpdate/
        public string tipoUpdate() {
            NameValueCollection nvc = Request.Form;
            int id = int.Parse(nvc["txtid"]);
            string nombre = nvc["txtnombre"];
            string descripcion = nvc["txtdescripcion"];
            int userid = int.Parse(nvc["txtuserid"]);
            string retorno; 

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString());
            SqlCommand cmd = new SqlCommand("PA_MOV_TAREAS_TIPO_UPDATE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("tiptar_int_id", id); 
            cmd.Parameters.AddWithValue("tiptar_str_nombre", nombre); 
            cmd.Parameters.AddWithValue("tiptar_str_descripcion", descripcion); 
            cmd.Parameters.AddWithValue("tiptar_int_estado", 1); 
            cmd.Parameters.AddWithValue("tiptar_int_usrmodif", userid); 
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

        // /Tareas/insert
        public string insert()
        {
            NameValueCollection nvc = Request.Form;
            int idtt = int.Parse(nvc["txtidtt"]); 
            int userid = int.Parse(nvc["txtuserid"]);
            int prioridad = int.Parse(nvc["txtprioridad"]);
            string flimite = nvc["txtflimite"];
            IFormatProvider culture = new CultureInfo("es-US", true); 
            DateTime flimitedt = DateTime.ParseExact(flimite, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            string detalle = nvc["txtdetalle"];
            int estado = 1;
            string observ = nvc["txtobserv"];
            string orden = nvc["txtorden"];
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString());
            SqlCommand cmd = new SqlCommand("PA_MOV_TAREA_INSERT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("tiptar_int_id", idtt);
            cmd.Parameters.AddWithValue("usr_int_id", userid);
            cmd.Parameters.AddWithValue("tar_int_prioridad", prioridad); 
            cmd.Parameters.AddWithValue("tar_dat_fchlimite", flimitedt);
            cmd.Parameters.AddWithValue("tar_txt_detalle", detalle);
            cmd.Parameters.AddWithValue("tar_int_estado", estado);
            cmd.Parameters.AddWithValue("tar_str_observacion", observ);
            cmd.Parameters.AddWithValue("tar_str_orden", orden);
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

        // /Tareas/delete/                       
        public string delete()
        {
            NameValueCollection nvc = Request.Form;
            int id = int.Parse(nvc["txtid"]);
            string retorno;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString());
            SqlCommand cmd = new SqlCommand("PA_MOV_TAREA_DELETE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("tar_int_id", id); 
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

        // /Tareas/listar
        public String listar()
        {
            NameValueCollection nvc = Request.Form;
            int id = int.Parse(nvc["txtid"]);
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_TAREA_SELECT", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@usr_int_id", id));
                    da.Fill(dt);
                    return Serialization(dt);
                }
            }
        }

        // /Tareas/update/
        public string update()
        { 
            NameValueCollection nvc = Request.Form;
            int id = int.Parse(nvc["txtid"]);
            int idtt = int.Parse(nvc["txtidtt"]);
            int userid = int.Parse(nvc["txtuserid"]);
            int prioridad = int.Parse(nvc["txtprioridad"]);
            string flimite = nvc["txtflimite"];
            IFormatProvider culture = new CultureInfo("es-US", true);
            DateTime flimitedt = DateTime.ParseExact(flimite, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            string detalle = nvc["txtdetalle"];
            int estado = int.Parse(nvc["txtestado"]); // VHC -- 1
            string observ = nvc["txtobserv"];
            string orden = nvc["txtorden"];
            string retorno; 
            
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString());
            SqlCommand cmd = new SqlCommand("PA_MOV_TAREA_UPDATE", conn);
            cmd.CommandType = CommandType.StoredProcedure; 
            cmd.Parameters.AddWithValue("tar_int_id", id);
            cmd.Parameters.AddWithValue("tiptar_int_id", idtt);
            cmd.Parameters.AddWithValue("usr_int_id", userid);
            cmd.Parameters.AddWithValue("tar_int_prioridad", prioridad);
            cmd.Parameters.AddWithValue("tar_dat_fchlimite", flimitedt);
            cmd.Parameters.AddWithValue("tar_txt_detalle", detalle);
            cmd.Parameters.AddWithValue("tar_int_estado", estado);
            cmd.Parameters.AddWithValue("tar_str_observacion", observ);
            cmd.Parameters.AddWithValue("tar_str_orden", orden);

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
