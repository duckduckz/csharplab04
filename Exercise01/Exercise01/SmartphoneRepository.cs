using System.Data.Common;

public class SmartphoneRepository {

    private readonly string _filePath = "../../docs/smartphones.csv";

    public List<Smartphone> GetSmartphones() {
        var smartphones = new List<Smartphone>();
        
        if (File.Exists(_filePath)) {
            var lines = File.ReadAllLines(_filePath).Skip(1);

            foreach (var line in lines) {
                var columns = line.Split(';');

                if (columns.Length == 6) {
                    var smartphone = new Smartphone(
                        int.Parse(columns[0]),
                        columns[1],
                        columns[2],
                        int.Parse(columns[3]),
                        decimal.Parse(columns[4]),
                        columns[5]
                    );
                    smartphones.Add(smartphone);
                }
                
            }
        }
        else {
            Console.WriteLine($"The file at {_filePath} does not exist.");
        }

        return smartphones;
    }

    public Smartphone GetSmartphoneById(int id) {
        try {
            var smartphone = GetSmartphones().FirstOrDefault(s => s.Id == id);
            return smartphone ?? throw new Exception("Smartphone not found.");
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public void AddSmartphone(Smartphone smartphone) {
        try {

            // Check if the smartphone already exists
            if (GetSmartphoneById(smartphone.Id) != null) {
                Console.WriteLine($"Smartphone with id {smartphone.Id} already exists.");
            }

            // create new line to insert into the file
            var newLine = $"{smartphone.Id};{smartphone.Brand};{smartphone.Type};{smartphone.ReleaseYear};{smartphone.StartPrice};{smartphone.OperatingSystem}";
            File.AppendAllLines(_filePath, new string[] { newLine });
            Console.WriteLine("Smartphone added successfully.");
        }
        catch (Exception e) {
            Console.WriteLine("An error occurred while writing to the file: " + e.Message);
        }
    }

}