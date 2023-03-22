using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProgOb
{
    
    public sealed class Bitflix
    {
        private static Bitflix instance = null;
        
        private Dictionary<int, Author> AuthorsDict = new Dictionary<int, Author>();
        private Dictionary<int, Series> SeriesDict = new Dictionary<int, Series>();
        private Dictionary<int, Episode> EpisodesDict = new Dictionary<int, Episode>();
        private Dictionary<int,Movie> MoviesDict = new Dictionary<int, Movie>();

        private Dictionary<(string, string), int> AuthorToId = new Dictionary<(string, string), int>();
        private Dictionary<string, int> MovieToId = new Dictionary<string, int>();
        private Dictionary<string, int> SeriesToId = new Dictionary<string, int>();
        private Dictionary<(string, string), int> EpisodeToId = new Dictionary<(string, string), int>();
        private Bitflix()
        {
        }

        public static Bitflix Instance => instance ?? (instance = new Bitflix());

        public void AddAuthor(string name, string surname, int birthYear, int awards)
        {
            if (AuthorToId.ContainsKey((name, surname)))
            {
                Console.WriteLine($"Author {name} {surname} already exists Bitflix");
                return;
            }
            Author author = new Author(name, surname, birthYear, awards);
            AuthorsDict.Add(author.Id,author);
            AuthorToId.Add((author.Name,author.Surname),author.Id);
            
        }

        public void AddMovie(string title, string genre, string director, string duration, int releaseYear)
        {
            if (duration[duration.Length - 1] != 'm')
            {
                Console.WriteLine("Wrong duration format");
                return;
            }
            duration = duration.Substring(0, duration.Length - 1);
            if (!int.TryParse(duration, out var dur))
            {
                Console.WriteLine("Wrong duration format");
                return;
            }
            
            if (MovieToId.ContainsKey(title))
            {
                Console.WriteLine($"Movie {title} already exists in Bitflix");
                return;
            }

            (string name, string surname) = ParseName(director);
            if (!AuthorToId.ContainsKey((name, surname)))
            {
                Console.WriteLine($"Author {name} {surname} not found");
                return;
            }
            
            Movie movie = new Movie(title, genre, AuthorToId[(name, surname)], dur, releaseYear);
            MovieToId.Add(movie.Title, movie.Id);
            MoviesDict.Add(movie.Id, movie);
        }

        public void AddSeries(string title, string genre, string showrunner)
        {
            if (SeriesToId.ContainsKey(title))
            {
                Console.WriteLine($"Series {title} already exists in Bitflix");
                return;
            }

            (string name, string surname) = ParseName(showrunner);
            if (!AuthorToId.ContainsKey((name, surname)))
            {
                Console.WriteLine($"Author {name} {surname} not found");
                return;
            }
            
            Series series = new Series(title, genre, AuthorToId[(name, surname)], new List<int>());
            SeriesDict.Add(series.Id,series);
            SeriesToId.Add(title,series.Id);
        }

        public void AddEpisodeToSeries(string seriesTitle, string episodeTitle, int duration, int releaseYear,
            string director)
        {
            if (!SeriesToId.ContainsKey(seriesTitle))
            {
                Console.WriteLine($"Series {seriesTitle} not found");
                return;
            }
            if(EpisodeToId.ContainsKey((seriesTitle,episodeTitle)))
            {
               Console.WriteLine($"Episode {episodeTitle} already exists in {seriesTitle} series");
               return;
            }

            (string name, string surname) = ParseName(director);
            if (!AuthorToId.ContainsKey((name, surname)))
            {
                Console.WriteLine($"Author {name} {surname} not found");
                return;
            }
            
            Episode episode = new Episode(episodeTitle, duration, releaseYear, AuthorToId[(name, surname)]);
            
            SeriesDict[SeriesToId[seriesTitle]].AddEpisode(episode.Id);
            EpisodesDict.Add(episode.Id,episode);
            EpisodeToId.Add((seriesTitle,episodeTitle),episode.Id);
        }

        public Author GetAuthor(int id)
        {
            return AuthorsDict.ContainsKey(id) ? AuthorsDict[id] : null;
        }
        public Author GetAuthor(string auth)
        {
            (string name, string surname) = ParseName(auth);
            if (!AuthorToId.ContainsKey((name, surname)))
            {
                Console.WriteLine($"Author {name} {surname} not found");
                return null;
            }

            return AuthorsDict[AuthorToId[(name, surname)]];
        }

        public Episode GetEpisode(int id)
        {
            return EpisodesDict.ContainsKey(id) ? EpisodesDict[id] : null;
        }
        
        public Episode GetEpisode(string seriesTitle, string episodeTitle)
        {
            if (!EpisodeToId.ContainsKey((seriesTitle, episodeTitle)))
            {
                Console.WriteLine($"Episode {episodeTitle} not found in {seriesTitle}");
                return null;
            }

            return EpisodesDict[EpisodeToId[(seriesTitle, episodeTitle)]];
        }

        public Movie GetMovie(int id)
        {
            return MoviesDict.ContainsKey(id) ? MoviesDict[id] : null;
        }
        
        public Movie GetMovie(string title)
        {
            if (!MovieToId.ContainsKey(title))
            {
                Console.WriteLine($"Movie {title} not found");
                return null;
            }

            return MoviesDict[MovieToId[title]];
        }
        
        public Series GetSeries(int id)
        {
            return SeriesDict.ContainsKey(id) ? SeriesDict[id] : null;
        }
        
        public Series GetSeries(string title)
        {
            if (!SeriesToId.ContainsKey(title))
            {
                Console.WriteLine($"Series {title} not found");
                return null;
            }

            return SeriesDict[SeriesToId[title]];
        }

        private (string name, string surname) ParseName(string director)
        {
            string[] names = director.Split(' ');
            if (names.Length < 2)
            {
                Console.WriteLine("Wrong director name");
                return (null, null);
            }

            string name = names[0];
            StringBuilder surnameBuild = new StringBuilder(director.Length);
            if (names.Length >= 2)
            {
                int n = names.Length;
                for (int i = 1; i < n; i++)
                {
                    surnameBuild.Append(names[i]);
                    if (i != n - 1)
                        surnameBuild.Append(' ');
                }
            }

            string surname = surnameBuild.ToString();
            return (name, surname);
        }
    }
}