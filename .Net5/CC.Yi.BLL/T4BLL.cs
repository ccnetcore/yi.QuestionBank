
using CC.Yi.IBLL;
using CC.Yi.IDAL;
using CC.Yi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Yi.BLL
{
    public partial class questionBll : BaseBll<question>, IquestionBll
        {
            public questionBll(IBaseDal<question> cd):base(cd)
            {
                CurrentDal = cd;
            }
        }
    public partial class userBll : BaseBll<user>, IuserBll
        {
            public userBll(IBaseDal<user> cd):base(cd)
            {
                CurrentDal = cd;
            }
        }
}