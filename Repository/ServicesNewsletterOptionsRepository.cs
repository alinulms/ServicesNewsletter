using System;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.EmailCampaign.SampleNewsletter;
using Sitecore.EmailCampaign.SampleNewsletter.Extensions;
using Sitecore.EmailCampaign.SampleNewsletter.Models;
using Sitecore.EmailCampaign.SampleNewsletter.Services;

namespace Sitecore.Feature.ServicesNewsletter.Repository
{

	public class ServicesNewsletterOptionsRepository
	{
		
		public ServicesNewsletterOptionsRepository() : this(new FindNewsletterRootService())
		{
		}

		
		public ServicesNewsletterOptionsRepository(FindNewsletterRootService findNewsletterRootService)
		{
			Assert.ArgumentNotNull(findNewsletterRootService, "findNewsletterRootService");
			this._findNewsletterRootService = findNewsletterRootService;
		}

		
		public NewsletterOptions Get(Item contextItem)
		{
			Assert.ArgumentNotNull(contextItem, "contextItem");
			Item newsletterRoot = this._findNewsletterRootService.FindNewsletterRoot(contextItem);
			Item item = newsletterRoot.Children.FirstOrDefault((Item c) => c.IsDerived(Sitecore.EmailCampaign.SampleNewsletter.Templates.NewsletterOptions.ID));
			bool flag = item == null;
			if (flag)
			{
				throw new ArgumentException("Cannot find EmailOptionsRepository below '" + newsletterRoot.Paths.FullPath + "'");
			}
			int result;
			bool flag2 = !int.TryParse(item[Sitecore.EmailCampaign.SampleNewsletter.Templates.NewsletterOptions.Fields.MaxWidth], out result);
			if (flag2)
			{
				result = 800;
			}
			return new NewsletterOptions
			{
				ContentFontSize = item[Sitecore.EmailCampaign.SampleNewsletter.Templates.NewsletterOptions.Fields.ContentFontSize],
				FontFamily = item[Sitecore.EmailCampaign.SampleNewsletter.Templates.NewsletterOptions.Fields.FontFamily],
				HeadingFontSize = item[Sitecore.EmailCampaign.SampleNewsletter.Templates.NewsletterOptions.Fields.HeadingFontSize],
				MaxWidth = result,
				BeforeBodyHtml = item[Sitecore.EmailCampaign.SampleNewsletter.Templates.NewsletterOptions.Fields.BeforeBodyHtml],
				AfterBodyHtml = item[Sitecore.EmailCampaign.SampleNewsletter.Templates.NewsletterOptions.Fields.AfterBodyHtml]
			};
		}

		
		private const int DefaultMaxWidth = 800;

	
		private readonly FindNewsletterRootService _findNewsletterRootService;
	}
}
