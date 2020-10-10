using AutoMapper;
using Project.OnlineQA.Dto.Concrete;
using Project.OnlineQA.Entities.Concrete;
using Project.OnlineQA.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.OnlineQA.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserAddDto, User>();
            CreateMap<User, UserAddDto>();
            CreateMap<QuestionAddDto, Question>();
            CreateMap<Question, QuestionAddDto>();
            CreateMap<CommentAddDto, Comment>();
            CreateMap<Comment, CommentAddDto>();
            CreateMap<SelectionAddDto, Selection>();
            CreateMap<Selection, SelectionAddDto>();
            CreateMap<QuestionListModel, Question>();
            CreateMap<Question, QuestionListModel>();
            CreateMap<SelectionListModel, Selection>();
            CreateMap<Selection, SelectionListModel>();
            CreateMap<User, UserListModel>();
            CreateMap<UserListModel, User>();
            CreateMap<Comment, CommentListModel>();
            CreateMap<CommentListModel, Comment>();



        }
    }
}
