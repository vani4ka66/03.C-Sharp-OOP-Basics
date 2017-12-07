namespace TheSystem.Interfaces
{
    using Enum;

    public interface ISoftwareComponent
    {
        string Name { get; }

        SoftwareType Type { get; }

        long CapacityConsumption { get; }

        long MemoryConsuption { get; }
    }
}