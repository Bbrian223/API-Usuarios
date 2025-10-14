using Application.DTOs;
using AutoMapper;
using Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.models
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateModel, User>();
            CreateMap<UserUpdateModel, User>();
            CreateMap<UserDetailModel, User>();
            CreateMap<UserListModel, User>();


            CreateMap<User, UserCreateModel>();
            CreateMap<User, UserUpdateModel>();
            CreateMap<User, UserDetailModel>();
            CreateMap<User, UserListModel>();
        }
    }
}
