public class SmartphoneService {
    private readonly SmartphoneRepository smartphoneRepository;

    public SmartphoneService(SmartphoneRepository smartphoneRepository) {
        this.smartphoneRepository = smartphoneRepository;
    }

    public List<Smartphone> GetAllSmartphones() {
        return smartphoneRepository.GetSmartphones();
    }

    public List<Smartphone> SearchSmartphones(string keyword) {
        return this.smartphoneRepository.GetSmartphones()
                                        .Where(s => s.Brand.Contains(keyword, StringComparison.OrdinalIgnoreCase) || 
                                        s.Type.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                                        .ToList();  
        
    }

    public void AddSmartphone(Smartphone smartphone) {
        try {
            this.smartphoneRepository.AddSmartphone(smartphone);
            Console.WriteLine("Smartphone added successfully.");
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
        }

    }
}