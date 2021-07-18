using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Entities
{
    public class Language
    {
        public string id_language { get; set; }

        public string name { get; set; }

        public bool is_default { get; set; }

        public List<ProductTranslation> ProductTranslations { get; set; }

        public List<CategoryTranslation> CategoryTranslations { get; set; }
    }
}
