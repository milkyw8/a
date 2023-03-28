using System.Linq;

namespace EasyShop.Helper.Action;
/// <summary>
/// Класс для проверки пароля
/// </summary>
public class CheckPassword
{
    internal static bool CheckPass(string password) => password.Length >= 8
                                               && password.Any(char.IsNumber)
                                               && password.Any(char.IsLower)
                                               && password.Any(char.IsUpper);
}