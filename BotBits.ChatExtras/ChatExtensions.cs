using JetBrains.Annotations;

namespace BotBits.ChatExtras
{
    public static class ChatExtensions
    {
        public static void Send(this IChat chat, string message)
        {
            chat.Say(ChatEx.SendPrefix + message);
        }

        [StringFormatMethod("args")]
        public static void Send(this IChat chat, string message, params object[] args)
        {
            chat.Say(ChatEx.SendPrefix + message, args);
        }

        public static void Reply(this IChat chat, Player player, string message)
        {
            player.Reply(message);
        }

        [StringFormatMethod("args")]
        public static void Reply(this IChat chat, Player player, string message, params object[] args)
        {
            player.Reply(message, args);
        }
    }
}
