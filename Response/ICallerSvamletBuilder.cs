﻿using System;
using Sinch.Callback.Request;

namespace Sinch.Callback.Response
{
    public interface ICallerSvamletBuilder<out T> : ISvamletBuilder<T>
    {
        ISvamletResponse ConnectPstn(string destination, TimeSpan bridgedTimeout, string callerId = null, bool suppressCallbacks = false, TimeSpan? dialTimeout = null);
        ISvamletResponse ConnectMxp(string userName, string callerId = null);
        ISvamletResponse ConnectMxp(IIdentity identity, string callerId = null);
        ISvamletResponse ConnectConference(string conferenceId);
        ISvamletResponse Park(string holdPrompt, TimeSpan timeout);
    }
}