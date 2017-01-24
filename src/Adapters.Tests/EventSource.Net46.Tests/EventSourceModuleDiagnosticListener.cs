﻿//-----------------------------------------------------------------------
// <copyright file="EventSourceModuleDiagnosticListener.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ApplicationInsights.EventSourceListener.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Tracing;

    internal class EventSourceModuleDiagnosticListener : EventListener
    {
        public EventSourceModuleDiagnosticListener()
        {
            this.EventsReceived = new List<string>();
        }

        public IList<string> EventsReceived { get; private set; }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            this.EventsReceived.Add(eventData.EventName);
        }

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource.Name == "Microsoft-ApplicationInsights-Extensibility-EventSourceListener")
            {
                EnableEvents(eventSource, EventLevel.LogAlways);
            }
        }
    }
}