﻿using Serilog.Events;

public static class LogEventExtensions
{
    public static string Value(this LogEvent logEvent, string property)
    {
        return (string)((ScalarValue)logEvent.Properties[property].Value).Value;
    }
}