using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Converters;
using DSharpPlus.CommandsNext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscordBot.Common
{
    class HelpFormatter:BaseHelpFormatter
    {
        private StringBuilder MessageBuilder { get; set; }
        public HelpFormatter(CommandContext ctx):base(ctx)
        {
            MessageBuilder = new StringBuilder();
        }
        public override CommandHelpMessage Build()
        {
            return new CommandHelpMessage(this.MessageBuilder.ToString().Replace("\r\n", "\n"));
        }

        public override BaseHelpFormatter WithCommand(DSharpPlus.CommandsNext.Command command)
        {
            MessageBuilder.Append("Command: ")
              .AppendLine(Formatter.Bold(command.Name))
              .AppendLine();


            MessageBuilder.Append("Description: ")
                .AppendLine(command.Description)
                .AppendLine();

            if (command is CommandGroup)
                MessageBuilder.AppendLine("This group has a standalone command.").AppendLine();
            if (command.Aliases != null && command.Aliases.Any())
            {
                Console.WriteLine("Aaa" + command.Aliases.Count);
                MessageBuilder.Append("Aliases: ")
                    .AppendLine(string.Join(", ", command.Aliases))
                    .AppendLine();
            }
            foreach (var overload in command.Overloads)
            {
                if (overload.Arguments.Count == 0)
                {
                    continue;
                }

                MessageBuilder.Append($"[Overload {overload.Priority}] Arguments: ")
                .AppendLine(string.Join(", ", overload.Arguments.Select(xarg => $"{xarg.Name} ({xarg.Type.Name})")))
                .AppendLine();
            }   
            return this;
        }

        public override BaseHelpFormatter WithSubcommands(IEnumerable<DSharpPlus.CommandsNext.Command> subcommands)
        {
            MessageBuilder.Append("Subcommand: ")
                .AppendLine(string.Join(",", subcommands.Select(x => x.Name)))
                .AppendLine();
            return this;
        }
    }
}
