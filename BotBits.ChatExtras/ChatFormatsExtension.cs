using System;

namespace BotBits.ChatExtras
{
    public sealed class ChatFormatsExtension : Extension<ChatFormatsExtension>
    {
        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(botBits) method instead.", true)]
        public ChatFormatsExtension()
        {
        }

        protected override void Initialize(BotBitsClient client, object args)
        {
            var syntaxProvider = (IChatSyntaxProvider)args ?? new DefaultChatSyntaxProvider();
            ChatEx.Of(client).SyntaxProvider = syntaxProvider;
        }

        public static bool LoadInto(BotBitsClient client, IChatSyntaxProvider syntaxProvider = null)
        {
            return LoadInto(client, (object)syntaxProvider);
        }
    }
}
