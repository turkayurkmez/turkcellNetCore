namespace LifeCycleOfDI.Models
{
    public class GuidService
    {
        public ISingletonGuid SingletonGuid { get; set; }
        public IScopedGuid ScopedGuid { get; set; }
        public ITransientGuid TransientGuid { get; set; }

        public GuidService(ISingletonGuid singletonGuid, IScopedGuid scopedGuid, ITransientGuid transientGuid)
        {
            SingletonGuid = singletonGuid ?? throw new ArgumentNullException(nameof(singletonGuid));
            ScopedGuid = scopedGuid ?? throw new ArgumentNullException(nameof(scopedGuid));
            TransientGuid = transientGuid ?? throw new ArgumentNullException(nameof(transientGuid));
        }


    }
}
