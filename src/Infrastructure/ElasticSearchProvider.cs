using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Infrastructure
{
    public class ElasticSearchProvider
    {
        private int _port = 9200;
        private string _host = "http://localhost";
        private string _index = "cqrs-workshop";
        private string _url;
        

        public ElasticSearchProvider()
        {
            _url = _host + ":" + _port + "/" + _index + "/";
        }

        public async Task<JObject> Save(string type, Guid id, string data)
        {
            string resource = _url + "/" + type + "/" + id.ToString() + "/";
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(resource, new StringContent(data));

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return await Task.Run(() => JObject.Parse(content));

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);

            //request.Accept = "application/json";
            //request.Method = WebRequestMethods.Http.Post;
            //request.ContentType = "application/json; charset=utf-8";

            //string text;
            //var response = (HttpWebResponse)request.GetResponse();

            //using (var sr = new StreamReader(response.GetResponseStream()))
            //{
            //    text = sr.ReadToEnd();
            //}

            //dynamic json = JsonConvert.DeserializeObject(text);
        }
    }
}
