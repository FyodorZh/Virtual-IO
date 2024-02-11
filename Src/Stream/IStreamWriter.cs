using System;
using System.Threading.Tasks;

namespace vIO
{
    public interface IStreamWriter<T> : IActor<T>
    {
        IStreamSyncWriter<T>? SyncWriter { get; }
        IStreamAsyncWriter<T>? AsyncWriter { get; }
    }
    
    public interface IStreamSyncWriter<T> : IActor<T>
    {
        IStreamWriter<T> Writer { get; }
        bool WriteOne(T value);
        int WriteMany(Span<T> values);
    }
    
    public interface IStreamAsyncWriter<T> : IActor<T>
    {
        IStreamWriter<T> Writer { get; }
        Task<bool> WriteOne(T value);
        Task<int> WriteMany(Span<T> values);
    }
}