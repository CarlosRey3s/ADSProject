using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ADSProject.Utils;
namespace ADSProject.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/materias/")]
    public class MateriaController : ControllerBase
    {
        private readonly IMateria materia;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeusuario;
        private string pMensajeTecnico;

        public MateriaController(IMateria materia)
        {
            this.materia = materia;
        }
        [HttpPost("agregarMateria")] //FUNCIONA
        public ActionResult<string> AgregarMateria([FromBody] Materia materia)
        {
            try
            {
                //Verificar que todad las validacioones por atributo  dekl modelo este correctas.
                if (!ModelState.IsValid)
                {
                    //En caso de no cumplir con topdas las validaciones se procede a retornar una respuesta erronea.
                    return BadRequest(ModelState);
                }
                int contador = this.materia.AgregarMateria(materia);

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
        [HttpPut("actualizarMateria/{idMateria}")]
        public ActionResult<string> ActualizarMateria(int idMateria, [FromBody] Materia materia)
        {
            try
            {
                //Verificar que todad las validacioones por atributo  dekl modelo este correctas.
                if (!ModelState.IsValid)
                {
                    //En caso de no cumplir con topdas las validaciones se procede a retornar una respuesta erronea.
                    return BadRequest(ModelState);
                }
                int contador = this.materia.ActualizarMateria(idMateria, materia);

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

       

        [HttpDelete("eliminarMateria/{idMateria}")]
        public ActionResult<string> EliminarMateria(int idMateria)
        {
            try
            {
                bool eliminado = this.materia.EliminarMateria(idMateria);

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
        [HttpGet("obtenerMateriaPorID/{idMateria}")] //FUNCIONA
        public ActionResult<Materia> ObtenerMateriaPorID(int idMateria)
        {
            try
            {
                Materia materia = this.materia.ObtenermateriaPorID(idMateria);

                if (materia != null)
                {
                    return Ok(materia);
                }
                else
                {
                    pCodRespuesta = Constants.COD_ERROR;
                    pMensajeusuario = "No se encontraron datos del Estudinates";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeusuario;
                    return Ok(new { pCodRespuesta, pMensajeusuario, pMensajeTecnico });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("obtenerMateria")] //FUNCIONA
        public ActionResult<List<Materia>> ObtenerMateria()
        {
            try
            {
                List<Materia> lstMaterias = this.materia.ObtenerTodosLasMaterias();
                return Ok(lstMaterias);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
