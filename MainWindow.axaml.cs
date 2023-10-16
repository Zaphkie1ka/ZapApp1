using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;
using ZapApp1.Models;

namespace ZapApp1;

public partial class MainWindow : Window {
    private MySqlConnectionStringBuilder _connectionSql;
    private List<Passengers> passengers { get; set; }
    SecondWindow window2 = new SecondWindow();
    public MainWindow()
    {
        InitializeComponent();
        passengers = new List<Passengers>();
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
    }
    private void Btn1_Click(object? sender, RoutedEventArgs e)
    {
        window2.Show();
    }
}