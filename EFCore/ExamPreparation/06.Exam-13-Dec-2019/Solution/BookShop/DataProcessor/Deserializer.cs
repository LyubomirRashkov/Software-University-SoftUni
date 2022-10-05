namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(BookImportModel[]), new XmlRootAttribute("Books"));

            var bookDtos = xmlSerializer.Deserialize(new StringReader(xmlString)) as BookImportModel[];

            var valids = new List<Book>();

            var sb = new StringBuilder();

            foreach (var bookDto in bookDtos)
            {
                if (!IsValid(bookDto))
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var book = new Book()
                {
                    Name = bookDto.Name,
                    Genre = (Genre)bookDto.Genre,
                    Price = bookDto.Price,
                    Pages = bookDto.Pages,
                    PublishedOn = DateTime.ParseExact(bookDto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                };

                valids.Add(book);

                sb.AppendLine(String.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            context.Books.AddRange(valids);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorDtos = JsonConvert.DeserializeObject<IEnumerable<AuthorImportModel>>(jsonString);

            var sb = new StringBuilder();

            var valids = new List<Author>();

            foreach (var authorDto in authorDtos)
            {
                if (!IsValid(authorDto))
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var authorWithEmail = valids.FirstOrDefault(a => a.Email == authorDto.Email);

                if (authorWithEmail != null)
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var author = new Author()
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Email = authorDto.Email,
                    Phone = authorDto.Phone,
                };

                foreach (var bookDto in authorDto.Books)
                {
                    var bookDb = context.Books.FirstOrDefault(b => b.Id == bookDto.Id);

                    if (bookDb == null)
                    {
                        continue;
                    }

                    var authorBook = new AuthorBook()
                    {
                        Book = bookDb,
                    };

                    author.AuthorsBooks.Add(authorBook);
                }

                if (!author.AuthorsBooks.Any())
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                valids.Add(author);

                string authorFullName = author.FirstName + " " + author.LastName;

                sb.AppendLine(String.Format(SuccessfullyImportedAuthor, authorFullName, author.AuthorsBooks.Count));
            }

            context.Authors.AddRange(valids);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}