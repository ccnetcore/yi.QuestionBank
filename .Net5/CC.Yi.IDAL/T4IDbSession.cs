using CC.Yi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Yi.IDAL
{
    public partial interface IDbSession
    {
        IquestionDal questionDal{get;}

        IuserDal userDal{get;}

    }
}