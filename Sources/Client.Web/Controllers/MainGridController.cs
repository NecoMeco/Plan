﻿using System.Linq;
using System.Web.Mvc;
using Common.Data.Core;
using MvcJqGrid;
using Entities;

namespace Client.Web.Controllers
{
    [Attributes.ActionFilters.Localize]
    [Attributes.ActionFilters.AllowAnonymous]
    public class MainGridController : BaseController<MainGridController>
    {
        public const string ListAction = "List";
        private IBaseDao Dao { get; set; }

        public MainGridController(IBaseDao dao)
        {
            Dao = dao;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(GridSettings gridSettings)
        {
            var items = Dao.SelectRange<CashTransfer>(new SelectCondition());

            var jsonData = new
            {
                total = items.ItemsCount / gridSettings.PageSize + 1,
                page = gridSettings.PageIndex,
                records = items.Result.Count,
                rows = items.Result.ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}