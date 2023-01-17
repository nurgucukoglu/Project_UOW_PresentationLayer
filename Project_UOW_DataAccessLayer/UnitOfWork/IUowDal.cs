using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_UOW_DataAccessLayer.UnitOfWork
{
    public interface IUowDal
    {
        //kayıt işlemini tamamlayacak metod
        void Save();
    }
}
