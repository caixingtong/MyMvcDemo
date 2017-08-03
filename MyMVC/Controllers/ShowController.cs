using MyMVC.Models;
using MyMVC.Views.Show;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
namespace MyMVC.Controllers
{
    public class ShowController : Controller
    {
        // GET: Show
        /// <summary>
        /// 
        /// </summary>
        /// <param name="质量"></param>
        /// <param name="纹理"></param>
        /// <param name="颜色"></param>
        /// <param name="地域"></param>
        /// <returns></returns>
        public ActionResult Index(string strQuality, string strGrain, string strColor, string strProvinceName)
        {
            int iResult = -1;
            int Id = Int32.TryParse(Request.QueryString["Id"], out iResult) ? iResult : -1;
            if (Id == -1)
            {
                using (DbFirstModel context = new DbFirstModel())
                {
                    Expression<Func<Goods, bool>> lambdaWhere = (t => t.IsEnable == "1");
                    if (strQuality != "材质" && strQuality != null)
                    {
                        //  lambdaWhere = t => t.Quality == strQuality;
                        lambdaWhere = lambdaWhere.And<Goods>(t => t.Quality == strQuality);
                    }
                    if (strGrain != "纹理" && strGrain != null)
                    {
                        lambdaWhere = lambdaWhere.And<Goods>(t => t.Grain == strGrain);
                    }
                    if (strColor != "色系" && strColor != null)
                    {
                        lambdaWhere = lambdaWhere.And<Goods>(t => t.Color == strColor);
                    }
                    if (strProvinceName != "地区" && strProvinceName != null)
                    {
                        lambdaWhere = lambdaWhere.And<Goods>(t => t.ProvinceName == strProvinceName);
                    }
                    List<Goods> goodslist = context.Goods.Where(lambdaWhere).ToList();
                    return View(goodslist);
                }
            }
            else
            {
                using (DbFirstModel context = new DbFirstModel())
                {
                    List<Goods> goodslist = context.Goods.Where(t => t.Id == Id).ToList();
                    return View(goodslist);
                }
            }
        }

        public ActionResult ShowGoods()
        {
            return View();
        }

        public ActionResult Detail()
        {
            int iResult = -1;
            int Id = Int32.TryParse(Request.QueryString["Id"], out iResult) ? iResult : -1;
            using (DbFirstModel context = new DbFirstModel())
            {
                Goods goodsModel = context.Goods.Find(Id);
                return View(goodsModel);
            }
        }


        public int SendOrder(string OrderId)
        {
          
            if (Session["Phone"] != null)
            {
                string strPhone = Session["Phone"].ToString();
                DBCommon.DbHelper helper = new DBCommon.DbHelper();
                string strSql = string.Format("select Email,Name from [User] where mobile='{0}'", strPhone);
                DataTable table = helper.ExecuteDataTable(strSql);
                string strEmail = table.Rows[0][0].ToString();
                string strUserName = table.Rows[0][1].ToString();
                string strContent = string.Format("您的订单:已经下单成功！订单号为:{0}",new Random().Next(1,100000));
                SendEmail(strEmail, strContent);
                return 1;
            }
            else
            {
                return 0;  //下单失败
            }
        }

        public void SendEmail(string strEmail, string strContent)
        {
            var emailAcount = "2636889319@qq.com";
            var emailPassword = "inqeyrnxnemhdiji";
            var reciver = strEmail;
            var content = strContent;
            MailMessage message = new MailMessage();
            //设置发件人,发件人需要与设置的邮件发送服务器的邮箱一致
            MailAddress fromAddr = new MailAddress(emailAcount);
            message.From = fromAddr;
            //设置收件人,可添加多个,添加方法与下面的一样
            message.To.Add(reciver);
            //设置抄送人
            //message.CC.Add("izhaofu@163.com");
            //设置邮件标题
            message.Subject = "Test";
            //设置邮件内容
            message.Body = content;
            //设置邮件发送服务器,服务器根据你使用的邮箱而不同,可以到相应的 邮箱管理后台查看,下面是QQ的
            SmtpClient client = new SmtpClient("smtp.qq.com", 25);
            //设置发送人的邮箱账号和密码
            client.Credentials = new NetworkCredential(emailAcount, emailPassword);
            //启用ssl,也就是安全发送
            client.EnableSsl = true;
            //发送邮件
            client.Send(message);
        }
    }
}