using JetBrains.Annotations;

namespace BotBits.ChatExtras
{
    public static class PlayerExtensions
    {
        internal static string GetTrimmedName(this Player p)
        {
            var g = p.Get<string>("TrimmedName");
            if (g == null)
            {
                g = ChatUtils.ApplyAntiSpam(p.Username);
                p.SetTrimmedName(g);
            }
            return g;
        }

        private static void SetTrimmedName(this Player p, string name)
        {
            p.Set("TrimmedName", name);
        }

        public static void Reply(this Player player, string message)
        {
            ChatEx.Of(player.BotBits).Reply(player.Username, message);
        }

        [StringFormatMethod("args")]
        public static void Reply(this Player player, string message, params object[] args)
        {
            ChatEx.Of(player.BotBits).Reply(player.Username, message, args);
        }
    }
}
