using CC.Yi.Common;
using CC.Yi.IBLL;
using CC.Yi.Model;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Yi.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private IuserBll _userBll;
        private ILogger<AccountController> _logger;
        public AccountController(IuserBll userBll, ILogger<AccountController> logger)
        {
            IsCheck = 0;
            _userBll = userBll;
            _logger = logger;
        }

        [HttpPost]//验证登录
        public async Task<Result> login(user _user)
        {
            var data = await _userBll.GetEntities(u => u.user_name == _user.user_name).AsNoTracking().FirstOrDefaultAsync();

            if (data != null)
            {
                if (data.password == _user.password)
                {
                    HttpContext.Session.SetString("login", JsonHelper.ToString(data));
                    _logger.LogInformation(_user.user_name + "登录成功!");
                    return Result.Success().SetData(data);
                }
            }

            _logger.LogInformation(_user.user_name + "登录失败!");
            return Result.Error("用户或者密码错误!");
        }
        [HttpPost]//退出登入
        public Result logOff()
        {
            var data = HttpContext.Session.GetString("login");
            if (data != null)
            {
                string user_name = JsonHelper.ToJson<user>(data).user_name;
                _logger.LogInformation(user_name + "已退出登录!");
            }
           
            HttpContext.Session.Clear();
            return Result.Success();
        }
        [HttpPost]//判断session是否过期
        public Result Logged()
        {
            var data = HttpContext.Session.GetString("login");

            if (data == null)//表示登入已经过期
            {
                return Result.Error("登录已过期");
            }
            else
            {
                return Result.Success();//session没有过期
            }

        }
        [HttpPost]//注册
        public async Task<Result> Register(user _user)
        {
            var user = await _userBll.GetEntities(u => u.user_name == _user.user_name).FirstOrDefaultAsync();
            if (user == null)
            {
                _user.integral = 1;
                var data = _userBll.Add(_user);
                return Result.Success("注册成功");
            }
            else
            {
                _logger.LogInformation(_user.user_name + "注册失败!");
                return  Result.Error("当前用户已被注册");
            }


        }
    }
}
