using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopModel.DAO
{
    public class ProductDAO
    {
        #region Singleton
        private OnlineShopDbContext db;
        private static ProductDAO instance;

        public static ProductDAO Instance {
            get
            {
                if (instance == null)
                {
                    instance = new ProductDAO();
                }
                return instance;
            }
        }

        private ProductDAO()
        {
            db = new OnlineShopDbContext();
        }
        #endregion

        public IEnumerable<Product> GetAllPaged()
        {
            return db.Products.ToList();
        }

        public int Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }


    }
}
