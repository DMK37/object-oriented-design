using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProgOb
{
    public class Movie
    {
        private static int StatId = 0;

        public int Id { get; }
        public string Title { get; }
        public string Genre { get; }

        public int IdDirector { get; }

        public int ReleaseYear { get; }
        public int Duration { get; }

        public Movie(string title, string genre, int idDirector,  int duration, int releaseYear)
        { 
            Title = title;
            Genre = genre;
            IdDirector = idDirector;
            ReleaseYear = releaseYear;
            Duration = duration;
            Id = StatId++;
        }

        public override string ToString()
        {
            Bitflix bitflix = Bitflix.Instance;
            return
                $"Movie: {Title}, {Genre}, {bitflix.GetAuthor(IdDirector).Name} " +
                $"{bitflix.GetAuthor(IdDirector).Surname}, {ReleaseYear}, {Duration}";
        }
    }
    
    
}
