using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models.SignupForms
{
    public class SignupForm
    {
        [DeserializeAs(Name = "id")]
        public int SignupFormId { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }
    }
}
