using BlueNotify.Models;
using BlueNotify.Services;
using Microsoft.Azure.NotificationHubs;
using Newtonsoft.Json;

namespace BlueNotify.Views;

public partial class Explorer : ContentPage
{
    private readonly NotificationHubService notificationHubService;
    private ExplorerView explorerView = new ExplorerView();
    public Explorer(NotificationHubService notificationHubService)
	{
		InitializeComponent();
        this.BindingContext = explorerView;
        this.notificationHubService = notificationHubService;
    }

    private async void InstallationListBtn(object sender, EventArgs e)
    {
        try
        {
            if (notificationHubService.StatusConnection != StatusConnection.Connected)
                throw new Exception("NotificationHub not connected!");
            await FetchDataProgressBar.ProgressTo(0.75, 100, Easing.Linear);
            var results = await notificationHubService.HubInstance.GetAllRegistrationsAsync(0);
            await FetchDataProgressBar.ProgressTo(1, 100, Easing.Linear);
            if (results.Any())
                explorerView.Response = JsonConvert.SerializeObject(results, Formatting.Indented);
            else
                await DisplayAlert("Response", "Empty response!", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
        await FetchDataProgressBar.ProgressTo(0, 100, Easing.Linear);
    }

    private async void DeleteDeviceBtn(object sender, EventArgs e)
    {
        try
        {
            if (notificationHubService.StatusConnection != StatusConnection.Connected)
                throw new Exception("NotificationHub not connected!");
            await FetchDataProgressBar.ProgressTo(0.45, 100, Easing.Linear);
            var payload = JsonConvert.DeserializeObject<DeleteDevice>(explorerView.Request);
            await FetchDataProgressBar.ProgressTo(0.75, 100, Easing.Linear);
            var device = await notificationHubService.HubInstance.GetRegistrationAsync<RegistrationDescription>(payload.DeviceId);
            await FetchDataProgressBar.ProgressTo(1, 100, Easing.Linear);
            if (device != null)
            {
                explorerView.Response = JsonConvert.SerializeObject(device, Formatting.Indented);
                await notificationHubService.HubInstance.DeleteRegistrationAsync(device);
                await DisplayAlert("Success", "Deleted!", "OK");
            }
            else
                await DisplayAlert("Response", "Empty response!", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
        await FetchDataProgressBar.ProgressTo(0, 100, Easing.Linear);
    }

    private async void GetDeviceBtn(object sender, EventArgs e)
    {
        try
        {
            if (notificationHubService.StatusConnection != StatusConnection.Connected)
                throw new Exception("NotificationHub not connected!");
            await FetchDataProgressBar.ProgressTo(0.45, 100, Easing.Linear);
            var payload = JsonConvert.DeserializeObject<DeleteDevice>(explorerView.Request);
            await FetchDataProgressBar.ProgressTo(0.75, 100, Easing.Linear);
            var device = await notificationHubService.HubInstance.GetRegistrationAsync<RegistrationDescription>(payload.DeviceId);
            await FetchDataProgressBar.ProgressTo(1, 100, Easing.Linear);
            if (device != null)
                explorerView.Response = JsonConvert.SerializeObject(device, Formatting.Indented);
            else
                await DisplayAlert("Response", "Empty response!", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
        await FetchDataProgressBar.ProgressTo(0, 100, Easing.Linear);
    }

    private async void SendIosNotifyBtn(object sender, EventArgs e)
    {
        try
        {
            if (notificationHubService.StatusConnection != StatusConnection.Connected)
                throw new Exception("NotificationHub not connected!");
            await FetchDataProgressBar.ProgressTo(0.45, 100, Easing.Linear);
            var payload = JsonConvert.DeserializeObject<NotificationRequest>(explorerView.Request);
            var results = await notificationHubService.HubInstance.SendAppleNativeNotificationAsync(payload.Payload, payload.Tags);
            await FetchDataProgressBar.ProgressTo(1, 100, Easing.Linear);
            if (results != null)
                explorerView.Response = JsonConvert.SerializeObject(results, Formatting.Indented);
            else
                await DisplayAlert("Response", "Empty response!", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
        await FetchDataProgressBar.ProgressTo(0, 100, Easing.Linear);
    }
}