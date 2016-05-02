using DigitalSignageUI.Models.Entity;
using DigitalSignageUI.PrmissionServices;
using DigitalSignageUI.StoresServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Mapper
{
    public static class UserInfoMapper
    {

        internal static UserInfo MapFrom(UserInfoWTO store)
        {
            AutoMapper.Mapper.CreateMap<UserInfoWTO, UserInfo>();
            UserInfo wto = AutoMapper.Mapper.Map<UserInfoWTO, UserInfo>(store);
            return wto;
        }

        internal static UserInfoWTO MapTo(UserInfo store)
        {
            AutoMapper.Mapper.CreateMap<UserInfo, UserInfoWTO>();
            UserInfoWTO wto = AutoMapper.Mapper.Map<UserInfo, UserInfoWTO>(store);

            return wto;
        }
    }
}