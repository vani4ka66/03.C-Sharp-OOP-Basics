namespace TheSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;
    using Enum;

    public abstract class HardwareComponent : IHardwareComponent
    {
        private string name;
        private long maximumCapacity;
        private long maximumMemory;
        private HardwareType type;
        private IDictionary<string, ISoftwareComponent> softwareComponents;

        protected HardwareComponent(string name, long maximumCapacity, long maximumMemory, HardwareType type)
        {
            this.Name = name;
            this.MaximumCapacity = maximumCapacity;
            this.MaximumMemory = maximumMemory;
            this.Type = type;
            softwareComponents = new Dictionary<string, ISoftwareComponent>();
        }

        public string Name { get; private set; }

        public virtual long MaximumCapacity { get; private set; }

        public virtual long MaximumMemory { get; private set; }

        public IDictionary<string, ISoftwareComponent> SoftwaresComponents
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public HardwareType Type { get; private set; }

        public long UsedCapacity { get; private set; }

        public long UsedMemory { get; private set; }

        public long FreeCapacity
        {
            get { return this.MaximumCapacity - this.UsedCapacity; }
        }

        public long FreeMemory
        {
            get { return this.MaximumMemory - this.UsedMemory; }
        }
        
        public void AddSoftwareComponent(ISoftwareComponent component)
        {
            bool hasEnoughSpace = component.MemoryConsuption <= this.FreeMemory &&
                component.CapacityConsumption <= this.FreeCapacity;

            string componentName = component.Name;
            if (!this.softwareComponents.ContainsKey(componentName) && hasEnoughSpace)
            {
                this.softwareComponents.Add(componentName, component);
                this.UsedCapacity += component.CapacityConsumption;
                this.UsedMemory += component.MemoryConsuption;
            }
        }

        public void RemoveSoftwareComponent(string componentName)
        {
            if (this.softwareComponents.ContainsKey(componentName))
            {
                var component = this.softwareComponents[componentName];
                this.UsedCapacity -= component.CapacityConsumption;
                this.UsedMemory -= component.MemoryConsuption;
                this.softwareComponents.Remove(componentName);
            }
        }

        public int GetSoftwareComponentsCount()
        {
            return this.softwareComponents.Count;
        }

        public string GetHardwareInfo()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            int expressSoftwareComponentsCount = this.softwareComponents
                .Where(c => c.Value.Type == SoftwareType.Express)
                .Count();
            int lightSoftwareComponentsCount = this.softwareComponents
                .Where(c => c.Value.Type == SoftwareType.Light)
                .Count();
            string softwareComponentsList = string.Join(", ", this.softwareComponents.Keys);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Hardware Component - {0}{1}", 
                this.Name, Environment.NewLine);
            sb.AppendFormat("Express Software Components - {0}{1}", 
                expressSoftwareComponentsCount, Environment.NewLine);
            sb.AppendFormat("Light Software Components - {0}{1}",
                lightSoftwareComponentsCount, Environment.NewLine);
            sb.AppendFormat("Memory Usage: {0} / {1}{2}", 
                this.UsedMemory, this.MaximumMemory, Environment.NewLine);
            sb.AppendFormat("Capacity Usage: {0} / {1}{2}", 
                this.UsedCapacity, this.MaximumCapacity, Environment.NewLine);
            sb.AppendFormat("Type: {0}{1}", 
                this.Type.ToString(), Environment.NewLine);
            sb.AppendFormat("Software Components: {0}",
                expressSoftwareComponentsCount + lightSoftwareComponentsCount == 0 ? "None" : softwareComponentsList);

            return sb.ToString();
        }
    }
}