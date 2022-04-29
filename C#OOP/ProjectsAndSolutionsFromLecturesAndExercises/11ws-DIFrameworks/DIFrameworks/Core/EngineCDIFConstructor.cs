using CustomDIFramework.Attributes;
using DIFrameworks.Interfaces;

namespace DIFrameworks.Core
{
    public class EngineCDIFConstructor : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter consoleWriter;
        private readonly IWriter fileWriter;

        [Inject]
        public EngineCDIFConstructor(IReader reader, 
                                     [Named("ConsoleWriter")] 
                                     IWriter consoleWriter, 
                                     [Named("FileWriter")] 
                                     IWriter fileWriter)
        {
            this.reader = reader;
            this.consoleWriter = consoleWriter;
            this.fileWriter = fileWriter;
        }

        public void Run()
        {
            string text = this.reader.Read();
            this.consoleWriter.Write(text);
            this.fileWriter.Write(text);
        }
    }
}
