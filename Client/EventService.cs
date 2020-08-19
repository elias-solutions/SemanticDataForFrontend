namespace Client
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR.Client;

    public class EventService
    {
        private readonly string _url;
        private readonly string _hubName;
        private readonly HubConnection _connection;

        public EventService(string url, string hubName)
        {
            _url = url;
            _hubName = hubName;
            _connection = new HubConnectionBuilder()
                .WithUrl(_url + _hubName)
                .WithAutomaticReconnect()
                .Build();

            _connection.On<string>("CarAdded", key => Console.WriteLine($"Added item: identifier {key}"));
            _connection.On<string>("CarUpdated", key => Console.WriteLine($"Updated item: identifier {key}"));
            _connection.On<string>("CarDeleted", key => Console.WriteLine($"Deleted item: identifier {key}"));
        }

        public Task StartAsync()
        {
            return _connection.StartAsync();
        }
    }
}
