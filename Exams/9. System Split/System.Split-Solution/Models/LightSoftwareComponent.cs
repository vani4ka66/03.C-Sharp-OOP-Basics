using TheSystem.Enum;

namespace TheSystem.Models
{
    public class LightSoftwareComponent : SoftwareComponent
    {
        private const SoftwareType Type = SoftwareType.Light;

        public LightSoftwareComponent(string name, long capacityConsumption, long memoryConsumption)
            : base(name, capacityConsumption, memoryConsumption, Type)
        {
        }

        public override long CapacityConsumption
        {
            get
            {
                long capacity = base.CapacityConsumption + (base.CapacityConsumption * 1) / 2;
                return capacity;
            }
        }

        public override long MemoryConsuption
        {
            get
            {
                long memory = base.MemoryConsuption - (base.MemoryConsuption * 1) / 2;
                return memory;
            }
        }
    }
}
