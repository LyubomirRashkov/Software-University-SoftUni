using DIFrameworks.Interfaces;

namespace DIFrameworks.Core
{
    public class EngineMEDI : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter consoleWriter;
        private readonly IWriter fileWriter;

        public EngineMEDI(IReader reader, IConsoleWriter consoleWriter, IFileWriter fileWriter)
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
