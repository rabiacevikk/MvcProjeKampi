using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Concrete.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace MvcCampProject.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
         Context context = new Context();

        public ActionResult Index()
        {
            var totalCategory = context.Categories.Count().ToString();
            ViewBag.category = totalCategory;

            var totalSoftwareHeading = context.Headings.Count(x => x.CategoryID == 6);
            ViewBag.software = totalSoftwareHeading;

            int writerAtotal = context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.writer = writerAtotal;


            var mostHeading = context.Categories.Where(c => c.CategoryID == context.Headings.GroupBy(h => h.HeadingID).OrderByDescending(h => h.Count()).Select(h => h.Key).FirstOrDefault()).Select(h => h.CategoryName).FirstOrDefault();
            ViewBag.heading = mostHeading;

            var categoryDifference = (context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(x => x.CategoryStatus == false));
            ViewBag.difference = categoryDifference;

            return View();

        }
    }
}