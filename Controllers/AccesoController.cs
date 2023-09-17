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
            List<decimal> listaniolectivo = new List<decimal>();
			listaniolectivo = ObtenerAnioLectivos();
			return View(listaniolectivo);

		}

        public List<decimal> ObtenerAnioLectivos()
        {
			List<decimal> listaniolectivo = new List<decimal>();

			using (SqlConnection cn = new SqlConnection(cadena))
			{
				string query = @"select año_lectivo from calificaciones group by año_lectivo";

				SqlCommand cmd = new SqlCommand(query, cn);

				cmd.CommandType = CommandType.Text;

				cn.Open();
				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					listaniolectivo.Add((decimal)reader["año_lectivo"]);
				}
                return listaniolectivo;
			}
		}
    

        public ActionResult Registar()
        {
            return View();
        }

        public ActionResult LoginAccess(Usuario oUsuario)
        {
			List<decimal> listaniolectivo = new List<decimal>();
			listaniolectivo = ObtenerAnioLectivos();
			//oUsuario.Clave = ConvertirSHA256(oUsuario.Clave);
			using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", cn);
                cmd.Parameters.AddWithValue("CodAlumna", oUsuario.CodigoAlumno);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                oUsuario.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            }

            if (oUsuario.IdUsuario != 0)
            {
                List<Bimensuales> listaBimensual = new List<Bimensuales>();

				using (SqlConnection cn = new SqlConnection(cadena))
                {
                    
                    SqlCommand cmd = new SqlCommand("sp_ValidarAranceles", cn);
                    cmd.Parameters.AddWithValue("CodAlumna", oUsuario.CodigoAlumno);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        Bimensuales temp = new Bimensuales();
                        temp.Parcial = reader["Parcial"] + "";
                        temp.Aplica =(bool)reader["Aplica"];
						listaBimensual.Add(temp);
                    }
                   
                    //oUsuario.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                }
                
                bool aplica = listaBimensual.Where(y => y.Parcial == oUsuario.Bimensual).Select(x => x.Aplica).FirstOrDefault();
                if(aplica)
                { 
				    return RedirectToAction("Index", "Home", new { codAlumna = oUsuario.CodigoAlumno, Bimensual = oUsuario.Bimensual });
                }
                else
                {
					ViewBag.Mensaje = "No esta al dia, para ese Bimensual";
					ViewBag.UsarioNoValido = true;
					return View("Login", listaniolectivo);
				}
			}
            else
            {
                ViewBag.Mensaje = "Usuario no encontrado";
                ViewBag.UsarioNoValido = true;
                return View("Login", listaniolectivo);
            }
        }
    }
}
