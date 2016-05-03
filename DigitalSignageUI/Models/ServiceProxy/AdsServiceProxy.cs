using Aryaban.Engine.Core.WebService;
using DigitalSignageUI.Models.Entity;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigitalSignageUI.AdsServices;
using DigitalSignageUI.Models.Mapper;

namespace DigitalSignageUI.Models.ServiceProxy
{
    public class AdsServiceProxy
    {
        public ResultMessage<List<AdsInfo>> loadAdsItemListWithType(long AdsType, long companyId, string contentId, string position)
        {

            List<AdsInfo> listContentInfo = new List<AdsInfo>();
            using (AdsServices.IadsClient clientProxy = new AdsServices.IadsClient())
            {
                ResultMessage<AdsInfoWTO[]> serviceResult;

                serviceResult = clientProxy.getAdsWithItemDetail(AdsType.ToString(), companyId, Convert.ToInt64(contentId), Convert.ToInt32(position));
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

        public ResultMessage<string> saveAds(AdsInfo adsInfo)
        {
            using (IadsClient clientProxy = new IadsClient())
            {
                ResultMessage<string> serviceResult;


                serviceResult = clientProxy.saveAds(AdsMapper.MapTo(adsInfo));
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
                            }
                        };
                        break;
                }

            }
        }
        public void uploadFile(byte[] stream, string filename)
        {
            using (IadsClient clientProxy = new IadsClient())
            {

                clientProxy.UploadFile(stream, filename);

            }
        }

        public ResultMessage<List<AdsInfo>> getAdsList(long companyId)
        {
            using (IadsClient clientProxy = new IadsClient())
            {
                ResultMessage<AdsServices.AdsInfoWTO[]> serviceResult;


                serviceResult = clientProxy.getAllAdsWithItemDetail(companyId);
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
                        return new ResultMessage<List<AdsInfo>>
                        {
                            resultSet = AdsMapper.MapFrom(serviceResult.resultSet),
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


        public ResultMessage<bool> deleteFile(string filename)
        {
            try
            {
                using (IadsClient clientProxy = new IadsClient())
                {
                    clientProxy.deleteAdsFile(filename);
                }
                return new ResultMessage<bool>
                {
                    resultSet = true,
                    result = new Result()
                    {
                        status = Aryaban.Engine.Core.WebService.Result.state.error
                    }
                };
            }
            catch (Exception)
            {
                return new ResultMessage<bool>
                {
                    resultSet = false,
                    result = new Result()
                    {
                        status = Aryaban.Engine.Core.WebService.Result.state.error
                    }
                };

            }

        }

        public ResultMessage<string> deleteAdsWithdetail(long id)
        {
            try
            {
                using (IadsClient clientProxy = new IadsClient())
                {
                    clientProxy.deleteAdsWithDetail(id);
                }
                return new ResultMessage<string>
                {
                    resultSet = "success",
                    result = new Result()
                    {
                        status = Aryaban.Engine.Core.WebService.Result.state.error
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResultMessage<string>
                {
                    resultSet = ex.Message,
                    result = new Result()
                    {
                        status = Aryaban.Engine.Core.WebService.Result.state.error
                    }
                };

            }

        }

        public ResultMessage<AdsInfo> editAdsWithDetail(long id)
        {
            using (IadsClient clientProxy = new IadsClient())
            {
                ResultMessage<AdsInfoWTO> serviceResult;


                serviceResult = clientProxy.editAdsWithDetail(id);
                switch (serviceResult.result.status)
                {
                    case Result.state.error:
                        return new ResultMessage<AdsInfo>
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
                        return new ResultMessage<AdsInfo>
                        {
                            resultSet = AdsMapper.MapFrom(serviceResult.resultSet),
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.success,
                            }
                        };
                        break;
                    default:
                        return new ResultMessage<AdsInfo>
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