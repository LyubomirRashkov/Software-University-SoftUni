using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    public class Piece
    {
        public string Name { get; set; }

        public string Composer { get; set; }

        public string Key { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPieces = int.Parse(Console.ReadLine());

            List<Piece> pieces = new List<Piece>(numberOfPieces);

            List<string> piecesNames = new List<string>(numberOfPieces);

            for (int i = 0; i < numberOfPieces; i++)
            {
                string[] parts = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string name = parts[0];
                string composer = parts[1];
                string key = parts[2];

                Piece piece = new Piece
                {
                    Name = name,
                    Composer = composer,
                    Key = key
                };

                pieces.Add(piece);
                piecesNames.Add(name);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Stop")
                {
                    break;
                }

                string[] commandParts = command
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string currentCommand = commandParts[0];
                string pieceName = commandParts[1];

                if (currentCommand == "Add")
                {
                    if (DoesExist(piecesNames, pieceName))
                    {
                        Console.WriteLine($"{pieceName} is already in the collection!");
                        continue;
                    }

                    string composerName = commandParts[2];
                    string pieceKey = commandParts[3];

                    Piece piece = new Piece
                    {
                        Name = pieceName,
                        Composer = composerName,
                        Key = pieceKey
                    };

                    pieces.Add(piece);

                    piecesNames.Add(pieceName);

                    Console.WriteLine($"{pieceName} by {composerName} in {pieceKey} added to the collection!");
                }
                else if (currentCommand == "Remove")
                {
                    if (!DoesExist(piecesNames, pieceName))
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                        continue;
                    }

                    piecesNames.Remove(pieceName);

                    foreach (Piece piece in pieces)
                    {
                        if (piece.Name == pieceName)
                        {
                            pieces.Remove(piece);
                            break;
                        }
                    }

                    Console.WriteLine($"Successfully removed {pieceName}!");
                }
                else if (currentCommand == "ChangeKey")
                {
                    string newKey = commandParts[2];

                    if (!DoesExist(piecesNames, pieceName))
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                        continue;
                    }

                    foreach (Piece piece in pieces)
                    {
                        if (piece.Name == pieceName)
                        {
                            piece.Key = newKey;
                            break;
                        }
                    }

                    Console.WriteLine($"Changed the key of {pieceName} to {newKey}!");
                }
            }

            List<Piece> sortedPieces = pieces
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Composer)
                .ToList();

            foreach (Piece piece in sortedPieces)
            {
                Console.WriteLine($"{piece.Name} -> Composer: {piece.Composer}, Key: {piece.Key}");
            }
        }

        private static bool DoesExist(List<string> collection, string element)
        {
            if (collection.Contains(element))
            {
                return true;
            }

            return false;
        }
    }
}
