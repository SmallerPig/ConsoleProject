using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsoleProject.Areas.Admin.Models
{
    public class ContentUnitModel
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string ValidatorRules { get; set; }

        public string DefaultValue
        {
            get
            {
                if (MetaData != null)
                {
                    Type type = MetaData.GetType();
                    var properties = type.GetProperties();

                    foreach (var propertyInfo in properties)
                    {
                        if (Name == propertyInfo.Name)
                        {
                            var result = propertyInfo.GetValue(MetaData);

                            return result == null ? "" : result.ToString();
                        }
                    }
                }
                return "";
            }
        }

        public string Tips { get; set; }

        public string UploaderAccpect { get; set; }

        public IEnumerable<SelectorItem> SelectorItems { get; set; }

        public object MetaData { get; set; }


    }

    public class SelectorItem
    {
        public string Text { get; set; }

        public string Value { get; set; }
    }
}