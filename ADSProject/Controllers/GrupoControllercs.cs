using ADSProject.Interfaces;
using ADSProject.Models;
using ADSProject.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/grupo/")]
    public class GrupoControllercs : ControllerBase
    {
        private readonly IGrupo grupo;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeusuario;
        private string pMensajeTecnico;

        public GrupoControllercs(IGrupo grupo)
        {
            this.grupo = grupo;
        }
        [HttpPost("agregarGrupo")] //FUNCIONA
        public ActionResult<string> AgregarGrupo([FromBody] Grupo grupo)
        {
            try
            {
                int contador = this.grupo.AgregarGrupo(grupo);

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
        [HttpPut("actualizarGrupo/{idGrupo}")]
        public ActionResult<string> ActualizarGrupo(int idGrupo, [FromBody] Grupo grupo)
        {
            try
            {
                int contador = this.grupo.ActualizarGrupo(idGrupo, grupo);

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
        [HttpDelete("eliminarGrupo/{idGrupo}")]
        public ActionResult<string> EliminarGrupo(int idGrupo)
        {
            try
            {
                bool eliminado = this.grupo.EliminarGrupo(idGrupo);

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
        [HttpGet("obtenerGruposPorID/{idgrupo}")] //FUNCIONA
        public ActionResult<Grupo> ObtenerGrupoPorID(int idGrupo)
        {
            try
            {
                Grupo grupo = this.grupo.ObtenergrupoPorID(idGrupo);


                if (grupo != null)
                {
                    return Ok(grupo);
                }
                else
                {
                    pCodRespuesta = Constants.COD_ERROR;
                    pMensajeusuario = "No se encontraron datos del Grupo";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeusuario;
                    return Ok(new { pCodRespuesta, pMensajeusuario, pMensajeTecnico });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("obtenerGrupo")] //FUNCIONA
        public ActionResult<List<Grupo>> ObtenerGrupo()
        {
            try
            {
                List<Grupo> lstGrupo = this.grupo.ObtenerTodosLosGrupos();
                return Ok(lstGrupo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
