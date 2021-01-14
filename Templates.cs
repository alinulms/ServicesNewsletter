using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Publishing.Pipelines.PublishItem;

namespace Sitecore.Feature.ServicesNewsletter
{
    public struct Templates
    {
        public struct ImageBlockWithText
        {
            public static readonly ID ID = new ID("{ED129D2F-0D44-4E41-8A43-A65A4112C95F}");

            public struct Fields
            {
                public static readonly ID Image = new ID("{05150429-10FF-4BB4-A9C7-6F636C252CE8}");
                public static readonly ID Headline = new ID("{A3F301E8-1770-44D9-9EFB-045473170ACB}");
                public static readonly ID Content = new ID("{F582F380-7B59-4565-BBCA-7C67D475DE0F}");
            }
        }
        public struct Heading
        {
            public static readonly ID ID = new ID("{7F2F706A-8B03-4A0D-BE5E-25E20A1A10B7}");

            public struct Fields
            {
                public static readonly ID Title = new ID("{7A26EAFE-59A3-4A9A-9753-A12D49C8D120}");
           
            }
        }
    }
}