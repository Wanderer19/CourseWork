namespace OOP.Solutions.LibraryUtils
{
    public class Article
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }

        public Article(string title, string text, string author)
        {
            Title = title;
            Text = text;
            Author = author;
        }
    }
}
