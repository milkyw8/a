using EasyShop.Models;

namespace EasyShop.Helper.Navigation;

public class ConnectDb
{
    public static ProfUser1Context connect { get; set; } = new ProfUser1Context();
}