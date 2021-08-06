using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.Answer;
using Model.Functions.Note;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.NoteRepository
{
    public class NoteRepository : BaseRepository, INoteRepository
    {
        public NoteRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {

        }

        public Guid AddNote(AddNote addNote)
        {
            Guid outGuid = Guid.Empty;
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@courseLessonItemId", addNote.CourseLessonItem),
                new SqlParameter("@noteType", addNote.NoteType),
                new SqlParameter("@text", addNote.Text),
                new SqlParameter("@userId",addNote.UserId),
                new SqlParameter("@noteName",addNote.NoteName),
                new SqlParameter("@fileName",addNote.FileName),

            };
            CallSqlProcedure("AddNote", sqlParameters, true, ref outGuid);
            return outGuid;
        }

        public HashSet<GetMyNote> GetMyNote(Guid userId)
        {
            return CallSqlFunction<GetMyNote>("GetMyNote", new List<SqlParameter>()
            {
                new SqlParameter("@userId",userId)
            }).ToHashSet();
        }

        public GetNoteDetail GetNoteDetail(Guid noteId)
        {
            return CallSqlFunction<GetNoteDetail>("GetNoteDetail", new List<SqlParameter>()
            {
                new SqlParameter("@noteId",noteId)
            }).FirstOrDefault();
        }

        public void UpdateNote(UpdateNote updateNote)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@noteId",updateNote.NoteId),
                new SqlParameter("@text", updateNote.Text),
                new SqlParameter("@noteName",updateNote.NoteName),
            new SqlParameter("@fileName",updateNote.FileName)};
            CallSqlProcedure("UpdateNote", sqlParameters);
        }
    }
}
