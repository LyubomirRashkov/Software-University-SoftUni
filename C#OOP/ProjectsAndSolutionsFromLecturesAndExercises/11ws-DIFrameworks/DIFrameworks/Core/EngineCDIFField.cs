using CustomDIFramework.Attributes;
using DIFrameworks.Interfaces;

namespace DIFrameworks.Core
{
    public class EngineCDIFField : IEngine
    {
        [Inject]
        private readonly IReader reader;

        [Inject]
        [Named("ConsoleWriter")]
        private readonly IWriter consoleWriter;

        [Inject]
        [Named("FileWriter")]
        private readonly IWriter fileWriter;

        public void Run()
        {
            string text = this.reader.Read();
            this.consoleWriter.Write(text);
            this.fileWriter.Write(text);
        }
    }
}
