using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public string Login()
        {
            string phone = Request.Form["Phone"];
            string Email = Request.Form["Email"];
            string password = Request.Form["Pwd1"];
            if (Email == "")
            {
                return "<script>alert('邮箱不能为空！');window.history.back(-1);</script>";
            }
            if (phone == "")
            {
                return "<script>alert('手机号码不能为空！');window.history.back(-1);</script>";
            }
            if (password == "")
            {
                return "<script>alert('密码不能为空！');window.history.back(-1);</script>";
            }
            else
            {
                DBCommon.DbHelper helper = new DBCommon.DbHelper();
                string strSql = string.Format("select * from [User] where Mobile='{0}' and password='{1}'", phone, password);
                if (helper.ExecuteScalar(strSql) != null)
                {
                    Session["Phone"] = phone;
                    return "<script>alert('登入成功！'); window.location.href = '/Show/ShowGoods';</script>";
                }
                else
                {
                    return "<script>alert('用户名或者密码错误！'); window.location.href = '/Login/Index';</script>";
                }
            }
        }
    }
}