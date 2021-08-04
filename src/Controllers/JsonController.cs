using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Controllers
{
    public class JsonController
    {
        public static string SerializeObjectToJson(List<Afiliados> obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public static List<Afiliados> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<List<Afiliados>>(File.ReadAllText(json));
        }
    }
}
