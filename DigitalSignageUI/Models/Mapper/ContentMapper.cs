using DigitalSignageUI.ContentsServices;
using DigitalSignageUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.Mapper
{
    public static class ContentMapper
    {
        internal static List<ContentInfo> MapFrom(ContentInfoWTO[] wtos)
        {
            List<ContentInfo> contentList = new List<ContentInfo>();

            if (wtos != null)
                foreach (ContentInfoWTO c in wtos)
                {
                    contentList.Add(MapFrom(c));
                }

            return contentList;
        }
        internal static ContentInfo MapFrom(ContentInfoWTO content)
        {
            AutoMapper.Mapper.CreateMap<ContentInfoWTO, ContentInfo>();
            ContentInfo wto = AutoMapper.Mapper.Map<ContentInfoWTO, ContentInfo>(content);
            return wto;
        }

        internal static ContentInfoWTO MapTo(ContentInfo content)
        {
            AutoMapper.Mapper.CreateMap<ContentInfo, ContentInfoWTO>();
            ContentInfoWTO wto = AutoMapper.Mapper.Map<ContentInfo, ContentInfoWTO>(content);

            return wto;

        }

        internal static List<ContentOptionInfo> MapFrom(ContentOptionInfoWTO[] wtos)
        {
            List<ContentOptionInfo> contentList = new List<ContentOptionInfo>();

            if (wtos != null)
                foreach (ContentOptionInfoWTO c in wtos)
                {
                    contentList.Add(MapFrom(c));
                }

            return contentList;
        }
        internal static ContentOptionInfo MapFrom(ContentOptionInfoWTO content)
        {
            AutoMapper.Mapper.CreateMap<ContentOptionInfoWTO, ContentOptionInfo>();
            ContentOptionInfo wto = AutoMapper.Mapper.Map<ContentOptionInfoWTO, ContentOptionInfo>(content);
            return wto;
        }

        internal static ContentOptionInfoWTO MapTo(ContentOptionInfo content)
        {
            AutoMapper.Mapper.CreateMap<ContentOptionInfo, ContentOptionInfoWTO>();
            ContentOptionInfoWTO wto = AutoMapper.Mapper.Map<ContentOptionInfo, ContentOptionInfoWTO>(content);

            return wto;

        }

        #region Ads
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

            foreach (AdsIemInfoWTO c in ads.itemList)
            {
                listItem.Add(MapFrom(c));
            }
            AdsInfo wto = AutoMapper.Mapper.Map<AdsInfoWTO, AdsInfo>(ads);
            wto.itemList = listItem;
            return wto;
        }

        internal static AdsIemInfo MapFrom(AdsIemInfoWTO adsItem)
        {
            AutoMapper.Mapper.CreateMap<AdsIemInfoWTO, AdsIemInfo>();
            AdsIemInfo wto = AutoMapper.Mapper.Map<AdsIemInfoWTO, AdsIemInfo>(adsItem);
            return wto;
        }

        internal static AdsInfoWTO MapTo(AdsInfo ads)
        {
            AutoMapper.Mapper.CreateMap<AdsInfo, AdsInfoWTO>();
            AdsInfoWTO wto = AutoMapper.Mapper.Map<AdsInfo, AdsInfoWTO>(ads);

            return wto;
        }
        #endregion
    }
}
