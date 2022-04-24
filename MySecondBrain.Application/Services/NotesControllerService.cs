using System;
using System.Collections.Generic;
using System.Security.Claims;
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
            vm.Notes = Domain.Services.ElasticSearch.ElasticSearchServiceAgent.GetAllNotes();
            vm.Categories = Domain.Services.CategoryService.GetNotes();
            return vm;
        }

        /// <summary>
        /// Renvoie une liste de notes basé sur une recherche dans Elastic Search.
        /// </summary>
        /// <returns>NoteListViewModel</returns>
        public static ViewModels.NoteListViewModel GetNoteListFromQuery(string query)
        {
            ViewModels.NoteListViewModel vm = new ViewModels.NoteListViewModel();
            vm.Notes = Domain.Services.ElasticSearch.ElasticSearchServiceAgent.SearchNotes(query);
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

        /// <summary>
        /// Appelle le service de la couche domain pour créer une note
        /// </summary>
        /// <param name="noteId">Note à créer</param>
        /// <returns></returns>
        public static void CreateNote(Infrastructure.DB.Note note)
        {
            Domain.Services.NoteService.CreateNote(note);
        }

        /// <summary>
        /// Appelle le service de la couche domain pour éditer une note
        /// </summary>
        /// <param name="noteId">Note à éditer</param>
        /// <returns></returns>
        public static void EditNote(Infrastructure.DB.Note note)
        {
            Domain.Services.NoteService.EditNote(note);
        }

        /// <summary>
        /// Supprime une note
        /// </summary>
        /// <param name="noteId">Note à éditer</param>
        public static void DeleteNote(int noteId)
        {
            Domain.Services.NoteService.DeleteNote(noteId);
        }

    }
}
