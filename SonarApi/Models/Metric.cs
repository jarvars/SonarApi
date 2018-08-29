using System.Collections.Generic;

namespace SonarApi.Models
{
    public class Metric
    {
        public int row { get; set; }
        public string Id { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Domain { get; set; }
        public int Direction { get; set; }
        public bool Qualitative { get; set; }
        public bool Hidden { get; set; }
        public bool Custom { get; set; }
        public int? DecimalScale { get; set; }
    }

    public class RootMetrics
    {
        public List<Metric> Metrics { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

}