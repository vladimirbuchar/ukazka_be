using EduServices.CodeBookService;
using Model.Tables.CodeBook;
using System.Collections.Generic;
using System.Linq;
using WebModel.Page;

namespace EduFacade.PageFacade
{
    public class PageFacade : BaseFacade, IPageFacade
    {
        private readonly ICodeBookService _codeBookService;
        public PageFacade(ICodeBookService codeBookService)
        {
            _codeBookService = codeBookService;
        }
        public HashSet<PriceListDto> PriceList()
        {
            HashSet<License> licences = _codeBookService.GetCodeBookItems<License>();
            return licences.Select(x => new PriceListDto()
            {
                CreatePrivateCourse = x.CreatePrivateCourse,
                Id = x.Id,
                MaximumBranch = x.MaximumBranch,
                MaximumCourse = x.MaximumCourse,
                MaximumUser = x.MaximumUser,
                MounthPrice = x.MounthPrice,
                Name = x.SystemIdentificator,
                OneYearSale = x.OneYearSale,
                SendCourseInquiry = x.SendCourseInquiry
            }).ToHashSet();
        }
    }
}
