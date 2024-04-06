using ADSProject.Interfaces;
using ADSProject.Models;
using ADSProject.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/profesor/")]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesor profesor;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeusuario;
        private string pMensajeTecnico;

        public ProfesorController(IProfesor profesor)
        {
            this.profesor = profesor;
        }
        [HttpPost("agregarProfesor")] //FUNCIONA
        public ActionResult<string> AgregarProfesor([FromBody] Profesor profesor)
        {
            try
            {
                int contador = this.profesor.AgregarProfesor(profesor);

                if (contador > 0)
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

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut("actualizarProfesor/{idProfesor}")]
        public ActionResult<string> ActualizarProfesor(int idProfesor, [FromBody] Profesor profesor)
        {
            try
            {
                int contador = this.profesor.ActualizarProfesor(idProfesor, profesor);

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
        [HttpDelete("eliminarProfesor/{idProfesor}")]
        public ActionResult<string> EliminarProfesor(int idProfesor)
        {
            try
            {
                bool eliminado = this.profesor.EliminarProfesor(idProfesor);

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

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("obtenerProfesorPorID/{idProfesor}")] //FUNCIONA
        public ActionResult<Profesor> ObtenerProfesorPorID(int idProfesor)
        {
            try
            {
                Profesor profesor = this.profesor.ObtenerprofesorPorID(idProfesor);

                if (profesor != null)
                {
                    return Ok(profesor);
                }
                else
                {
                    pCodRespuesta = Constants.COD_ERROR;
                    pMensajeusuario = "No se encontraron datos del Profesor";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeusuario;
                    return Ok(new { pCodRespuesta, pMensajeusuario, pMensajeTecnico });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("obtenerProfesor")] //FUNCIONA
        public ActionResult<List<Profesor>> ObtenerProfesor()
        {
            try
            {
                List<Profesor> lstProfesor = this.profesor.ObtenerTodosLosProfesores();
                return Ok(lstProfesor);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
