using EnrageTgBotILovePchel.Bot;
using EnrageTgBotILovePchel.Db.Repositories.Interfaces;
using EnrageTgBotILovePchel.Bot.Router;
using EnrageTgBotILovePchel.Db.Models;
using EnrageTgBotILovePchel.Util.Button;
using EnrageTgBotILovePchel.Util.String;
using Telegram.Bot.Types.ReplyMarkups;

namespace EnrageTgBotILovePchel.Service
{
    public class SearchTeammateMenuService
    {
        ITournamentDatasRepository _tournamentDatasRepository;
        IUsersDatasRepository _usersDatasRepository;

        public SearchTeammateMenuService(ITournamentDatasRepository tournamentDatasRepository,
            IUsersDatasRepository usersDatasRepository)
        {
            _tournamentDatasRepository = tournamentDatasRepository;
            _usersDatasRepository = usersDatasRepository;
        }

        public BotMessage ProcessInputName(string textData, TransmittedData transmittedData)
        {
            if (CheckIsButton(textData) == false)
            {
                if (textData.Length > ConstraintStringsStorage.MaxUserFirstName)
                {
                    return new BotMessage(DialogsStringsStorage.NameInputError, MessageState.Create);
                }

                if (transmittedData.State == States.SearchTeammateMenu.UpdateName)
                {
                    transmittedData.State = States.SearchTeammateMenu.UpdateNickname;
                }
                else
                {
                    transmittedData.State = States.SearchTeammateMenu.InputNickname;
                }

                _usersDatasRepository.AddUser(textData, 0, 0, string.Empty, transmittedData.ChatId);

                return new BotMessage(DialogsStringsStorage.NewQuestionnaireUserTgNickname,
                    InlineKeyboardMarkup.Empty(), MessageState.Create);
            }

            return new BotMessage(DialogsStringsStorage.NameInputError, MessageState.Create);
        }

        public BotMessage ProcessInputTgUsername(string textData, TransmittedData transmittedData)
        {
            if (CheckIsButton(textData) == false)
            {
                if (textData.Length > ConstraintStringsStorage.MaxUserTgUsername)
                {
                    return new BotMessage(DialogsStringsStorage.NicknameInputError, MessageState.Create);
                }

                UsersDatum usersData = _usersDatasRepository.GetLastUserDataByChatId(transmittedData.ChatId);
                usersData.PlayerTgNick = "@" + textData;
                _usersDatasRepository.UpdateUser(usersData);

                if (transmittedData.State == States.SearchTeammateMenu.UpdateNickname)
                {
                    transmittedData.State = States.SearchTeammateMenu.UpdateRating;
                }
                else
                {
                    transmittedData.State = States.SearchTeammateMenu.InputRating;
                }

                return new BotMessage(DialogsStringsStorage.NewQuestionnaireRatingInput,
                    InlineKeyboardMarkup.Empty(), MessageState.Create);
            }

            return new BotMessage(DialogsStringsStorage.NicknameInputError, MessageState.Create);
        }

        public BotMessage ProcessInputRating(string textData, TransmittedData transmittedData)
        {
            int intRating = 0;
            bool isNumber = false;
            isNumber = int.TryParse(textData, out intRating);

            if (isNumber == false || intRating > ConstraintStringsStorage.MaxUserRating ||
                intRating < ConstraintStringsStorage.MinUserRating)
            {
                return new BotMessage(DialogsStringsStorage.RatingInputError, MessageState.Create);
            }

            if (transmittedData.State == States.SearchTeammateMenu.UpdateRating)
            {
                transmittedData.State = States.SearchTeammateMenu.UpdatePosition;
            }
            else
            {
                transmittedData.State = States.SearchTeammateMenu.InputPosition;
            }

            UsersDatum userData = _usersDatasRepository.GetLastUserDataByChatId(transmittedData.ChatId);
            userData.PlayerRating = intRating;

            return new BotMessage(DialogsStringsStorage.NewQuestionnairePosition,
                ReplyKeyboardMarkupStorage.CreateKeyboardSelectPosition(), MessageState.Create);
        }

        public BotMessage ProcessClickOnInlineButtonPosition(string textData, TransmittedData transmittedData)
        {
            if (CheckIsButton(textData) == false)
            {
                if (textData == BotButtonsStorage.SearchTeammateMenu.FirstPos.Name ||
                    textData == BotButtonsStorage.SearchTeammateMenu.SecondPos.Name ||
                    textData == BotButtonsStorage.SearchTeammateMenu.ThirdPos.Name ||
                    textData == BotButtonsStorage.SearchTeammateMenu.FourthPos.Name ||
                    textData == BotButtonsStorage.SearchTeammateMenu.FifthPos.Name)
                {
                    UsersDatum usersData = _usersDatasRepository.GetLastUserDataByChatId(transmittedData.ChatId);
                    usersData.PlayerPosition = int.Parse(textData);

                    _usersDatasRepository.UpdateUser(usersData);

                    if (transmittedData.State == States.SearchTeammateMenu.UpdatePosition)
                    {
                        transmittedData.State = States.SearchTeammateMenu.QuestionnaireUpdateCreateConfirmation;
                    }
                    else
                    {
                        transmittedData.State = States.SearchTeammateMenu.QuestionnaireInputCreateConfirmation;
                    }

                    usersData = _usersDatasRepository.GetLastUserDataByChatId(transmittedData.ChatId);

                    return new BotMessage(DialogsStringsStorage.ConfirmCreateQuestionnaire(usersData),
                        InlineKeyboardMarkupStorage.QuestionnaireCreateConfirmation, true, MessageState.Create);
                }
            }

            return new BotMessage(DialogsStringsStorage.PositionInputError, MessageState.Create);
        }

        public BotMessage ProcessClickOnButtonDeleteQuestionnaireConfirmation(string textData,
            TransmittedData transmittedData)
        {
            if (textData == ConstraintStringsStorage.Confirm)
            {
                _usersDatasRepository.DeleteUser(
                    _usersDatasRepository.GetLastUserDataByChatId(transmittedData.ChatId));
                transmittedData.State = States.MainMenu.ClickOnInlineButton;

                return new BotMessage(
                    DialogsStringsStorage.QuestionnaireDeleted + "\n\n" + DialogsStringsStorage.MainMenu,
                    InlineKeyboardMarkupStorage.MainMenu, MessageState.Create);
            }

            if (textData == ConstraintStringsStorage.Back)
            {
                transmittedData.State = States.SearchTeammateMenu.WatchingOnUserQuestionnaire;

                return new BotMessage(
                    DialogsStringsStorage.UserQuestionnaire(
                        _usersDatasRepository.GetLastUserDataByChatId(transmittedData.ChatId)),
                    InlineKeyboardMarkupStorage.ChooseFindingMenu, MessageState.Create);
            }

            return new BotMessage("Неопознанная ошибка",
                InlineKeyboardMarkup.Empty(), MessageState.Create);
        }

        public BotMessage ProcessClickOnButtonActionQuestionnaire(string textData, TransmittedData transmittedData)
        {
            if (textData == ConstraintStringsStorage.EditQuestionnaire)
            {
                transmittedData.State = States.SearchTeammateMenu.UpdateName;
                return new BotMessage(DialogsStringsStorage.NewQuestionnaireNameInput,
                    InlineKeyboardMarkup.Empty(), MessageState.Create);
            }

            if (textData == ConstraintStringsStorage.DeleteQuestionnaire)
            {
                transmittedData.State = States.SearchTeammateMenu.QuestionnaireInputDeleteConfirmation;
                return new BotMessage(DialogsStringsStorage.QuestionnaireDeletedConfirmation,
                    InlineKeyboardMarkupStorage.QuestionnaireDeleteConfirmation, MessageState.Create);
            }

            if (textData == ConstraintStringsStorage.Back)
            {
                transmittedData.State = States.MainMenu.ClickOnInlineButton;
                return new BotMessage(DialogsStringsStorage.MainMenu,
                    InlineKeyboardMarkupStorage.MainMenu, MessageState.Edit);
            }

            if (textData == ConstraintStringsStorage.FindTeammate)
            {
                List<UsersDatum> usersData = _usersDatasRepository.GetAllUserExcept(transmittedData.ChatId);
                UsersDatum userData = _usersDatasRepository.GetLastUserDataByChatId(transmittedData.ChatId);
                List<UsersDatum> findingUsersData = _usersDatasRepository.GetAllUserExcept(transmittedData.ChatId);
                transmittedData.DataStorage.AddOrUpdate("currentPageNumber", 0);
                transmittedData.State = States.SearchTeammateMenu.FindingTeammate;
                var pageNumber = transmittedData.DataStorage.Get("currentPageNumber");

                return new BotMessage(
                    "Поиск команды: " + DialogsStringsStorage.FindingTeammate(usersData[(int)pageNumber]),
                    InlineKeyboardMarkupStorage.FindTeammateControlMenu, MessageState.Edit);
            }

            return new BotMessage("Неопознанная ошибка", MessageState.Create);
        }

        public BotMessage ConfirmingCreateQuestionnaire(string textData, TransmittedData transmittedData)
        {
            if (textData == ConstraintStringsStorage.Confirm)
            {
                if (transmittedData.State == States.SearchTeammateMenu.QuestionnaireUpdateCreateConfirmation)
                {
                    transmittedData.State = States.SearchTeammateMenu.WatchingOnUserQuestionnaire;
                    UsersDatum user = _usersDatasRepository.GetFirstUserDataByChatId(transmittedData.ChatId);
                    _usersDatasRepository.DeleteUser(user);

                    return new BotMessage(DialogsStringsStorage.QuestionnaireUpdateSuccess + "\n" +
                                          DialogsStringsStorage.UserQuestionnaire(
                                              _usersDatasRepository
                                                  .GetLastUserDataByChatId(transmittedData.ChatId)),
                        InlineKeyboardMarkupStorage.ChooseFindingMenu, MessageState.Create);
                }
                else
                {
                    return new BotMessage(DialogsStringsStorage.QuestionnaireCreateSuccess + "\n" +
                                          DialogsStringsStorage.UserQuestionnaire(
                                              _usersDatasRepository
                                                  .GetLastUserDataByChatId(transmittedData.ChatId)),
                        InlineKeyboardMarkupStorage.ChooseFindingMenu, MessageState.Create);
                }
            }

            if (textData == ConstraintStringsStorage.Back)
            {
                transmittedData.State = States.SearchTeammateMenu.WatchingOnUserQuestionnaire;
                UsersDatum user = new UsersDatum();

                if (transmittedData.State == States.SearchTeammateMenu.QuestionnaireUpdateCreateConfirmation)
                    user = _usersDatasRepository.GetFirstUserDataByChatId(transmittedData.ChatId);
                else
                    user = _usersDatasRepository.GetLastUserDataByChatId(transmittedData.ChatId);

                _usersDatasRepository.DeleteUser(user);

                return new BotMessage(
                    DialogsStringsStorage.UserQuestionnaire(
                        _usersDatasRepository.GetLastUserDataByChatId(transmittedData.ChatId)),
                    InlineKeyboardMarkupStorage.ChooseFindingMenu, MessageState.Edit);
            }

            return new BotMessage("Неопознанная ошибка",
                InlineKeyboardMarkup.Empty(), MessageState.Create);
        }

        public BotMessage SearchTeammateControlMenuAction(string textData, TransmittedData transmittedData)
        {
            List<UsersDatum> usersData = _usersDatasRepository.GetAllUserExcept(transmittedData.ChatId);

            if (textData == BotButtonsStorage.SearchTeammateMenu.NextPlayer.CallBackData)
            {
                var pageNumber = transmittedData.DataStorage.Get("currentPageNumber");
                if ((int)pageNumber == usersData.Count() - 1)
                {
                    return new BotMessage(
                        "Это последняя страница, заходите позже чтобы увидеть новые анкеты.\n Последняя анкета была: " +
                        DialogsStringsStorage.FindingTeammate(usersData[(int)pageNumber]),
                        InlineKeyboardMarkupStorage.FindTeammateControlMenu, MessageState.Edit);
                }
                else
                {
                    pageNumber = (int)pageNumber + 1;
                    transmittedData.DataStorage.AddOrUpdate("currentPageNumber", (int)pageNumber);
                    return new BotMessage(DialogsStringsStorage.FindingTeammate(usersData[(int)pageNumber]),
                        InlineKeyboardMarkupStorage.FindTeammateControlMenu, MessageState.Edit);
                }
            }

            if (textData == BotButtonsStorage.SearchTeammateMenu.PreviousPlayer.CallBackData)
            {
                var pageNumber = transmittedData.DataStorage.Get("currentPageNumber");
                if ((int)pageNumber == 0)
                {
                    return new BotMessage(
                        "Это первая страница ! \n" +
                        DialogsStringsStorage.FindingTeammate(usersData[(int)pageNumber]),
                        InlineKeyboardMarkupStorage.FindTeammateControlMenu, MessageState.Edit);
                }
                else
                {
                    pageNumber = (int)pageNumber - 1;
                    transmittedData.DataStorage.AddOrUpdate("currentPageNumber", (int)pageNumber);
                    return new BotMessage(DialogsStringsStorage.FindingTeammate(usersData[(int)pageNumber]),
                        InlineKeyboardMarkupStorage.FindTeammateControlMenu, MessageState.Edit);
                }
            }

            if (textData == BotButtonsStorage.SearchTeammateMenu.Back.CallBackData)
            {
                UsersDatum userData = _usersDatasRepository.GetLastUserDataByChatId(transmittedData.ChatId);
                transmittedData.State = States.SearchTeammateMenu.WatchingOnUserQuestionnaire;
                return new BotMessage(DialogsStringsStorage.UserQuestionnaire(userData),
                    InlineKeyboardMarkupStorage.ChooseFindingMenu, MessageState.Create);
            }
            
            return new BotMessage("Неопознанная ошибка", MessageState.Create);
        }

        private bool CheckIsButton(string textData)
        {
            if (textData == BotButtonsStorage.MainMenu.FindCommand.CallBackData ||
                textData == BotButtonsStorage.MainMenu.Rules.CallBackData ||
                textData == BotButtonsStorage.MainMenu.WhenIsNextTournament.CallBackData ||
                textData == BotButtonsStorage.SearchTeammateMenu.NextPlayer.CallBackData ||
                textData == BotButtonsStorage.SearchTeammateMenu.PreviousPlayer.CallBackData ||
                textData == BotButtonsStorage.SearchTeammateMenu.DeleteQuestionnaire.CallBackData ||
                textData == BotButtonsStorage.SearchTeammateMenu.EditQuestionnaire.CallBackData ||
                textData == BotButtonsStorage.SearchTeammateMenu.FindTeammate.CallBackData)
            {
                return true;
            }

            return false;
        }
    }
}