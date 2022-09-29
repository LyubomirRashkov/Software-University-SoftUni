namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var gameDtos = JsonConvert.DeserializeObject<IEnumerable<GameInputModel>>(jsonString);

            foreach (var gameDto in gameDtos)
            {
                bool isDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

                if (!IsValid(gameDto) || !isDateValid || !gameDto.Tags.Any())
                {
                    sb.AppendLine("Invalid Data");

                    continue;
                }

                var developer = context.Developers.FirstOrDefault(d => d.Name == gameDto.Developer)
                                ?? new Developer()
                                {
                                    Name = gameDto.Developer,
                                };

                var genre = context.Genres.FirstOrDefault(g => g.Name == gameDto.Genre)
                            ?? new Genre()
                            {
                                Name = gameDto.Genre,
                            };

                var game = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate,
                    Developer = developer,
                    Genre = genre,
                };

                foreach (var tag in gameDto.Tags)
                {
                    var gtag = context.Tags.FirstOrDefault(t => t.Name == tag)
                               ?? new Tag()
                               {
                                   Name = tag,
                               };

                    var gameTag = new GameTag()
                    {
                        Tag = gtag,
                    };

                    game.GameTags.Add(gameTag);
                }

                context.Games.Add(game);

                context.SaveChanges();

                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var userDtos = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(jsonString);

            foreach (var userDto in userDtos)
            {
                if (!IsValid(userDto) || !userDto.Cards.Any() || userDto.Cards.Any(c => !IsValid(c)))
                {
                    sb.AppendLine("Invalid Data");

                    continue;
                }

                var user = new User()
                {
                    Username = userDto.Username,
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    Age = userDto.Age,
                };

                foreach (var cardDto in userDto.Cards)
                {
                    var card = new Card()
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.CVC,
                        Type = cardDto.Type.Value,
                    };

                    user.Cards.Add(card);
                }

                context.Users.Add(user);

                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(PurchaseInputModel[]), new XmlRootAttribute("Purchases"));

            var purchaseDtos = xmlSerializer.Deserialize(new StringReader(xmlString)) as PurchaseInputModel[];

            foreach (var purchaseDto in purchaseDtos)
            {
                var game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title);

                var card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card);

                bool isDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                if (!IsValid(purchaseDto) || game == null || card == null || !isDateValid)
                {
                    sb.AppendLine("Invalid Data");

                    continue;
                }

                var purchase = new Purchase()
                {
                    Type = purchaseDto.Type.Value,
                    ProductKey = purchaseDto.Key,
                    Date = date,
                    Card = card,
                    Game = game,
                };

                context.Purchases.Add(purchase);

                sb.AppendLine($"Imported {game.Name} for {purchase.Card.User.Username}");
            }

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