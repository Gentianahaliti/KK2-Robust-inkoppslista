ShoppingList list = new ShoppingList("items.txt");
list.Load();

while (true)
{
    Console.WriteLine();
    list.Print();
    Console.WriteLine();
    Console.WriteLine("1. Lägg till vara");
    Console.WriteLine("2. Ta bort vara");
    Console.WriteLine("3. Spara");
    Console.WriteLine("4. Sök vara");
    Console.WriteLine("5. Avsluta");
    Console.Write("Välj: ");

    string choiceText = Console.ReadLine();
    if (choiceText == null)
    {
        break;
    }

    if (!int.TryParse(choiceText, out int choice))
    {
        Console.WriteLine("Du måste skriva ett nummer.");
        continue;
    }

    if (choice == 1)
    {
        Console.Write("Ange namn: ");
        string name = Console.ReadLine();
        if (name == null)
        {
            break;
        }

        Console.Write("Pris: ");
        string priceText = Console.ReadLine();
        if (priceText == null)
        {
            break;
        }

        if (!int.TryParse(priceText, out int price))
        {
            Console.WriteLine("Du måste skriva ett nummer.");
            continue;
        }

        try
        {
            list.Add(new Item(name, price));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Fel: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Fel: {ex.Message}");
        }
    }
    else if (choice == 2)
    {
        Console.Write("Nummer: ");
        string numberText = Console.ReadLine();
        if (numberText == null)
        {
            break;
        }

        if (!int.TryParse(numberText, out int number))
        {
            Console.WriteLine("Du måste skriva ett nummer.");
            continue;
        }
        list.RemoveAt(number);
    }
    else if (choice == 3)
    {
        list.Save();
    }
    else if (choice == 4)
    {
        Console.Write("Namn att söka efter: ");
        string wanted = Console.ReadLine();
        if (wanted == null)
        {
            break;
        }

        Item found = list.Find(wanted);

        if (found == null)
        {
            Console.WriteLine("Varan finns inte i listan.");
        }
        else
        {
            Console.WriteLine($"Hittade: {found}");
        }
    }
    else if (choice == 5)
    {
        break;
    }
    else
    {
        Console.WriteLine("Välj ett nummer mellan 1 och 5.");
    }
}
