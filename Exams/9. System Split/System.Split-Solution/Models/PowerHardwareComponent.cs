namespace TheSystem.Models
{
    using TheSystem.Enum;

    public class PowerHardwareComponent : HardwareComponent
    {
        private const HardwareType Type = HardwareType.Power;

        public PowerHardwareComponent(string name, long maximumCapacity, long maximumMemory)
            : base(name, maximumCapacity, maximumMemory, Type)
        {
        }

        public override long MaximumCapacity
        {
            get
            {
                long capacity = base.MaximumCapacity - (base.MaximumCapacity * 3) / 4;
                return capacity;
            }
        }

        public override long MaximumMemory
        {
            get
            {
                long memory = base.MaximumMemory + (base.MaximumMemory * 3) / 4;
                return memory;
            }
        }
    }
}
