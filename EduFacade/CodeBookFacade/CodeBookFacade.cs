using EduFacade.CodeBookFacade.Convertor;
using EduServices.CodeBookService;
using Model.Tables.CodeBook;
using System.Collections.Generic;
using System.Linq;
using WebModel.CodeBook;

namespace EduFacade.CodeBookFacade
{
    public class CodeBookFacade : BaseFacade, ICodeBookFacade
    {
        private readonly ICodeBookService _codeBookService;
        private readonly ICodeBookConvertor _codeBookConvertor;
        public CodeBookFacade(ICodeBookService codeBookService, ICodeBookConvertor codeBookConvertor)
        {
            _codeBookService = codeBookService;
            _codeBookConvertor = codeBookConvertor;
        }

        public HashSet<GetCodeBookItemsDto> GetCodeBookItems(string codeBookName)
        {
            switch (codeBookName)
            {
                case "cb_license":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<License>());
                    }
                case "cb_coursetype":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<CourseType>());
                    }
                case "cb_coursestatus":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<CourseStatus>());
                    }
                case "cb_timetable":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<TimeTable>());
                    }
                case "cb_country":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<Country>());
                    }
                case "cb_addresstype":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<AddressType>());
                    }
                case "cb_answermode":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<AnswerMode>());
                    }
                case "cb_courselessonitemtemplate":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<CourseLessonItemTemplate>());
                    }
                case "cb_env_culture":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<Culture>().Where(x => x.IsEnvironmentCulture).OrderBy(x => x.Priority).ToHashSet());
                    }
                case "cb_culture":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<Culture>().OrderBy(x => x.Priority).ToHashSet());
                    }
                case "cb_sendmessagetype":
                    {
                        HashSet<GetCodeBookItemsDto> sendmessagetype = _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<SendMessageType>().OrderBy(x => x.Priority).ToHashSet());
                        foreach (GetCodeBookItemsDto item in sendmessagetype)
                        {
                            item.Disabled = item.SystemIdentificator == SendMessageTypeValue.SMS;
                        }
                        return sendmessagetype;
                    }
                case "cb_questionmode":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<QuestionMode>());
                    }
                case "cb_notetype":
                    {
                        return _codeBookConvertor.ConvertToWebModel(_codeBookService.GetCodeBookItems<NoteType>());
                    }


            }
            return null;
        }
    }
}
