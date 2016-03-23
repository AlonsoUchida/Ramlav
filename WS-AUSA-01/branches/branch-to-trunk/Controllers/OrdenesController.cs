using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MvcAppRest.Controllers
{
    //[Authorize]
    public class OrdenesController : Controller
    {
        //
        // GET: /Ordenes/

        public ActionResult Index()
        {
            return View();
        }

        // /Ordenes/detalle/373306
        public String detalle(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_CLIENTE_DESPACHO", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@orden", id));
                    cmd.Parameters.Add(new SqlParameter("@referencia", ""));

                    da.Fill(dt); 
                    return Serialization(dt);
                }
            }
        }

        // /Ordenes/valor?fecha=2015&id=027290&cliente=288
        public String valor(string fecha, string id, string cliente)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_ORDEN_ID", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@anio", fecha));
                    cmd.Parameters.Add(new SqlParameter("@numero", id));
                    cmd.Parameters.Add(new SqlParameter("@cliente", cliente));

                    da.Fill(dt);
                    return Serialization(dt);
                }
            }
        }

        // /Ordenes/valorA?fecha=2015&id=027290
        public String valorA(string fecha, string id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_ORDEN_ID_AUSA", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@anio", fecha));
                    cmd.Parameters.Add(new SqlParameter("@numero", id));

                    da.Fill(dt);
                    return Serialization(dt);
                }
            }
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
