using SonarApi.Client;
using SonarApi.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SonarApi.Controllers
{
    /// <summary>
    /// Api para notificar a Teams resultados de análisis de Sonarqube
    /// </summary>
    public class TeamsController : ApiController
    {
        /// <summary>
        /// Notifica el resultado de un análisis de Sonarqube a Microsoft Teams
        /// </summary>
        /// <param name="analysis">Json correspondiente al payload que genera Sonarqube por medio de un webhook</param>
        /// <returns>Código http</returns>
        [HttpPost]
        public async Task<HttpResponseMessage> NotificarAnalisis(SonarPayload analysis)
        {
            try
            {
                if (analysis != null)
                {
                    await new Teams().EnviarMensaje(analysis);
                    return Request.CreateResponse(HttpStatusCode.Accepted);
                }
                else
                {
                    throw new ArgumentNullException(nameof(analysis), "Análisis payload nulo.");
                }
            }
            catch (Exception err)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error: " + err.Message);
            }
        }
    }
}