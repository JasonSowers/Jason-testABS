using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using Microsoft.Bot.Builder.Dialogs;

#pragma warning disable 649

// The SandwichOrder is the simple form you want to fill out.  It must be serializable so the bot can be stateless.
// The order of fields defines the default order in which questions will be asked.
// Enumerations shows the legal options for each field in the SandwichOrder and the order is the order values will be presented 
// in a conversation.
namespace Microsoft.Bot.Sample.FormBot
{

    public enum CompetitionEntries
    {
        XamCam, Hunt, PhotoSharing, Partner, Ent2
    }

    [Serializable]
    public class CompetitionEntry
    {
        [Prompt("Which team would you like to vote for? {||}")]
        public CompetitionEntries? Entry;

        public static IForm<CompetitionEntry> BuildForm()
        {
            return new FormBuilder<CompetitionEntry>()
                .Message("Welcome to the Intelligent Cloud Competition Voting Bot!")
                .OnCompletion(async (context, entry) =>
                {
                    context.UserData.SetValue<string>(
                        "Entry", entry.Entry.ToString());
                    await context.PostAsync("Thanks for voting!");
                })
                .Build();
        }
    };
}