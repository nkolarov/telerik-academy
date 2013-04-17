using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamingIdentifiers
{
    public class Score
    {
        private string name;
        private int points;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
            }
        }

        public Score()
        {
        }

        public Score(string name, int points)
        {
            this.name = name;
            this.points = points;
        }
    }
}