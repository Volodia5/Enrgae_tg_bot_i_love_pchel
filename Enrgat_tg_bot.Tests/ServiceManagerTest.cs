using EnrageTgBotILovePchel.Bot;
using EnrageTgBotILovePchel.Bot.Router;
using EnrageTgBotILovePchel.Service;
using EnrageTgBotILovePchel.Util.Button;
using EnrageTgBotILovePchel.Util.String;
using Telegram.Bot.Types.ReplyMarkups;

namespace Enrgat_tg_bot_i_love_pchel.Tests
{
    public class ServiceManagerTest
    {
        [Fact]
        public void ProcessBotUpdate_ReturnStateAndCountMainMenu()
        {
            TransmittedData transmittedData = new TransmittedData(chatId: 0);
            string command = SystemStringsStorage.CommandReset;

            ServiceManager serviceManager = new ServiceManager();

            BotMessage botMessage = serviceManager.ProcessBotUpdate(command, transmittedData);

            string expectedText = DialogsStringsStorage.MainMenu;
            string actualText = botMessage.Text;

            InlineKeyboardMarkup expectedKeyboard = InlineKeyboardMarkupStorage.MainMenu;
            IReplyMarkup actualKeyboard = botMessage.KeyboardMarkup;

            string expectedState = States.MainMenu.ClickOnInlineButton;
            string actualState = transmittedData.State;

            int expecredDataStorageCount = 0;
            int actualDataStorageCount = transmittedData.DataStorage.GetCount();

            Assert.Equal(expectedText, actualText);
            Assert.Equal(expectedKeyboard, actualKeyboard);
            Assert.Equal(expectedState, actualState);
            Assert.Equal(expecredDataStorageCount, actualDataStorageCount);
        }


    }
}