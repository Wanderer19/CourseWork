using System;
using System.Collections.Generic;

namespace OOP.Solutions.LibraryUtils
{
    public class Magazine
    {
        public DateTime Release { get; set; }
        public string Name { get; set; }
        private readonly List<Article> articles;
 
        public Magazine(string name, DateTime release)
        {
            Release = release;
            Name = name;
            articles = new List<Article>();
        }

        public Magazine(string name, DateTime release, List<Article> articles)
        {
            Release = release;
            Name = name;
            this.articles = articles;
        }

        public void AddArticle(Article article)
        {
            articles.Add(article);
        }
    }
}
