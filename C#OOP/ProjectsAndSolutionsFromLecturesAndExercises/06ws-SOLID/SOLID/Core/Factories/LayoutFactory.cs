using SOLID.Layouts;
using System;

namespace SOLID.Core.Factories
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            ILayout layout;

            if (type == nameof(SimpleLayout))
            {
                layout = new SimpleLayout();
            }
            else if (type == nameof(XmlLayout))
            {
                layout = new XmlLayout();
            }
            else if (type == nameof(JsonLayout))
            {
                layout = new JsonLayout();
            }
            else
            {
                throw new ArgumentException($"{type} is invalid Layout type!");
            }

            return layout;
        }
    }
}
