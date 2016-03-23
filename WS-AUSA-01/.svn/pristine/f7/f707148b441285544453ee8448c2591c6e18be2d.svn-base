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
    public class ClientesController : Controller
    {
        //
        // GET: /Clientes/

        public ActionResult Index()
        {
            return View();
        }

        private ActionResult Rest(object datos)
        {
            ActionResult resultado = null;
            //if (Request.ContentType == "application/json")
            resultado = Json(datos, JsonRequestBehavior.AllowGet);

            return resultado;
        }

        

        // /Clientes/cartera/305
        public String cartera(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {

                using (SqlCommand cmd = new SqlCommand("PA_MOV_USUARIO_CARTERA_CLIENTES", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@usr", id));
                    da.Fill(dt);
                    //return Rest(dt);
                    return Serialization(dt);
                }
            }
        }

        // /Clientes/cartera/305
        public String carteraFiltro(int id, string filtro)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {

                using (SqlCommand cmd = new SqlCommand("PA_MOV_USUARIO_CARTERA_CLIENTES_FILTRO", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@usr", id));//
                    cmd.Parameters.Add(new SqlParameter("@filtro", filtro));
                    da.Fill(dt);
                    //return Rest(dt);
                    return Serialization(dt);
                }
            }
        }


        // /Clientes/contacto/199
        public String contacto(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_CLIENTE_CONTACTOS", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@cliente", id));
                    da.Fill(dt); 
                    return Serialization(dt);
                }
            }
        }

        // contacto telefonos
        // /Clientes/contactoT?id=199&contacto=0
        public String contactoT(int id, int contacto)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_CLIENTE_CONTACTOS_TELEFONOS", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@cliente", id));
                    cmd.Parameters.Add(new SqlParameter("@contacto", contacto));
                    da.Fill(dt);
                    return Serialization(dt);
                }
            }
        }

        // /Clientes/participacion/199
        public ActionResult participacion(int id)
        {
            DataTable dt = new DataTable();
            ActionResult resultado = null;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_CLIENTE_PARTICIPACION", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@cliente", id));
                    da.Fill(dt);

                    List<Participacion> _participacion = Helper.DataTableToList<Participacion>(dt);
                    resultado = Json(_participacion, JsonRequestBehavior.AllowGet);
                    return resultado;
                }
            }
        }

        // /Clientes/participacionD/199
        public ActionResult participacionD(int id)
        {
            DataTable dt = new DataTable();
            ActionResult resultado = null;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_CLIENTE_PARTICIPACION_DETALLE", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@cliente", id));
                    da.Fill(dt);

                    List<ParticipacionDetalle> _participacionDetalle = Helper.DataTableToList<ParticipacionDetalle>(dt);
                    resultado = Json(_participacionDetalle, JsonRequestBehavior.AllowGet);
                    return resultado;
                }
            }
        }


        // condicion pago
        // /Clientes/condpago/199
        public ActionResult condpago(int id)
        {
            DataTable dt = new DataTable();
            ActionResult resultado = null;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_CLIENTE_CONDICIONPAGO", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@cliente", id));
                    da.Fill(dt);

                    List<CondicionPago> _condicionPago = Helper.DataTableToList<CondicionPago>(dt);
                    resultado = Json(_condicionPago, JsonRequestBehavior.AllowGet);
                    return resultado;
                }
            }
        }

        // condicion pago detalle
        // /Clientes/condpagoD/199
        public ActionResult condpagoD(int id)
        {
            DataTable dt = new DataTable();
            ActionResult resultado = null;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_CLIENTE_CONDICIONPAGO_DETALLE", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@cliente", id));
                    da.Fill(dt);

                    List<CondicionPagoDetalle> _condicionPagoDetalle = Helper.DataTableToList<CondicionPagoDetalle>(dt);
                    resultado = Json(_condicionPagoDetalle, JsonRequestBehavior.AllowGet);
                    return resultado;
                }
            }
        }

        // tarifas
        // /Clientes/tarifas/199
        public String tarifas(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_CLIENTE_TARIFAS", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@cliente", id));
                    da.Fill(dt);
                    return Serialization(dt);
                }
            }
        }
        
        // /Clientes/morosidad/199
        public ActionResult morosidad(int id)
        {
            DataTable dt = new DataTable();
            ActionResult resultado = null;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_CLIENTE_MOROSIDAD_UTILIZACION_LINEA", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@cliente", id));
                    da.Fill(dt);

                    List<MorosidadLinea> _morosidadLinea = Helper.DataTableToList<MorosidadLinea>(dt);
                    resultado = Json(_morosidadLinea, JsonRequestBehavior.AllowGet);
                    return resultado;
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
