using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProgOb
{
    class Program
    {
        public static void Main(string[] args)
        {
            Bitflix bitflix = Bitflix.Instance;
            
            bitflix.AddAuthor("Francis", "Coppola", 1939, 32);
            bitflix.AddAuthor("Steven", "Spielberg", 1956, 73);
            bitflix.AddAuthor("Charlie", "Chaplin", 1889, 6);
            bitflix.AddAuthor("Vince", "Gilligan", 1967, 17);
            bitflix.AddAuthor("Rian", "Johnson", 1973, 29);
            bitflix.AddAuthor("Greg", "Daniels", 1963, 5);
            bitflix.AddAuthor("Troy", "Miller", 1960, 0);
            bitflix.AddAuthor("Victor", "Nelli, Jr.", 1960, 0);
            bitflix.AddAuthor("Charles", "McDougall", 1960, 0);
            
            
            bitflix.AddMovie("Apocalypse now", "war film", "Francis Coppola", "147m", 1979);
            bitflix.AddMovie("The Godfather", "criminal", "Francis Coppola", "175m", 1972);
            bitflix.AddMovie("Raiders of the lost ark", "adventure", "Steven Spielberg", "115m", 1981);
            bitflix.AddMovie("The Great Dictator", "comedy", "Charlie Chaplin", "125m", 1940);
            
            bitflix.AddSeries("Breaking Bad", "drama", "Vince Gilligan");
            bitflix.AddEpisodeToSeries("Breaking Bad", "Fly", 45, 2010, "Rian Johnson");
            bitflix.AddEpisodeToSeries("Breaking Bad", "Ozymandias", 50, 2013, "Rian Johnson");
            bitflix.AddEpisodeToSeries("Breaking Bad","Pilot", 43, 2008, "Vince Gilligan");
            
            bitflix.AddSeries("The Office US", "horror", "Greg Daniels");
            bitflix.AddEpisodeToSeries("The Office US","Dwight K. Schrute, (Acting) Manager", 22, 2011,"Troy Miller");
            bitflix.AddEpisodeToSeries("The Office US","The Carpet", 23, 2006, "Victor Nelli, Jr.");
            bitflix.AddEpisodeToSeries("The Office US","Dwight's Speech", 22, 2006, "Charles McDougall");
            
            Console.WriteLine(bitflix.GetSeries("Breaking Bad"));
            Console.WriteLine(bitflix.GetSeries("The Office US"));
        }
    }
}


