// See https://aka.ms/new-console-template for more information
Console.WriteLine("Simulate deck shuffle");

//LINQ in query syntax
{
    var cards =
        from rank in "A23456789TJQK"
        from suit in "DCHS"
        from deck in Enumerable.Range(1,2)
        select $"{rank}{suit}{deck}";

    //foreach (var card in cards)
    //    Console.WriteLine(card);

    var cardArray = cards.ToArray();

    new Random().Shuffle(cardArray);

    Console.WriteLine(string.Join(" ", cardArray.Take(5)));
}
//LINQ in method syntax
{
    var cards = "A23456789TJQK"
        .SelectMany(rank => "DCHS", (rank, suit) => new { rank, suit })
        .SelectMany(card => Enumerable.Range(1, 2), (card, deck) => $"{card.rank}{card.suit}{deck}");
        

    //foreach (var card in cards)
    //    Console.WriteLine(card);

    var cardArray = cards.ToArray();

    new Random().Shuffle(cardArray);

    Console.WriteLine(string.Join(" ", cardArray.Take(5)));
}