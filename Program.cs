using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        int parkingId = 0; 
        List<Auto> autosToPark = new List<Auto>{
            new Auto { motorcycle = new Motorcycle{ size = SpaceSize.Compact, id = ++parkingId}},
            new Auto { van = new Van { size = SpaceSize.Large, id = ++parkingId}},
            new Auto { car = new Car { size = SpaceSize.Regular, id = ++parkingId}},
            new Auto { van = new Van { size = SpaceSize.Regular, id = ++parkingId}}
        }; 

        ParkingLot pl = new ParkingLot();        
        pl.parkAutos(autosToPark);  
        Console.Write(pl.TotalSpotsTaken);                       
    }
}

public class ParkingLot{
    public Dictionary<int, Auto> pkLot = new System.Collections.Generic.Dictionary<int, Auto>(); 

    public int TotalSpotsTaken { get; set; } = 0; 
    public int TotalSpotsAvailable {get; set; } = 50;

    public void parkAutos(List<Auto> autos){    
        foreach (var auto in autos)
        {
            if (TotalSpotsTaken < TotalSpotsAvailable)
            {
                if (auto.car != null)
                {
                    pkLot.Add(auto.car!.id, auto); 
                    TotalSpotsTaken = TotalSpotsTaken + (int)auto.car.size;
                    TotalSpotsAvailable = TotalSpotsAvailable - TotalSpotsTaken;  
                }
                if (auto.van != null)
                {
                    pkLot.Add(auto.van!.id, auto);
                    TotalSpotsTaken = TotalSpotsTaken + (int)auto.van.size;
                    TotalSpotsAvailable = TotalSpotsAvailable - TotalSpotsTaken;  
                }
                if (auto.motorcycle != null)
                {
                    pkLot.Add(auto.motorcycle!.id, auto);
                    TotalSpotsTaken = TotalSpotsTaken + (int)auto.motorcycle.size;
                    TotalSpotsAvailable = TotalSpotsAvailable - TotalSpotsTaken;  
                }
            }
        }
    }
}

public class Auto  {
    public Motorcycle? motorcycle { get; set; }
    public Car? car { get; set; }
    public Van? van { get; set; }
}

public interface IAuto {
    SpaceSize size {get; set; }
    int id {get; set;}
}

public class Motorcycle: IAuto {
    public SpaceSize size { get; set; }
    public int id { get; set; }
}

public class Car: IAuto {
    public SpaceSize size { get; set;}
    public int id { get; set; }
}

public class Van: IAuto {
    public SpaceSize size { get; set;} 
    public int id { get; set; }   
}
public enum SpaceSize {
    Compact = 1, 
    Regular,
    Large
}




