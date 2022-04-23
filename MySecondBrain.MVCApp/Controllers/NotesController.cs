using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySecondBrain.MVCApp.Models;
using MySecondBrain.Application.Services;
using System.Security.Claims;

namespace MySecondBrain.Controllers
{
    public class NotesController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public NotesController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var vm = Application.Services.NotesControllerService.GetNoteList();
            return View(vm);
        }

        public IActionResult Detail(int id)
        {
            var vm = Application.Services.NotesControllerService.GetNoteDetails(id);
            if (vm == null)
                return NotFound();

            return View(vm);

        }

        [HttpPost]
        public IActionResult Index(string query)
        {
            var vm = Application.Services.NotesControllerService.GetNoteListFromQuery(query);
            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Application.ViewModels.NoteDetailViewModel noteDetailViewModel)
        {
            noteDetailViewModel.Note.AspNetUsersId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Application.Services.NotesControllerService.CreateNote(noteDetailViewModel.Note);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
