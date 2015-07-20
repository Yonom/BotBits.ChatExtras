using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BotBits.Commands;
using JetBrains.Annotations;

namespace BotBits.ChatExtras
{
    public static class ParsedRequestExtensions
    {
        [Pure]
        public static string GetUsernameIn(this ParsedRequest request, BotBitsClient client, int index)
        {
            var query = request.Args[index];
            PlayerSearchFilter filter;
            query = MatchHelper.TrimFilterPrefix(query, out filter);

            try
            {
                var list = request
                    .GetPlayersIn(client, index)
                    .Select(p => p.Username)
                    .Distinct()
                    .ToArray();

                if (!filter.HasFlag(PlayerSearchFilter.FirstResult) && list.Length >= 2)
                    throw new CommandException("More than one username was found.");

                return list.First();
            }
            catch (UnknownPlayerCommandException)
            {
                return query;
            }
        }

        [Pure]
        public static string[] GetUsernamesIn(this ParsedRequest request, BotBitsClient client, int index)
        {
            var query = request.Args[index];
            PlayerSearchFilter filter;
            query = MatchHelper.TrimFilterPrefix(query, out filter);

            try
            {
                return request
                    .GetPlayersIn(client, index)
                    .Select(p => p.Username)
                    .Distinct()
                    .ToArray();
            }
            catch (UnknownPlayerCommandException)
            {
                return new []{query};
            }
        }

        [Pure]
        public static Player GetPlayerIn(this ParsedRequest request, BotBitsClient client, int index)
        {
            var query = request.Args[index];
            PlayerSearchFilter filter;
            query = MatchHelper.TrimFilterPrefix(query, out filter);
            var list = MatchPlayers(client, query, filter);

            if (!filter.HasFlag(PlayerSearchFilter.FirstResult) && list.Length >= 2)
                throw new CommandException("More than one player was found.");

            return list.First();
        }

        [Pure]
        public static Player[] GetPlayersIn(this ParsedRequest request, BotBitsClient client, int index)
        {
            var query = request.Args[index];
            PlayerSearchFilter filter;
            query = MatchHelper.TrimFilterPrefix(query, out filter);
            return MatchPlayers(client, query, filter);
        }

        private static Player[] MatchPlayers(BotBitsClient client, string query, PlayerSearchFilter filter)
        {
            IList<Player> list = new List<Player>();

            var exactMatch = filter.HasFlag(PlayerSearchFilter.ExactMatch);
            var regex = filter.HasFlag(PlayerSearchFilter.Regex);
            foreach (var player in Players.Of(client))
            {
                var match = false;
                if (exactMatch)
                {
                    if (player.Username.Equals(query, StringComparison.OrdinalIgnoreCase))
                        match = true;
                }
                else if (regex)
                {
                    try
                    {
                        if (Regex.IsMatch(player.Username, query, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
                            match = true;
                    }
                    catch (ArgumentException ex)
                    {
                        throw new CommandException("Regex error: " + ex.Message);
                    }
                }
                else
                {
                    if (player.Username.StartsWith(query, StringComparison.OrdinalIgnoreCase) ||
                        player.GetTrimmedName().StartsWith(query, StringComparison.OrdinalIgnoreCase))
                        match = true;
                }
                if (match)
                    list.Add(player);
            }

            if (list.Count == 0)
                throw new UnknownPlayerCommandException("No player found!");
            if (!filter.HasFlag(PlayerSearchFilter.AllowMultiple) && list.GroupBy(i => i.Username).Count() > 1)
                throw new CommandException("Multiple players with different usernames found.");
            return list.ToArray();
        }
    }

    public static class MatchHelper
    {
        [Pure]
        public static string TrimFilterPrefix(string chatName, out PlayerSearchFilter filters)
        {
            filters = PlayerSearchFilter.None;
            if (String.IsNullOrEmpty(chatName)) return chatName;

            if (chatName.StartsWith("@"))
            {
                filters |= PlayerSearchFilter.ExactMatch;
            }
            else if (chatName.StartsWith("~"))
            {
                filters |= PlayerSearchFilter.FirstResult;
            }
            else if (chatName.StartsWith("%"))
            {
                filters |= PlayerSearchFilter.AllowMultiple;
            }
            else if (chatName.StartsWith(":"))
            {
                filters |= PlayerSearchFilter.Regex;
                return chatName.Substring(1); // no more parsing after regex
            }
            else
            {
                return chatName;
            }

            PlayerSearchFilter innerFilters;
            chatName = TrimFilterPrefix(chatName.Substring(1), out innerFilters);
            filters |= innerFilters;
            return chatName;
        }
    }
}
