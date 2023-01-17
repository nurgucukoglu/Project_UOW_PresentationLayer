using Project_UOW_DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_UOW_DataAccessLayer.UnitOfWork
{
    public class UowDal: IUowDal
    {
        private readonly Context _context;

        public UowDal(Context context)
        {
            _context = context;
        }

        public void Save()   //Save metotunu burda yazdık.
        {
            _context.SaveChanges();
        } 
        //context.in nerden geldiğini EF d e yazıcaz.
    }
}


