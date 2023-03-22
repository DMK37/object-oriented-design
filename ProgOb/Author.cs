using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgOb
{
    public class Author
    {
        private static int StatId = 0;
        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public int BirthYear { get; }
        public int Awards { get; }


        public Author(string name, string surname, int birthYear, int awards)
        {
            this.Name = name;
            this.Surname = surname;
            this.BirthYear = birthYear;
            this.Awards = awards;
            Id = StatId++;
        }

        public override string ToString()
        {
            return $"Author: {Name} {Surname}, {BirthYear}, {Awards}";
        }
    }
}
