using System;
using System.Threading.Tasks;

namespace vIO
{
    public class StreamSyncToAsyncReader<T> : IStreamAsyncReader<T>
    {
        private readonly IStreamSyncReader<T> _reader;
        
        public StreamSyncToAsyncReader(IStreamSyncReader<T> reader)
        {
            _reader = reader;
        }

        public bool IsValid => _reader.IsValid;

        public IStreamReader<T> Reader => _reader.Reader;
        
        public Task<(bool, T?)> ReadOneAsync()
        {
            return Task.FromResult(_reader.ReadOne());
        }

        public Task<int> ReadMany(Span<T> dst)
        {
            return Task.FromResult(_reader.ReadMany(dst));
        }

        public Task<int> Skip(int count)
        {
            return Task.FromResult(_reader.Skip(count));
        }
    }
}