using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Applications.ContentEditor.Gutters;
using System;

namespace Sitecore.Feature.LanguageVersionGutter
{
    public class LanguageVersionGutter : GutterRenderer
    {
        protected override GutterIconDescriptor GetIconDescriptor(Item item)
        {
            Assert.ArgumentNotNull(item, "item");

            try
            {
                bool hasVersion = HasLanguageVersion(item);

                var gutter = hasVersion ?
                    base.GetIconDescriptor(item) :
                    new GutterIconDescriptor()
                    {
                        Icon = "Core/32x32/minus.png",
                        Tooltip = $"No version for {item.Language.Name.ToUpper()} language."
                    };

                return gutter;
            }
            catch (Exception)
            {
                return base.GetIconDescriptor(item);
            }
        }

        protected bool HasLanguageVersion(Item item)
        {
            return item != null && item.Versions.Count > 0;
        }
    }
}