using ConsultarNotasRecoleccion.Models;
using System.Data;
using System.Data.SqlClient;

namespace ConsultarNotasRecoleccion.DataAccess
{
    public class HomeDataAccess
    {
        static string cadena = "Server=localhost;Database=ESTADISTICA;Trusted_Connection=True;TrustServerCertificate=True;";

        /// <summary>
        /// Obtiene todas las calificaciones sin filtros
        /// </summary>
        /// <returns>Retorna todas las calificaciones, de todas las alumnas</returns>
        public List<Calificaciones> ObtenerCalificaciones()
        {
            List<Calificaciones> respuesta = new List<Calificaciones>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                string query = @"select n_lista
                                ,codigo_profesor
                                ,profesor
                                ,codigo_grado
                                ,grado
                                ,codigo_asignatura
                                ,asignatura
                                ,codigo_nivel
                                ,nivel
                                ,codigo_aula
                                ,aula
                                ,año_lectivo
                                ,codigo_alumna
                                ,alumnas
                                ,ps_primera_evalucion_parcial
                                ,cat1p
                                ,ps_segunda_evaluacion_parcial
                                ,cat2p
                                ,primer_semestre
                                ,cat1s
                                ,ss_primera_evalucion_parcial
                                ,cat3p
                                ,ss_segunda_evaluacion_parcial
                                ,cat4p
                                ,segundo_semestre
                                ,cat2s
                                ,nota_final
                                ,catnf
                                ,clave_calificacion
                                ,codigo_profesor_guia
                                ,profesor_guia
                                ,telefono_responsable
                                ,domicilio
                                ,directora
                                ,observacion_maestra
                                ,observaciones
                                ,disciplina_1p
                                ,disciplina_1pcat
                                ,disciplina_2p
                                ,disciplina_2pcat
                                ,disciplina_ps
                                ,disciplina_pscat
                                ,disciplina_3p
                                ,disciplina_3pcat
                                ,disciplina_4p
                                ,disciplina_4pcat
                                ,disciplina_ss
                                ,disciplina_sscat
                                ,disciplina_nf
                                ,disciplina_nfcat
                                ,tipocalificacion
                                ,codigo_tipo
                                ,observacion
                                ,retirada
                                ,nota_reparacion
                                ,nombre_disciplinas
                                ,codigo_categoria
                                ,categoria 
                                from calificaciones ";

                SqlCommand cmd = new SqlCommand(query, cn);

                cmd.CommandType = CommandType.Text;

                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Calificaciones temp = new Calificaciones();

                    temp.NLista = (decimal)reader["NLista"];
                    temp.CodigoProfesor = (decimal)reader["CodigoProfesor"];
                    temp.Profesor = reader["Profesor"] + "";
                    temp.CodigoGrado = (decimal)reader["CodigoGrado"];
                    temp.Grado = reader["Grado"] + "";
                    temp.CodigoAsignatura = (decimal)reader["CodigoAsignatura"];
                    temp.Asignatura = reader["Asignatura"] + "";
                    temp.CodigoNivel = (decimal)reader["CodigoNivel"];
                    temp.Nivel = reader["Nivel"] + "";
                    temp.CodigoAula = (decimal)reader["CodigoAula"];
                    temp.Aula = reader["Aula"] + "";
                    temp.AñoLectivo = (decimal)reader["AñoLectivo"];
                    temp.CodigoAlumna = (decimal)reader["CodigoAlumna"];
                    temp.Alumnas = reader["Alumnas"] + "";
                    temp.PsPrimeraEvalucionParcial = (decimal)reader["PsPrimeraEvalucionParcial"];
                    temp.Cat1p = reader["Cat1p"] + "";
                    temp.PsSegundaEvaluacionParcial = (decimal)reader["PsSegundaEvalucionParcial"];
                    temp.Cat2p = reader["Cat2p"] + "";
                    temp.PrimerSemestre = (decimal)reader["PrimerSemestre"];
                    temp.Cat1s = reader["Cat1s"] + "";
                    temp.SsPrimeraEvalucionParcial = (decimal)reader["SsPrimeraEvalucionParcial"];
                    temp.Cat3p = reader["Cat3p"] + "";
                    temp.SsSegundaEvaluacionParcial = (decimal)reader["SsSegundaEvaluacionParcial"];
                    temp.Cat4p = reader["Cat4p"] + "";
                    temp.SegundoSemestre = (decimal)reader["SegundoSemestre"];
                    temp.Cat2s = reader["Cat2s"] + "";
                    temp.NotaFinal = (decimal)reader["Notafinal"];
                    temp.Catnf = reader["Catnf"] + "";
                    temp.ClaveCalificacion = reader["ClaveClasificacion"] + "";
                    temp.CodigoProfesorGuia = (decimal)reader["CodigoProfesorGuia"];
                    temp.ProfesorGuia = reader["ProfesorGuia"] + "";
                    temp.TelefonoResponsable = reader["TelefonoResponsable"] + "";
                    temp.Domicilio = reader["Domicilio"] + "";
                    temp.Directora = reader["Directora"] + "";
                    temp.ObservacionMaestra = reader["ObservacionesMaestra"] + "";
                    temp.Observaciones = reader["Observaciones"] + "";
                    temp.Disciplina1p = reader["Disciplina"] + "";
                    temp.Disciplina1pcat = reader["Disciplina1pcat"] + "";
                    temp.Disciplina2p = reader["Disciplina2p"] + "";
                    temp.Disciplina2pcat = reader["Disciplina2pcat"] + "";
                    temp.DisciplinaPs = reader["DisciplinaPs"] + "";
                    temp.DisciplinaPs = reader["DisciplinaPs"] + "";
                    temp.DisciplinaPscat = reader["DisciplinaPscat"] + "";
                    temp.Disciplina3p = reader["Disciplina3p"] + "";
                    temp.Disciplina3pcat = reader["Disciplina3pcat"] + "";
                    temp.Disciplina4p = reader["Disciplina4p"] + "";
                    temp.Disciplina4pcat = reader["Disciplina4pcat"] + "";
                    temp.DisciplinaSs = reader["DisciplinaSs"] + "";
                    temp.DisciplinaSscat = reader["DisciplinaSscat"] + "";
                    temp.DisciplinaNf = reader["DisciplinaNf"] + "";
                    temp.DisciplinaNfcat = reader["DisciplinaNfcat"] + "";
                    temp.Tipocalificacion = reader["Tipocalificacion"] + "";
                    temp.CodigoTipo = (decimal)reader["CodigoTipo"];
                    temp.Observacion = reader["Observacion"] + "";
                    temp.Retirada = (bool)reader["Retirada"];
                    temp.NotaReparacion = (decimal)reader["NotaReparacion"];
                    temp.NombreDisciplinas = reader["NombreDisciplinas"] + "";
                    temp.CodigoCategoria = (decimal)reader["CodigoCategoria"];
                    temp.Categoria = reader["Categoria"] + "";
                    respuesta.Add(temp);
                }

            }
            return respuesta;
        }

        /// <summary>
        /// Obtiene las notas de una alumna
        /// </summary>
        /// <param name="codigoAlumna"></param>
        /// <returns>Retorna las notas de una alumna</returns>
        public List<Calificaciones> ObtenerCalificacionPorAlumno(decimal codigoAlumna)
        {
            List<Calificaciones> respuesta = new List<Calificaciones>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                string query = @"select n_lista
                                ,codigo_profesor
                                ,profesor
                                ,codigo_grado
                                ,grado
                                ,codigo_asignatura
                                ,asignatura
                                ,codigo_nivel
                                ,nivel
                                ,codigo_aula
                                ,aula
                                ,año_lectivo
                                ,codigo_alumna
                                ,alumnas
                                ,ps_primera_evalucion_parcial
                                ,cat1p
                                ,ps_segunda_evaluacion_parcial
                                ,cat2p
                                ,primer_semestre
                                ,cat1s
                                ,ss_primera_evalucion_parcial
                                ,cat3p
                                ,ss_segunda_evaluacion_parcial
                                ,cat4p
                                ,segundo_semestre
                                ,cat2s
                                ,nota_final
                                ,catnf
                                ,clave_calificacion
                                ,codigo_profesor_guia
                                ,profesor_guia
                                ,telefono_responsable
                                ,domicilio
                                ,directora
                                ,observacion_maestra
                                ,observaciones
                                ,disciplina_1p
                                ,disciplina_1pcat
                                ,disciplina_2p
                                ,disciplina_2pcat
                                ,disciplina_ps
                                ,disciplina_pscat
                                ,disciplina_3p
                                ,disciplina_3pcat
                                ,disciplina_4p
                                ,disciplina_4pcat
                                ,disciplina_ss
                                ,disciplina_sscat
                                ,disciplina_nf
                                ,disciplina_nfcat
                                ,tipocalificacion
                                ,codigo_tipo
                                ,observacion
                                ,retirada
                                ,nota_reparacion
                                ,nombre_disciplinas
                                ,codigo_categoria
                                ,categoria 
                                from calificaciones 
                                where codigo_alumna = @codigo_alumna";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@codigo_alumna", codigoAlumna);

                cmd.CommandType = CommandType.Text;

                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Calificaciones temp = new Calificaciones();

                    temp.NLista = (decimal)reader["n_lista"];
                    temp.CodigoProfesor = (decimal)reader["codigo_profesor"];
                    temp.Profesor = reader["profesor"] + "";
                    temp.CodigoGrado = (decimal)reader["codigo_grado"];
                    temp.Grado = reader["grado"] + "";
                    temp.CodigoAsignatura = (decimal)reader["codigo_asignatura"];
                    temp.Asignatura = reader["asignatura"] + "";
                    temp.CodigoNivel = (decimal)reader["codigo_nivel"];
                    temp.Nivel = reader["nivel"] + "";
                    temp.CodigoAula = (decimal)reader["codigo_aula"];
                    temp.Aula = reader["aula"] + "";
                    temp.AñoLectivo = (decimal)reader["año_lectivo"];
                    temp.CodigoAlumna = (decimal)reader["codigo_alumna"];
                    temp.Alumnas = reader["alumnas"] + "";
                    temp.PsPrimeraEvalucionParcial = (decimal)reader["ps_primera_evalucion_parcial"];
                    temp.Cat1p = reader["cat1p"] + "";
                    temp.PsSegundaEvaluacionParcial = (decimal)reader["ps_segunda_evaluacion_parcial"];
                    temp.Cat2p = reader["cat2p"] + "";
                    temp.PrimerSemestre = (decimal)reader["primer_semestre"];
                    temp.Cat1s = reader["cat1s"] + "";
                    temp.SsPrimeraEvalucionParcial = (decimal)reader["ss_primera_evalucion_parcial"];
                    temp.Cat3p = reader["cat3p"] + "";
                    temp.SsSegundaEvaluacionParcial = (decimal)reader["ss_segunda_evaluacion_parcial"];
                    temp.Cat4p = reader["cat4p"] + "";
                    temp.SegundoSemestre = (decimal)reader["segundo_semestre"];
                    temp.Cat2s = reader["cat2s"] + "";
                    temp.NotaFinal = (decimal)reader["nota_final"];
                    temp.Catnf = reader["catnf"] + "";
                    temp.ClaveCalificacion = reader["clave_calificacion"] + "";
                    temp.CodigoProfesorGuia = (decimal)reader["codigo_profesor_guia"];
                    temp.ProfesorGuia = reader["profesor_guia"] + "";
                    temp.TelefonoResponsable = reader["telefono_responsable"] + "";
                    temp.Domicilio = reader["domicilio"] + "";
                    temp.Directora = reader["directora"] + "";
                    temp.ObservacionMaestra = reader["observacion_maestra"] + "";
                    temp.Observaciones = reader["observaciones"] + "";
                    temp.Disciplina1p = reader["disciplina_1p"] + "";
                    temp.Disciplina1pcat = reader["disciplina_1pcat"] + "";
                    temp.Disciplina2p = reader["disciplina_2p"] + "";
                    temp.Disciplina2pcat = reader["disciplina_2pcat"] + "";
                    temp.DisciplinaPs = reader["disciplina_ps"] + "";
                    temp.DisciplinaPscat = reader["disciplina_pscat"] + "";
                    temp.Disciplina3p = reader["disciplina_3p"] + "";
                    temp.Disciplina3pcat = reader["disciplina_3pcat"] + "";
                    temp.Disciplina4p = reader["disciplina_4p"] + "";
                    temp.Disciplina4pcat = reader["disciplina_4pcat"] + "";
                    temp.DisciplinaSs = reader["disciplina_ss"] + "";
                    temp.DisciplinaSscat = reader["disciplina_sscat"] + "";
                    temp.DisciplinaNf = reader["disciplina_nf"] + "";
                    temp.DisciplinaNfcat = reader["disciplina_nfcat"] + "";
                    temp.Tipocalificacion = reader["tipocalificacion"] + "";
                    temp.CodigoTipo = (decimal)reader["codigo_tipo"];
                    temp.Observacion = reader["observacion"] + "";
                    temp.Retirada = (bool)reader["retirada"];
                    temp.NotaReparacion = (decimal)reader["nota_reparacion"];
                    temp.NombreDisciplinas = reader["nombre_disciplinas"] + "";
                    temp.CodigoCategoria = (decimal)reader["codigo_categoria"];
                    temp.Categoria = reader["categoria"] + "";
                    respuesta.Add(temp);
                }

            }
            return respuesta;

        }
    }
}
