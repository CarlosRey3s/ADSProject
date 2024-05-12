using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace ADSProject.Controllers
{

    [Microsoft.AspNetCore.Mvc.Route("api/estudiantes/")]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudiante estudiante;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeusuario;
        private string pMensajeTecnico;

        public EstudiantesController(IEstudiante estudiante)
        {
            this.estudiante = estudiante;  
        }
        [HttpPost("agregarEstudiante")] //FUNCIONA
        public ActionResult<string> AgregarEstudiante([FromBody] Estudiante estudiante)
        {
            try {
                //Verificar que todad las validacioones por atributo  dekl modelo este correctas.
                if (!ModelState.IsValid)
                {
                    //En caso de no cumplir con topdas las validaciones se procede a retornar una respuesta erronea.
                    return BadRequest(ModelState);
                }
                int contador = this.estudiante.AgregarEstudiante(estudiante);

                if(contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeusuario = "Registro insertado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeusuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeusuario = "Ocurrio un porblema al insertar el Registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeusuario;
                }
                return Ok(new { pCodRespuesta, pMensajeusuario, pMensajeTecnico });

            }catch(Exception ) 
            {
                throw;
            }
        }
        [HttpPut("actualizarEstudiante/{idEstudiante}")]
        public ActionResult<string> ActualizarEstudiante(int idEstudiante, [FromBody] Estudiante estudiante)
        {
            try
            {
                //Verificar que todad las validacioones por atributo  dekl modelo este correctas.
                if (!ModelState.IsValid)
                {
                    //En caso de no cumplir con topdas las validaciones se procede a retornar una respuesta erronea.
                    return BadRequest(ModelState);
                }
                int contador = this.estudiante.ActualizarEstudiante(idEstudiante, estudiante);

                if (contador > 0)
                {
                    string pCodRespuesta = "COD_EXITO";
                    string pMensajeusuario = "Registro actualizado con éxito";
                    string pMensajeTecnico = $"{pCodRespuesta} || {pMensajeusuario}";

                    return Ok(new { pCodRespuesta, pMensajeusuario, pMensajeTecnico });
                }
                else
                {
                    string pCodRespuesta = "COD_ERROR";
                    string pMensajeusuario = "Ocurrió un problema al actualizar el Registro";
                    string pMensajeTecnico = $"{pCodRespuesta} || {pMensajeusuario}";

                    return StatusCode(500, new { pCodRespuesta, pMensajeusuario, pMensajeTecnico });
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");

                // Return a meaningful error response
                return StatusCode(500, new { pCodRespuesta = "COD_ERROR", pMensajeusuario = "Error interno del servidor", pMensajeTecnico = ex.Message });
            }
        }
        [HttpDelete("eliminarEstudiante/{idEstudiante}")]
        public ActionResult<string> EliminarEstudiante(int idEstudiante)
        {
            try
            {
                bool eliminado = this.estudiante.EliminarEstudiante(idEstudiante);

                if (eliminado)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeusuario = "Registro eliminado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeusuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeusuario = "Ocurrio un porblema al eliminar el Registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeusuario;
                }
                return Ok(new { pCodRespuesta, pMensajeusuario, pMensajeTecnico });

            }catch(Exception ex)
            {
                throw;
            }
        }
        [HttpGet("obtenerEstudiantesPorID/{idEstudiante}")] //FUNCIONA
        public ActionResult<Estudiante> ObtenerEstudiantesPorID(int idEstudiante)
        {
            try
            {
                Estudiante estudiante = this.estudiante.ObtenerEstudiantesPorID(idEstudiante);

                if (estudiante != null)
                {
                    return Ok(estudiante);
                }else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeusuario = "No se encontraron datos del Estudinates";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeusuario;
                    return Ok(new { pCodRespuesta, pMensajeusuario, pMensajeTecnico });
                }
            }catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("obtenerEstudiantes")] //FUNCIONA
        public ActionResult<List<Estudiante>> ObtenerEstudiante()
        {
            try
            {
                List<Estudiante> lstEstudiante = this.estudiante.ObtenerTodosLosEstudinates();
                return Ok(lstEstudiante);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
