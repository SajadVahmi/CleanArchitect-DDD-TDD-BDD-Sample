using Framework.Domain.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application.Services
{
    public class NewtonSoftSerializer : IJsonSerializer
    {
        public TOutput Deserialize<TOutput>(string input) =>
            string.IsNullOrWhiteSpace(input) ?
                default : JsonConvert.DeserializeObject<TOutput>(input);

        public object Deserialize(string input, Type type) =>
            string.IsNullOrWhiteSpace(input) ?
                null : JsonConvert.DeserializeObject(input, type);

        public string Serilize<TInput>(TInput input) => input == null ? string.Empty : JsonConvert.SerializeObject(input, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
    }
}
