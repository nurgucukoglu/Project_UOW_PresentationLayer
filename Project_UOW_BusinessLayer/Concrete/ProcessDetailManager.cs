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
    public class ProcessDetailManager : IProcessDetailService
    {
        private readonly IProcessDetailDal _processdetailDal;
        private readonly IUowDal _uowDal;

        public ProcessDetailManager(IProcessDetailDal processdetailDal, IUowDal uowDal)
        {
            _processdetailDal = processdetailDal;
            _uowDal = uowDal;
        }

        public void TDelete(ProcessDetail t)
        {
           _processdetailDal.Delete(t);
            _uowDal.Save();
        }

        public ProcessDetail TGetByID(int id)
        {
            return _processdetailDal.GetByID(id);
        }

        public List<ProcessDetail> TGetList()
        {
            return _processdetailDal.GetList();
        }

        public void TInsert(ProcessDetail t)
        {
            _processdetailDal.Insert(t);
            _uowDal.Save();
        }

        public void TMultiUpdate(List<ProcessDetail> t)
        {
           _processdetailDal.MultiUpdate(t);
        }

        public void TUpdate(ProcessDetail t)
        {
            _processdetailDal.Update(t);
            _uowDal.Save();
        }
    }
}
