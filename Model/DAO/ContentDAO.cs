using Model.EF;
using PagedList;
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
        public Content GetByID(int id)
        {
            return dbContext.Contents.Find(id);
        }

        /// <summary>
        /// Insert a new Content to db
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Trả về id của bài viết mới được tạo</returns>
        public int Insert(Content entity)
        {
            dbContext.Contents.Add(entity);
            dbContext.SaveChanges();
            return entity.ID;
        }

        /// <summary>
        /// cập nhật bài viết
        /// </summary>
        /// <param name="entity"></param>
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

        /// <summary>
        /// lấy danh sách bài viết + phân trang
        /// </summary>
        public IEnumerable<Content> GetAllContentPaged(int pageNumber, int pageSize, string searchString, string sortOrder)
        {
            var model = from c in dbContext.Contents select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(p => p.Name.ToUpper().Contains(searchString.ToUpper()) ||
                                         p.ID.ToString().ToUpper().Contains(searchString.ToUpper()) ||
                                         p.Description.ToUpper().Contains(searchString.ToUpper())
                );
            }

            switch (sortOrder)
            {
                #region Sort by name
                case "Name":
                    model = model.OrderBy(p => p.Name);
                    break;
                case "Name_Desc":
                    model = model.OrderByDescending(p => p.Name);
                    break;
                #endregion

                #region Sort by status
                case "Status":
                    model = model.OrderBy(p => p.Status);
                    break;
                case "Status_Desc":
                    model = model.OrderByDescending(p => p.Status);
                    break;
                #endregion

                #region Sort by description
                case "Description":
                    model = model.OrderBy(p => p.Description);
                    break;
                case "Description_Desc":
                    model = model.OrderByDescending(p => p.Description);
                    break;
                #endregion

                #region Sort by ID
                case "ID_Desc":
                    model = model.OrderByDescending(p => p.ID);
                    break;
                default:
                    model = model.OrderBy(p => p.ID);
                    break;
                    #endregion
            }
            return model.ToPagedList(pageNumber, pageSize);
        }

        public void Delete(int ID)
        {
            var entity = dbContext.Contents.Find(ID);
            dbContext.Contents.Remove(entity);

            dbContext.SaveChanges();
        }

        public bool ChangeStatus(int id)
        {
            var entity = dbContext.Contents.Find(id);
            entity.Status = !entity.Status;
            dbContext.SaveChanges();

            return entity.Status;

        }
    }
}
