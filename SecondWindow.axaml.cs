using System;
using System.Collections.Generic;
using System.Data.Common;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;
using ZapApp1.Models;

namespace ZapApp1;

public partial class SecondWindow : Window
{
    private MySqlConnectionStringBuilder _connectionSql;
    private List<Runways> runways { get; set; }
    public SecondWindow()
    {
        InitializeComponent();
        runways = new List<Runways>();
        _connectionSql = new MySqlConnectionStringBuilder {
            Server = "10.10.1.24",
            Database = "pro18",
            UserID = "user_01",
            Password = "user01pro"
        };
        UpdateDataGrid();

    }
    public void UpdateDataGrid()
    {
        using (var connection = new MySqlConnection(_connectionSql.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * From Runways";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        runways.Add(new Runways
                        {
                            ID = reader.GetInt32("RunwayID"),
                            RunwayTrack = reader.GetString("RunwayTrack")
                        });
                    }
                }
            }
            connection.Close();
        }
        Runway.ItemsSource = runways;
        
    }
}