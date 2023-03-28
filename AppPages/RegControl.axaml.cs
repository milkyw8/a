using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using EasyShop.Helper.Action;
using EasyShop.Helper.Connection;
using EasyShop.Helper.Navigation;
using EasyShop.Models;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;

namespace EasyShop.AppPages;

public partial class RegControl : UserControl
{
    public RegControl()
    {
        InitializeComponent();
    }
    
    private void BtnSignUp_OnClick(object? sender, RoutedEventArgs e)
    {
        FrameNavigation.navigate.Content = new AuthControl();
    }

    private void BtnProducts_OnClick(object? sender, RoutedEventArgs e)
    {
        FrameNavigation.navigate.Content = new ProductControl();
    }

    private void BtnReg_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (TxbLogin.Text != null && TxbPassword.Text != null)
            {
                var checkUser = ConnectDb.connect.Users.FirstOrDefault(x => x.Login == TxbLogin.Text);

                if (checkUser == null) 
                {
                    var Result = CheckPassword.CheckPass(TxbPassword.Text);
                    if (Result == true)
                    {
                        var CreateUser = new User()
                        {
                            Login = TxbLogin.Text,
                            Password = TxbPassword.Text,
                            RoleId = 2
                        };
                        ConnectDb.connect.Add(CreateUser);
                        ConnectDb.connect.SaveChanges();
                        
                        TxbLogin.Clear();
                        TxbPassword.Clear();
                        MessageBoxManager.GetMessageBoxStandardWindow("Успех ","Аккаунт создан", ButtonEnum.Ok, Icon.Success).Show();
                    }
                    else
                    {
                        MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", 
                            "Минимальная длина пароля 8 символов, 1 символ в верхнем регистре, 1 символ в нижнем регистре, 1 спецсимвол", 
                            ButtonEnum.Ok, Icon.Error).Show();
                        
                    }
                    
                }
                else
                {
                    MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", 
                        "Логин уже занят, выберите другой", 
                        ButtonEnum.Ok, Icon.Error).Show();   
                }
                
            }
            else
            {
                MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Логин или пароль пусты", ButtonEnum.Ok, Icon.Error).Show();
            }
        }
        catch (Exception exception)
        {
            MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Необработанное исключение", ButtonEnum.Ok, Icon.Error).Show();
           
        }
    }
}