using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameVerse.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;

namespace GameVerse.Services
{
    public class ImageValidationService(IConfiguration configuration) : IImageValidationService
    {
        private readonly IConfiguration _configuration = configuration;

        public async Task<bool> ValidateImageWithApi(string imageUrl)
        {
            string apiUrl = "https://nsfw-images-detection-and-classification.p.rapidapi.com/adult-content";
            string apiKey = "eef38abf0emsh6661c57d682594fp10ed0cjsn841fc5b63cfb";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "nsfw-images-detection-and-classification.p.rapidapi.com");

                StringContent content = new StringContent($"{{\"url\": \"{imageUrl}\"}}", System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    JObject jsonResponse = JObject.Parse(result);

                    //Example API response:
                    /*{
                        "unsafe": false,
                        "objects": [
                        {
                            "box": [
                            156,
                            239,
                            473,
                            589
                                ],
                            "score": 0.8797686696052551,
                            "label": "FACE_F"
                        }
                        ]
                    }*/


                    bool isUnsafe = jsonResponse["unsafe"].Value<bool>();

                    return !isUnsafe; 
                }
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }
    }
}
