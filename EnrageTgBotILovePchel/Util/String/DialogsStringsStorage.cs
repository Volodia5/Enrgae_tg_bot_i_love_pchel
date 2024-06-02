using EnrageTgBotILovePchel.Db.Models;

namespace EnrageTgBotILovePchel.Util.String;

public class DialogsStringsStorage
{
    public const string CommandStartInputErrorInput = "Команда не распознана. Для начала работы с ботом введите /start";

    public const string MainMenu = "Выберите действие";

    public static string WhenIsNextTournament(TournamentsDatum data)
    {
        return $"Следующий турнир: \n\n {data.NextTournamentData}";
    }

    public const string NameInputError = "Имя не должно превышать 25 символов\n\n";

    public const string RatingInputError = "Укажите рейтинг в пределах от 0 до 12000 (ммр)\n\n";

    public const string PositionInputError = "Ваша позиция должна быть от 1 до 5";
    
    public const string NicknameInputError = "Ваш никнейм не может привышать 30 символов\n\n";

    public const string AnketaCreateSuccess = "Анкета создана успешно!";

    public const string AnketaUpdateSuccess = "Анкета успешно обновлена!";

    public static string UserQuestionnaire(UsersDatum userData)
    {
        return "Ваша анкета:\n\n" +
               $"Имя - {userData.PlayerName}\n" +
               $"Рейтинг- {userData.PlayerRating}\n" +
               $"Основная позиция- {userData.PlayerPosition}\n" +
               $"Ваш ник tg- {userData.PlayerTgNick}\n";
    }

    public static string FindingTeammate(UsersDatum userData)
    {
        return $"Aнкета пользователя: {userData.PlayerTgNick}\n\n" +
               $"Имя - {userData.PlayerName}\n" +
               $"Рейтинг- {userData.PlayerRating}\n" +
               $"Основная позиция- {userData.PlayerPosition}\n";
    }

    public static string ConfirmCreateQuestionnaire(UsersDatum userData)
    {
        return "Подтвердите создание анкеты. Ваши данные:\n " +
               $"Имя - {userData.PlayerName}\n" +
               $"Рейтинг- {userData.PlayerRating}\n" +
               $"Основная позиция- {userData.PlayerPosition}\n" +
               $"Ваш ник tg- {userData.PlayerTgNick}\n";
    }

    public static string TournamentsRules(TournamentsDatum tournData) =>
        $"Вы можете ознакомиться с правилама по данной ссылке: {tournData.TournamentsRules}";

    public const string QuestionnaireDeleted = "Анкета удалена :_(";

    public const string ChangeTournamentData =
        "Введите основную информацию о турнире (вместе со всеми ссылками, в том числе ссылкой на регистрацию):";

    public const string ChangeTournamentRules = "Отправьте ссылку на правила турнира:";

    public const string QuestionnaireDeletedConfirmation = "Вы уверены что хотите удалить анкету ?";

    public const string NewQuestionnaireNameInput = "Давайте познакомимся? Введите ваше имя: ";

    public const string NewQuestionnaireUserTgNickname =
        "Введите ваш nickname тг без @ (впоследствие по нему с вами будут связаваться): ";

    public const string NewQuestionnaireRatingInput = "Введите ваш рейтинг (0-12000) ммр: ";

    public const string NewQuestionnairePosition = "Укажите вашу основную позицию: ";
}