using System;

namespace MoviegramApi.Core.Entities
{
    public class Movie
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime ShowTime { get;  set; }
        public int Duration { get; set; } 
        public string Image { get; set; }
    }
}