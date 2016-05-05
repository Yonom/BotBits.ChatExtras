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
            return $"/pm {playername} {chat}";
        }

        public virtual string ApplyKickSyntax(string playerName, string reason)
        {
            return $"/kick {playerName} {reason}";
        }
    }
}