namespace Yudin_back.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<string> Author { get; set; }
        public int Year { get; set; }
        public bool IsAvailable { get; set; }



    }
}