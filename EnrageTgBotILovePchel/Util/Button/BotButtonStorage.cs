using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrageTgBotILovePchel.Util.Button
{
    public static class BotButtonsStorage
    {
        public static AdminMainMenu AdminMainMenu { get; } = new();
        public static MainMenu MainMenu { get; } = new();
        public static SearchTeammateMenu SearchTeammateMenu { get; } = new();
    }

    public class SearchTeammateMenu
    {
        public BotButton FirstPos { get; } = new("1", "FirstPos");
        public BotButton SecondPos { get; } = new("2", "SecondPos");
        public BotButton ThirdPos { get; } = new("3", "ThirdPos");
        public BotButton FourthPos { get; } = new("4", "FourthPos");
        public BotButton FifthPos { get; } = new("5", "FifthPos");
        public BotButton PreviousPlayer{ get; } = new("<<", "PreviousPlayer");
        public BotButton NextPlayer { get; } = new(">>", "NextPlayer");
        public BotButton FindTeammate { get; } = new("Найти команду", "FindTeammate");
        public BotButton EditQuestionnaire { get; } = new("Изменить анкету", "EditQuestionnaire");
        public BotButton DeleteQuestionnaire { get; } = new("Удалить анкету", "DeleteQuestionnaire");
        public BotButton Confirm { get; } = new("Подтверждаю", "Confirm");
        public BotButton Cancel { get; } = new("Отменить", "Cancel");
        public BotButton Back { get; } = new("Назад", "Back");
    }

    public class MainMenu
    {
        public BotButton WhenIsNextTournament { get; } = new("Когда следующий турнир ???", "WhenIsNextTournament");
        public BotButton Rules { get; } = new("Правила", "Rules");
        public BotButton FindCommand { get; } = new("Найти команду", "FindTeammate");
    }
    
    public class AdminMainMenu
    {
        public BotButton ChangeTournamentData { get; } = new("Изменить данные следующего турнира", "ChangeTournamentData");
        public BotButton WhenIsNextTournament { get; } = new("Когда следующий турнир ???", "WhenIsNextTournament");
        public BotButton Rules { get; } = new("Правила", "Rules");
        public BotButton FindCommand { get; } = new("Найти команду", "FindTeammate");
    }
}
