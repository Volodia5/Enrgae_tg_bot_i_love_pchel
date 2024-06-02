using EnrageTgBotILovePchel.Bot;
using EnrageTgBotILovePchel.Bot.Router;
using EnrageTgBotILovePchel.Db.Models;
using EnrageTgBotILovePchel.Db.Repositories.Interfaces;
using EnrageTgBotILovePchel.Util.String;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnrageTgBotILovePchel.Util.Button;
using Telegram.Bot.Types.ReplyMarkups;

namespace EnrageTgBotILovePchel.Service
{
    public class MainMenuService
    {
        private ITournamentDatasRepository _tournamentDatasRepository;
        private IUsersDatasRepository _usersDatas;

        public MainMenuService(ITournamentDatasRepository tournamentDatasRepository, IUsersDatasRepository usersDatas)
        {
            _tournamentDatasRepository = tournamentDatasRepository;
            _usersDatas = usersDatas;
        }

        public BotMessage ProcessClickOnInlineButton(string textData, TransmittedData transmittedData)
        {
            TournamentsDatum tournamentsData = _tournamentDatasRepository.GetTournamentsData();
            UsersDatum userData = _usersDatas.GetLastUserDataByChatId(transmittedData.ChatId);

            if (textData == ConstraintStringsStorage.ChangeTournamentData)
            {
                transmittedData.State = States.TournamentMenu.ProcessInputTournamentData;

                return new BotMessage(DialogsStringsStorage.ChangeTournamentData, InlineKeyboardMarkup.Empty(), MessageState.Create);
            }
            
            if (textData == ConstraintStringsStorage.WhenIsNextTournament)
            {
                transmittedData.State = States.MainMenu.ClickOnInlineButton;
                return new BotMessage(DialogsStringsStorage.WhenIsNextTournament(tournamentsData), MessageState.Create);
            }

            if (textData == ConstraintStringsStorage.FindTeammate)
            {
                if (userData != null)
                {
                    transmittedData.State = States.SearchTeammateMenu.WatchingOnUserQuestionnaire;
                    return new BotMessage(DialogsStringsStorage.UserQuestionnaire(userData), InlineKeyboardMarkupStorage.ChooseFindingMenu, MessageState.Create);
                }
                else
                {
                    transmittedData.State = States.SearchTeammateMenu.InputName;
                    return new BotMessage(DialogsStringsStorage.NewQuestionnaireNameInput, InlineKeyboardMarkup.Empty(), true, MessageState.Create);
                }
            }

            if (textData == ConstraintStringsStorage.Rules)
            {
                transmittedData.State = States.MainMenu.ClickOnInlineButton;
                return new BotMessage(DialogsStringsStorage.TournamentsRules(tournamentsData), MessageState.Create);
            }


            throw new Exception("Неизветсная ошибка в ProcessClickOnInlineButton");
        }
    }
}