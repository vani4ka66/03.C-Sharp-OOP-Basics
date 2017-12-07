namespace TheSystem.Interfaces
{
    using System.Collections.Generic;
    using Enum;

    public interface IHardwareComponent
    {
        string Name { get; }

        HardwareType Type { get; }

        long MaximumCapacity { get; }

        long MaximumMemory { get; }

        long FreeCapacity { get; }

        long FreeMemory { get; }

        long UsedCapacity { get; }

        long UsedMemory { get; }

        IDictionary<string ,ISoftwareComponent> SoftwaresComponents { get; }

        void AddSoftwareComponent(ISoftwareComponent component);

        void RemoveSoftwareComponent(string componentName);

        string GetHardwareInfo();

        int GetSoftwareComponentsCount();
    }
}
