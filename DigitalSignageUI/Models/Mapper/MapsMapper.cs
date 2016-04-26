using DigitalSignageUI.MapsServices;
using DigitalSignageUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Mapper
{
    public static class MapsMapper
    {
        internal static List<MapsInfo> MapFrom(MapsInfoWTO[] wtos)
        {
            List<MapsInfo> contentList = new List<MapsInfo>();

            if (wtos != null)
                foreach (MapsInfoWTO c in wtos)
                {
                    contentList.Add(MapFrom(c));
                }

            return contentList;
        }
        internal static MapsInfo MapFrom(MapsInfoWTO map)
        {
            AutoMapper.Mapper.CreateMap<MapsInfoWTO, MapsInfo>();
            MapsInfo wto = AutoMapper.Mapper.Map<MapsInfoWTO, MapsInfo>(map);
            return wto;
        }

        internal static MapsInfoWTO MapTo(MapsInfo map)
        {
            AutoMapper.Mapper.CreateMap<MapsInfo, MapsInfoWTO>();
            MapsInfoWTO wto = AutoMapper.Mapper.Map<MapsInfo, MapsInfoWTO>(map);

            return wto;
        }
    }
}