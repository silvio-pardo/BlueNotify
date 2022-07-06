using BlueNotify.Models;
using BlueNotify.Services;

namespace BlueNotify.Views;

public partial class AppSettings : ContentPage
{
    private readonly NotificationHubService notificationHubService;
    private NotificationHubParameters notificationHubParameters = new NotificationHubParameters();
    public AppSettings(NotificationHubService notificationHubService)
	{
		InitializeComponent();
        this.BindingContext = notificationHubParameters;
        this.notificationHubService = notificationHubService;
    }

    private void EndButtonClicked(object sender, EventArgs e)
    {
        this.notificationHubParameters.HubName = "";
        this.notificationHubParameters.HubUrl = "";
        this.notificationHubService.HubInstance = null;
    }
    private async void StartButtonClicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.notificationHubParameters.HubUrl))
                throw new Exception("HubUrl empty!");
            if (string.IsNullOrEmpty(this.notificationHubParameters.HubName))
                throw new Exception("HubName empty!");
            notificationHubService.InitializeHub(this.notificationHubParameters.HubUrl, this.notificationHubParameters.HubName);
            await DisplayAlert("Connected", "You are connected!", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}