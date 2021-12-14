using System;

namespace _02.Articles
{
    public class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

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
                string[] commandData = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];
                string newContent = commandData[1];

                if (command == "Edit")
                {
                    article.Content = newContent;
                }
                else if (command == "ChangeAuthor")
                {
                    article.Author = newContent;
                }
                else if (command == "Rename")
                {
                    article.Title = newContent;
                }
            }

            Console.WriteLine(article);
        }
    }
}
