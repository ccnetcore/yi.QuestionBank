using CC.Yi.Common;
using CC.Yi.Model;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Yi.API.Controllers
{
    public class BaseController : Controller
    {
        public int IsCheck = 1;//设置是否需要校验用户是否登录属性
        public int loginId = -1;//登入Id
        public int questionId = -1;//问题Id

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            switch (IsCheck)
            {
                case 1:
                    var myUser = HttpContext.Session.GetString("login");
                    if (myUser != null)//表示已经登入过
                    {
                        var data = JsonHelper.ToJson<user>(myUser);
                        loginId = Convert.ToInt32(data.Id);
                        questionId = Convert.ToInt32(data.integral);
                    }
                    else
                    {
                        filterContext.Result = Content(JsonHelper.ToString(Result.Error("登入超时")));
                    }
                    break;
                case 0:
                    return;
            }
        }
    }
}
