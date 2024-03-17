using System.ComponentModel.Design;

public class Program01 {
    static void Main(string[] args) {
        var smartphoneRepository = new SmartphoneRepository();
        var smartphoneService = new SmartphoneService(smartphoneRepository);

        while (true) {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1 - List all smartphones");
            Console.WriteLine("2 - Search smartphones");
            Console.WriteLine("3 - Add smartphone");
            Console.WriteLine("4 - Exit");
            Console.Write("Choose an option: ");

            var option = Console.ReadLine();

            switch (option) {
                case "1":
                    var smartphones = smartphoneService.GetAllSmartphones();
                    foreach (var smartphone in smartphones) {
                        Console.WriteLine(smartphone);
                    }
                    break;

                case "2":
                    Console.Write("Enter a keyword: ");
                    var keyword = Console.ReadLine();
                    var searchResult = smartphoneService.SearchSmartphones(keyword);
                    foreach (var smartphone in searchResult) {
                        Console.WriteLine(smartphone);
                    }
                    break;

                case "3":
                    Console.Write("Enter smartphone details (Id, Brand, Type, Release Year, Start Price, Operating System) separated by commas: ");
                    var input = Console.ReadLine();
                    var parts = input?.Split(',');

                    if (parts != null && parts.Length == 6) {
                        try {
                            var newSmartphone = new Smartphone(
                                int.Parse(parts[0]),
                                parts[1],
                                parts[2],
                                int.Parse(parts[3]),
                                decimal.Parse(parts[4]),
                                parts[5]
                            );
                            smartphoneService.AddSmartphone(newSmartphone);
                        }
                        catch (Exception e) {
                            Console.WriteLine(e.Message);
                        }
                        
                    }
                    else {
                        Console.WriteLine("Invalid input.");
                    }
                    break;

                case "4":
                    Console.WriteLine("Exiting...");
                    return;
                
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;

            }
        }
    }
}