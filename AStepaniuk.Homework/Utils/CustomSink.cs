using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Configuration;

namespace AStepaniuk.Homework.Utils
{
    class CustomSink : ILogEventSink
    {
        private readonly IFormatProvider _formatProvider;

        public CustomSink(IFormatProvider formatProvider)
        {
            _formatProvider = formatProvider;
        }

        public void Emit(LogEvent logEvent)
        {
            var message = logEvent.RenderMessage(_formatProvider);
            Console.WriteLine(DateTimeOffset.Now.ToString() + " " + message);
        }

        public static class CustomSinkExtensions
        {
            public static LoggerConfiguration CustomSink(
                      this LoggerSinkConfiguration loggerConfiguration,
                      IFormatProvider formatProvider = null)
            {
                return loggerConfiguration.Sink(new CustomSink(formatProvider));
            }
        }
    }
}
