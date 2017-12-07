namespace TheSystem.Models
{
    using Enum;

    public class ExpressSoftwareComponent : SoftwareComponent
    {
        private const SoftwareType Type = SoftwareType.Express;

        public ExpressSoftwareComponent(string name, long capacityConsumption, long memoryConsumption)
            : base(name, capacityConsumption, memoryConsumption, Type)
        {
        }

        public override long MemoryConsuption
        {
            get
            {
                return base.MemoryConsuption * 2;
            }
        }
    }
}
