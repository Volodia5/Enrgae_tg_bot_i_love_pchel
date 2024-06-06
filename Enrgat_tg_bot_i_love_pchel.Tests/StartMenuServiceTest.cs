using EnrageTgBotILovePchel.Bot.Router;
using EnrageTgBotILovePchel.Bot;
using EnrageTgBotILovePchel.Service;
using EnrageTgBotILovePchel.Util.String;

namespace Enrgat_tg_bot_i_love_pchel.Tests
{
    public class StartMenuServiceTest
    {
        [Fact]
        public void ProcessCommandStart_ReturnClickOnInlineButtonState()
        {
            TransmittedData transmittedData = new TransmittedData(chatId: 0);
            string command = SystemStringsStorage.CommandStart;

            StartMenuService startMenuService = new StartMenuService();

            startMenuService.ProcessCommandStart(command, transmittedData);

            string expectedState = States.MainMenu.ClickOnInlineButton; ;
            string actualState = transmittedData.State;
            Assert.Equal(expectedState, actualState);
        }

        [Fact]
        public void ProcessCommandStart_ReturnCommandStartInputErrorInputText()
        {
            TransmittedData transmittedData = new TransmittedData(chatId: 0);
            string command = "WrongCommand";

            StartMenuService startMenuService = new StartMenuService();

            BotMessage botMessage = startMenuService.ProcessCommandStart(command, transmittedData);

            string expectedText = DialogsStringsStorage.CommandStartInputErrorInput;
            string actualText = botMessage.Text;

            Assert.Equal(expectedText, actualText);
        }
    }
}
