using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;

namespace JuegoRoll.Modelos
{
    class API_Poderes
    {
        public List<Result> ListadoDePoderes;

        public API_Poderes()
        {
            ListadoDePoderes = GetPoderes();
        }


        public static List<Result> GetPoderes()
        {
            var url = "https://www.dnd5eapi.co/api/spells?level=2";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream streamReader = response.GetResponseStream())
                    {
                        if (streamReader != null)
                        {
                            using (StreamReader ObjReader = new StreamReader(streamReader))
                            {
                                string responseBody = ObjReader.ReadToEnd();
                                Poderes poderes = JsonSerializer.Deserialize<Poderes>(responseBody);
                                return poderes.Results;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
    }
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Result
    {
        [JsonPropertyName("index")]
        public string Index { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Poderes
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }
    }


}
