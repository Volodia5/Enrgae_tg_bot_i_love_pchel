using EnrageTgBotILovePchel.Db.Models;

namespace EnrageTgBotILovePchel.Util.String;

public class DialogsStringsStorage
{
    public const string CommandStartInputErrorInput = "Команда не распознана. Для начала работы с ботом введите /start";

    public const string MainMenu = "Выберите действие:";

    public const string NameInputError = "Длина вашего имени не может превышать 25 символов\n\n";

    public const string RatingInputError = "Укажите рейтинг в пределах от 0 до 12000 (ммр)\n\n";

    public const string PositionInputError = "Ваша позиция должна быть от 1 до 5";

    public const string NicknameInputError = "Ваш никнейм не может привышать 30 символов\n\n";

    public const string UserInformationInputError = "Ваше описание не может привышать 4000 символов\n\n";

    public const string QuestionnaireCreateSuccess = "Анкета создана успешно!";

    public const string QuestionnaireUpdateSuccess = "Анкета успешно обновлена!";

    public static string UserQuestionnaire(UsersDatum userData)
    {
        return "Ваша анкета:\n\n" +
               $"Имя - {userData.PlayerName}\n" +
               $"Рейтинг- {userData.PlayerRating}\n" +
               $"Основная позиция- {userData.PlayerPosition}\n" +
               $"Ваш ник tg- {userData.PlayerTgNick}\n" +
               $"Ваше описание - {userData.PlayerDescription}\n";
    }

    public static string FindingTeammate(UsersDatum userData)
    {
        return $"Aнкета пользователя: {userData.PlayerTgNick}\n\n" +
               $"Имя - {userData.PlayerName}\n" +
               $"Рейтинг- {userData.PlayerRating}\n" +
               $"Основная позиция- {userData.PlayerPosition}\n" +
               $"О пользователе - {userData.PlayerDescription}\n";
    }

    public static string ConfirmCreateQuestionnaire(UsersDatum userData)
    {
        return "Подтвердите создание анкеты. Ваши данные:\n " +
               $"Имя - {userData.PlayerName}\n" +
               $"Рейтинг- {userData.PlayerRating}\n" +
               $"Основная позиция- {userData.PlayerPosition}\n" +
               $"Ваш ник tg- {userData.PlayerTgNick}\n" +
               $"Ваше описание - {userData.PlayerDescription}\n";
    }

    public static string TournamentsRules =>
        $"Вы можете ознакомиться с правилама в данном файле";

    public const string QuestionnaireDeleted = "Анкета удалена :_(";

    public const string ChangeTournamentData =
        "Введите основную информацию о турнире (вместе со всеми ссылками, в том числе ссылкой на регистрацию):";

    //public const string ChangeTournamentRules = "Отправьте ссылку на правила турнира:";

    public const string QuestionnaireDeletedConfirmation = "Вы уверены что хотите удалить анкету ?";

    public const string NewQuestionnaireNameInput = "Давайте познакомимся?! Введите ваше имя: ";

    public const string NewQuestionnaireUserTgNickname =
        "Введите ваш nickname тг в формате @122345(впоследствии по нему с вами будут связываться): ";

    public const string NewQuestionnaireRatingInput = "Введите ваш рейтинг (0-12000) ммр: ";

    public const string NewQuestionnairePosition = "Укажите вашу основную позицию: ";

    public const string NewUserInformation =
        "Расскажите о себе (действительно важная информация, которая поможет найти команду): ";
}