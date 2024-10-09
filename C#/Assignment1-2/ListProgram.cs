namespace Assignment1_2;

public class ListProgram
{
    public void Main()
    {
        List<String> items = new List<String>();

        while (true)
        {
            Console.Write("\nCurrent List:\n");
            foreach (var item in items)
            {
                Console.WriteLine("-" + item);
            }
            
            Console.WriteLine("\nEnter command (+ item, - item, or -- to clear): ");
            string command = Console.ReadLine();

            if (command.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            if (command.StartsWith("+"))
            {
                string itemToAdd = command.Substring(1).Trim();
                if (!string.IsNullOrWhiteSpace(itemToAdd))
                {
                    items.Add(itemToAdd);
                    Console.WriteLine("Added: " + itemToAdd);
                }
                else
                {
                    Console.WriteLine("Invalid command");
                }
            }
            else if (command.StartsWith("-"))
            {
                string itemToRemove = command.Substring(1).Trim();
                if (items.Remove(itemToRemove))
                {
                    Console.WriteLine("Removed: " + itemToRemove);
                }
            }
            else if (command.Equals("--"))
            {
                items.Clear();
                Console.WriteLine("List cleared.");
            }
            else
            {
                Console.WriteLine("Invalid command");
            }
        }
    }
}