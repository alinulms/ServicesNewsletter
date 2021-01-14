using System;
using System.Web.Mvc;
using Sitecore.Diagnostics;
using Sitecore.EmailCampaign.SampleNewsletter.Models;
using Sitecore.Feature.ServicesNewsletter.Repository;
using Sitecore.Mvc.Presentation;

namespace Sitecore.Feature.ServicesNewsletter.Controllers
{
	
	public class ServicesNewsletterController : Controller
	{
		private readonly ViewModelServicesNewsletterRepository _repository;
		public ServicesNewsletterController() : this(new ViewModelServicesNewsletterRepository())
		{
			//test
		}

		public ServicesNewsletterController(ViewModelServicesNewsletterRepository repository)
		{
			Assert.ArgumentNotNull(repository, "repository");
			this._repository = repository;
		}
	
		public ActionResult Footer()
		{
			SectionViewModel fixedSectionViewModel = this._repository.GetFixedSectionViewModel(RenderingContext.Current.Rendering);
			return base.View("~/sitecore modules/web/exm/layouts/ServicesNewsletter/Footer.cshtml", fixedSectionViewModel);
		}

		public ActionResult Header()
		{
			SectionViewModel fixedSectionViewModel = this._repository.GetFixedSectionViewModel(RenderingContext.Current.Rendering);
			return base.View("~/sitecore modules/web/exm/layouts/ServicesNewsletter/Header.cshtml", fixedSectionViewModel);
		}

		public ActionResult ContentSection()
		{
			SectionViewModel sectionViewModel = this._repository.GetSectionViewModel(RenderingContext.Current.Rendering);
			return base.View("~/sitecore modules/web/exm/layouts/ServicesNewsletter/ContentSection.cshtml", sectionViewModel);
		}

		
		public ActionResult ImageSection()
		{
			SectionViewModel sectionViewModel = this._repository.GetSectionViewModel(RenderingContext.Current.Rendering);
			return base.View("~/sitecore modules/web/exm/layouts/ServicesNewsletter/ImageSection.cshtml", sectionViewModel);
		}

		
		public ActionResult ListSection()
		{
			ListSectionViewModel listSectionViewModel = this._repository.GetListSectionViewModel(RenderingContext.Current.Rendering);
			return base.View("~/sitecore modules/web/exm/layouts/ServicesNewsletter/ListSection.cshtml", listSectionViewModel);
		}

		
		public ActionResult SingleCtaSection()
		{
			SectionViewModel sectionViewModel = this._repository.GetSectionViewModel(RenderingContext.Current.Rendering);
			return base.View("~/sitecore modules/web/exm/layouts/ServicesNewsletter/SingleCTASection.cshtml", sectionViewModel);
		}

	
		public ActionResult TwoColumnCtaSection()
		{
			ListSectionViewModel listSectionViewModel = this._repository.GetListSectionViewModel(RenderingContext.Current.Rendering);
			return base.View("~/sitecore modules/web/exm/layouts/ServicesNewsletter/TwoColumnCTASection.cshtml", listSectionViewModel);
		}
    }
}
