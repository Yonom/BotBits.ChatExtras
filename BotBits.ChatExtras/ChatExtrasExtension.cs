namespace BotBits.ChatExtras
{
    public sealed class ChatExtrasExtension : Extension<ChatExtrasExtension>
    {
        protected override void Initialize(BotBitsClient client, object args)
        {
            var syntaxProvider = (IChatSyntaxProvider)args ?? new DefaultChatSyntaxProvider();
            ChatEx.Of(client).SyntaxProvider = syntaxProvider;
        }

        public static void LoadInto(BotBitsClient client, IChatSyntaxProvider syntaxProvider = null)
        {
            LoadInto(client, (object)syntaxProvider);
        }
    }
}
