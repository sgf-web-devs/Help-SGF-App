using System;
using System.Collections.Generic;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace HelpSGF.Views
{
    public partial class SendMessagePage : ContentPage
    {
        public SendMessagePage()
        {
            InitializeComponent();
        }

        async void TakePhoto_ClickedAsync(object sender, System.EventArgs e)
        {
            var filename = Guid.NewGuid().ToString() + ".jpg";

            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];
            }

            if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted)
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    //Directory = "Help SGF",
                    //Name = filename
                    SaveToAlbum = false,
                    PhotoSize = PhotoSize.Medium
                });

                if (file == null)
                    return;

                //await DisplayAlert("File Location", file.Path, "OK");

                Image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });

                Image.IsVisible = true;
            }
            else
            {
                await DisplayAlert("Permissions Denied", "Unable to take photos.", "OK");
                //On iOS you may want to send your user to the settings screen.
                //CrossPermissions.Current.OpenAppSettings();
            }
        }

        async void PickPhoto_ClickedAsync(object sender, System.EventArgs e)
        {
            var filename = Guid.NewGuid().ToString() + ".jpg";

            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];
            }

            if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted)
            {
                var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    //Directory = "Help SGF",
                    //Name = filename
                    //SaveToAlbum = false
                    PhotoSize = PhotoSize.Medium
                });

                if (file == null)
                    return;

                //await DisplayAlert("File Location", file.Path, "OK");

                Image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });

                Image.IsVisible = true;
            }
            else
            {
                await DisplayAlert("Permissions Denied", "Unable to take photos.", "OK");
                //On iOS you may want to send your user to the settings screen.
                //CrossPermissions.Current.OpenAppSettings();
            }
        }
    }
}
