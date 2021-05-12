using CC.Yi.DAL;
using CC.Yi.IDAL;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CC.Yi.DALFactory
{
    public partial class StaticDalFactory
    {
        public static IquestionDal GetquestionDal()
        {
            IquestionDal Data = CallContext.GetData("questionDal") as IquestionDal;
            if (Data == null)
            {
                Data = new questionDal();
                CallContext.SetData("questionDal", Data);
            }
            return Data;
        }

        public static IuserDal GetuserDal()
        {
            IuserDal Data = CallContext.GetData("userDal") as IuserDal;
            if (Data == null)
            {
                Data = new userDal();
                CallContext.SetData("userDal", Data);
            }
            return Data;
        }

    }
}