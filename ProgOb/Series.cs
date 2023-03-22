using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgOb
{
    public class Series
    {
        private static int StatId = 0;
        public int Id { get; }
        public string Title { get; }
        public string Genre { get; }
        public int IdShowrunner { get; }

        public List<int> IdEpisodes { get; }

        public Series(string title, string genre, int idShowrunner, List<int> idEpisodes)
        {
            this.Title = title;
            this.Genre = genre;
            this.IdShowrunner = idShowrunner;
            this.IdEpisodes = idEpisodes;
            Id = StatId++;
        }

        public void AddEpisode(int idEpisode)
        {
            IdEpisodes.Add(idEpisode);
        }

        public override string ToString()
        {
            Bitflix bitflix = Bitflix.Instance;
            StringBuilder stringBuilder = new StringBuilder(
                $"Series: {Title}, {Genre}, {bitflix.GetAuthor(IdShowrunner).Name} " +
                $"{bitflix.GetAuthor(IdShowrunner).Surname},\n Episodes: \n");

            foreach (var episode in IdEpisodes)
            {
                var ep = bitflix.GetEpisode(episode);
                stringBuilder.Append("\t");
                stringBuilder.Append(ep);
                stringBuilder.Append("\n");
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            return stringBuilder.ToString();
        }
    }
}
