using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web.Mvc;
using MyMVC.Views.First;
using DBCommon;
using System.Text.RegularExpressions;

namespace MyMVC.Controllers
{
    public class FirstController : Controller
    {
        // GET: First
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowValidateCode()
        {
            ValidateCode ValidateCode = new ValidateCode();
            YzmClass yz = new YzmClass();
            string Code = yz.CreateRandomCode(4);
            byte[] image = yz.CreateImage(Code);
            Session["code"] = Code;
            return File(image, "image/jpeg");
        }

        [HttpPost]
        public string Regist()
        {
            string phone = Request.Form["Phone"];
            string username = Request.Form["UserName"];
            string password = Request.Form["Pwd1"];
            string password2 = Request.Form["Pwd2"];
            string code = Request.Form["Yz"].ToLower();
            string Email = Request.Form["Email"];
            if (username == "")
            {
                return "<script>alert('姓名不能为空！');window.history.back(-1);</script>";
            }
          
            if (phone == "")
            {
                return "<script>alert('手机号码不能为空！');window.history.back(-1);</script>";
            }

            if (!Regex.IsMatch(phone, @"^(13|15|18)[0-9]{9}$"))
            {
                return "<script>alert('手机号码有误，请重填！！');window.history.back(-1);</script>";
            }

            if (!Regex.IsMatch(Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                return "<script>alert('邮箱格式有误，请重填！！');window.history.back(-1);</script>";
            }
            if (password == "")
            {
                return "<script>alert('密码不能为空！');window.history.back(-1);</script>";
            }

            if (password != password2)
            {
                return "<script>alert('两次输入的密码不一致！');window.history.back(-1);</script>";
            }
            if (password.Length < 6 || password.Length > 16)
            {
                return "<script>alert('设置登录密码（6-16位数字、字母或符号组成）!');window.history.back(-1);</script>";
            }
            if (code != Session["code"].ToString().ToLower())
            {
                return "<script>alert('验证码错误，请重新输入！');window.history.back(-1);</script>";
            }
            else
            {
                string strSql = string.Format("select Mobile from [User] where Mobile='{0}'", phone);
                DbHelper helper = new DbHelper();
                if (helper.ExecuteScalar(strSql) != null)
                {
                    return "<script>alert('该手机已被注册！');window.history.back(-1); $('#imageYz').attr('src', $('#imageYz').attr('src') + 1); </script>";
                }
                else
                {
                    try
                    {
                        string strSql1 = string.Format("insert into [User](Name,Password,Mobile,CreateTime,Email) values('{0}','{1}','{2}','{3}','{4}')", username, password, phone, DateTime.Now, Email);
                        if (helper.ExecuteNonQuery(strSql1) > 0)
                        {
                            return "<script>alert('注册成功！');window.location.href='/Login/Index'</script>";
                        }
                        else
                        {
                            return "<script>alert('注册失败！');window.history.back(-1);</script>";
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }


    }
}