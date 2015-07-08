using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models.SignupForms
{
    public class SignupForm
    {
        [JsonProperty("id")]
        public int? SignupFormId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
