using System;

namespace CoreLib
{
    public interface IMyEnumerable<T>
    {
#if IS_DIM_ADDED
        bool TryGetNonEnumeratedCount(out int count)
        {
            count = 0;
            return false;
        }
#endif
    }

    public interface IMyReadOnlyCollection<T> : IMyEnumerable<T>
    {
        int Count { get; }

#if IS_DIM_ADDED
        bool IMyEnumerable<T>.TryGetNonEnumeratedCount(out int count)
        {
            count = Count;
            return true;
        }
#endif
    }

    public interface IMyCollection<T> : IMyEnumerable<T>
    {
        int Count { get; }

#if IS_DIM_ADDED
        bool IMyEnumerable<T>.TryGetNonEnumeratedCount(out int count)
        {
            count = Count;
            return true;
        }
#endif
    }
}
