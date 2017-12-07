namespace TheSystem.Models
{
    using Interfaces;
    using Enum;
    using System;

    public abstract class SoftwareComponent :  ISoftwareComponent
    {
        private long capacityConsumption;
        private long memoryConsumption;
        private SoftwareType type;

        protected SoftwareComponent(string name, long capacityConsumption, long memoryConsumption, SoftwareType type)
        {
            this.Name = name;
            this.CapacityConsumption = capacityConsumption;
            this.MemoryConsuption = memoryConsumption;
            this.Type = type;
        }

        public string Name { get; private set; }

        public virtual long CapacityConsumption { get; private set; }

        public virtual long MemoryConsuption { get; private set; }       

        public SoftwareType Type { get; private set; }
    }
}
