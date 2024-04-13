using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/carrera/")]
    public class CarreraController : ControllerBase
    {
        private readonly IECarrera carrera;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeusuario;
        private string pMensajeTecnico;

        public CarreraController(IECarrera carrera)
        {
             this.carrera = carrera;
        }
        [HttpPost("agregarCarrera")] //FUNCIONA
        public ActionResult<string> AgregarCarrera([FromBody] Carrera carrera)
            {
                try
                {
                //Verificar que todad las validacioones por atributo  dekl modelo este correctas.
                if (!ModelState.IsValid)
                {
                    //En caso de no cumplir con topdas las validaciones se procede a retornar una respuesta erronea.
                    return BadRequest(ModelState);
                }
                int contador = this.carrera.AgregarCarrera(carrera);

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

        [HttpPut("actualizarCarrera/{idCarrera}")]
        public ActionResult<string> ActualizarCarrera(int idCarrera, [FromBody] Carrera carrera)
        {
            try
            {
                //Verificar que todad las validacioones por atributo  dekl modelo este correctas.
                if (!ModelState.IsValid)
                {
                    //En caso de no cumplir con topdas las validaciones se procede a retornar una respuesta erronea.
                    return BadRequest(ModelState);
                }
                int contador = this.carrera.ActualizarCarrera(idCarrera, carrera);

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
         [HttpDelete("eliminarCarrera/{idCarrera}")]

         public ActionResult<string> EliminarCarrera(int idCarrera)
            {
                try
                {
                    bool eliminado = this.carrera.EliminarCarrera(idCarrera);

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

         [HttpGet("obtenerCarreraPorID/{idCarrera}")] //FUNCIONA

         public ActionResult<Carrera> ObtenerCarreraPorID(int idCarrera)
            {
                try
                {
                Carrera carrera = this.carrera.ObtenercarrerasPorID(idCarrera);

                if (carrera != null)
                    {
                        return Ok(carrera);
                    }
                    else
                    {
                        pCodRespuesta = COD_ERROR;
                        pMensajeusuario = "No se encontraron datos de la Carrera";
                        pMensajeTecnico = pCodRespuesta + " || " + pMensajeusuario;
                        return Ok(new { pCodRespuesta, pMensajeusuario, pMensajeTecnico });
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
        
         [HttpGet("obtenerCarrera")] //FUNCIONA

         public ActionResult<List<Carrera>> ObtenerCarreras()
         {
             try
             {
                    List<Carrera> lstCarreras = this.carrera.ObtenerTodosLasCarreras();
                    return Ok(lstCarreras);
              }
              catch (Exception ex)
              {
                    throw;
              }
         }
    }
}
