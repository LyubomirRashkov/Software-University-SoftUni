using SOLID.Enums;
using SOLID.Layouts;

namespace SOLID.Appenders
{
    public abstract class Appender : IAppender
    {
        protected readonly ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        protected int MessagesCount { get; set; }

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string date, ReportLevel reportLevel, string message);

        protected bool CanAppend(ReportLevel reportLevel) => reportLevel >= this.ReportLevel;

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesCount}";
        }
    }
}
