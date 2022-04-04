using SOLID.Core;
using SOLID.Core.Factories;
using SOLID.Core.IO;

namespace SOLID
{
    public class StartUp
    {
        public static void Main()
        {
            IAppenderFactory appenderFactory = new AppenderFactory();
            ILayoutFactory layoutFactory = new LayoutFactory();
            IReader reader = new FileReader("../../../input.txt");

            IEngine engine = new Engine(appenderFactory, layoutFactory, reader);

            engine.Run();
        }
    }
}
