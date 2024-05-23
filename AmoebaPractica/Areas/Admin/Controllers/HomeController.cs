using AmoebaPractica.DAL;
using AmoebaPractica.Models;
using AmoebaPractica.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmoebaPractica.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class HomeController(AmoebaContext _context) : Controller
	{

		public async Task<IActionResult> Index()
		{
			return View(await _context.Teams.ToListAsync());
		}
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateTeamVM vm)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);
			await _context.Teams.AddAsync(new Team
			{
				Fullname = vm.Fullname,
				Position = vm.Position,
				ImageUrl = vm.ImageUrl,
				Icons = vm.Icons,
				Description = vm.Description,
			});
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Update(int? id)
		{
			if (id == null || id < 1) return BadRequest();
			var fd =await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
			if (fd == null) return NotFound();
			return View(fd);
		}
		[HttpPost]
		public async Task<IActionResult> Update(int? id ,CreateTeamVM vm)
		{
			if (id == null || id < 1) return BadRequest();
			var fd = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
			if (fd == null) return NotFound();
			fd.Fullname=vm.Fullname;
			fd.Position=vm.Position;
			fd.ImageUrl=vm.ImageUrl;
			fd.Icons=vm.Icons;
			_context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || id < 1) return BadRequest();
			var fd = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
			if (fd == null) return NotFound();
			_context.Remove(fd);
			_context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
