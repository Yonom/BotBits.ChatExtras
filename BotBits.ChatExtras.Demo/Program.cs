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
            ChatExtrasExtension.LoadInto(bot, new CakeChatSyntaxProvider("Bot"));
            CommandsExtension.LoadInto(bot, '!');
            ConnectionManager.Of(bot).EmailLogin("guest1@tbp.com", "guest").JoinRoom("PWAARLDluVa0I");
            InitEvent.Of(bot).WaitOneAsync().Wait();
            JoinCompleteEvent.Of(bot).WaitOneAsync().Wait();
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
