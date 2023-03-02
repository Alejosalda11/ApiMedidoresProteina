using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;


namespace ApiMedidoresProteina
{
    public class Medidor
    {

        public async void Get()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://somexpro-t-default-rtdb.firebaseio.com/");
                HttpResponseMessage response = await client.GetAsync("/protein-samples.json");
                if (response.IsSuccessStatusCode)
                {
                    string data2 = await response.Content.ReadAsStringAsync();
                    Dictionary<string, object> deserializarJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(data2);


                    dynamic jsonObj = JObject.Parse(data2);

                    int count = 0;

                    foreach (dynamic item in jsonObj) 
                    {
                        string primerValor = deserializarJson.Keys.ElementAt(count);
                        string id = primerValor;
                        string day = jsonObj[primerValor]["day"];
                        string idMedidor = jsonObj[primerValor]["id"];
                        string kind = jsonObj[primerValor]["kind"];
                        string lat = jsonObj[primerValor]["lat"];
                        string @long = jsonObj[primerValor]["long"];
                        string lux = jsonObj[primerValor]["lux"];
                        string month = jsonObj[primerValor]["month"];
                        string planting = jsonObj[primerValor]["planting"];
                        string protein = jsonObj[primerValor]["protein"];
                        string time = jsonObj[primerValor]["time"];
                        string year = jsonObj[primerValor]["year"];

                        count = count + 1;

                        string connectionString = "Data Source=DESKTOP-VJO9FRT;Initial Catalog=GENERAL_DB;Integrated Security=True";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {

                            string query = "SP_Medidores_Proteina '" + id + "', '" + day + "', '" + idMedidor + "', '" + kind + "', '" + lat + "', '" + @long + "', '" + lux + "', '" + month + "', '" + @planting + "', '" + protein + "', '" + time + "', '" + year + "'";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                connection.Open(); command.CommandTimeout = 4000;

                                try
                                {
                                    command.ExecuteNonQuery();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);

                                }

                            }
                        }

                    }
                }
            }
        }


    }
}
