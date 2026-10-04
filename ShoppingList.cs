// Holds the items and takes care of loading and saving them.
class ShoppingList
{
    private List<Item> items = new List<Item>();
    private string path;

    public ShoppingList(string path)
    {
        this.path = path;
    }

    public void Add(Item item)
    {
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

        // FEL: i = 1 hoppar över första varan
        // RÄTT: i = 0
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
            if (item.Name == name)
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

    // Writes one item per line, as "price;name".
    public void Save()
    {
        try
        {
            File.WriteAllLines(path, items.Select(i => $"{i.Name};{i.Price}"));
            Console.WriteLine("Listan sparades.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Kunde inte spara filen: {ex.Message}");
        }
    }

    // Reads the file back into the list.
    public void Load()
    {
        // FEL: kraschar om filen saknas
        if (!File.Exists(path))
            return;

       string[] lines = File.ReadAllLines(path);

        if (lines.Length == 0)
        {
            Console.WriteLine("Filen är tom. Ingen data att läsa.");
            return;
        }

        foreach (string line in lines)
        {
            // FEL: kraschar på tom rad
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split(';');

            // FEL: kraschar om rad inte har två delar
            if (parts.Length != 2)
                continue;

            // FEL: kraschar om pris inte är ett tal
            if (!int.TryParse(parts[0], out int price))
                continue;

            items.Add(new Item(parts[1], price));
        }
    }
}