using System.Collections.Specialized;
using Sitecore.Diagnostics;
using Sitecore.EmailCampaign.SampleNewsletter.Models;
using Sitecore.Web;

namespace Sitecore.Feature.ServicesNewsletter.Repository
{
    public static class ServicesSectionOptionsRepository
    {​​       
        public static SectionOptions Get(string parameters)
        {
            Assert.ArgumentNotNull(parameters, "parameters");
            NameValueCollection parameters2 = WebUtil.ParseUrlParameters(parameters);
            return new SectionOptions
            {
                BackgroundColor = ServicesSectionOptionsRepository.GetParameter(parameters2, "Background Color", "#fff"),
                ContentFontColor = ServicesSectionOptionsRepository.GetParameter(parameters2, "Content Font Color", "#000"),
                HeadingFontColor = ServicesSectionOptionsRepository.GetParameter(parameters2, "Heading Font Color", "#000"),
                LinkColor = ServicesSectionOptionsRepository.GetParameter(parameters2, "Link Color", "#000")
            };
        }
        private static string GetParameter(NameValueCollection parameters, string name, string defaultValue = "")
        {
            Assert.ArgumentNotNull(parameters, "parameters");
            Assert.ArgumentNotNull(name, "name");
            string text = parameters[name];
            if (!string.IsNullOrEmpty(text))
            {
                return text;
            }​​            
            return defaultValue;
        }​​    
    }
}