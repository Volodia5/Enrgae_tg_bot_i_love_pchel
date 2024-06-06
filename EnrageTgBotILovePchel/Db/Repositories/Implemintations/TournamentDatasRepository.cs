using EnrageTgBotILovePchel.Db.Models;
using EnrageTgBotILovePchel.Db.Repositories.Interfaces;
using EnrageTgBotILovePchel.Db.DbConnector;

namespace EnrageTgBotILovePchel.Db.Repositories.Implemintations
{
    public class TournamentDatasRepository : ITournamentDatasRepository
    {
        private EnrageBotVovodyaDbContext _dbContext;

        public TournamentDatasRepository(EnrageBotVovodyaDbContext db)
        {
            _dbContext = db;
        }

        public TournamentsDatum GetTournamentsData()
        {
            return _dbContext.TournamentsData.FirstOrDefault();
        }

        public void AddTournament(string tournamentData, string tournamentRules)
        {
            _dbContext.TournamentsData.Add(new TournamentsDatum()
            {
                NextTournamentData = tournamentData,
                TournamentsRules = tournamentRules
            });

            _dbContext.SaveChanges();
        }

        public void UpdateTournamentData(int id, string data)
        {
            TournamentsDatum datum = _dbContext.TournamentsData.Where(x => x.TournId == id).FirstOrDefault();
            datum.NextTournamentData = data;

            _dbContext.Update(datum);
            _dbContext.SaveChanges();
        }

        public void UpdateTournamentRules(int id, string rules)
        {
            TournamentsDatum datum = _dbContext.TournamentsData.Where(x => x.TournId == id).FirstOrDefault();
            datum.TournamentsRules = rules;

            _dbContext.Update(datum);
            _dbContext.SaveChanges();
        }
    }
}