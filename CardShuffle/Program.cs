// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Simulate deck shuffle");

//LINQ in query syntax
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    var cards =
        from rank in "A23456789TJQK"
        from suit in "DCHS"
        from deck in Enumerable.Range(1, 2)
        select $"{rank}{suit}{deck}";
    stopwatch.Stop();
    Console.WriteLine($"query syntax took: {stopwatch.ElapsedTicks} ticks");

    //foreach (var card in cards)
    //    Console.WriteLine(card);

    var cardArray = cards.ToArray();

    new Random().Shuffle(cardArray);

    Console.WriteLine(string.Join(" ", cardArray.Take(5)));
}
//LINQ in method syntax
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    var cards = "A23456789TJQK"
        .SelectMany(rank => "DCHS", (rank, suit) => new { rank, suit })
        .SelectMany(card => Enumerable.Range(1, 2), (card, deck) => $"{card.rank}{card.suit}{deck}");
    stopwatch.Stop();
    Console.WriteLine($"method syntax with anonymous object took: {stopwatch.ElapsedTicks} ticks");

    //foreach (var card in cards)
    //    Console.WriteLine(card);

    var cardArray = cards.ToArray();

    new Random().Shuffle(cardArray);

    Console.WriteLine(string.Join(" ", cardArray.Take(5)));
}
//LINQ in method syntax without anonymous object
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    var cards = "A23456789TJQK"
        .SelectMany(rank => "DCHS", (rank, suit) => $"{rank}{suit}")
        .SelectMany(card => Enumerable.Range(1, 2), (card, deck) => $"{card}{deck}");
    stopwatch.Stop();
    Console.WriteLine($"method syntax without anonymous object took: {stopwatch.ElapsedTicks} ticks");

    var cardArray = cards.ToArray();

    new Random().Shuffle(cardArray);

    Console.WriteLine(string.Join(" ", cardArray.Take(5)));
}