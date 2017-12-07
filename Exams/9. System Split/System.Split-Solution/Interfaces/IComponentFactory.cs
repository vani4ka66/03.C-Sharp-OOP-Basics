namespace TheSystem.Interfaces
{
    public interface IComponentFactory
    {
        IHardwareComponent CreatePowerHardware(string name, long capacity, long memory);

        IHardwareComponent CreateHeavyHardware(string name, long capacity, long memory);

        ISoftwareComponent CreateLightSoftware(string name, long capacity, long memory);

        ISoftwareComponent CreateExpressSoftware(string name, long capacity, long memory);
    }
}
