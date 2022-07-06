using BlueNotify.Models;
using Microsoft.Azure.NotificationHubs;

namespace BlueNotify.Services
{
    public class NotificationHubService
    {
        public StatusConnection StatusConnection { get; set; } = StatusConnection.Notconnected;
        public NotificationHubClient? HubInstance { get; set; } = null;
        public void InitializeHub(String connection, String hubName)
        {
            StatusConnection = StatusConnection.Connecting;
            HubInstance = NotificationHubClient.CreateClientFromConnectionString(connection, hubName);
            StatusConnection = StatusConnection.Connected;
        }

        public String GetStatus()
        {
            switch (StatusConnection)
            {
                case StatusConnection.Notconnected: return "Not Connected";
                case StatusConnection.Connected: return "Connected";
                case StatusConnection.Connecting: return "Connecting";
                case StatusConnection.Error: return "Error";
            }
            return "Unknown";
        }
    }
}
