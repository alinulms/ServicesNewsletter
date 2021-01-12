using System.Web.Mvc;
using Sitecore.Diagnostics;
using Sitecore.EmailCampaign.SampleNewsletter.Repositories;
using Sitecore.Mvc.Presentation;

namespace ServicesNewsletter.Controllers
{
    public class TestLetterController : Controller
    {
        private readonly ViewModelRepository _repository;

        public TestLetterController():this(new ViewModelRepository())
        {
            
        }
        public TestLetterController(ViewModelRepository repository)
        {
            Assert.ArgumentNotNull((object)repository, nameof(repository));
            this._repository = repository;
        }

        public ActionResult POQ()
        {
            return (ActionResult)this.View("~/sitecore modules/Web/Exm/layouts/TestLetter/POQ.cshtml", (object)this._repository.GetFixedSectionViewModel(RenderingContext.Current.Rendering));
        }
    }
}