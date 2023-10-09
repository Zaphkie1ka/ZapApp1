using System;
using System.Runtime.InteropServices.JavaScript;

namespace ZapApp1.Models; 

public class Flights 
{
    public int ID { get; set; }

    public DateTime Date { get; set; }
    public int JetID { get; set; }
    public string Departure { get; set; }
    public string Destination { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int RunwayID { get; set; }
    public string Staff { get; set; }
}