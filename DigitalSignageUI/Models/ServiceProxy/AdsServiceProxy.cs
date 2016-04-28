using Aryaban.Engine.Core.WebService;
using DigitalSignageUI.Models.Entity;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigitalSignageUI.AdsServices;

namespace DigitalSignageUI.Models.ServiceProxy
{
    public class AdsServiceProxy
    {
        public ResultMessage<List<AdsInfo>> loadAdsItemListWithType(long AdsType,long companyId, string contentId, string position)
        {

            List<AdsInfo> listContentInfo = new List<AdsInfo>();
            using (AdsServices.IadsClient clientProxy = new AdsServices.IadsClient())
            {
                ResultMessage<AdsInfoWTO[]> serviceResult;

                serviceResult = clientProxy.getAdsWithItemDetail(AdsType.ToString(),companyId ,Convert.ToInt64( contentId), Convert.ToInt32(position));
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
                        listContentInfo = DigitalSignageUI.Models.Mapper.AdsMapper.MapFrom(serviceResult.resultSet);
                        return new ResultMessage<List<AdsInfo>>
                        {
                            resultSet = listContentInfo,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.success,
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
                            }
                        };
                        break;
                }

            }

        }
        public ResultMessage<List<AdsInfo>> loadWidgetAdsItemListWithCompanyId(long companyId)
        {

            List<AdsInfo> listContentInfo = new List<AdsInfo>();
            using (AdsServices.IadsClient clientProxy = new AdsServices.IadsClient())
            {
                ResultMessage<AdsInfoWTO[]> serviceResult;

                serviceResult = clientProxy.getWidgetAdsWithItemDetail(companyId);
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
                        listContentInfo = DigitalSignageUI.Models.Mapper.AdsMapper.MapFrom(serviceResult.resultSet);
                        return new ResultMessage<List<AdsInfo>>
                        {
                            resultSet = listContentInfo,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.success,
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
                            }
                        };
                        break;
                }

            }

        }


    }
}