﻿using System;
using System.Collections.Generic;

namespace Sinch.Callback.Response.Internal
{
    internal class Menu<T> : AbstractMenu, IMenu<T>
    {
        private readonly T _builder;

        public IDictionary<Dtmf,Tuple<string,IDictionary<string,string>>> GotoMenuOptions { get; private set; }
        public IDictionary<Dtmf,string> ReturnOptions { get; private set; }

        internal Menu(T builder, string prompt, string repeatPrompt, int repeats)
            : base(prompt, repeatPrompt, repeats)
        {
            _builder = builder;

            GotoMenuOptions = new Dictionary<Dtmf, Tuple<string, IDictionary<string, string>>>();
            ReturnOptions = new Dictionary<Dtmf, string>();
        }

        public IMenu<T> AddGotoMenuOption(Dtmf option, string targetMenuId, IDictionary<string,string> cookies = null)
        {
            CheckClash(option);
            GotoMenuOptions[option] = new Tuple<string, IDictionary<string, string>>(targetMenuId,cookies);
            return this;
        }

        private void CheckClash(Dtmf option)
        {
            if(GotoMenuOptions.ContainsKey(option) || ReturnOptions.ContainsKey(option))
                throw new BuilderException("Option '" + option + "' already defined");
        }

        public IMenu<T> AddTriggerPieOption(Dtmf option, string result)
        {
            CheckClash(option);
            ReturnOptions[option] = result;
            return this;
        }

        public T EndMenuDefinition()
        {
            return _builder;
        }
    }
}