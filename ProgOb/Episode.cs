using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgOb
{
    public class Episode
    {
        private static int StatId = 0;
        public int Id { get; }
        public string Title { get; }
        public int Duration { get; }
        public int ReleaseYear { get; }

        public int IdDirector { get; }

        public Episode(string title, int duration, int releaseYear, int idDirector)
        {
            this.Title = title;
            this.Duration = duration;
            this.ReleaseYear = releaseYear;
            this.IdDirector = idDirector;
            Id = StatId++;
        }

        public override string ToString()
        {
            Bitflix bitflix = Bitflix.Instance;
            return
                $"Episode: {Title}, {Duration}, {ReleaseYear}, {bitflix.GetAuthor(IdDirector).Name} " +
                $"{bitflix.GetAuthor(IdDirector).Surname}";
        }
    }
}
