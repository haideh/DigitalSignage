using DigitalSignageUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigitalSignageUI.LiveVideosServices;
using DigitalSignageUI.Models.Mapper;
using Aryaban.Engine.Core.WebService;

namespace DigitalSignageUI.Models.ServiceProxy
{
    public class LiveServiceProxy
    {
        public ResultMessage<List<LiveTVInfo>> loadLiveVedioContent(long content_id, long companyId, int position)
        {

            List<LiveTVInfo> listLiveInfo = new List<LiveTVInfo>();
            using (IliveVideosClient clientProxy = new IliveVideosClient())
            {
                ResultMessage<LiveTVInfoWTO[]> serviceResult;

                serviceResult = clientProxy.loadLivesTvAds(content_id,companyId,position);
                switch (serviceResult.result.status)
                {
                    case Result.state.error:
                        return new ResultMessage<List<LiveTVInfo>>
                        {
                            resultSet = null,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.error,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                    case Result.state.success:
                        listLiveInfo = LiveVideoMapper.MapFrom(serviceResult.resultSet);
                        return new ResultMessage<List<LiveTVInfo>>
                        {
                            resultSet = listLiveInfo,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.success,
                            }
                        };
                        break;
                    default:
                        return new ResultMessage<List<LiveTVInfo>>
                        {
                            resultSet = null,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.warning,
                            }
                        };
                        break;
                }

            }

        }

        public ResultMessage<List<LiveTVInfo>> loadLiveVedio(long content_id)
        {

            List<LiveTVInfo> listLiveInfo = new List<LiveTVInfo>();
            using (IliveVideosClient clientProxy = new IliveVideosClient())
            {
                ResultMessage<LiveTVInfoWTO[]> serviceResult;

                serviceResult = clientProxy.loadLiveContentsAds(content_id);
                switch (serviceResult.result.status)
                {
                    case Result.state.error:
                        return new ResultMessage<List<LiveTVInfo>>
                        {
                            resultSet = null,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.error,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                    case Result.state.success:
                        listLiveInfo = LiveVideoMapper.MapFrom(serviceResult.resultSet);
                        return new ResultMessage<List<LiveTVInfo>>
                        {
                            resultSet = listLiveInfo,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.success,
                            }
                        };
                        break;
                    default:
                        return new ResultMessage<List<LiveTVInfo>>
                        {
                            resultSet = null,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.warning,
                            }
                        };
                        break;
                }

            }

        }

        public ResultMessage<List<LiveTVInfo>> loadContentLiveVedioWithPosition(long content_id, int position)
        {

            List<LiveTVInfo> listLiveInfo = new List<LiveTVInfo>();
            using (IliveVideosClient clientProxy = new IliveVideosClient())
            {
                ResultMessage<LiveTVInfoWTO[]> serviceResult;

                serviceResult = clientProxy.searchContentsWithLiveItem(content_id,position);
                switch (serviceResult.result.status)
                {
                    case Result.state.error:
                        return new ResultMessage<List<LiveTVInfo>>
                        {
                            resultSet = null,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.error,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                    case Result.state.success:
                        listLiveInfo = LiveVideoMapper.MapFrom(serviceResult.resultSet);
                        return new ResultMessage<List<LiveTVInfo>>
                        {
                            resultSet = listLiveInfo,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.success,
                            }
                        };
                        break;
                    default:
                        return new ResultMessage<List<LiveTVInfo>>
                        {
                            resultSet = null,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.warning,
                            }
                        };
                        break;
                }

            }

        }

    }
}