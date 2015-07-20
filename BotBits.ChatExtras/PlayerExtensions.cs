using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace BotBits.ChatExtras
{
    public static class PlayerExtensions
    {
        private static BotBitsClient GetClient(this Player p)
        {
            var client = p.Get<BotBitsClient>("ChatExtrasClient");
            if (client == null)
                throw new InvalidOperationException("Unable to find the connection associated with this player.");
            return client;
        }

        internal static void SetClient(this Player p, BotBitsClient client)
        {
            p.Set("ChatExtrasClient", client);
        }

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

        public static void Kick(this Player player)
        {
            Chat.Of(player.GetClient()).Kick(player);
        }

        public static void Kick(this Player player, string reason)
        {
            Chat.Of(player.GetClient()).Kick(player, reason);
        }
        
        [StringFormatMethod("args")]
        public static void Kick(this Player player, string reason, params object[] args)
        {
            Chat.Of(player.GetClient()).Kick(player, reason, args);
        }

        public static void GiveCrown(this Player player)
        {
            Chat.Of(player.GetClient()).GiveCrown(player);
        }

        public static void GiveEdit(this Player player)
        {
            Chat.Of(player.GetClient()).GiveEdit(player);
        }

        public static void RemoveEdit(this Player player)
        {
            Chat.Of(player.GetClient()).RemoveEdit(player);
        }

        public static void GodOn(this Player player)
        {
            Chat.Of(player.GetClient()).GodOn(player);
        }

        public static void GodOff(this Player player)
        {
            Chat.Of(player.GetClient()).GodOff(player);
        }

        public static void Kill(this Player player)
        {
            Chat.Of(player.GetClient()).Kill(player);
        }

        public static void Mute(this Player player)
        {
            Chat.Of(player.GetClient()).Mute(player);
        }

        public static void Unmute(this Player player)
        {
            Chat.Of(player.GetClient()).Unmute(player);
        }

        public static void PrivateMessage(this Player player, string message)
        {
            Chat.Of(player.GetClient()).PrivateMessage(player, message);
        }

        [StringFormatMethod("args")]
        public static void PrivateMessage(this Player player, string message, params object[] args)
        {
            Chat.Of(player.GetClient()).PrivateMessage(player, message, args);
        }

        public static void ReportAbuse(this Player player, string reason)
        {
            Chat.Of(player.GetClient()).ReportAbuse(player, reason);
        }

        [StringFormatMethod("args")]
        public static void ReportAbuse(this Player player, string reason, params object[] args)
        {
            Chat.Of(player.GetClient()).ReportAbuse(player, reason, args);
        }

        public static void Teleport(this Player player)
        {
            Chat.Of(player.GetClient()).Teleport(player);
        }

        public static void Teleport(this Player player, Point point)
        {
            Chat.Of(player.GetClient()).Teleport(player, point);
        }

        public static void Teleport(this Player player, int x, int y)
        {
            Chat.Of(player.GetClient()).Teleport(player, x, y);
        }
        

        public static void Reply(this Player player, string message)
        {
            ChatEx.Of(player.GetClient()).Reply(player.Username, message);
        }

        [StringFormatMethod("args")]
        public static void Reply(this Player player, string message, params object[] args)
        {
            ChatEx.Of(player.GetClient()).Reply(player.Username, message, args);
        }
    }
}
