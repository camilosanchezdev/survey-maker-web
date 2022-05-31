using SurveyMakerApi.Domain.DTOs;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Mapper
{
    public class Mapper : AutoMapper.Profile
    {
        public Mapper()
        {
            CreateMap<Survey, SurveyDto>()
                .ForMember(dest => dest.SurveyTags, opt => opt.MapFrom(src => src.SurveyTags.Select(x => x.Name)))
                .ForMember(dest => dest.Questions, opt => opt.Ignore())

                .ForMember(dest => dest.Questions,
                opt => opt.MapFrom(src => src.Questions
                .Select(x => new QuestionDTO { Id = x.Id, Name = x.Name, Multiple = x.Multiple, Answers = x.Answers.Select(x => new AnswerDto { Id = x.Id, Name = x.Name}).ToList() })));


            CreateMap<SurveyInputDTO, Survey>().ForMember(dest => dest.SurveyTags, opt => opt.Ignore())
                .ForMember(dest => dest.Questions, opt => opt.Ignore());
            CreateMap<QuestionInputDto, Question>()
                .ForMember(dest => dest.Answers, opt => opt.Ignore());
            CreateMap<AnswerInputDto, Answer>();

            CreateMap<User, UserDTO>().ForMember(dest => dest.UserId, opt => opt.MapFrom(x => x.Id));

        }
    }
}
