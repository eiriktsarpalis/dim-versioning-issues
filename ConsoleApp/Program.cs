using System;
using CoreLib;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
#if IS_DIM_ADDED
            IMyEnumerable<int> instance = new ThirdPartyLibrary.MyCollection<int>();
            Console.WriteLine(instance.TryGetNonEnumeratedCount(out int count));
#else
            IMyCollection<int> instance = new ThirdPartyLibrary.MyCollection<int>();
            Console.WriteLine(instance.Count);
#endif
        }
    }
}
