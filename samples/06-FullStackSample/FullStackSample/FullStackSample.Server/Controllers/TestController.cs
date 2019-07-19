using FullStackSample.DomainLayer.ServicesImpl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FullStackSample.Server.Controllers
{
	public class TestController : Controller
	{
		readonly FullStackDbContext DbContext;

		public TestController(FullStackDbContext dbContext)
		{
			DbContext = dbContext;
		}

		public async Task<IActionResult> Index()
		{
		int count = await DbContext.Products.CountAsync();
			return View();
		}
	}
}