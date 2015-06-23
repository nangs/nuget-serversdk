﻿namespace Sinch.Callback.Response.Internal
{
    internal class NumberInputMenu : AbstractMenu
    {
        public int MaxDigits { get; private set; }

        internal NumberInputMenu(Prompt prompt, Prompt repeatPrompt, int repeats, int maxDigits)
            : base(prompt, repeatPrompt, repeats)
        {
            MaxDigits = maxDigits;
        }
    }
}