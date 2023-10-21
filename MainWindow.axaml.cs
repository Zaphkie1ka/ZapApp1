using System;
using System.Collections.Generic;
using System.Data;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;
using ZapApp1.Models;

namespace ZapApp1;

public partial class MainWindow : Window {
    private MySqlConnectionStringBuilder _connectionSql;
    private List<Passengers> passengers { get; set; }
    private List<Flights> flights { get; set; }
    private List<Tickets> tickets { get; set; }
    private List<Jets> jets { get; set; }
    private List<Runways> runways { get; set; }
    SecondWindow window2 = new SecondWindow();
    public MainWindow()
    {
        InitializeComponent();
        passengers = new List<Passengers>();
        tickets = new List<Tickets>();
        jets = new List<Jets>();
        runways = new List<Runways>();
        flights = new List<Flights>();
        _connectionSql = new MySqlConnectionStringBuilder {
            Server = "10.10.1.24",
            Database = "pro18",
            UserID = "user_01",
            Password = "user01pro"
        };
        UpdateDataGrid();
        
    }
    void UpdateDataGrid()
    {
        using (var connection = new MySqlConnection(_connectionSql.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * From Flights";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        flights.Add(new Flights
                        {
                            ID = reader.GetInt32("FlightID"),
                            Date = Convert.ToDateTime(reader.GetString("Date")),
                            JetID = reader.GetInt32("JetID"),
                            Departure = reader.GetString("Departure"),
                            Destination = reader.GetString("Destination"),
                            DepartureTime = Convert.ToDateTime(reader.GetString("DepartureTime")),
                            ArrivalTime = Convert.ToDateTime(reader.GetString("ArrivalTime")),
                            RunwayID = reader.GetInt32("RunwayID"),
                            Staff = reader.GetString("Staff")
                        });
                    }
                }
                command.CommandText = "SELECT * From Jets";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        jets.Add(new Jets
                        {
                            ID = reader.GetInt32("JetID"),
                            JetType = reader.GetString("JetType"),
                            SeatCapacity = reader.GetString("SeatCapacity")
                        });
                    }
                }
                command.CommandText = "SELECT * From Passengers";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        passengers.Add(new Passengers
                        {
                            ID = reader.GetInt32("PassengerID"),
                            Name = reader.GetString("Name"),
                            Sex = reader.GetString("Sex"),
                            Age = reader.GetInt32("Age"),
                            Nationality = reader.GetString("Nationality"),
                            Passport = reader.GetInt32("Passport"),
                            Contact = reader.GetInt64("Contact")
                        });
                    }
                }

            }
            connection.Close();
        }
        Passenger.ItemsSource = passengers;
        Flight.ItemsSource = flights;
        Jet.ItemsSource = jets;
    }
    private void Btn1_Click(object? sender, RoutedEventArgs e)
    {
        window2.Show();
    }
}