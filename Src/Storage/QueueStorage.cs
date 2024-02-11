using System;
using System.Collections.Generic;
using vIO.Storage;

namespace vIO
{
    public abstract class Storage<T> : IStorage
    {
        public abstract bool IsValid { get; }
        public abstract int Size { get; }
    }

    public class QueueStorage<T> : Storage<T>, IReadableStorage<T>, IAppendableStorage<T>
    {
        private readonly Queue<T> _queue = new Queue<T>();

        public override bool IsValid => true;

        public override int Size => _queue.Count;

        IStreamReader<T> IReadableStorage<T>.BeginRead()
        {
            return new Reader(this);
        }

        IStreamWriter<T> IAppendableStorage<T>.BeginAppend()
        {
            return new Appender(this);
        }

        private class QueueReader : IStreamReader<T>, IStreamSyncReader<T>
        {
            private readonly QueueStorage<T> _owner;
            
            public QueueReader(QueueStorage<T> owner)
            {
                _owner = owner;
            }

            public bool IsValid => _owner.IsValid;
            
            public IStreamSyncReader<T>? SyncReader { get; }
            public IStreamAsyncReader<T>? AsyncReader { get; }
            public IStreamReader<T> Reader => this;
            public (bool, T?) ReadOne()
            {
                throw new NotImplementedException();
            }

            public int ReadMany(Span<T> dst)
            {
                throw new NotImplementedException();
            }

            public int Skip(int count)
            {
                throw new NotImplementedException();
            }
        }

        private class Appender : IStreamWriter<T>
        {
            private readonly QueueStorage<T> _owner;
            public Appender(QueueStorage<T> owner)
            {
                _owner = owner;
            }

            public bool IsValid => _owner.IsValid;
            
            public IStreamSyncWriter<T>? SyncWriter { get; }
            public IStreamAsyncWriter<T>? AsyncWriter { get; }
        }
    }
}