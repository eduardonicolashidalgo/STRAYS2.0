﻿using Newtonsoft.Json;
using STRAYS.Models;
using System.Net.Http.Headers;
using System.Text;

namespace STRAYS.Services
{
    public class ImageGenerator
    {
        string key = "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"; //DEbemos cambiar la Api cada cierto tiempo

        public void setKey(string key)
        {
            this.key = key;
        }

        public async Task<responseModel> GenerateImage(input input)
        {
            responseModel resp = new responseModel();
            using(var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", key);

                var Message = await client.PostAsync("https://api.openai.com/v1/images/generations",
                    new StringContent(JsonConvert.SerializeObject(input),
                    Encoding.UTF8, "application/json"));

                if (Message.IsSuccessStatusCode)
                {
                    var content = await Message.Content.ReadAsStringAsync();
                    resp = JsonConvert.DeserializeObject<responseModel>(content);
                }
            }

            return resp;
        }
    }
}
