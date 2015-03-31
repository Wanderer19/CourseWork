namespace DataStructure.Solutions.DictionaryTasks.InvertedIndexUtils
{
    public class Document
    {
        public int Id { get; private set; }
        public string Text { get; private set; }

        public Document(int id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}
