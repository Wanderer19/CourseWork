using System;
using System.Collections.Generic;

namespace OOP.Solutions.LibraryUtils
{
    public class Magazine
    {
        public DateTime Release { get; set; }
        public string Name { get; set; }
        public List<Article> Articles;
 
        public Magazine(string name, DateTime release)
        {
            Release = release;
            Name = name;
            Articles = new List<Article>();
        }

        public Magazine(string name, DateTime release, List<Article> articles)
        {
            Release = release;
            Name = name;
            this.Articles = articles;
        }

        public void AddArticle(Article article)
        {
            Articles.Add(article);
        }
    }
}
