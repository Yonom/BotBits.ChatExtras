using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotBits.ChatExtras
{
    public interface IChatSyntaxProvider
    {
        string ApplyChatSyntax(string chat);

        string ApplyReplySyntax(string playerName, string chat);

        string ApplyPrivateMessageSyntax(string playername, string chat);

        string ApplyKickSyntax(string playerName, string reason);
    }
}
