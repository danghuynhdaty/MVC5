using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopModel.DAO
{
    public class NewsCategoryDAO
    {
        private OnlineShopDbContext dbContext;

        #region Singletone

        private static NewsCategoryDAO instance;

        public static NewsCategoryDAO Instance {
            get
            {
                if (instance == null)
                {
                    instance = new NewsCategoryDAO();
                }
                return instance;
            }
        }

        private NewsCategoryDAO()
        {
            dbContext = new OnlineShopDbContext();
        }

        #endregion

        public List<CategoryNew> GetListCategory()
        {
            return dbContext.CategoryNews.Where(p => p.Status == true).ToList();
        }

    }
}
