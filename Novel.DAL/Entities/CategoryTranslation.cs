using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Entities
{
    public class CategoryTranslation
    {
        public int id_categoryTranslation { set; get; }
        public int id_category { set; get; }
        public string name { set; get; }
        public string seo_description { set; get; }
        public string seo_title { set; get; }
        public string id_language { set; get; }
        public string seo_alias { set; get; }

        public Category Category { get; set; }

        public Language Language { get; set; }

    }
}
