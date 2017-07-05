using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.ConsoleClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press a key to get response...");
            Console.ReadKey(false);

            ConsumeEventSync objSync = new ConsumeEventSync();
            objSync.GetAllCategories();

            Console.ReadKey(false);
        }
    }
}
