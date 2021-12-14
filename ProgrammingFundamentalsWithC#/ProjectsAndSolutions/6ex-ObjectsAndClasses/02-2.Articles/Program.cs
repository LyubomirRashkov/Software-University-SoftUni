using System;

namespace _02_2.Articles
{
    public class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] articleData = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string title = articleData[0];
            string content = articleData[1];
            string author = articleData[2];

            Article article = new Article
            {
                Title = title,
                Content = content,
                Author = author
            };

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandParts = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandParts[0];
                string substitute = commandParts[1];

                if (command == "Edit")
                {
                    article.Edit(substitute);
                }
                else if (command == "ChangeAuthor")
                {
                    article.ChangeAuthor(substitute);
                }
                else if (command == "Rename")
                {
                    article.Rename(substitute);
                }
            }

            Console.WriteLine(article);
        }
    }
}
