﻿using Serilog.Core;
using Serilog.Events;

namespace Nancy.Serilog
{
    public class ResponseLogEnricher : ILogEventEnricher
    {
        private ResponseLogData response;

        public ResponseLogEnricher(ResponseLogData response)
        {
            this.response = response;
        }
         
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var log = response;
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.RequestId), new ScalarValue(log.RequestId)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.StatusCode), new ScalarValue(log.StatusCode)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.ResponseContentType), new ScalarValue(log.ResponseContentType)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.Duration), new ScalarValue(log.Duration)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.ReasonPhrase), new ScalarValue(log.ReasonPhrase)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.ResolvedPath), new ScalarValue(log.ResolvedPath)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.RequestedPath), new ScalarValue(log.RequestedPath)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.ResponseHeaders), EnricherProps.FromDictionary(log.ResponseHeaders)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.ResponseContent), new ScalarValue(log.ResponseContent)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.ResponseContentLength), new ScalarValue(log.ResponseContentLength)));
            logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.RawResponseCookies), EnricherProps.FromCookies(log.RawResponseCookies)));
			logEvent.AddOrUpdateProperty(new LogEventProperty(nameof(log.ResponseCookies), EnricherProps.FromDictionary(log.ResponseCookies)));
		}
    }
}
