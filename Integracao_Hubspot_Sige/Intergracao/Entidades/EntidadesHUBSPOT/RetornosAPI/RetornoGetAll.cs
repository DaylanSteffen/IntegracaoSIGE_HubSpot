using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integracao_Hubspot_Sige.Intergracao.Entidades.EntidadesHUBSPOT.RetornosAPI
{
    public class RetornoGetAll
    {
        public List<Vid> contacts { get; set; }

        [JsonProperty("has-more")]
        public bool has_more { get; set; }

        [JsonProperty("vid-offset")]
        public string vid_offset { get; set; }
    }

    public class Vid
    {
        public string vid { get; set; }
    }
}
