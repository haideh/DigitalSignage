
using DigitalSignageUI.LiveVideosServices;
using DigitalSignageUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Mapper
{
    public static class LiveVideoMapper
    {
        internal static List<LiveTVInfo> MapFrom(LiveTVInfoWTO[] wtos)
        {
            List<LiveTVInfo> contentList = new List<LiveTVInfo>();

            if (wtos != null)
                foreach (LiveTVInfoWTO c in wtos)
                {
                    contentList.Add(MapFrom(c));
                }

            return contentList;
        }

        internal static LiveTVInfoWTO[] MapTo(List<LiveTVInfo> content)
        {
            List<LiveTVInfoWTO> wtos = new List<LiveTVInfoWTO>();

            foreach (var item in content)
            {
                wtos.Add((MapTo(item)));
            }

            return wtos.ToArray();

        } 
        internal static LiveTVInfo MapFrom(LiveTVInfoWTO liveVideo)
        {
            AutoMapper.Mapper.CreateMap<LiveTVInfoWTO, LiveTVInfo>();
            LiveTVInfo wto = AutoMapper.Mapper.Map<LiveTVInfoWTO, LiveTVInfo>(liveVideo);
            return wto;
        }

        internal static LiveTVInfoWTO MapTo(LiveTVInfo liveVideo)
        {
            AutoMapper.Mapper.CreateMap<LiveTVInfo, LiveTVInfoWTO>();
            LiveTVInfoWTO wto = AutoMapper.Mapper.Map<LiveTVInfo, LiveTVInfoWTO>(liveVideo);

            return wto;
        }
    }
}