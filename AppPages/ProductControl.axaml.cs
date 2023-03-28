using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using EasyShop.DataObject;
using EasyShop.Helper.Connection;
using EasyShop.Helper.Navigation;
using EasyShop.Models;

namespace EasyShop.AppPages;
/// <summary>
/// Страница с товарами 
/// </summary>
public partial class ProductControl : UserControl
{
    /// <summary>
    /// Основная логика обработки страницы
    /// </summary>
    public List<Product> ProductsList;
    public List<Product> FiltreProducts;
    public ProductControl()
    {
        InitializeComponent();
        LoadProducts();
    }
    
    private void BtnBasket_OnClick(object? sender, RoutedEventArgs e)
    {
        FrameNavigation.navigate.Content = new BasketControl();
    }

    private void BtnSignUp_OnClick(object? sender, RoutedEventArgs e)
    {
        FrameNavigation.navigate.Content = new AuthControl();
    }
    
    private void TxbSearch_OnGotFocus(object? sender, GotFocusEventArgs e)
    {
        TextBox Tb = (TextBox)sender;
        Tb.Text = string.Empty;
        Tb.GotFocus -= TxbSearch_OnGotFocus;
    }
    
    private void LoadProducts()
    {
        var ProductData = ConnectDb.connect.Products.ToList();
        ProductsList = ProductData;
        ItemsProduct.Items = ProductsList;
    }

    public Basket Basket;
    // public List<Product> UserBasket;
    private void BtnBuy_OnClick(object? sender, RoutedEventArgs e)
    {
        HeapProduct.ProductHeap = (sender as Button).DataContext as Product;
        // var IdProduct = HeapProduct.ProductHeap.Id;
        
        Basket.BasketItems.Add(HeapProduct.ProductHeap);

    }

    private void BtnSearch_OnClick(object? sender, RoutedEventArgs e)
    {
        var ProductFilter =  ProductsList.Where(x =>
            x.Name == TxbSearch.Text ||
            x.Description == TxbSearch.Text ||
            x.Price == Convert.ToDecimal(TxbSearch.Text));

        FiltreProducts = ProductFilter.ToList();
        ItemsProduct.Items = FiltreProducts;
    }
}