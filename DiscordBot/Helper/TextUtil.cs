using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DiscordBot.Helper
{
    class TextUtil
    {
        private static readonly TextInfo textInfo = new CultureInfo("en-Us", false).TextInfo;
        public static string ToTitleCase(string text)
        {
            return textInfo.ToTitleCase(text.ToLower());
        }
    }
}
