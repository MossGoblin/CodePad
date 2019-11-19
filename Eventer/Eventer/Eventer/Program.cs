using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Eventer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Subject> sbjList = new List<Subject>();
            //var sbj = New<Subject>.Instance();
            //Console.WriteLine(sbj.ToString());

            //Publisher pbl = new Publisher();
            //string result = pbl.GetSbjString(sbj, "TESTING");
            //Console.WriteLine(result);

            Random rnd = new Random();
            Publisher pbl = new Publisher();

            for (int count = 0; count < 10; count++)
            {
                Subject newSubject = pbl.GenNewSbj(rnd.Next());
                sbjList.Add(newSubject);
                Console.WriteLine(newSubject.ToString());
            }

            foreach (Subject sbj in sbjList)
            {
                Console.WriteLine(pbl.GetSbjString(sbj, "Acounted for: "));
            }


        }
    }

    public class New<T>
        where T : class
    {
        public static Func<T> Instance = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();
    }
}
