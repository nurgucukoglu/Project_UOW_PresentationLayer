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
    public class EfAccountDal:GenericRepository<Account>, IAccountDal  
    {
        //Generic Repository içinde context alan constructor olduğundan 
        //o constructor burada da tanımlanır
        public EfAccountDal(Context context) : base(context)
        {
            //constructor burada base class alıyor


        }
    }
}
