using EnrageTgBotILovePchel.Bot.Router;
using EnrageTgBotILovePchel.Bot;
using EnrageTgBotILovePchel.Service;
using EnrageTgBotILovePchel.Util.String;
using EnrageTgBotILovePchel.Db.DbConnector;
using EnrageTgBotILovePchel.Db.Repositories.Implemintations;

namespace Enrgat_tg_bot_i_love_pchel.Tests
{
    
    public class TournamentMenuServiceTest
    {
        [Fact]
        public void ProcessInputTournamentData_ReturnProcessInputTournamentRulesTextState()
        {
            TransmittedData transmittedData = new TransmittedData(chatId: 0);
            string command = " ";
            EnrageBotVovodyaDbContext db = new EnrageBotVovodyaDbContext();
            TournamentDatasRepository tournamentDatasRepository = new TournamentDatasRepository(db);
            TournamentMenuService tournamentMenuService = new TournamentMenuService(tournamentDatasRepository);

            BotMessage botMessage = tournamentMenuService.ProcessInputTournamentData(command, transmittedData);

            string expectedText = DialogsStringsStorage.ChangeTournamentRules;
            string actualText = botMessage.Text;

            string expectedState = States.TournamentMenu.ProcessInputTournamentRules;
            string actualState = transmittedData.State;


            Assert.Equal(expectedText, actualText);
            Assert.Equal(expectedState, actualState);
        }

        [Fact]
        public void ProcessInputTournamentRules_ReturnCommandStartTextKeyBoard()
        {
            TransmittedData transmittedData = new TransmittedData(chatId: 0);
            string command = " ";
            EnrageBotVovodyaDbContext db = new EnrageBotVovodyaDbContext();
            TournamentDatasRepository tournamentDatasRepository = new TournamentDatasRepository(db);
            TournamentMenuService tournamentMenuService = new TournamentMenuService(tournamentDatasRepository);

            BotMessage botMessage = tournamentMenuService.ProcessInputTournamentRules(command, transmittedData);

            string expectedText = "Данные о предстоящем турнире успешно изменены !!!" + DialogsStringsStorage.MainMenu;
            string actualText = botMessage.Text;

            string expectedState = States.StartMenu.CommandStart;
            string actualState = transmittedData.State;


            Assert.Equal(expectedText, actualText);
            Assert.Equal(expectedState, actualState);
        }
    }
}

