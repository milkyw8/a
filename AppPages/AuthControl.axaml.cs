using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Remote.Protocol.Viewport;
using EasyShop.Helper.Connection;
using EasyShop.Helper.Navigation;
using EasyShop.Models;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.AppPages;

public partial class AuthControl : UserControl
{
    public AuthControl()
    {
        InitializeComponent();
    }

    private void BtnProducts_OnClick(object? sender, RoutedEventArgs e)
    {
        FrameNavigation.navigate.Content = new ProductControl();
    }


    private void BtnSignUp_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {

            var Data = ConnectDb.connect.Users.Include(x => x.Role).FirstOrDefault(x => x.Login == TxbLogin.Text && x.Login == TxbLogin.Text);

            if (Data != null)
            {
                switch (Data.Role.Name)
                {
                    case "Клиент":
                        MessageBoxManager.GetMessageBoxStandardWindow("Успех", $"Вы в системе ваша роль {Data.Role.Name}", ButtonEnum.Ok, Icon.Error).Show();
                        break;
                    
                    case "Администратор":
                        MessageBoxManager.GetMessageBoxStandardWindow("Успех", $"Вы в системе ваша роль {Data.Role.Name}", ButtonEnum.Ok, Icon.Error).Show();
                        break;
                    
                }
            }
            else
            {
                MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Неправильный логин или пароль", ButtonEnum.Ok, Icon.Error).Show();
            }
            
        }
        catch (Exception ex)
        {
            MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Необработанное исключение", ButtonEnum.Ok, Icon.Error).Show();

        }
    }

    private void BtnReg_OnClick(object? sender, RoutedEventArgs e)
    {
        FrameNavigation.navigate.Content = new RegControl();
    }
}