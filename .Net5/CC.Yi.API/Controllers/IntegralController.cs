using CC.Yi.IBLL;
using CC.Yi.Model;
using CC.Yi.ViewModel;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CC.Yi.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class IntegralController : Controller
    {
        private IuserBll _userBll;
        public IntegralController(IuserBll userBll)
        {
            _userBll = userBll;
        }

        //public async Task<Result> GetMyTop()
        //{ 
        
        //}
        [HttpPost]
        public Result GetTop(page pageData)
        {
            
           var data= _userBll.GetPageEntities(pageData.pageSize, pageData.pageIndex, out int totol,u=>u.Id>0, u=>u.integral, false).ToList();
           var myData = (from u in data
                    select new
                    {
                        u.Id,
                        u.user_name,
                        u.integral
                    }).ToList();
            return Result.Success().SetData(myData);

        }
    }
}
