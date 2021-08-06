using Core.DataTypes;
using EduFacade.PageFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.Page;

namespace EduApi.Controllers.Web.Organization
{
    public class PageController : BaseWebController
    {
        private readonly IPageFacade _pageFacade;

        public PageController(ILogger<OrganizationController> logger, IPageFacade pageFacade) : base(logger)
        {
            _pageFacade = pageFacade;
        }

        [HttpGet]
        [ProducesResponseType(typeof(HashSet<PriceListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult PriceList()
        {
            try
            {
                return SendResponse(_pageFacade.PriceList());
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }


    }
}

