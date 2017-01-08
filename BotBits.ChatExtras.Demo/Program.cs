using System.Threading;
using BotBits.Commands;
using BotBits.Events;

namespace BotBits.ChatExtras.Demo
{
    class Program
    {
        static void Main()
        {
            var bot = new BotBitsClient();
            ChatFormatsExtension.LoadInto(bot, new CakeChatSyntaxProvider("Bot"));
            CommandsExtension.LoadInto(bot, '!');
            Login.Of(bot).AsGuest().JoinRoom("PW01");
            InitEvent.Of(bot).WaitOneAsync().Wait();
            JoinCompleteEvent.Of(bot).WaitOneAsync().Wait();
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
