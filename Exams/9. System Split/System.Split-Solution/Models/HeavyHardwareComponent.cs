namespace TheSystem.Models
{
    using Enum;

    public class HeavyHardwareComponent : HardwareComponent
    {
        private const HardwareType Type = HardwareType.Heavy;

        public HeavyHardwareComponent(string name, long maximumCapacity, long maximumMemory)
            : base(name, maximumCapacity, maximumMemory, Type)
        {
        }

        public override long MaximumCapacity
        {
            get
            {
                return base.MaximumCapacity * 2;
            }
        }

        public override long MaximumMemory
        {
            get
            {
                long memory = base.MaximumMemory - (base.MaximumMemory * 1) / 4;
                return memory;
            }
        }
    }
}
