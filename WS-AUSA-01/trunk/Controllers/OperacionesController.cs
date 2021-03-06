﻿using System;
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
    public class OperacionesController : Controller
    {
        //
        // GET: /Operaciones/

        public ActionResult Index()
        {
            return View();
        }

        #region Operaciones
        // /Operaciones/Iniciar/                       
        public string Iniciar()
        {
            NameValueCollection nvc = Request.Form;
            int id = int.Parse(nvc["txtid"]);
            int idUsuario = int.Parse(nvc["txtidUsuario"]);
            string retorno;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString());
            SqlCommand cmd = new SqlCommand("PA_MOV_OPERACIONES_INICIAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ope_int_id", id);
            cmd.Parameters.AddWithValue("usr_int_id", idUsuario);
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

        // /Operaciones/Listar/ 
        [AcceptVerbs(HttpVerbs.Post)]
        public String Listar(string txtdespachador, string txtcliente, string txtorden, string txtfecha, string txtalmacen, string txtestado)
        {
            
            int despachador = int.Parse(txtdespachador);
            int cliente = int.Parse(txtcliente);
            int orden = int.Parse(txtorden);
            
            DateTime fecha = DateTime.Parse(txtfecha); //"24/09/2015";
            
            int almacen = int.Parse(txtalmacen);
            int estado = int.Parse(txtestado);

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_OPERACIONES_LISTAR", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@ope_int_despachador", despachador));
                    cmd.Parameters.Add(new SqlParameter("@cli_int_id", cliente));
                    cmd.Parameters.Add(new SqlParameter("@ord_int_id", orden));
                    cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
                    cmd.Parameters.Add(new SqlParameter("@alm_int_id", almacen));
                    cmd.Parameters.Add(new SqlParameter("@estado", estado));
                    da.Fill(dt);
                    return Serialization(dt);
                }
            }
        }

        // /Operaciones/Detalle/226667                 
        public string Detalle(int id)
        {           
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_OPERACIONES_DETALLE", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("ope_int_id", id);
                    da.Fill(dt);
                    return Serialization(dt);
                }
            }            
        }        

        // /Operaciones/Reasignar/     
        [AcceptVerbs(HttpVerbs.Post)]          
        public string Reasignar(string txtid, string txtdespachador, string txtobservacion)
        {
            int id = int.Parse(txtid); //2926
            int despachador = int.Parse(txtdespachador); //
            string observacion = txtobservacion; //
            string retorno;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString());
            SqlCommand cmd = new SqlCommand("PA_MOV_OPERACIONES_REASGINACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ope_int_id", id);
            cmd.Parameters.AddWithValue("ope_int_despachador", despachador);
            cmd.Parameters.AddWithValue("ope_str_observacion", observacion);
            try
            {   //exitoso
                conn.Open();
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);      
                retorno = Serialization(dt);
            }
            catch
            {
                //error
                retorno = "[{\"Ejecucion\":1}]";
            }
            return retorno;
        }

        // /Operaciones/Terminar/                       
        public string Terminar()
        {
            NameValueCollection nvc = Request.Form;
            int id = int.Parse(nvc["txtid"]);
            int idUsuario = int.Parse(nvc["txtidUsuario"]);
            string retorno;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString());
            SqlCommand cmd = new SqlCommand("PA_MOV_OPERACIONES_TERMINAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ope_int_id", id);
            cmd.Parameters.AddWithValue("usr_int_id", idUsuario);
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
        
        // /Operaciones/Permiso/
        [AcceptVerbs(HttpVerbs.Post)]
        public string Permiso(string txtid, string txtidUsuario)
        {
            int id = int.Parse(txtid);
            int idUsuario = int.Parse(txtidUsuario);
            string retorno;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString());
            SqlCommand cmd = new SqlCommand("PA_MOV_OPERACIONES_PERMISOOK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ope_int_id", id);
            cmd.Parameters.AddWithValue("usr_int_id", idUsuario);
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

        // /Operaciones/Solicitar/
        public string Solicitar()
        {
            NameValueCollection nvc = Request.Form;
            int id = int.Parse(nvc["txtid"]);
            int idUsuario = int.Parse(nvc["txtidUsuario"]);
            string retorno;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString());
            SqlCommand cmd = new SqlCommand("PA_MOV_OPERACIONES_SOLICITARTRANSPORTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ope_int_id", id);
            cmd.Parameters.AddWithValue("usr_int_id", idUsuario);
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
        
        // /Operaciones/Despachadores/                       
        public string Despachadores()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_OPERACIONES_DESPACHADORES", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd); 
                    da.Fill(dt);
                    return Serialization(dt);
                }
            }      
        }

        // /Operaciones/Opciones/id
        public string Opciones(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("PA_MOV_OPERACIONES_OPCIONES", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("ope_int_id", id);
                    da.Fill(dt);
                    return Serialization(dt);
                }
            }
        }

        // /Operaciones/ObtenerTareaFotos/
        [AcceptVerbs(HttpVerbs.Get)]
        public string ObtenerTareaFotos(string archivo, string operacion)
        {
            try
            {
                int operacionID = int.Parse(operacion);

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("PA_MOV_TAREAS_FOTO_SELECT", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("ARCHIVO", archivo);
                        cmd.Parameters.AddWithValue("OPERACION", operacionID);
                        da.Fill(dt);
                        return Serialization(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                return "[{\"Ejecucion\":1}]";
            }                 
        }

        // /Operaciones/InsertarTareaFotos/
        [AcceptVerbs(HttpVerbs.Post)]
        public int InsertarTareaFotos(string archivo, string usuario, string operacion)
        {
            try
            {
                int usuarioID = int.Parse(usuario);
                int operacionID = int.Parse(operacion);

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("PA_MOV_TAREAS_FOTO_INSERT", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("ARCHIVO", archivo);
                        cmd.Parameters.AddWithValue("USUARIO", usuarioID);
                        cmd.Parameters.AddWithValue("OPERACION", operacionID);
                        da.Fill(dt);
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        // /Operaciones/EliminarTareaFotos/
        [AcceptVerbs(HttpVerbs.Post)]
        public int EliminarTareaFotos(string archivo, string operacion)
        {
            try
            {
                int operacionID = int.Parse(operacion);

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("PA_MOV_TAREAS_FOTO_DELETE", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("ARCHIVO", archivo);
                        cmd.Parameters.AddWithValue("OPERACION", operacionID);
                        da.Fill(dt);
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        // /Operaciones/ObtenerFotos/
        [AcceptVerbs(HttpVerbs.Get)]
        public string ObtenerFotos(string operacion)
        {
            try
            {
                int operacionID = int.Parse(operacion);

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("PA_MOV_FOTO_SELECT", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("@ope_int_id", operacionID);
                        da.Fill(dt);
                        return Serialization(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                return "[{\"Ejecucion\":1}]";
            }
        }
        
        // /Operaciones/InsertarFotos/
        [AcceptVerbs(HttpVerbs.Post)]
        public string InsertarFotos(string archivo, string usuario, string operacion)
        {
            try
            {
                int usuarioID = int.Parse(usuario);
                int operacionID = int.Parse(operacion);

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("PA_MOV_FOTO_INSERT", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("@fot_str_archivo", archivo);
                        cmd.Parameters.AddWithValue("@fot_int_usrcreacion", usuarioID);
                        cmd.Parameters.AddWithValue("@ope_int_id", operacionID);
                        da.Fill(dt);

                        return Serialization(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                return "[{\"Ejecucion\":1}]";
            }
        }

        // /Operaciones/EliminarFotos/
        [AcceptVerbs(HttpVerbs.Post)]
        public int EliminarFotos(string idFoto)
        {
            try
            {
                int id = int.Parse(idFoto);

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("PA_MOV_FOTO_DELETE", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("@fot_int_id", id);
                        da.Fill(dt);
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        // /Operaciones/Levante/
        [AcceptVerbs(HttpVerbs.Post)]
        public string Levante(string operacion, string usuario, string fecha)
        {
            try
            {
                int ope_int_id = int.Parse(operacion);
                int usr_int_id = int.Parse(usuario);
                DateTime ord_dat_flevante = DateTime.Parse(fecha);

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("PA_MOV_OPERACIONES_LEVANTE", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("ope_int_id", ope_int_id);
                        cmd.Parameters.AddWithValue("usr_int_id", usr_int_id);
                        cmd.Parameters.AddWithValue("ord_dat_flevante", ord_dat_flevante);
                        da.Fill(dt);
                        return "[{\"Ejecucion\":0}]";
                    }
                }
            }
            catch (Exception ex)
            {
                return "[{\"Ejecucion\":1}]";
            }
        }

        // /Operaciones/Canal/
        [AcceptVerbs(HttpVerbs.Post)]
        public string Canal(string operacion, string usuario, string canal)
        {
            try
            {
                int ope_int_id = int.Parse(usuario);
                int usr_int_id = int.Parse(operacion);
                char ord_str_canaldua = char.Parse(canal);

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("PA_MOV_OPERACIONES_CANAL", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("ope_int_id", ope_int_id);
                        cmd.Parameters.AddWithValue("usr_int_id", usr_int_id);
                        cmd.Parameters.AddWithValue("ord_str_canaldua", ord_str_canaldua);
                        da.Fill(dt);
                        return "[{\"Ejecucion\":0}]";
                    }
                }
            }
            catch (Exception ex)
            {
                return "[{\"Ejecucion\":1}]";
            }
        }

        // /Operaciones/Notificar/
        [AcceptVerbs(HttpVerbs.Post)]
        public string Notificar(string operacion, string usuario)
        {
            try
            {
                int ope_int_id = int.Parse(usuario);
                int usr_int_id = int.Parse(operacion);

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("PA_MOV_OPERACIONES_NOTIFICACION", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("ope_int_id", ope_int_id);
                        cmd.Parameters.AddWithValue("usr_int_id", usr_int_id);
                        da.Fill(dt);
                        return "[{\"Ejecucion\":0}]";
                    }
                }
            }
            catch (Exception ex)
            {
                return "[{\"Ejecucion\":1}]";
            }
        }

        // /Operaciones/Notificar/
        [AcceptVerbs(HttpVerbs.Get)]
        public string AlmacenesListar(string almacenes)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("PA_MOV_ALMACENES_LISTAR", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("alm_str_descripcion", almacenes);
                        da.Fill(dt);
                        return Serialization(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                return "[{\"Ejecucion\":1}]";
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public string UbicacionListar(string usuario)
        {
            try
            {
                int usr_int_id = int.Parse(usuario);

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("PA_MOV_UBICACION_LISTAR", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("usr_int_id", usr_int_id);
                        da.Fill(dt);
                        return Serialization(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                return "[{\"Ejecucion\":1}]";
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public string UbicacionInsertar(string usuario, string latitud, string longitud, string operacion)
        {
            try
            {
                int usr_int_id = int.Parse(usuario);
                decimal ubi_dec_latitud = decimal.Parse(latitud, CultureInfo.InvariantCulture);
                decimal ubi_dec_longitud = decimal.Parse(latitud, CultureInfo.InvariantCulture);
                int ope_int_id = int.Parse(operacion);

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("PA_MOV_UBICACION_INSERT", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("usr_int_id", usr_int_id);
                        cmd.Parameters.AddWithValue("ubi_dec_latitud", ubi_dec_latitud);
                        cmd.Parameters.AddWithValue("ubi_dec_longitud", ubi_dec_longitud);
                        cmd.Parameters.AddWithValue("ope_int_id", ope_int_id);
                        da.Fill(dt);
                        return "[{\"Ejecucion\":0}]";
                    }
                }
            }
            catch (Exception ex)
            {
                return "[{\"Ejecucion\":1}]";
            }
        }

        #endregion

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
