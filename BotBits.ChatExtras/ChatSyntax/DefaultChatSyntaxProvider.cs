namespace BotBits.ChatExtras
{
    public class DefaultChatSyntaxProvider : IChatSyntaxProvider
    {
        public virtual string ApplyChatSyntax(string chat)
        {
            return chat;
        }

        public virtual string ApplyReplySyntax(string playerName, string chat)
        {
            return chat;
        }

        public string ApplyPrivateMessageSyntax(string playername, string chat)
        {
            return string.Format("/pm {0} {1}", playername, chat);
        }

        public virtual string ApplyKickSyntax(string playerName, string reason)
        {
            return string.Format("/kick {0} {1}", playerName, reason);
        }
    }
}