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
    }
}