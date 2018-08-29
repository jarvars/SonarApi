using System.Collections.Generic;

namespace SonarApi.Models
{
    public class Paging
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int total { get; set; }
    }

    public class User
    {
        public string login { get; set; }
        public string name { get; set; }
    }

    public class RootUsers
    {
        public Paging paging { get; set; }
        public List<User> users { get; set; }
    }
}