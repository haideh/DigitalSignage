using DigitalSignageUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigitalSignageUI.PrmissionServices;
using Aryaban.Engine.Core.WebService;
using DigitalSignageUI.Models.Mapper;

namespace DigitalSignageUI.Models.ServiceProxy
{
    public class PermissionServiceProxy
    {
        public ResultMessage<string> login(UserInfo userInfo)
        {

            using (IpermissionClient clientProxy = new IpermissionClient())
            {
                ResultMessage<UserInfoWTO> serviceResult;

                serviceResult = clientProxy.login(UserInfoMapper.MapTo(userInfo));
             
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
                        UserInfo user = UserInfoMapper.MapFrom(serviceResult.resultSet);
                        SessionManage.setUserSession(user);
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

        public ResultMessage<string> signUp(UserInfo userInfo)
        {

            using (IpermissionClient clientProxy = new IpermissionClient())
            {
                ResultMessage<UserInfoWTO> serviceResult;

                serviceResult = clientProxy.signup(UserInfoMapper.MapTo(userInfo));

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
                        UserInfo user = UserInfoMapper.MapFrom(serviceResult.resultSet);
                        SessionManage.setUserSession(user);
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

        public ResultMessage<bool> changePassword(UserInfo userInfo, string OldPass, string NewPass, string ReNewPass)
        {

            using (IpermissionClient clientProxy = new IpermissionClient())
            {
                ResultMessage<bool> serviceResult;

                serviceResult = clientProxy.ChangePassword(userInfo.id,  OldPass,  NewPass,  ReNewPass);

                switch (serviceResult.result.status)
                {
                    case Result.state.error:
                        return new ResultMessage<bool>
                        {
                            resultSet = false,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.error,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                    case Result.state.success:
                       
                        return new ResultMessage<bool>
                        {
                            resultSet = true,
                            result = new Result()
                            {
                                status = Aryaban.Engine.Core.WebService.Result.state.success,
                                message = serviceResult.result.message
                            }
                        };
                        break;
                    default:
                        return new ResultMessage<bool>
                        {
                            resultSet = true,
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