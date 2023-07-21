using Microsoft.AspNetCore.Mvc;
using ConsultarNotasRecoleccion.Models;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using Renci.SshNet;


namespace ConsultarNotasRecoleccion.Controllers
{
    public class AccesoController : Controller
    {
        static string cadena = "Server=localhost;Database=ESTADISTICA;Trusted_Connection=True;TrustServerCertificate=True;";

        public Usuario Session { get; private set; }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Registar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registar(Usuario oUsuarios)
        {
            bool registrado;
            string mensaje;
            if (oUsuarios.Clave == oUsuarios.ConfirmarClave)
            {
                oUsuarios.Clave = ConvertirSHA256(oUsuarios.Clave);
            }
            else
            {
                ViewData["Mensaje"] = "Las contrasenas no coinciden";
                return View();
            }
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", cn);
                cmd.Parameters.AddWithValue("Correo", oUsuarios.Correo);
                cmd.Parameters.AddWithValue("Clave", oUsuarios.Clave);
                cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();

                registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();


            }

            ViewData["Mensaje"] = "Las contrasenas no coinciden";
            if (registrado)
            {
                return RedirectToAction("Login", "Acceso");


            }
            else
            {
                return View();
            }
        }

        public ActionResult LoginAccess(Usuario oUsuario)
        {
            oUsuario.Clave = ConvertirSHA256(oUsuario.Clave);
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", cn);
                cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                cmd.Parameters.AddWithValue("Clave", oUsuario.Clave);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                oUsuario.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            }

            if (oUsuario.IdUsuario != 0)
            {
                Session = oUsuario;
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }
        }

        public static string ConvertirSHA256(string texto)
        {

            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));
                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }

        }



    }
}
