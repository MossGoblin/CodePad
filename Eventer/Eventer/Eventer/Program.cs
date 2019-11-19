using System;
using System.Linq.Expressions;

namespace Eventer
{
    class Program
    {
        static void Main(string[] args)
        {
            var sbj = New<Subject>.Instance();
            Console.WriteLine(sbj.ToString());

            Publisher pbl = new Publisher();
            string result = pbl.GetSbjString(sbj, "TESTING");
            Console.WriteLine(result);
        }
    }

    public class New<T>
        where T : class
    {
        public static Func<T> Instance = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();
    }
}
