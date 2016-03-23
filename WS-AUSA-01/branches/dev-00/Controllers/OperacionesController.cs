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
using MvcAppRest.Models;
using System.Web.Script.Serialization;

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
        /*[AcceptVerbs(HttpVerbs.Get)]
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
        }*/

        // /Operaciones/InsertarTareaFotos/ 
        [AcceptVerbs(HttpVerbs.Post)]
        public string InsertarTareaFotos(string archivo, string usuario, string operacion, string tipo, string ruta)
        {
            try
            {
                int usuarioID = int.Parse(usuario);
                int operacionID = int.Parse(operacion);
                int tipoInt = int.Parse(tipo);

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
                        cmd.Parameters.AddWithValue("TIPO", tipoInt);
                        cmd.Parameters.AddWithValue("RUTA", ruta);
                        da.Fill(dt);
                        //TODO: Id que devuelve el query
                        return Serialization(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                return "[{\"Ejecucion\":1}]";
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

        //PA_MOV_OPERACIONES_FOTO_DELETE
        [AcceptVerbs(HttpVerbs.Post)]
        public string EliminarFotosOperaciones(string idDigitalizacion)
        {
            try
            {
                int id = int.Parse(idDigitalizacion);

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("PA_MOV_OPERACIONES_FOTO_DELETE", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("@dig_int_id", id);
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


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ListarFotosOperaciones(string idOperacion, string tipo)
        {
            ActionResult resultado = null;
            string urlBase = @"http://www.ausa.com.pe/SOL3ARCHIVOS/ordenes/{0}/{1}/{2}";
            try
            {
                int id = int.Parse(idOperacion);
                int tipoId = int.Parse(tipo);
                DataTable dt = new DataTable();
                
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("PA_MOV_OPERACIONES_FOTOS_LISTAR", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("@ope_int_id", id);
                        cmd.Parameters.AddWithValue("@tipo", tipoId);
                        da.Fill(dt);
                        /*
                         * 
                                urlBase = http://www.ausa.com.pe/SOL3ARCHIVOS/ordenes/


                                id =  dig_int_id
                                url = urlBase+ "/" + ord_int_ano+"/"+ord_str_numero+"/"+dig_str_archivo
                                archivo = dig_str_archivo
                         */

                        List<FotosOperaciones> _fotosOperaciones = Helper.DataTableToList<FotosOperaciones>(dt);
                        List<FotosOperacionesFinal> _fotosOperacionesFinal = new List<FotosOperacionesFinal>();
                        foreach (var item in _fotosOperaciones)
                        {
                            FotosOperacionesFinal foto = new FotosOperacionesFinal();
                            foto.Id = item.DigId;

                            if (item.Ruta.Equals("Archivo subido.") || String.IsNullOrEmpty(item.Ruta))
                                foto.Url = String.Format(urlBase, item.OrdenAno, item.OrdenNum, item.DigDesc);                                 
                            else
                                foto.Url = item.Ruta;

                            foto.Archivo = item.DigDesc;
                            _fotosOperacionesFinal.Add(foto);
                        }

                        resultado = Json(_fotosOperacionesFinal, JsonRequestBehavior.AllowGet);
                        return resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = Json(Helper.obtenerConfirmacion(ex.Message), JsonRequestBehavior.AllowGet); 
                return resultado;
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
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AlmacenesListar()
        {
            ActionResult resultado = null;
            DataTable dt = new DataTable();

            try
            {               
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("PA_MOV_ALMACENES_LISTAR", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        List<Almacen> _almacenes = Helper.DataTableToList<Almacen>(dt);
                        List<AlmacenResult> _almacenesResult = new List<AlmacenResult>();
                        foreach (var item in _almacenes)
	                    {
		                   AlmacenResult result = new AlmacenResult();
                           result.AlmID = item.AlmID;
                           result.AlmDescripcion = item.AlmDescripcion;
                           result.AlmDireccion = item.AlmDireccion;
                           decimal almLatitud = 0, almLongitud = 0;
                           if (item.AlmLatitud != null) 
                           {
                               almLatitud = item.AlmLatitud.Equals("") ? decimal.Parse(item.AlmLatitud) : 0;
                           }
                            if (item.AlmLongitud != null) 
                           {
                               almLongitud = item.AlmLongitud.Equals("") ? decimal.Parse(item.AlmLongitud) : 0;
                           }
                           decimal[] latlong = { almLatitud, almLongitud };
                           result.LatLong = latlong;

                           string descripcion = "";
                           string direccion = "";
                           for (int i = 0; i < item.AlmDescripcion.Length; i++)
                           {
                               descripcion += item.AlmDescripcion[i];
                               if (((i + 1) % 20) == 0)
                                   descripcion += " <br> ";
                           }
                           for (int i = 0; i < item.AlmDireccion.Length; i++)
                           {
                               direccion += item.AlmDireccion[i];
                               if (((i + 1) % 20) == 0)
                                   direccion += " <br> ";
                           }
                           result.InfoAlmacen = String.Format("<b>Descripcion: </b> {0} <br><b>Direccion: </b> {1}",
                                                                      descripcion, direccion);
                           _almacenesResult.Add(result);
	                    }

                        resultado = Json(_almacenesResult, JsonRequestBehavior.AllowGet);
                        return resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = Json(Helper.obtenerConfirmacion(ex.Message), JsonRequestBehavior.AllowGet);
                return resultado;
            }
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UbicacionListar(string usuario, string fechaIni, string fechaFin)
        {
            DataTable dt = new DataTable();
            ActionResult resultado = null;
            string auditLog = "";
            try
            {
                int usr_int_id = int.Parse(usuario);

                var formats = new[] {
                  "yyyy.MM.dd HH:mm:ss",
                  "yyyy-MM-dd HH:mm:ss",
                  "yyyy/MM/dd HH:mm:ss",
                  "yyyy.MM.dd hh:mm:ss",
                  "yyyy-MM-dd hh:mm:ss",
                  "yyyy/MM/dd hh:mm:ss"
                };

                DateTime dateIni = DateTime.ParseExact(fechaIni, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
                DateTime dateFin = DateTime.ParseExact(fechaFin, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AUSACnn"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("PA_MOV_UBICACION_LISTAR", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Parameters.AddWithValue("@usr_int_id", usr_int_id);
                        cmd.Parameters.AddWithValue("@fechaini", dateIni);
                        cmd.Parameters.AddWithValue("@fechafin", dateFin);
                        da.Fill(dt);

                        List<Ubicacion> _ubicacion = Helper.DataTableToList<Ubicacion>(dt);
                        List<UbicacionLite> _ubicacionLite = new List<UbicacionLite>();
                        foreach (var item in _ubicacion)
                        {
                            UbicacionLite ubicacionLite = new UbicacionLite();
                            decimal[] latlong = { decimal.Parse(item.Latitud), decimal.Parse(item.Longitud) };
                            ubicacionLite.LatLong = latlong;
                            ubicacionLite.Fecha = item.Fecha;
                            ubicacionLite.Operacion = item.OperacionId;
                            ubicacionLite.Info = String.Format("Fecha = {0} --- Operación = {1}", item.Fecha, item.OperacionId);
                            DateTime fecha = DateTime.Parse(item.Fecha);
                            auditLog += item.Fecha;
                            String hourToString = fecha.ToString("HH:mm:ss");
                            String fechaToString = fecha.ToString("dd-MM-yyyy");
                            ubicacionLite.Info = String.Format("<b>Fecha: </b> {0} <br> <b>Hora: </b> {1} <br> <b>Operación: </b> {2}", fechaToString, hourToString, item.OperacionId);
                            _ubicacionLite.Add(ubicacionLite);
                        }
                        resultado = Json(_ubicacionLite, JsonRequestBehavior.AllowGet);
                        return resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = Json(Helper.obtenerConfirmacion(ex.Message + " " + auditLog), JsonRequestBehavior.AllowGet); 
                return resultado;
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public string UbicacionInsertar(string usuario, string latitud, string longitud, string operacion)
        {
            try
            {
                int usr_int_id = int.Parse(usuario);
                decimal ubi_dec_latitud = decimal.Parse(latitud, CultureInfo.InvariantCulture);
                decimal ubi_dec_longitud = decimal.Parse(longitud, CultureInfo.InvariantCulture);
                int ope_int_id = int.Parse(operacion);

                int hourBoundary5 = DateTime.Compare(DateTime.Now, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 5, 00, 00));
                int hourBoundary7 = DateTime.Compare(DateTime.Now, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 00, 00));

                //Restriccion de horario para registrar ubicaciones es de Lunes a Viernes de 5am - 7pm
                /*if (!(Helper.InBetweenDaysInclusive(DateTime.Now, DayOfWeek.Monday, DayOfWeek.Saturday) && (hourBoundary5 == 1 && hourBoundary7 < 0)))
                {
                    return "[{\"Ejecucion\":1}]";
                }*/

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
