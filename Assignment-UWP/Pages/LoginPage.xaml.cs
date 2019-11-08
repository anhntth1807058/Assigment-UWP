using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Assignment_UWP.Entity;
using Assignment_UWP.Pages;
using Assignment_UWP.Service;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Assignment_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Windows.UI.Xaml.Controls.Page
    {

        private IMemberService _memberService;
        private IFileService _fileService;

        public LoginPage()
        {
            Debug.WriteLine("Init login.");
            this.InitializeComponent();
            this._memberService = new MemberService();
            this._fileService = new LocalFileService();
        }



        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegisterPage));
        }

        private void ButtonLogin_OnClick(object sender, RoutedEventArgs e)
        {
            var memberLogin = new MemberLogin
            {
                email = Email.Text,
                password = Password.Password
            };
            var memberCredential = this._memberService.Login(memberLogin);
            this._fileService.SaveMemberCredentialToFile(memberCredential);
        }

    }
}