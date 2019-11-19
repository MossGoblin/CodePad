using System;
using System.Collections.Generic;
using System.Text;

namespace Eventer
{
    public class Subject
    {
        public int ID { get; private set; }

        public string Name { get; private set; }

        public Subject()
        {
            this.ID = 0;
            GenerateName();
        }
        public Subject(int ID)
        {
            this.ID = ID;
            GenerateName();
        }

        private void GenerateName()
        {
            System.Random rnd = new Random(ID);
            Name = rnd.Next().ToString();
        }

        public string GetNbrs(List<Subject> nbrs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Subject nbr in nbrs)
            {
                sb.AppendLine(nbr.ToString());
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return ($"{Name} : {ID}");
        }
    }
}
