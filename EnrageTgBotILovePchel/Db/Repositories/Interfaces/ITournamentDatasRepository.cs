using EnrageTgBotILovePchel.Db.Models;

namespace EnrageTgBotILovePchel.Db.Repositories.Interfaces
{
    public interface ITournamentDatasRepository
    {
        TournamentsDatum GetTournamentsData();
        void AddTournament(string tournamentData, string tournamentRules);
        void UpdateTournamentData(int id, string data);
        void UpdateTournamentRules(int id, string rules);
    }
}
