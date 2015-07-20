using System;
using BotBits.Commands;

namespace BotBits.ChatExtras
{
    public class UnknownPlayerCommandException : CommandException
    {
        public UnknownPlayerCommandException()
        {
        }

        public UnknownPlayerCommandException(string message)
            : base(message)
        {
        }

        public UnknownPlayerCommandException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}