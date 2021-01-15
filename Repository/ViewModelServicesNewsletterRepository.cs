using Sitecore.Mvc.Presentation;
using Sitecore.Diagnostics;
using Sitecore.EmailCampaign.SampleNewsletter.Extensions;
using Sitecore.EmailCampaign.SampleNewsletter.Models;
using Sitecore.EmailCampaign.SampleNewsletter.Repositories;

namespace Sitecore.Feature.ServicesNewsletter.Repository
{
    public class ViewModelServicesNewsletterRepository : ViewModelRepository
    {
        private readonly ServicesNewsletterOptionsRepository _servicesNewsletterOptionsRepository;
        
        public ViewModelServicesNewsletterRepository() : this(new ServicesNewsletterOptionsRepository()) { }

        public ViewModelServicesNewsletterRepository(
            ServicesNewsletterOptionsRepository servicesNewsletterOptionsRepository)
        {
            Assert.ArgumentNotNull(servicesNewsletterOptionsRepository, "servicesNewsletterOptionsRepository");
            this._servicesNewsletterOptionsRepository = servicesNewsletterOptionsRepository;
        }

        public SectionViewModel GetImageBlockWithTextViewModel(Rendering rendering)
        {
            Assert.ArgumentNotNull(rendering, "rendering");
            if (!rendering.Item.IsDerived(Templates.ImageBlockWithText.ID))
            {
                return null;
            }

            return new SectionViewModel()
            {
                ContentItem = rendering.Item,
                NewsletterOptions = this._servicesNewsletterOptionsRepository.Get(rendering.Item),
                SectionOptions =
                    ServicesSectionOptionsRepository.Get(rendering.RenderingItem.InnerItem["Parameters"])
            };
        }

        public SectionViewModel GetImageBlocSectionViewModel(Rendering rendering)
        {
            Assert.ArgumentNotNull(rendering, "rendering");
            if (!rendering.Item.IsDerived(Templates.ImageBlockWithText.ID))
            {
                return null;
            }

            return new SectionViewModel
            {
                ContentItem = rendering.Item,
                NewsletterOptions = this._servicesNewsletterOptionsRepository.Get(rendering.Item),
                SectionOptions = ServicesSectionOptionsRepository.Get(rendering.RenderingItem.InnerItem["Parameters"])
            };
        }
    }
}
