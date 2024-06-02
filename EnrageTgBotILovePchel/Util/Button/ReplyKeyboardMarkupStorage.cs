using Telegram.Bot.Types.ReplyMarkups;

namespace EnrageTgBotILovePchel.Util.Button
{
    public class ReplyKeyboardMarkupStorage
    {
        public static ReplyKeyboardMarkup CreateKeyboardSelectPosition()
        {
            var rows = new List<KeyboardButton[]>();

            rows.Add(new[] { new KeyboardButton(BotButtonsStorage.SearchTeammateMenu.FirstPos.Name) });
            rows.Add(new[] { new KeyboardButton(BotButtonsStorage.SearchTeammateMenu.SecondPos.Name) });
            rows.Add(new[] { new KeyboardButton(BotButtonsStorage.SearchTeammateMenu.ThirdPos.Name) });
            rows.Add(new[] { new KeyboardButton(BotButtonsStorage.SearchTeammateMenu.FourthPos.Name) });
            rows.Add(new[] { new KeyboardButton(BotButtonsStorage.SearchTeammateMenu.FifthPos.Name) });

            return new ReplyKeyboardMarkup(rows.ToArray());
        }

        // public static ReplyKeyboardMarkup CreateKeyboardMainMenu()
        // {
        //     var rows = new List<KeyboardButton[]>();
        //
        //     rows.Add(new[] { new KeyboardButton(BotButtonsStorage.MainMenu.WhenIsNextTournament.Name) });
        //     rows.Add(new[] { new KeyboardButton(BotButtonsStorage.MainMenu.Rules.Name) });
        //     rows.Add(new[] { new KeyboardButton(BotButtonsStorage.MainMenu.FindCommand.Name) });
        //
        //     return new ReplyKeyboardMarkup(rows.ToArray()) { ResizeKeyboard = true };
        // }
        //
        // public static ReplyKeyboardMarkup ConfirmingDeleteQuestionnaire()
        // {
        //     var rows = new List<KeyboardButton[]>();
        //
        //     rows.Add(new[] { new KeyboardButton(BotButtonsStorage.SearchTeammateMenu.Confirm.Name) });
        //     rows.Add(new[] { new KeyboardButton(BotButtonsStorage.SearchTeammateMenu.Cancel.Name) });
        //
        //     rows.Add(new[] { new KeyboardButton(BotButtonsStorage.SearchTeammateMenu.Back.Name) });
        //
        //     return new ReplyKeyboardMarkup(rows.ToArray()) { ResizeKeyboard = true };
        // }
        //
        // public static ReplyKeyboardMarkup AdminMainMenu()
        // {
        //     var rows = new List<KeyboardButton[]>();
        //
        //     rows.Add(new[] { new KeyboardButton(BotButtonsStorage.AdminMainMenu.ChangeTournamentData.Name) });
        //     rows.Add(new[] { new KeyboardButton(BotButtonsStorage.MainMenu.WhenIsNextTournament.Name) });
        //     rows.Add(new[] { new KeyboardButton(BotButtonsStorage.MainMenu.Rules.Name) });
        //     rows.Add(new[] { new KeyboardButton(BotButtonsStorage.MainMenu.FindCommand.Name) });
        //
        //     return new ReplyKeyboardMarkup(rows.ToArray()) { ResizeKeyboard = true };
        // }
    }
}