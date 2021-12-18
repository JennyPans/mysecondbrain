using System;
using System.Linq;

namespace MySecondBrain.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TestInfrastructure();
        }

        private static void TestInfrastructure()
        {
            using (MySecondBrain.Infrastructure.DB.MySecondBrainContext db = new Infrastructure.DB.MySecondBrainContext())
            {
                var tags = db.Tag.ToList();
                foreach (var tag in tags)
                {
                    Console.WriteLine(tag.Name);
                }
            }
        }
    }
}
