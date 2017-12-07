namespace TheSystem.IO
{
    using System;
    using Interfaces;

    public class OutputWriter : IOutputWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
