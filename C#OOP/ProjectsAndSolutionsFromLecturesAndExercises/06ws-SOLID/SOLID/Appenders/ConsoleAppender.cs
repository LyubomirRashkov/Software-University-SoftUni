using SOLID.Enums;
using SOLID.Layouts;
using System;

namespace SOLID.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (!this.CanAppend(reportLevel))
            {
                return;    //т.е. не прави нищо
            }

            string content = string.Format(this.layout.Template, date, reportLevel, message);

            Console.WriteLine(content);

            this.MessagesCount++;
        }
    }
}
