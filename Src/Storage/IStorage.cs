namespace vIO.Storage
{
    public interface IStorage 
    {
        bool IsValid { get; }
        int Size { get; }
    }

    public interface IReadableStorage<T> : IStorage
    {
        IStreamReader<T> BeginRead();
    }

    public interface IWritableStorage<T> : IStorage
    {
        IStreamOverWriter<T> BeginOverWrite();
    }

    public interface IAppendableStorage<T> : IStorage
    {
        IStreamWriter<T> BeginAppend();
    }
}