using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;
using EasyShop.AppPages;
using EasyShop.Helper.Connection;

namespace EasyShop;
/// <summary>
/// Главное окно приложения
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// Основная логика обработки гавного окна
    /// </summary>
    private bool m_Done = false;
    
    public MainWindow()
    {
        InitializeComponent();
        
        FrameNavigation.navigate = FrmMain;
        FrmMain.Content = new ProductControl();
    
        var iv = this.GetObservable(Window.IsVisibleProperty);
        iv.Subscribe(value =>
        {
            if (value && !m_Done)
            {
                m_Done = true;
                CenterWindow();
            }
        });
        
    }
    
    private async void CenterWindow()
    {
        if (this.WindowStartupLocation == WindowStartupLocation.Manual)
            return;
    
        Screen screen = null;
        while (screen == null)
        {
            await Task.Delay(1);
            screen = this.Screens.ScreenFromVisual(this);
        }
    
        if (this.WindowStartupLocation == WindowStartupLocation.CenterScreen)
        {
            var x = (int)Math.Floor(screen.Bounds.Width / 2 - this.Bounds.Width / 2);
            var y = (int)Math.Floor(screen.Bounds.Height / 2 - (this.Bounds.Height + 30) / 2);
    
            this.Position = new PixelPoint(x, y);
        }
        else if (this.WindowStartupLocation == WindowStartupLocation.CenterOwner)
        {
            var pw = this.Owner as Window;
            if (pw != null)
            {
                var x = (int)Math.Floor(pw.Bounds.Width / 2 - this.Bounds.Width / 2 + pw.Position.X);
                var y = (int)Math.Floor(pw.Bounds.Height / 2 - (this.Bounds.Height + 30) / 2 + pw.Position.Y);
    
                this.Position = new PixelPoint(x, y);
            }
        }
    }
    
}