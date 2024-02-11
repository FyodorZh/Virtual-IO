using System;
using System.Threading.Tasks;

namespace vIO
{
    public class StreamSyncToAsyncWriter<T> : IStreamAsyncWriter<T>
    {
        private readonly IStreamSyncWriter<T> _writer;
        
        public StreamSyncToAsyncWriter(IStreamSyncWriter<T> writer)
        {
            _writer = writer;
        }

        public bool IsValid => _writer.IsValid;

        public IStreamWriter<T> Writer => _writer.Writer;
        
        public Task<bool> WriteOne(T value)
        {
            return Task.FromResult(_writer.WriteOne(value));
        }

        public Task<int> WriteMany(Span<T> values)
        {
            return Task.FromResult(_writer.WriteMany(values));
        }
    }
}