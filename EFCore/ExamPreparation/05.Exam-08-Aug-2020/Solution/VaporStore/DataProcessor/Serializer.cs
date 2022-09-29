namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var data = context.Genres
                .ToList()
                .Where(g => genreNames.Contains(g.Name))
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                    .Where(game => game.Purchases.Any())
                    .Select(game => new
                    {
                        Id = game.Id,
                        Title = game.Name,
                        Developer = game.Developer.Name,
                        Tags = string.Join(", ", game.GameTags.Select(gt => gt.Tag.Name)),
                        Players = game.Purchases.Count,
                    })
                    .OrderByDescending(x => x.Players)
                    .ThenBy(x => x.Id)
                    .ToList(),
                    TotalPlayers = g.Games.Sum(game => game.Purchases.Count),
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToList();

            string result = JsonConvert.SerializeObject(data, Formatting.Indented);

            return result;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var data = context.Users
                .ToArray()
                .Where(u => u.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
                .Select(u => new UserXmlExportModel()
                {
                    Username = u.Username,
                    Purchases = u.Cards
                        .SelectMany(c => c.Purchases)
                        .Where(p => p.Type.ToString() == storeType)
                        .OrderBy(p => p.Date)
                        .Select(p => new PurchaseXmlExportModel()
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new GameXmlExportModel()
                            {
                                Title = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price,
                            },
                        })
                        .ToArray(),
                    TotalSpent = context.Purchases
                        .ToArray()
                        .Where(p => p.Card.User.Username == u.Username && p.Type.ToString() == storeType)
                        .Select(p => p.Game.Price)
                        .Sum(),
                })
                .OrderByDescending(x => x.TotalSpent)
                .ThenBy(x => x.Username)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(UserXmlExportModel[]), new XmlRootAttribute("Users"));

            var sw = new StringWriter();

            var ns = new XmlSerializerNamespaces();

            ns.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(sw, data, ns);

            return sw.ToString();
        }
    }
}