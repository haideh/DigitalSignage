using DigitalSignageUI.Models.Entity;
using DigitalSignageUI.StoresServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Mapper
{
    public static class StoreMapper
    {
        internal static List<StoresInfo> MapFrom(StoresInfoWTO[] wtos)
        {
            List<StoresInfo> contentList = new List<StoresInfo>();

            if (wtos != null)
                foreach (StoresInfoWTO c in wtos)
                {
                    contentList.Add(MapFrom(c));
                }

            return contentList;
        }
        internal static StoresInfo MapFrom(StoresInfoWTO store)
        {
            AutoMapper.Mapper.CreateMap<StoresInfoWTO, StoresInfo>();
            StoresInfo wto = AutoMapper.Mapper.Map<StoresInfoWTO, StoresInfo>(store);
            return wto;
        }

        internal static StoresInfoWTO MapTo(StoresInfo store)
        {
            AutoMapper.Mapper.CreateMap<StoresInfo, StoresInfoWTO>();
            StoresInfoWTO wto = AutoMapper.Mapper.Map<StoresInfo, StoresInfoWTO>(store);

            return wto;
        }
    }
}