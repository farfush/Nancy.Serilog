﻿using Serilog.Core;
using Serilog.Events;

namespace Nancy.Serilog
{
    public class RequestLogEnricher : ILogEventEnricher
    {
        private RequestLogData request;

        public RequestLogEnricher(RequestLogData request)
        {
            this.request = request;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var log = request;

            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.RequestId), new ScalarValue(log.RequestId)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.Method), new ScalarValue(log.Method)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.Path), new ScalarValue(log.Path)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.QueryString), new ScalarValue(log.QueryString)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.RequestHostName), new ScalarValue(log.RequestHostName)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.RequestContentLength), new ScalarValue(log.RequestContentLength)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.RequestContentType), new ScalarValue(log.RequestContentType)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.RequestBodyContent), new ScalarValue(log.RequestBodyContent)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.UserIPAddress), new ScalarValue(log.UserIPAddress)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.RequestHeaders), EnricherProps.FromDictionary(log.RequestHeaders)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.Query), EnricherProps.FromDictionary(log.Query)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.RequestCookies), EnricherProps.FromDictionary(log.RequestCookies)));
        }





    }
}
