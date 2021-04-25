using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Service
{
    class PictureService
    {
        private readonly HttpClient http;
        public PictureService(HttpClient _http)
        {
            http = _http;
        }
        public async Task<Stream> GetPicture()
        {
            var resp = await http.GetAsync("");
            return await resp.Content.ReadAsStreamAsync();
        }
    }
}
