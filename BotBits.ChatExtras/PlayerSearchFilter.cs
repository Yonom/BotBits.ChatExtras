using System;

namespace BotBits.ChatExtras
{
    [Flags]
    public enum PlayerSearchFilter
    {
        None = 0,
        FirstResult = 1 << 0,
        ExactMatch = 1 << 1,
        AllowMultiple = 1 << 2,
        Regex = 1 << 3,
    }
}