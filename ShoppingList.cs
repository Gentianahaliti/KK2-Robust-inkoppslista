// Holds the items and takes care of loading and saving them.
class ShoppingList
{
    private const int BudgetLimit = 1000;
    private List<Item> items = new List<Item>();
    private string path;

    public ShoppingList(string path)
    {
        this.path = path;
    }

    public void Add(Item item)
    {
        if (item.Price > BudgetLimit - Total())
        {
            throw new InvalidOperationException($"Budgettaket på {BudgetLimit} kr skulle överskridas.");
        }

        foreach (var existingItem in items)
        {
            if (existingItem.Name.Equals(item.Name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Fel: varan finns redan i listan.");
                return;
            }
        }

        items.Add(item);
    }

    // Removes the item the user sees as number 1, 2, 3 ...
    public void RemoveAt(int number)
    {
        if (number < 1 || number > items.Count)
        {
            Console.WriteLine("Fel: det finns ingen vara med det numret.");
            return;
        }

        items.RemoveAt(number - 1);
    }

    // Adds up the price of every item on the list.
    public int Total()
    {
        int sum = 0;

        for (int i = 0; i < items.Count; i++)
        {
            sum += items[i].Price;
        }

        return sum;
    }

    // Looks up an item by its name. Returns null if there is no such item.
    public Item Find(string name)
    {
        foreach (Item item in items)
        {
            if (item.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return item;
            }
        }

        return null;
    }

    public void Print()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }

        Console.WriteLine($"Totalt: {Total()} kr");
    }

    // Writes one item per line, as "name;price".
    public void Save()
    {
        List<string> lines = new List<string>();

        foreach (Item item in items)
        {
            lines.Add($"{item.Name};{item.Price}");
        }

        try
        {
            File.WriteAllLines(path, lines);
            Console.WriteLine("Listan sparades.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Kunde inte spara filen: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Kunde inte spara filen: {ex.Message}");
        }
    }

    // Reads the file back into the list.
    public void Load()
    {
        string[] lines;
        try
        {
            lines = File.ReadAllLines(path);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Kunde inte läsa en sparad lista ({ex.Message}). Programmet startar med en tom lista.");
            return;
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Kunde inte läsa filen: {ex.Message}");
            return;
        }

        if (lines.Length == 0)
        {
            Console.WriteLine("Filen är tom. Ingen data att läsa.");
            return;
        }

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split(';');

            if (parts.Length != 2)
                continue;

            string name = parts[0];
            if (!int.TryParse(parts[1], out int price))
                continue;

            try
            {
                Add(new Item(name, price));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("En ogiltig vara i filen hoppades över.");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"Budgettaket på {BudgetLimit} kr överskreds av varor i filen. Resterande vara hoppades över.");
            }
        }
    }
}