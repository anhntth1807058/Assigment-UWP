﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using Assignment_UWP.Entity;
using Assignment_UWP.Service;
using StorageFile = Windows.Storage.StorageFile;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Assignment_UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        private string _gender = "Gender";
        private StorageFile photo;
        private IMemberService _memberService;
        public RegisterPage()
        {
            Debug.WriteLine("Init register.");
            this.InitializeComponent();
            this._memberService = new MemberService();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //CaptureImage();
            var birthdaySelectedDate = this.Birthday.SelectedDate;
            if (birthdaySelectedDate == null)
            {
                birthdaySelectedDate = DateTime.Now;
            }
            var birthday = birthdaySelectedDate.Value.ToString("yyyy-MM-dd");

            var member = new Member
            {
                firstName = this.FirstName.Text,
                lastName = this.LastName.Text,
                avatar = AvatarUrl.Text,
                phone = this.Phone.Text,
                address = this.Address.Text,
                introduction = this.Introduction.Text,
                email = this.Email.Text,
                gender = _gender.Equals("Male") ? 1 : (_gender.Equals("Female") ? 0 : 2),
                birthday = birthday,
                password = this.Password.Password
            };
            var responseMember = this._memberService.Register(member);
            if (responseMember != null)
            {
                Debug.WriteLine("Register success with id: " + responseMember.id);
            }
            else
            {
                Debug.WriteLine("Register fails !");
            }
        }

        private async void ProcessCaptureImage()
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);

            this.photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (this.photo == null)
            {
                // User cancelled photo capture
                return;
            }

            string uploadUrl = GetUploadUrl();
            HttpUploadFile(uploadUrl, "myFile", "image/jpeg");
        }

        public async void HttpUploadFile(string url, string paramName, string contentType)

            // write file.
            Stream fileStream = await this.photo.OpenStreamForReadAsync();
                //Debug.WriteLine(string.Format("File uploaded, server response is: @{0}@", reader2.ReadToEnd()));
                //string imgUrl = reader2.ReadToEnd();
                //Uri u = new Uri(reader2.ReadToEnd(), UriKind.Absolute);
                //Debug.WriteLine(u.AbsoluteUri);
                //ImageUrl.Text = u.AbsoluteUri;
                //MyAvatar.Source = new BitmapImage(u);
                //Debug.WriteLine(reader2.ReadToEnd());
                string imageUrl = reader2.ReadToEnd();

        private string GetUploadUrl()
        {
            var httpClient = new HttpClient();
            // thực hiện gửi dữ liệu với phương thức post.
            var response = httpClient.GetAsync(ProjectConfiguration.GET_UPLOAD_URL).GetAwaiter().GetResult();
            // lấy kết quả trả về từ server.
            var uploadUrl = response.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("Upload url: " + uploadUrl);
            return uploadUrl;
        }


        private void RadionButton_OnChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton checkedRadio)
            {
                this._gender = checkedRadio.Tag.ToString();
            }
        }

        private void ButtonLogin_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }

        private void CapturePhoto(object sender, RoutedEventArgs e)
        {
            ProcessCaptureImage();
        }
    }
}