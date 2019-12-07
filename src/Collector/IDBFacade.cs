using System.Collections.Generic;

namespace Collector
{
    public interface IDBFacade
    {
        void AddQuestionnaire(Questionnaire questionnaire);
        List<Questionnaire> GetQuestionnaires();
    }
}