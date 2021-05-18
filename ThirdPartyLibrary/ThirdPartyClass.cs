using System;
using CoreLib;

namespace ThirdPartyLibrary
{
    public class MyCollection<T> : IMyReadOnlyCollection<T>, IMyCollection<T>
    {
        int IMyReadOnlyCollection<T>.Count => 42;
        int IMyCollection<T>.Count => 42;

#if IS_DIM_ADDED_TO_NUGET_LIBRARY
        bool IMyEnumerable<T>.TryGetNonEnumeratedCount(out int count)
        {
            count = 42;
            return true;
        }
#endif
    }
}
