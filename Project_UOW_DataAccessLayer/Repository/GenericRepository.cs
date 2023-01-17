using Project_UOW_DataAccessLayer.Abstract;
using Project_UOW_DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_UOW_DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly Context _context;  //normlade burda const dönmemiştik, DI yoğun kullandığımız için burda döndük.

        public GenericRepository(Context context)
        {
            _context = context;
        }

        //savechanges başka bir metota yazıp ordan çağırılacak.
        //context.savechanges'leri async ve sync olarak yazabilmek için
        //burada değil ayrı bir sınıfta yazıp burada çağırarak yazarım.
        public void Delete(T t)
        {
            _context.Remove(t);
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            _context.Add(t);
        }

        public void MultiUpdate(List<T> t)
        {
            _context.UpdateRange(t);//updaterange metodu ile
                                    //Listeden gelen tüm elemanları günceller
                                    //Unit of work kullanımı ile 
        }

        public void Update(T t)
        {
            _context.Update(t);
        }
    }
}
