using Newtonsoft.Json;
using SonarApi.Helper;
using SonarApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SonarApi.Client
{
    /// <summary>
    /// Clase cliente para enviar mensajes a Teams
    /// </summary>
    internal sealed class Teams : IDisposable
    {
        private readonly Uri uri = new Uri(Config.UrlTeamsWebHook);
        private readonly HttpClient client = new HttpClient();

        internal async Task EnviarMensaje(SonarPayload analisis)
        {
            var estado = analisis.status.ToLower();
            var taskStatus = estado.First().ToString().ToUpper() + estado.Substring(1);

            var mensaje = new MessageCard
            {
                Title = $"Análisis {analisis.project.name}",
                Color = analisis.qualityGate.status == "OK" ? Config.OkColor : Config.BadColor,
                Text = $"Tarea: {analisis.taskId} - Estado {taskStatus}",
                Sections = new List<MessageSection>()
                {
                    new MessageSection()
                    {
                        Title = analisis.qualityGate.status,
                        Subtitle = $"{analisis.analysedAt}",
                        Image = analisis.qualityGate.status == "OK" ? Config.OkIcon : Config.BadIcon,
                        Facts = new List<MessageFact>()
                    }
                }
            };

            foreach (Condition condicion in analisis.qualityGate.conditions)
            {
                mensaje.Sections[0].Facts.Add(new MessageFact() { Name = condicion.metric, Value = condicion.status });
            }

            mensaje.PotentialActions = new List<PotentialAction>
            {
                new PotentialAction()
                {
                    Name = "Abrir en Sonar",
                    Targets = new List<PotentialActionLink>()
                        {
                            new PotentialActionLink()
                            {
                                Value = analisis.project.url
                            }
                        }
                }
            };

            var json = JsonConvert.SerializeObject(mensaje);
            var response = await client.PostAsync(uri, new StringContent(json, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}