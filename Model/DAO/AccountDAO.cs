using Model.Common;
using Model.EF;
using Model.ViewModels.Account;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class AccountDAO
    {

        private static AccountDAO instance;
        private OnlineShopDbContext db;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }

        private AccountDAO()
        {
            db = new OnlineShopDbContext();
        }

        public long Insert(Account entity)
        {
            db.Accounts.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }


        public void Update(AccountEditByAdmin entity)
        {
            try
            {
                Account account = db.Accounts.Find(entity.ID);
                account.ModifiedDate = DateTime.Now;
                //account.Name = entity.Name;
                //account.Address = entity.Address;
                //account.Email = entity.Email;
                account.Status = entity.Status;
                account.ModifiedBy = entity.ModifiedBy;



                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        /// <summary>
        /// result = 0 tài khoản không tồn tại
        /// result = 1 đăng nhập thành công
        /// result = -1 sai mật khẩu
        /// result = -2 tài khoản inactive
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public int Login(string userName, string passWord)
        {
            var result = db.Accounts.SingleOrDefault(a => a.UserName == userName);
            if (result == null)
            {
                return 0; // tài khoản không tồn tại
            }
            else
            {
                if (result.PassWord != passWord)
                {
                    return -1; //tài khoản inactive
                }
                else if (result.Status == false)
                {
                    return -2; // sai mật khẩu
                }
            }
            return 1; // đăng nhập thành công
        }

        public void Delete(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
        }

        public Account GetAccountByUserName(string userName)
        {
            return db.Accounts.SingleOrDefault(p => p.UserName == userName);
        }

        public Account GetAccountByID(int id)
        {
            return db.Accounts.Find(id);
        }

        /// <summary>
        /// lấy danh sách tất cả account
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Account> GetAllAccountPaged(int pageNumber, int pageSize, string searchString, string sortOrder)
        {
            var model = from s in db.Accounts select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(p => p.UserName.ToUpper().Contains(searchString.ToUpper()) || p.Name.ToUpper().Contains(searchString.ToUpper()) || p.Email.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Name_Desc":
                    model = model.OrderByDescending(p => p.Name);
                    break;
                case "UserName_Desc":
                    model = model.OrderByDescending(p => p.UserName);
                    break;
                case "UserName":
                    model = model.OrderBy(p => p.UserName);
                    break;
                case "Email":
                    model = model.OrderBy(p => p.Email);
                    break;
                case "Email_Desc":
                    model = model.OrderByDescending(p => p.Email);
                    break;
                case "Status":
                    model = model.OrderBy(p => p.Status);
                    break;
                case "Status_Desc":
                    model = model.OrderByDescending(p => p.Status);
                    break;
                case "ID_Desc":
                    model = model.OrderByDescending(p => p.ID);
                    break;
                default:
                    model = model.OrderBy(p => p.ID);
                    break;
            }
            return model.ToPagedList(pageNumber, pageSize);
        }

        /// <summary>
        /// thay đổi trạng thái của tài khoản
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ChangeStatus(long id)
        {
            //Lấy ra account cần đổi status 
            var account = db.Accounts.Find(id);

            //thay đổi status của account
            account.Status = !account.Status;

            //lưu thay đổi xuống database
            db.SaveChanges();
        
            return account.Status;
        }


    }
}
