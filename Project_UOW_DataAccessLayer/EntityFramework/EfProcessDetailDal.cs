using Project_UOW_DataAccessLayer.Abstract;
using Project_UOW_DataAccessLayer.Concrete;
using Project_UOW_DataAccessLayer.Repository;
using Project_UOW_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_UOW_DataAccessLayer.EntityFramework
{
    public class EfProcessDetailDal : GenericRepository<ProcessDetail>, IProcessDetailDal
    {
        //her bir entity için efdal sınıfında bu işlem yapılır
        private IServiceProvider _serviceProvider;


        //ctor
        public EfProcessDetailDal(Context context, IServiceProvider serviceProvider) : base(context)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
