using System;
using System.Collections.Generic;
using System.Text;

namespace MySecondBrain.Application.Services
{
    public class NotesControllerService
    {
        /// <summary>
        /// Renvoie une liste de toutes les notes du programme
        /// </summary>
        /// <returns>NoteListViewModel</returns>
        public static ViewModels.NoteListViewModel GetNoteList()
        {
            ViewModels.NoteListViewModel vm = new ViewModels.NoteListViewModel();
            vm.Notes = Domain.Services.NoteService.GetAllNotes();

            return vm;
        }

        /// <summary>
        /// Renvoie un ViewModel contenant la note
        /// </summary>
        /// <param name="noteId">Id de la note</param>
        /// <returns>NoteDetailViewModel</returns>
        public static ViewModels.NoteDetailViewModel GetNoteDetails(int noteId)
        {
            Infrastructure.DB.Note note = Domain.Services.NoteService.GetNote(noteId);
            if (note == null)
                return null;

            ViewModels.NoteDetailViewModel vm = new ViewModels.NoteDetailViewModel()
            {
                Note = note
            };

            return vm;

        }
    }
}
