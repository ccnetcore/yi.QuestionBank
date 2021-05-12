using CC.Yi.Common;
using CC.Yi.IBLL;
using CC.Yi.Model;
using CC.Yi.ViewModel;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Yi.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class questionController : BaseController
    {
        private readonly ILogger<questionController> _logger;//处理日志相关文件


        private IquestionBll _questionBll;
        private IuserBll _userBll;
        public questionController(ILogger<questionController> logger, IquestionBll questionBll, IuserBll userBll)
        {

            _logger = logger;
            _questionBll = questionBll;
            _userBll = userBll;
        }

        [HttpGet]
        public async Task<Result> GetById(int Id)//根据Id来得到题目
        {
            var data = await _questionBll.GetEntities(u => u.Id == Id).FirstOrDefaultAsync();
            return Result.Success("查询成功").SetData(data);
        }

        [HttpGet]
        public async Task<Result> GetQuestion()//根据已经登录得用户得到问题
        {
            return await GetById(questionId);
        }

        [HttpGet]
        public async Task<Result> Effectiveness(char answer)//效验答案
        {
            var myQuestion = (question)(await GetQuestion()).data;
            if (myQuestion.answer == answer)
            {
                var myUser = await _userBll.GetEntities(u => u.Id == loginId).FirstOrDefaultAsync();
                myUser.integral += 1;
                if (_userBll.Update(myUser))
                {
                    HttpContext.Session.SetString("login", JsonHelper.ToString(myUser));//更新session
                    //user的积分添加1
                    return Result.Success().SetData(1);
                }
            }
            return Result.Success().SetData(0);
        }

        [HttpPost]
        public Result GetAll(page pageData, string where)
        {
            int res = 0;
            var data = _questionBll.GetPageEntities(pageData.pageSize, pageData.pageIndex, out int totol, u => (int.TryParse(where, out res) ? u.Id == res : true), u => u.Id, true).ToList();
            var myData = (from u in data
                          select new
                          {
                              u.Id,
                              u.subject,
                              u.type,
                              u.difficulty,
                              u.question_a,
                              u.question_b,
                              u.question_c,
                              u.question_d,
                              u.answer
                          }).ToList();
            return Result.Success().SetData(new { mydata = myData, totol = totol });

        }
        [HttpGet]
        public async Task<Result> Last()
        {
            var myUser = await _userBll.GetEntities(u => u.Id == loginId).FirstOrDefaultAsync();
            if (myUser.integral > 1)
            {
                myUser.integral -= 1;
            }
            if (_userBll.Update(myUser))
            {
                HttpContext.Session.SetString("login", JsonHelper.ToString(myUser));
                return Result.Success().SetData(1);
            }
            else
            {
                return Result.Success().SetData(0);
            }
        }
    }
}

