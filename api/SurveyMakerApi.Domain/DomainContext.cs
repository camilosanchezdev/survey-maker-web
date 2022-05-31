using SurveyMakerApi.Domain.Repositories;
using SurveyMakerApi.Domain.Repositories.Interfaces;
using SurveyMakerApi.Domain.Services;
using SurveyMakerApi.Domain.Services.Interfaces;

namespace SurveyMakerApi.Domain
{
    public class DomainContext
    {
        public Tuple<Type, Type>[] Repositories => new Tuple<Type, Type>[] {
            new Tuple<Type, Type>(typeof(ISurveyRepository), typeof(SurveyRepository)),
            new Tuple<Type, Type>(typeof(ISurveyStatusesRepository), typeof(SurveyStatusesRepository)),
            new Tuple<Type, Type>(typeof(ISurveyTagsRepository), typeof(SurveyTagsRepository)),
            new Tuple<Type, Type>(typeof(IQuestionsRepository), typeof(QuestionsRepository)),
            new Tuple<Type, Type>(typeof(IAnswersRepository), typeof(AnswersRepository)),
            new Tuple<Type, Type>(typeof(IResponsesRepository), typeof(ResponsesRepository)),
            new Tuple<Type, Type>(typeof(IResponseQuestionsRepository), typeof(ResponseQuestionsRepository)),
            new Tuple<Type, Type>(typeof(IResponseAnswersRepository), typeof(ResponseAnswersRepository)),
            new Tuple<Type, Type>(typeof(IUsersRepository), typeof(UsersRepository)),
        };
        public Tuple<Type, Type>[] Services => new Tuple<Type, Type>[]
        {
            new Tuple<Type, Type>(typeof(ISurveysService), typeof(SurveysService)),
            new Tuple<Type, Type>(typeof(ISurveyStatusesService), typeof(SurveyStatusesService)),
            new Tuple<Type, Type>(typeof(ISurveyTagsService), typeof(SurveyTagsService)),
            new Tuple<Type, Type>(typeof(IQuestionsService), typeof(QuestionsService)),
            new Tuple<Type, Type>(typeof(IAnswersService), typeof(AnswersService)),
            new Tuple<Type, Type>(typeof(IResponsesService), typeof(ResponsesService)),
            new Tuple<Type, Type>(typeof(IResponseQuestionsService), typeof(ResponseQuestionsService)),
            new Tuple<Type, Type>(typeof(IResponseAnswersService), typeof(ResponseAnswersService)),
            new Tuple<Type, Type>(typeof(IReportsService), typeof(ReportsService)),
            new Tuple<Type, Type>(typeof(IUsersService), typeof(UsersService)),
        };
    }
}
