using Aryaban.Engine.Core.WebService;
using DigitalSignageUI.Models.Entity;
using DigitalSignageUI.Models.Mapper;
using DigitalSignageUI.TvsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalSignageUI.Models.ServiceProxy
{
    public class TvProxy
    {
        public ResultMessage<TvsInfo> isDirty(long tv_Id)
        {

            using (ItvsClient clientProxy = new ItvsClient())
            {
                ResultMessage<TvsInfoWTO> serviceResult;


                serviceResult = clientProxy.isDirty(tv_Id);
                TvsInfo tv = new TvsInfo();
                tv.isDirty = 0;
                switch (serviceResult.result.status)
                {

                    case Result.state.error:

                        return new ResultMessage<TvsInfo>
                        {
                            resultSet = tv,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.error,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                    case Result.state.success:
                        return new ResultMessage<TvsInfo>
                        {
                            resultSet = TvMapper.MapFrom(serviceResult.resultSet),
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.success,
                            }
                        };
                        break;
                    default:
                        return new ResultMessage<TvsInfo>
                        {
                            resultSet = tv,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.warning,
                            }
                        };
                        break;
                }

            }
        }

        public ResultMessage<List<TvContentsInfo>> getTvInfoById(string key)
        {

            List<TvContentsInfo> listTvInfo = new List<TvContentsInfo>();
            using (ItvsClient clientProxy = new ItvsClient())
            {
                ResultMessage<TvContentsInfoWTO[]> serviceResult;


                serviceResult = clientProxy.getTvInfo(key);
                switch (serviceResult.result.status)
                {
                    case Result.state.error:
                        return new ResultMessage<List<TvContentsInfo>>
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
                        listTvInfo = TvMapper.MapFrom(serviceResult.resultSet);
                        return new ResultMessage<List<TvContentsInfo>>
                        {
                            resultSet = listTvInfo,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.success,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                    default:
                        return new ResultMessage<List<TvContentsInfo>>
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