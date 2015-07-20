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
            return string.Format("[{0}] {1}", ChatName, chat);
        }

        public virtual string ApplyReplySyntax(string playerName, string chat)
        {
            return string.Format("[{0}] {1}: {2}", ChatName, playerName.ToUpper(), chat);
        }

        public string ApplyPrivateMessageSyntax(string playername, string chat)
        {
            return string.Format("/pm {0} [{1}] {2}", playername, ChatName, chat);
        }

        public virtual string ApplyKickSyntax(string playerName, string reason)
        {
            return string.Format("/kick {0} [{1}] {2}", playerName, ChatName, reason);
        }
    }
}
