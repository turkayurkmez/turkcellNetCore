namespace LifeCycleOfDI.Models
{
    public interface IGuidGenerator
    {
        Guid Guid { get; }
    }

    public interface ISingletonGuid : IGuidGenerator
    {

    }

    public interface IScopedGuid : IGuidGenerator
    {

    }

    public interface ITransientGuid : IGuidGenerator
    {

    }


    public class SingletonGuid : ISingletonGuid
    {
        public SingletonGuid()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }

    public class ScopedGuid : IScopedGuid
    {
        public ScopedGuid()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }

    public class TransientGuid : ITransientGuid
    {
        public TransientGuid()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }
}
