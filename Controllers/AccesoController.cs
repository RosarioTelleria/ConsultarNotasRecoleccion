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

        //public Usuario Session { get; private set; }


        public ActionResult Login()
        {
            ViewBag.UsarioNoValido = false;
            List<Calificaciones> resul = new List<Calificaciones>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                string query = @"select año_lectivo from calificaciones group by año_lectivo";

                SqlCommand cmd = new SqlCommand(query, cn);

                cmd.CommandType = CommandType.Text;

                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Calificaciones temp = new Calificaciones();
                    temp.AñoLectivo = (decimal)reader["año_lectivo"];
                    resul.Add(temp);
                }
                return View(resul);
            }
		}
    

        public ActionResult Registar()
        {
            return View();
        }

        public ActionResult LoginAccess(Usuario oUsuario)
        {
            //oUsuario.Clave = ConvertirSHA256(oUsuario.Clave);
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", cn);
                cmd.Parameters.AddWithValue("CodAlumna", oUsuario.Clave);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                oUsuario.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            }

            if (oUsuario.IdUsuario != 0)
            {
                List<Bimensuales> respuesta = new List<Bimensuales>();

                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    
                    SqlCommand cmd = new SqlCommand("sp_ValidarAranceles", cn);
                    cmd.Parameters.AddWithValue("CodAlumna", oUsuario.Clave);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        Bimensuales temp = new Bimensuales();
                        temp.Parcial = reader["Parcial"] + "";
                        temp.Aplica =(bool)reader["Aplica"];
                        respuesta.Add(temp);
                    }
                   
                    //oUsuario.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                }
               
                return RedirectToAction("ViewsIBimensual", "Home", new { codAlumna = oUsuario.Clave });
            }
            else
            {
                ViewBag.Mensaje = "Usuario no encontrado";
                ViewBag.UsarioNoValido = true;
                return View("Login");
            }
        }
    }
}
