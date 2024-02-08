using System;
using System.Threading.Tasks;

namespace vIO
{
    public interface IStreamCore
    {
        System.IObservable<bool> IsValid { get; }
    }

    public interface IStreamReader<T>
    {
        (bool, T?) ReadOne();
        Task<(bool, T?)> ReadOneAsync();
        int ReadN(Span<T> dst, int from, int count);
    }
}