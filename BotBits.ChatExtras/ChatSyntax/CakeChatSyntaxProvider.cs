using System.Globalization;

namespace BotBits.ChatExtras
{
    public class CakeChatSyntaxProvider : IChatSyntaxProvider
    {
        public string ChatName { get; set; }

        public CakeChatSyntaxProvider(string chatName)
        {
            this.ChatName = chatName;
        }

        public virtual string ApplyChatSyntax(string chat)
        {
            return string.Format("<{0}> {1}", ChatName, chat);
        }

        public virtual string ApplyReplySyntax(string playerName, string chat)
        {
            return string.Format("<{0} (@{1})> {2}", ChatName, MakeFirstLetterUpperCase(playerName), chat);
        }

        public string ApplyPrivateMessageSyntax(string playername, string chat)
        {
            return string.Format("/pm {0} <{1}> {2}", playername, ChatName, chat);
        }

        public virtual string ApplyKickSyntax(string playername, string reason)
        {
            return string.Format("/kick {0} <{1}> {2}", playername, ChatName, reason);
        }

        private static string MakeFirstLetterUpperCase(string value)
        {
            char[] letters = value.ToCharArray();
            letters[0] = char.ToUpper(letters[0], CultureInfo.InvariantCulture);

            return new string(letters);
        }
    }
}
