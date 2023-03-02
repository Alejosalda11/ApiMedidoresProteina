using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMedidoresProteina
{
    public class Medidores_Proteina
    {
        public string day { get; set; }
        public string idMedidor { get; set; }
        public string kind { get; set; }
        public string lat { get; set; }
        public string @long { get; set; }
        public string lux { get; set; }
        public string month { get; set; }
        public string planting { get; set; }
        public string protein { get; set; }
        public string time { get; set; }
        public string year { get; set; }
    }

    public class Root
    {
        [JsonProperty("id")]
        public Medidores_Proteina id { get; set; }
    }

}
    

