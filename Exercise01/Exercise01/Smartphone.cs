public class Smartphone {
    private int id;
    private string brand;
    private string type;
    private int release_year;
    private decimal start_price;
    private string operating_system;

    public Smartphone(int id, string brand, string type, int release_year, decimal start_price, string operating_system) {
        this.id = id;
        this.brand = brand;
        this.type = type;
        this.release_year = release_year;
        this.start_price = start_price;
        this.operating_system = operating_system;
    }

    public int Id {
        get { return id; }
        set { id = value; }
    }

    public string Brand {
        get { return brand; }
        set { brand = value; }
    }

    public string Type {
        get { return type; }
        set { type = value; }
    }

    public int ReleaseYear {
        get { return release_year; }
        set { release_year = value; }
    }

    public decimal StartPrice {
        get { return start_price; }
        set { start_price = value; }
    }

    public string OperatingSystem {
        get { return operating_system; }
        set { operating_system = value; }
    }

    public override string ToString() {
        return $"{id} - {brand} {type} ({release_year})";
    }
}