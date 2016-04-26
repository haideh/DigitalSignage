using DigitalSignageUI.AlarmsServices;
using DigitalSignageUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Mapper
{
    public static class AlarmsMapper
    {
        internal static List<AlarmsInfo> MapFrom(AlarmsInfoWTO[] wtos)
        {
            List<AlarmsInfo> contentList = new List<AlarmsInfo>();

            if (wtos != null)
                foreach (AlarmsInfoWTO c in wtos)
                {
                    contentList.Add(MapFrom(c));
                }

            return contentList;
        }
        internal static AlarmsInfo MapFrom(AlarmsInfoWTO alarm)
        {
            AutoMapper.Mapper.CreateMap<AlarmsInfoWTO, AlarmsInfo>();
            AlarmsInfo wto = AutoMapper.Mapper.Map<AlarmsInfoWTO, AlarmsInfo>(alarm);
            return wto;
        }

        internal static AlarmsInfoWTO MapTo(AlarmsInfo alarm)
        {
            AutoMapper.Mapper.CreateMap<AlarmsInfo, AlarmsInfoWTO>();
            AlarmsInfoWTO wto = AutoMapper.Mapper.Map<AlarmsInfo, AlarmsInfoWTO>(alarm);

            return wto;
        }
    }
}