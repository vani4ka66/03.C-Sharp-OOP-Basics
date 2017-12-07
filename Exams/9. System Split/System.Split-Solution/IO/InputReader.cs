namespace TheSystem.IO
{
    using System;
    using Interfaces;

    public class InputReader : IInputReader
    {
        public string Read()
        {
            string input = Console.ReadLine();

            return input;
        }
    }
}
