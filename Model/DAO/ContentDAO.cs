using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopModel.DAO
{
    public class ContentDAO
    {
        private OnlineShopDbContext dbContext;

        #region Singletone

        private static ContentDAO instance;

        public static ContentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ContentDAO();
                }
                return instance;
            }
        }

        private ContentDAO()
        {
            dbContext = new OnlineShopDbContext();
        }

        #endregion

        /// <summary>
        /// Get a content by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Content GetByID(long id)
        {
            return dbContext.Contents.Find(id);
        }

        /// <summary>
        /// Insert a new Content to db
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Trả về id của bài viết mới được tạo</returns>
        public long Insert(Content entity)
        {
            dbContext.Contents.Add(entity);
            dbContext.SaveChanges();
            return entity.ID;
        }


        public void Update(Content entity)
        {
            try
            {
                Content model = dbContext.Contents.Find(entity.ID);
                model.ModifiedDate = DateTime.Now;


                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
