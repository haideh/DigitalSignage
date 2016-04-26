using DigitalSignageUI.Models.Entity;
using DigitalSignageUI.TvsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Mapper
{
    public static class TvMapper
    {
        internal static List<TvsInfo> MapFrom(TvsInfoWTO[] wtos)
        {
            List<TvsInfo> contentList = new List<TvsInfo>();

            if (wtos != null)
                foreach (TvsInfoWTO c in wtos)
                {
                    contentList.Add(MapFrom(c));
                }

            return contentList;
        }
        internal static TvsInfo MapFrom(TvsInfoWTO tv)
        {
            AutoMapper.Mapper.CreateMap<TvsInfoWTO, TvsInfo>();
            TvsInfo wto = AutoMapper.Mapper.Map<TvsInfoWTO, TvsInfo>(tv);
            return wto;
        }

        internal static TvsInfoWTO MapTo(TvsInfo tv)
        {
            AutoMapper.Mapper.CreateMap<TvsInfo, TvsInfoWTO>();
            TvsInfoWTO wto = AutoMapper.Mapper.Map<TvsInfo, TvsInfoWTO>(tv);

            return wto;
        }
    }
}