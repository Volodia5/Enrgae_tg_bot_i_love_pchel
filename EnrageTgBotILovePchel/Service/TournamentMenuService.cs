using EnrageTgBotILovePchel.Bot;
using EnrageTgBotILovePchel.Bot.Router;
using EnrageTgBotILovePchel.Db.Models;
using EnrageTgBotILovePchel.Db.Repositories.Interfaces;
using EnrageTgBotILovePchel.Util.Button;
using EnrageTgBotILovePchel.Util.String;
using Telegram.Bot.Types.ReplyMarkups;

namespace EnrageTgBotILovePchel.Service
{
    public class TournamentMenuService
    {
        private ITournamentDatasRepository _tournamentDatasRepository;

        public TournamentMenuService(ITournamentDatasRepository tournamentDatasRepository)
        {
            _tournamentDatasRepository = tournamentDatasRepository;
        }

        public BotMessage ProcessInputTournamentData(string textData, TransmittedData transmittedData)
        {
            TournamentsDatum tournamentData = _tournamentDatasRepository.GetTournamentsData();

            if (tournamentData == null)
            {
                _tournamentDatasRepository.AddTournament(textData, "Null rules");
            }
            else
            {
                _tournamentDatasRepository.UpdateTournamentData(tournamentData.TournId, textData);
            }

            transmittedData.State = States.TournamentMenu.ProcessInputTournamentRules;

            return new BotMessage(DialogsStringsStorage.ChangeTournamentRules, InlineKeyboardMarkup.Empty(), MessageState.Create);
        }

        public BotMessage ProcessInputTournamentRules(string textData, TransmittedData transmittedData)
        {
            TournamentsDatum tournamentData = _tournamentDatasRepository.GetTournamentsData();
            _tournamentDatasRepository.UpdateTournamentRules(tournamentData.TournId, textData);
            transmittedData.State = States.StartMenu.CommandStart;
            
            return new BotMessage("Данные о предстоящем турнире успешно изменены !!!" + DialogsStringsStorage.MainMenu, InlineKeyboardMarkupStorage.AdminMainMenu, MessageState.Create);
        }
    }
}