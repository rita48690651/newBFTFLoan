using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using newBFTFLoan.Models.EFModels;

namespace newBFTFLoan.Controllers
{
    public class ApplyController : Controller
    {
        private DBModel db = new DBModel();
        // GET: Apply
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (DBModel db = new DBModel())
            {
                List<Loan> empList = db.Loans.ToList<Loan>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Main()//介紹借款流程、須知
        {
            return View();
        }

        public ActionResult Calculate()//貸款試算
        {
            return View();
        }

        public ActionResult Create()//填寫申貸表
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BorrowerId,Principal,InterestRate,NumOfPeriods,Reason,CreationTime")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                db.Loans.Add(loan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loan);
        }

        [HttpGet]//上傳身分證、學生證照(身分驗證)
        public ActionResult Add()
        {
            return View();
        }


        //[HttpPost]
        //public ActionResult Add(Validation imageModel)
        //{
        //    string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
        //    string extension = Path.GetExtension(imageModel.ImageFile.FileName);
        //    fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
        //    imageModel.IdCardPicture = "~/Image/" + fileName;
        //    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
        //    imageModel.ImageFile.SaveAs(fileName);
        //    using (DBModel db = new DBModel())
        //    {
        //        db.Validates.Add = (imageModel);
        //        db.SaveChanges();
        //    }
        //    ModelState.Clear();
        //    return View();
        //}
    }
}