namespace BotBits.ChatExtras
{
    public class BasicChatSyntaxProvider : IChatSyntaxProvider
    {
        public string ChatName { get; set; }

        public BasicChatSyntaxProvider(string chatName)
        {
            this.ChatName = chatName;
        }

        public virtual string ApplyChatSyntax(string chat)
        {
            return $"[{this.ChatName}] {chat}";
        }

        public virtual string ApplyReplySyntax(string playerName, string chat)
        {
            return $"[{this.ChatName}] {playerName.ToUpper()}: {chat}";
        }

        public string ApplyPrivateMessageSyntax(string playername, string chat)
        {
            return $"/pm {playername} [{this.ChatName}] {chat}";
        }

        public virtual string ApplyKickSyntax(string playerName, string reason)
        {
            return $"/kick {playerName} [{this.ChatName}] {reason}";
        }
    }
}
