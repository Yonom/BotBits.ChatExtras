using System;
using System.Linq;
using BotBits.Commands;
using BotBits.Events;
using JetBrains.Annotations;

namespace BotBits.ChatExtras
{
    public sealed class ChatEx : EventListenerPackage<ChatEx>, IChat
    {
        internal const string SendPrefix = "/send ";
        public IChatSyntaxProvider SyntaxProvider { get; internal set; }

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(botBits) method instead.", true)]
        public ChatEx()
        {
        }

        [EventListener]
        private void OnCommand(CommandEvent e)
        {
            var source = e.Source as PlayerInvokeSource;
            if (source == null) return;
            switch (source.Origin)
            {
                case PlayerInvokeOrigin.Chat:
                    e.Source = new PlayerInvokeSource(source.Player, source.Origin, message =>
                        source.Player.Reply(message));
                    break;
            }
        }

        [EventListener(GlobalPriority.BeforeMost)]
        private void OnQueueChat(QueueChatEvent e)
        {
            var pm = e.Message.StartsWith("/pm ", StringComparison.OrdinalIgnoreCase);
            var kick = e.Message.StartsWith("/kick ", StringComparison.OrdinalIgnoreCase);
            var sendraw = e.Message.StartsWith(SendPrefix, StringComparison.OrdinalIgnoreCase);
            if (e.Message.StartsWith("/", StringComparison.OrdinalIgnoreCase) && !pm && !kick && !sendraw) return;

            if (pm || kick)
            {
                var args = e.Message.Split(' ');
                var target = args.Skip(1).FirstOrDefault();
                var message = String.Join(" ", args.Skip(2));
                if (String.IsNullOrEmpty(message)) message = "Tsk Tsk Tsk";

                e.Message = pm 
                    ? this.SyntaxProvider.ApplyPrivateMessageSyntax(target, message) 
                    : this.SyntaxProvider.ApplyKickSyntax(target, message);
            }
            else if (sendraw)
            {
                e.Message = e.Message.Substring(SendPrefix.Length, e.Message.Length - SendPrefix.Length);
            }
            else 
            {
                e.Message = this.SyntaxProvider.ApplyChatSyntax(e.Message);
            }
        }

        public void Say(string msg)
        {
            Chat.Of(this.BotBits).Say(msg);
        }

        public void Reply(string username, string msg)
        {
            this.Send(this.SyntaxProvider.ApplyReplySyntax(username, msg));
        }

        [StringFormatMethod("args")]
        public void Reply(string username, string msg, params object[] args)
        {
            this.Reply(username, String.Format(msg, args));
        }
    }
}
