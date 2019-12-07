using System.Collections.Generic;

namespace Collector
{
    internal class AnswersRepository : IDBFacade
    {
        List<Questionnaire> questionnairesRepo;
        private static AnswersRepository _instance;
        public static AnswersRepository Instance 
        {
            get
            {
                if(_instance is null)
                    _instance = new AnswersRepository();
                
                return _instance;
            }
        }
        private AnswersRepository()
        {
            questionnairesRepo = new List<Questionnaire>();
        }
        public void AddQuestionnaire(Questionnaire questionnaire)
        {
            questionnairesRepo.Add(questionnaire);
        }

        public List<Questionnaire> GetQuestionnaires()
        {
            return questionnairesRepo;
        }
    }
}