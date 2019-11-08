using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Assignment_UWP.Entity;

namespace Assignment_UWP.Service
{
    class SongService: ISongService
    {

        public Song CreateSong(MemberCredential memberCredential, Song song)
        {
            throw new NotImplementedException();
        }

        public List<Song> GetAllSong(MemberCredential memberCredential)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(memberCredential.token);
            var response = httpClient.GetAsync(ProjectConfiguration.SONG_GET_ALL).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<List<Song>>(response.Content.ReadAsStringAsync().Result);
        }

        public List<Song> GetMineSongs(MemberCredential memberCredential)
        {
            throw new NotImplementedException();
        }
    }
}
