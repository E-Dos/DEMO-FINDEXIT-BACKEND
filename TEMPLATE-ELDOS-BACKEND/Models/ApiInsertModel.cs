namespace TEMPLATE_ELDOS_BACKEND.Models
{
    public class ApiInsertModel
    {
        public class DataItem
        {
            public long timestamp { get; set; }
            public string imei { get; set; }
            public string skv { get; set; }
            public string kust { get; set; }
            public string mr { get; set; }
            public string br { get; set; }
            public string ceh { get; set; }
            public string spy { get; set; }
            public string? fkmax { get; set; }
        }

        public class SubItem
        {
            public string id { get; set; }
            public string num { get; set; }
        }
    }
}
