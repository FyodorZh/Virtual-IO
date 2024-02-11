using System;
using System.Threading.Tasks;

namespace vIO
{
    public interface IStreamReader<T> : IActor<T>
    {
        IStreamSyncReader<T>? SyncReader { get; }
        IStreamAsyncReader<T>? AsyncReader { get; }
    }
    
    public interface IStreamSyncReader<T> : IActor<T>
    {
        IStreamReader<T> Reader { get; }
        
        (bool, T?) ReadOne();
        int ReadMany(Span<T> dst);
        int Skip(int count);
    }
    
    public interface IStreamAsyncReader<T> : IActor<T>
    {
        IStreamReader<T> Reader { get; }
        
        Task<(bool, T?)> ReadOneAsync();
        Task<int> ReadMany(Span<T> dst);
        Task<int> Skip(int count);
    }
}