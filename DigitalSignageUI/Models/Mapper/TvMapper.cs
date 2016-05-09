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



        internal static List<TvContentsInfo> MapFrom(TvContentsInfoWTO[] wtos)
        {
            List<TvContentsInfo> contentList = new List<TvContentsInfo>();

            if (wtos != null)
                foreach (TvContentsInfoWTO c in wtos)
                {
                    contentList.Add(MapFrom(c));
                }

            return contentList;
        }
        internal static TvContentsInfo MapFrom(TvContentsInfoWTO tv)
        {
            AutoMapper.Mapper.CreateMap<TvContentsInfoWTO, TvContentsInfo>();
            TvContentsInfo wto = AutoMapper.Mapper.Map<TvContentsInfoWTO, TvContentsInfo>(tv);
            wto.rootAddress = System.Web.HttpContext.Current.Request.PhysicalApplicationPath;
            return wto;
        }


        internal static TvContentsInfoWTO[] MapTo(List<TvContentsInfo> content)
        {
            List<TvContentsInfoWTO> wtos = new List<TvContentsInfoWTO>();

            foreach (var item in content)
            {
                wtos.Add((MapTo(item)));
            }

            return wtos.ToArray();

        }
        internal static TvContentsInfoWTO MapTo(TvContentsInfo tv)
        {
            AutoMapper.Mapper.CreateMap<TvContentsInfo, TvContentsInfoWTO>();
            TvContentsInfoWTO wto = AutoMapper.Mapper.Map<TvContentsInfo, TvContentsInfoWTO>(tv);

            return wto;
        }
    }
}