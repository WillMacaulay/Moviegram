using System;

namespace MoviegramApi.WebUI.Api.ApiModels
{
    public class MovieDTO
    {
        public string Name { get; set; }
        public DateTime ShowTime { get;  set; }
        public int Duration { get; set; } 
    }
}