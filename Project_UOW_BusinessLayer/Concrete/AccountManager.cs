using Project_UOW_BusinessLayer.Abstract;
using Project_UOW_DataAccessLayer.Abstract;
using Project_UOW_DataAccessLayer.UnitOfWork;
using Project_UOW_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_UOW_BusinessLayer.Concrete
{
    public class AccountManager : IAccountService
    {

        private readonly IAccountDal _accountDal;
        private readonly IUowDal _uowDal;

        public AccountManager(IAccountDal accountDal, IUowDal uowDal)
        {
            _accountDal = accountDal;
            _uowDal = uowDal;
        }

        public void TDelete(Account t)
        {
            _accountDal.Delete(t);//delete daldan çağırılır.
            _uowDal.Save();//save metodu unit of workten çağırılır.
        }

        public Account TGetByID(int id)
        {
           return _accountDal.GetByID(id);
        }

        public List<Account> TGetList()
        {
            return _accountDal.GetList();
        }

        public void TInsert(Account t)
        {
            _accountDal.Insert(t);
            _uowDal.Save();
        }

        public void TMultiUpdate(List<Account> t)
        {
            //for (int i = 0; i < t.Count; i++)
            //{
            //    if (t[i].AccountBalance > 0)
            //    {
            //        _accountDal.MultiUpdate(t);
            //        _uowDal.Save();

            //    }
            //}
            _accountDal.MultiUpdate(t);
            _uowDal.Save();
        }
        public void TUpdate(Account t)
        {
            _accountDal.Update(t);
            _uowDal.Save();
        }
    }
}
