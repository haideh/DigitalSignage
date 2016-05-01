using DigitalSignageUI.AdsServices;
using DigitalSignageUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Mapper
{
    public static class AdsMapper
    {
        internal static List<AdsInfo> MapFrom(AdsInfoWTO[] wtos)
        {
            List<AdsInfo> contentList = new List<AdsInfo>();

            if (wtos != null)
                foreach (AdsInfoWTO c in wtos)
                {
                    contentList.Add(MapFrom(c));
                }

            return contentList;
        }
        internal static AdsInfo MapFrom(AdsInfoWTO ads)
        {
            AutoMapper.Mapper.CreateMap<AdsInfoWTO, AdsInfo>();
            List<AdsIemInfo> listItem = new List<AdsIemInfo>();
            if (ads.itemList != null)
            {
                foreach (AdsIemInfoWTO c in ads.itemList)
                {
                    listItem.Add(MapFrom(c));
                }
            }
            AutoMapper.Mapper.CreateMap<AdsInfoWTO, AdsInfo>();
            AdsInfo wto = AutoMapper.Mapper.Map<AdsInfoWTO, AdsInfo>(ads);
            if (ads.itemList != null)
            {
                wto.itemList = listItem;
            }
            return wto;
        }

        internal static AdsInfoWTO MapTo(AdsInfo ads)
        {
            AutoMapper.Mapper.CreateMap<AdsInfo, AdsInfoWTO>();
            List<AdsIemInfoWTO> listItem = new List<AdsIemInfoWTO>();
            if (ads.itemList != null)
            {
                foreach (AdsIemInfo c in ads.itemList)
                {
                    listItem.Add(MapTo(c));
                }
            }
            AdsInfoWTO wto = AutoMapper.Mapper.Map<AdsInfo, AdsInfoWTO>(ads);
            if (ads.itemList != null)
            {
                wto.itemList = listItem.ToArray();
            }
            return wto;
        }
        internal static AdsIemInfoWTO MapTo(AdsIemInfo ads)
        {
            AutoMapper.Mapper.CreateMap<AdsIemInfo, AdsIemInfoWTO>();
            AdsIemInfoWTO wto = AutoMapper.Mapper.Map<AdsIemInfo, AdsIemInfoWTO>(ads);

            return wto;
        }

        internal static AdsIemInfo MapFrom(AdsIemInfoWTO adsItem)
        {
            AutoMapper.Mapper.CreateMap<AdsIemInfoWTO, AdsIemInfo>();
            AdsIemInfo wto = AutoMapper.Mapper.Map<AdsIemInfoWTO, AdsIemInfo>(adsItem);
            return wto;
        }
    }
}