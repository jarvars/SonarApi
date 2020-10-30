using System;
using System.Collections.Generic;

namespace SonarApi.Models
{
    /// <summary>
    /// Modelo del proyecto de análisis de Sonar
    /// </summary>
    public class Project
    {
        public string key { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    /// <summary>
    /// Modelo del branch del análisis de Sonar
    /// </summary>
    public class Branch
    {
        public string name { get; set; }
        public string type { get; set; }
        public bool isMain { get; set; }
        public string url { get; set; }
    }

    /// <summary>
    /// Modelo de condiciones del análisis del Sonar
    /// </summary>
    public class Condition
    {
        public string metric { get; set; }
        public string operador { get; set; }
        public string value { get; set; }
        public string status { get; set; }
        public string errorThreshold { get; set; }
    }

    /// <summary>
    /// Modelo del umbral de calidad del proyecto en Sonar
    /// </summary>
    public class QualityGate
    {
        public string name { get; set; }
        public string status { get; set; }
        public IList<Condition> conditions { get; set; }
    }

    public class Properties
    {
    }

    /// <summary>
    /// Modelo de salida del reporte de análisis de Sonar
    /// </summary>
    public class SonarPayload
    {
        public string serverUrl { get; set; }
        public string taskId { get; set; }
        public string status { get; set; }
        public DateTime analysedAt { get; set; }
        public DateTime changedAt { get; set; }
        public Project project { get; set; }
        public Branch branch { get; set; }
        public QualityGate qualityGate { get; set; }
        public Properties properties { get; set; }
    }
}