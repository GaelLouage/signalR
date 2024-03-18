using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace WPFClient;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    HubConnection connection;
    HubConnection counterConnection;
    public MainWindow()
    {
        InitializeComponent();
        connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7121/chathub")
            .WithAutomaticReconnect()
            .Build();


        counterConnection = new HubConnectionBuilder()
         .WithUrl("https://localhost:7121/counterhub")
         .WithAutomaticReconnect()
         .Build();

        connection.Reconnecting += (sender) =>
        {
            this.Dispatcher?.Invoke(() =>
            {
                var newMessage = "Attempting to reconnect...";
                lbMessages.Items.Add(newMessage);   
            });
            // wait on the above and return the successfully completed task
            return Task.CompletedTask;
        };


        connection.Reconnected += (sender) =>
        {
            this.Dispatcher?.Invoke(() =>
            {
                var newMessage = "Reconnected to the server.";
                lbMessages.Items.Clear();
            });
            // wait on the above and return the successfully completed task
            return Task.CompletedTask;
        };


        connection.Closed += (sender) =>
        {
            this.Dispatcher?.Invoke(() =>
            {
                var newMessage = "Connection Closed.";
                lbMessages.Items.Add(newMessage);
                btnOpenConnection.IsEnabled = true;
                btnSendMessage.IsEnabled = false;
            });
            // wait on the above and return the successfully completed task
            return Task.CompletedTask;
        };
    }

    private async void btnOpenConnection_Click(object sender, RoutedEventArgs e)
    {
        connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            this.Dispatcher?.Invoke(() =>
            {
                var newMessage = $"{user}: {message}";
                lbMessages.Items.Add(newMessage);
            });
        });
        try
        {
            await connection.StartAsync();
            lbMessages.Items.Add("Connection Started");
            btnOpenConnection.IsEnabled = false;
            btnSendMessage.IsEnabled = true;
        }
        catch (Exception ex)
        {

            lbMessages.Items.Add(ex.Message);
        }
    }

    private async void btnSendMessage_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtMessageInput.Text)) return;
            await connection.InvokeAsync("SendMessage", 
                "WPF Client", txtMessageInput.Text);
        }
        catch (Exception ex)
        {
            lbMessages.Items.Add(ex.Message);
        }
     
    }

    private async void btnCounterIncrement_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            await counterConnection.InvokeAsync("AddToTotal",
                "WPF Client", 1);
            //connection.On<string, int>("AddToTotal", (user, value) =>
            //{
            //    Dispatcher?.Invoke(() =>
            //    {
            //        MessageBox.Show($"{value}");
            //    });
            //});
        }
        catch (Exception ex)
        {

            lbMessages.Items.Add(ex.Message);
        }
     
    }

    private async void btnOpenCounterConnection_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            await counterConnection.StartAsync();
        }
        catch (Exception ex)
        {


            lbMessages.Items.Add(ex.Message);
        }
    }
}