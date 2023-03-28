using System.Collections.Generic;
using System.Linq;
using EasyShop.Models;

namespace EasyShop.DataObject;
/// <summary>
/// Класс для работы с корзиной
/// </summary>
public class Basket
{
    public List<Product> BasketItems { get; set; }
    public decimal TotalPrice => BasketItems.Sum(x => x.Price);
}