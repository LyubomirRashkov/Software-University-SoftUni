using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles2._0
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
            int numberOfArticles = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>(numberOfArticles);

            for (int i = 0; i < numberOfArticles; i++)
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

                articles.Add(article);
            }

            string sortingCriteria = Console.ReadLine();

            List<Article> sortedArticles = SortBy(sortingCriteria, articles);

            foreach (Article article in sortedArticles)
            {
                Console.WriteLine(article);
            }
        }

        private static List<Article> SortBy(string sortingCriteria, List<Article> listToBeSorted)
        {
            List<Article> sortedList = new List<Article>();

            if (sortingCriteria == "title")
            {
                sortedList = listToBeSorted
                    .OrderBy(x => x.Title)
                    .ToList();
            }
            else if (sortingCriteria == "content")
            {
                sortedList = listToBeSorted
                    .OrderBy(x => x.Content)
                    .ToList();
            }
            else if (sortingCriteria == "author")
            {
                sortedList = listToBeSorted
                    .OrderBy(x => x.Author)
                    .ToList();
            }

            return sortedList;
        }
    }
}
