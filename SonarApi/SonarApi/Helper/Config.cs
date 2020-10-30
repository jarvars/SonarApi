using System.Configuration;

namespace SonarApi.Helper
{
    /// <summary>
    /// Utilitario para obtener valores del archivo de configuración
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Obtiene la propiedad BAD_ICON de la configuración del servicio
        /// </summary>
        public static string BadIcon
        {
            get { return ValorPropiedad("BAD_ICON"); }
        }

        /// <summary>
        /// Obtiene la propiedad OK_ICON de la configuración del servicio
        /// </summary>
        public static string OkIcon
        {
            get { return ValorPropiedad("OK_ICON"); }
        }

        /// <summary>
        /// Obtiene la propiedad BAD_COLOR de la configuración del servicio
        /// </summary>
        public static string BadColor
        {
            get { return ValorPropiedad("BAD_COLOR"); }
        }

        /// <summary>
        /// Obtiene la propiedad OK_COLOR de la configuración del servicio
        /// </summary>
        public static string OkColor
        {
            get { return ValorPropiedad("OK_COLOR"); }
        }

        /// <summary>
        /// Obtiene la propiedad TEAMS_WEBHOOK de la configuración del servicio
        /// </summary>
        public static string UrlTeamsWebHook
        {
            get { return ValorPropiedad("TEAMS_WEBHOOK"); }
        }

        private static string ValorPropiedad(string propiedad)
        {
            string valor = ConfigurationManager.AppSettings[propiedad];            
            return string.IsNullOrEmpty(valor) ? string.Empty : valor;
        }
    }
}