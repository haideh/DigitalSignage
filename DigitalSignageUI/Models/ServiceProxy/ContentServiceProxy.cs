using DigitalSignageUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigitalSignageUI.ContentsServices;
using DigitalSignageUI.Models.Mapper;
using Aryaban.Engine.Core.WebService;

namespace DigitalSignageUI.Models.ServiceProxy
{
    public class ContentServiceProxy
    {
        public ResultMessage<List<AdsInfo>> loadContent(long content_id)
        {

            List<AdsInfo> listContentInfo = new List<AdsInfo>();
            using (IcontentsClient clientProxy = new IcontentsClient())
            {
                ResultMessage<AdsInfoWTO[]> serviceResult;

                serviceResult = clientProxy.loadContentsWithAdsItemDetail(content_id);
                switch (serviceResult.result.status)
                {
                    case Result.state.error:
                        return new ResultMessage<List<AdsInfo>>
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
                        listContentInfo = ContentMapper.MapFrom(serviceResult.resultSet);
                        return new ResultMessage<List<AdsInfo>>
                        {
                            resultSet = listContentInfo,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.success,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                    default:
                        return new ResultMessage<List<AdsInfo>>
                        {
                            resultSet = null,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.warning,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                }

            }

        }

        public ResultMessage<ContentInfo> getContentInfoByConfig(string IP, string companyName)
        {

            ContentInfo listContentInfo = new ContentInfo();
            using (IcontentsClient clientProxy = new IcontentsClient())
            {
                ResultMessage<ContentInfoWTO> serviceResult;

                serviceResult = clientProxy.searchContentId(IP, companyName);
                switch (serviceResult.result.status)
                {
                    case Result.state.error:
                        return new ResultMessage<ContentInfo>
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
                        listContentInfo = ContentMapper.MapFrom(serviceResult.resultSet);
                        return new ResultMessage<ContentInfo>
                        {
                            resultSet = listContentInfo,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.success,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                    default:
                        return new ResultMessage<ContentInfo>
                        {
                            resultSet = null,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.warning,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                }

            }

        }

        public ResultMessage<List<ContentInfo>> getContentInfoBytvId(ContentInfoWTO filter, ContentsServices.PagingInfo page)
        {

            List<ContentInfo> listContentInfo = new List<ContentInfo>();
            using (IcontentsClient clientProxy = new IcontentsClient())
            {
                ResultMessage<ContentInfoWTO[]> serviceResult;


                serviceResult = clientProxy.searchDataContent(filter, page);
                switch (serviceResult.result.status)
                {
                    case Result.state.error:
                        return new ResultMessage<List<ContentInfo>>
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
                        listContentInfo = ContentMapper.MapFrom(serviceResult.resultSet);
                        return new ResultMessage<List<ContentInfo>>
                        {
                            resultSet = listContentInfo,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.success,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                    default:
                        return new ResultMessage<List<ContentInfo>>
                        {
                            resultSet = null,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.warning,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                }

            }

        }

        public ResultMessage<List<AdsInfo>> searchContentPositionAdsItem(string type, string content_id, string position)
        {

            List<AdsInfo> listContentInfo = new List<AdsInfo>();
            using (IcontentsClient clientProxy = new IcontentsClient())
            {
                ResultMessage<AdsInfoWTO[]> serviceResult;

                serviceResult = clientProxy.searchContentsWithAdsItemDetail(type, Convert.ToInt64(content_id), Convert.ToInt32(position));
                switch (serviceResult.result.status)
                {
                    case Result.state.error:
                        return new ResultMessage<List<AdsInfo>>
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
                        listContentInfo = ContentMapper.MapFrom(serviceResult.resultSet);
                        return new ResultMessage<List<AdsInfo>>
                        {
                            resultSet = listContentInfo,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.success,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                    default:
                        return new ResultMessage<List<AdsInfo>>
                        {
                            resultSet = null,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.warning,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                }

            }

        }

        public ResultMessage<string> editContentAds(ContentOptionInfo contentOptionInfo)
        {
            List<ContentOptionInfo> listContentInfo = new List<ContentOptionInfo>();
            using (IcontentsClient clientProxy = new IcontentsClient())
            {
                ResultMessage<string> serviceResult;


                serviceResult = clientProxy.saveContentAds(ContentMapper.MapTo(contentOptionInfo));
                switch (serviceResult.result.status)
                {
                    case Result.state.error:
                        return new ResultMessage<string>
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
                        return new ResultMessage<string>
                        {
                            resultSet = null,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.success,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                    default:
                        return new ResultMessage<string>
                        {
                            resultSet = null,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.warning,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                }

            }
        }

        public ResultMessage<string> editContentLive(ContentOptionInfo contentOptionInfo)
        {
            List<ContentOptionInfo> listContentInfo = new List<ContentOptionInfo>();
            using (IcontentsClient clientProxy = new IcontentsClient())
            {
                ResultMessage<string> serviceResult;


                serviceResult = clientProxy.editContentOptionLive(ContentMapper.MapTo(contentOptionInfo));
                switch (serviceResult.result.status)
                {
                    case Result.state.error:
                        return new ResultMessage<string>
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
                        return new ResultMessage<string>
                        {
                            resultSet = null,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.success,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                    default:
                        return new ResultMessage<string>
                        {
                            resultSet = null,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.warning,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                }

            }
        }
        public ResultMessage<string> deleteContentAds(long contentId, int position)
        {
            List<ContentOptionInfo> listContentInfo = new List<ContentOptionInfo>();
            using (IcontentsClient clientProxy = new IcontentsClient())
            {
                ResultMessage<string> serviceResult;


                serviceResult = clientProxy.deleteContentsAsdWithPosition(contentId, position);
                switch (serviceResult.result.status)
                {
                    case Result.state.error:
                        return new ResultMessage<string>
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
                        return new ResultMessage<string>
                        {
                            resultSet = null,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.success,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                    default:
                        return new ResultMessage<string>
                        {
                            resultSet = null,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.warning,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                }

            }
        }

    }
}