namespace PersonalWebApp.Models.Files
{
    public class File
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public DateTime Date { get; set; }

        public File()
        {
        }

        public File(string name, string path, DateTime date)
        {
            Name = name;
            Path = path;
            Date = date;
        }

        public File(int id, string name, string path, DateTime date)
        {
            Id = id;
            Name = name;
            Path = path;
            Date = date;
        }
    }
}