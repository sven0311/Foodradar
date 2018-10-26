using Acr.UserDialogs;
using FoodRadar.Database.DatabaseModels;
using FoodRadar.Database;
using PageNavSingleton;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Pages;

namespace FoodRadar.ViewModels
{
    public class ProfilePrefViewModel : ViewModelBase
    {

        public PageNavigationManager navManager = PageNavigationManager.Instance;
        public string oldPassword;
        public string newPassword;
        public string confNewPassword;

        public string OldPassword
        {
            get
            {
                return oldPassword;
            }
            set
            {
                if (value != oldPassword)
                {
                    oldPassword = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NewPassword
        {
            get
            {
                return newPassword;
            }
            set
            {
                if (value != newPassword)
                {
                    newPassword = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ConfNewPassword
        {
            get
            {
                return confNewPassword;
            }
            set
            {
                if (value != confNewPassword)
                {
                    confNewPassword = value;
                    OnPropertyChanged();
                }
            }
        }




        public Command Button_ChangePassword { protected set; get; }
        public Command Button_DeleteAccount { protected set; get; }
        public Command Button_Messurements { protected set; get; }
        public Command Button_confirm { protected set; get; }

        public ProfilePrefViewModel()
        {
            

            Button_ChangePassword = new Command(async () => ChangePw());
            
            Button_DeleteAccount = new Command(async () => DelAcc());


            //Button_Messurements = new Command(async () => Messurem());

            Button_confirm = new Command(async () => test());
        }

        public void Confirm()
        {

        }

        public async void DelAcc()
        {
            var result = await UserDialogs.Instance.ConfirmAsync(new ConfirmConfig
            {
                Message = "Are You sure that you want to delete your account?",
                OkText = "Delete",
                CancelText = "Cancel"
            });
            if (result)
            {
                LoginViewModel.loggedIn = false;
                
                await App.Database.DeleteCustomerAsync(LoginViewModel.customer);
                LoginViewModel.customer = null;
                UserDialogs.Instance.Alert("", "Account Deleted!", "Ok");
                navManager.showMainPageAfterLoginPage();
                //Application.Current.MainPage = new LogInpage(false);
            }
        }
        public async void ChangePw()
        {
            await PopupNavigation.Instance.PushAsync(new PopUpPage());



        }
        //public async void Messurem()
        //{

        //  var result2 = await UserDialogs.Instance.ConfirmAsync(new ConfirmConfig
        //{
        //Message = "Which mesurement do you prefer?",
        //  OkText = "Kilimeters(Km)",
        //  CancelText = "Miles(Mi)"
        //});
        //if (result2)
        // {
        //   
        // }

        //        }

        const string pwRegex = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{5,}$";
        async void test()
        {
            if (confNewPassword == null || newPassword == null || oldPassword == null || confNewPassword.Equals("") || newPassword.Equals("") || oldPassword.Equals(""))
            {
                UserDialogs.Instance.Alert("Fields can not be blank");
            }
            if (this.ConfNewPassword != this.NewPassword)
            {
                UserDialogs.Instance.Alert("", "Password Confirmation Fail", "Try again");
            }

            else if (this.ConfNewPassword != this.NewPassword)
            {
                UserDialogs.Instance.Alert("", "Password not valid, please chose another password", "Try again");
            }
            else if (!Regex.IsMatch(this.NewPassword, pwRegex))
            {
                UserDialogs.Instance.Alert("", "Password not valid, please chose another password", "Try again");
            }
            else
            {
                LoginViewModel.customer.password = this.NewPassword;
                PopupNavigation.Instance.PopAsync(true);
                UserDialogs.Instance.Alert("", "Password changed!", "Ok");
            }
        
        }

    }
}