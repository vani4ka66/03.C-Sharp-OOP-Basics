namespace TheSystem.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;
    using IO;
    using Factory;
    using Enum;

    public class SystemEngine : ISystemEngine
    {
        private HashSet<IHardwareComponent> hardwareComponents;
        private IComponentFactory factory;
        private IOutputWriter writer;
        private IInputReader reader;

        public SystemEngine()
        {
            this.hardwareComponents = new HashSet<IHardwareComponent>();
            this.factory = new ComponentFactory();
            this.writer = new OutputWriter();
            this.reader = new InputReader();
        }

        public void Run()
        {
            string line = this.reader.Read();

            while (line != "System Split")
            {
                var commandArgs = ParseCommand(line);
                ExecuteCommand(commandArgs);
                         
                line = this.reader.Read();
            }

            SplitTheSystem();
        }

        private void SplitTheSystem()
        {
            var powerHardwares = this.hardwareComponents.Where(c => c.Type == HardwareType.Power);
            foreach (var component in powerHardwares)
            {
                writer.Write(component.ToString());
            }

            var heavyHardwares = this.hardwareComponents.Where(c => c.Type == HardwareType.Heavy);
            foreach (var component in heavyHardwares)
            {
                writer.Write(component.ToString());
            }
        }

        private void ExecuteCommand(List<string> commandArgs)
        {
            string commandName = commandArgs[0];

            switch (commandName)
            {
                case "RegisterPowerHardware":
                    string powerHardwareName = commandArgs[1];
                    long powerHardwareCapacity = long.Parse(commandArgs[2]);
                    long powerHardwareMemory = long.Parse(commandArgs[3]);
                    var powerHardware = factory.CreatePowerHardware(powerHardwareName, powerHardwareCapacity, powerHardwareMemory);
                    this.hardwareComponents.Add(powerHardware);
                    break;
                case "RegisterHeavyHardware":
                    string heavyHardwareName = commandArgs[1];
                    long heavyHardwareCapacity = long.Parse(commandArgs[2]);
                    long heavyHardwareMemory = long.Parse(commandArgs[3]);
                    var heavyHardware = factory.CreateHeavyHardware(heavyHardwareName, heavyHardwareCapacity, heavyHardwareMemory);
                    this.hardwareComponents.Add(heavyHardware);
                    break;
                case "RegisterExpressSoftware":                   
                    string expressSoftwareName = commandArgs[2];
                    long expressSoftwareCapacity = long.Parse(commandArgs[3]);
                    long expressSoftwareMemory = long.Parse(commandArgs[4]);
                    var expressSoftware = factory.CreateExpressSoftware(expressSoftwareName, expressSoftwareCapacity, expressSoftwareMemory);
                    AddSoftwareToCurrentHardware(expressSoftware, commandArgs[1]);                    
                    break;
                case "RegisterLightSoftware":                
                    string lightSoftwareName = commandArgs[2];
                    long lightSoftwareCapacity = long.Parse(commandArgs[3]);
                    long loightSoftwareMemory = long.Parse(commandArgs[4]);
                    var lightSoftware = factory.CreateExpressSoftware(lightSoftwareName, lightSoftwareCapacity, loightSoftwareMemory);
                    AddSoftwareToCurrentHardware(lightSoftware, commandArgs[1]);
                    break;
                case "ReleaseSoftwareComponent":
                    string hardwareName = commandArgs[1];
                    string softwareName = commandArgs[2];
                    ReleaseSoftware(hardwareName, softwareName);
                    break;
                case "Analyze":
                    string info = GetHardwareInfo();
                    writer.Write(info);
                    break;
                default:
                    break;
            }
        }

        private string GetHardwareInfo()
        {
            int hardwareComponentsCount = this.hardwareComponents.Count;
            int softwareComponentsCount = 0;
            long totalMemoryInUse = 0;
            long totalMemory = 0;
            long totalCpacityInUse = 0;
            long totalCapcity = 0;
            foreach (var component in this.hardwareComponents)
            {
                softwareComponentsCount += component.GetSoftwareComponentsCount();
                totalMemoryInUse += component.UsedMemory;
                totalMemory += component.MaximumMemory;
                totalCpacityInUse += component.UsedCapacity;
                totalCapcity += component.MaximumCapacity;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("System Analysis");
            sb.AppendFormat("Hardware Components: {0}", hardwareComponentsCount).AppendLine();
            sb.AppendFormat("Software Components: {0}", softwareComponentsCount).AppendLine();
            sb.AppendFormat("Total Operational Memory: {0} / {1}", totalMemoryInUse, totalMemory).AppendLine();
            sb.AppendFormat("Total Capacity Taken: {0} / {1}", totalCpacityInUse, totalCapcity);

            return sb.ToString();
        }

        private void ReleaseSoftware(string hardwareName, string softwareName)
        {
            var hardware = this.hardwareComponents.Where(c => c.Name == hardwareName).FirstOrDefault();
            if (hardware != null)
            {
                hardware.RemoveSoftwareComponent(softwareName);
            }
        }

        private void AddSoftwareToCurrentHardware(ISoftwareComponent expressSoftware, string hardwareName)
        {
            var hardwareComponent = this.hardwareComponents.Where(c => c.Name == hardwareName).FirstOrDefault();
            if (hardwareComponent != null)
            {
                hardwareComponent.AddSoftwareComponent(expressSoftware);
            }
            
        }

        private List<string> ParseCommand(string command)
        {
            var commandArgs = new List<string>();
            int separatorIndex = command.IndexOf('(');

            string commandName = command.Substring(0, separatorIndex);
            commandArgs.Add(commandName);

            command = command.Remove(command.Length - 1);
            if (separatorIndex + 1 >= command.Length)
            {
                return commandArgs;
            }
            command = command.Substring(separatorIndex + 1);

            commandArgs.AddRange(command.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList());

            return commandArgs;
        }
    }
}