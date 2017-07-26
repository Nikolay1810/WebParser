using Parsing.Infrastructure;
using Parsing.Infrastructure.Repository;
using Parsing.Models.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parsing.Controllers.History
{
    public class HistoryController : Controller
    {
        // GET: History
        public ActionResult History()
        {
            var historyWork = new WorkWithContext<HistoryRefreshPrice>();
            var historyList = historyWork.Get();
            return View(historyList);
        }

        public ActionResult HistoryTest(IRepository<HistoryRefreshPrice> repos)
        {
            var historyWork = new WorkWithContext<HistoryRefreshPrice>(repos);
            var historyList = historyWork.Get();
            return View(historyList);
        }
    }
}