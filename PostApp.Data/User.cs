using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApp.Data
{
    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
    }
}
