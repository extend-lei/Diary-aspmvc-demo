using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiaryApp.Controllers
{
	public class DiaryEntriesController(AppDbContext db) : Controller
	{
		private readonly AppDbContext _db = db;

		public IActionResult Index()
		{
			List<DiaryEntry> objDiaryEntryList = _db.DiaryEntries.ToList();
			return View(objDiaryEntryList);
		}

		public IActionResult Create(int? id)
		{
			if (id != null)
			{
				var obj = _db.DiaryEntries.FirstOrDefault(obj => obj.Id == id);
				return View(obj);
			}

			return View();
		}

		[HttpPost]
		public IActionResult Create(DiaryEntry obj)
		{
			if (obj != null && obj.Content.Length < 5)
			{
				ModelState.AddModelError("Content", "Content 不应该小于5个字符");
			}

			if (ModelState.IsValid)
			{
				if (obj.Id == 0)
				{
					_db.DiaryEntries.Add(obj);
				}
				else
				{
					_db.DiaryEntries.Update(obj);
				}

				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(obj);
		}

		public IActionResult Delete(int id)
		{
			var obj = _db.DiaryEntries.FirstOrDefault(obj => obj.Id == id);
			_db.DiaryEntries.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}