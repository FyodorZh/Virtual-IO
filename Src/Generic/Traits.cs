namespace vIO
{
    public enum RWA
    {
        Readable,
        Writable,
        Appendable
    }
    public interface IRWATrait
    {
        RWA RwaTrait { get; }
    }

    public interface IWritable : IRWATrait
    {
        RWA IRWATrait.RwaTrait => RWA.Writable;
    }
    public interface IReadable : IRWATrait
    {
        RWA IRWATrait.RwaTrait => RWA.Writable;
    }
    public interface IAppendable : IRWATrait
    {
        RWA IRWATrait.RwaTrait => RWA.Appendable;
    }

    public interface ISync {}
    public interface IAsync {}
    
    public interface IThreadSafe : IThreadUnsafe {}
    public interface IThreadUnsafe {}
}