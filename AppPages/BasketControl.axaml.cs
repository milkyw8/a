using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using EasyShop.DataObject;
using EasyShop.Helper.Connection;
using EasyShop.Models;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;

namespace EasyShop.AppPages;
/// <summary>
/// Страница для отображения товаров в корзине пользователя 
/// </summary>
public partial class BasketControl : UserControl
{
    /// <summary>
    /// Основная логика отображения товаров
    /// </summary>
    
    public BasketControl()
    {
        InitializeComponent();
        

    }

    private void BtnProducts_OnClick(object? sender, RoutedEventArgs e)
    {
        
        try
        {
            FrameNavigation.navigate.Content = new ProductControl();
        }
        catch (Exception ex)
        {
            MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", "Непредвиденная ошибка", ButtonEnum.Ok, Icon.Error).Show();
            Console.WriteLine(ex);
            throw;
        }
       
    }
}