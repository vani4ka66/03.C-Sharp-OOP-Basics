namespace TheSystem.Engine.Factory
{
    using Models;
    using Interfaces;

    public class ComponentFactory : IComponentFactory
    {
        public IHardwareComponent CreatePowerHardware(string name, long capacity, long memory)
        {
            var hardware = new PowerHardwareComponent(name, capacity, memory);

            return hardware;
        }

        public IHardwareComponent CreateHeavyHardware(string name, long capacity, long memory)
        {
            var hardware = new HeavyHardwareComponent(name, capacity, memory);

            return hardware;
        }

        public ISoftwareComponent CreateLightSoftware(string name, long capacity, long memory)
        {
            var software = new LightSoftwareComponent(name, capacity, memory);

            return software;
        }

        public ISoftwareComponent CreateExpressSoftware(string name, long capacity, long memory)
        {
            var software = new ExpressSoftwareComponent(name, capacity, memory);

            return software;
        }
    }
}
