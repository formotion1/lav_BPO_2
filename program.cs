using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_12
{
    public abstract class Goods
    {
        protected string productName;
        protected DateTime registrationDate;
        protected decimal price;
        protected int quantity;
        protected string invoiceNumber;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set { registrationDate = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string InvoiceNumber
        {
            get { return invoiceNumber; }
            set { invoiceNumber = value; }
        }

        public Goods(string productName, DateTime registrationDate, decimal price, int quantity, string invoiceNumber)
        {
            this.productName = productName;
            this.registrationDate = registrationDate;
            this.price = price;
            this.quantity = quantity;
            this.invoiceNumber = invoiceNumber;
        }

        public abstract void ChangePrice(decimal newPrice);
        public abstract void ChangeQuantity(int newQuantity);
        public abstract decimal CalculateTotalCost();
        public abstract string GetCostAsString();
    }

    public interface IPriceChangeable
    {
        void ChangePrice(decimal newPrice);
    }

    public interface IQuantityChangeable
    {
        void ChangeQuantity(int newQuantity);
    }

    public class ConcreteGoods : Goods, IPriceChangeable, IQuantityChangeable
    {
        public ConcreteGoods(string productName, DateTime registrationDate, decimal price, int quantity, string invoiceNumber)
            : base(productName, registrationDate, price, quantity, invoiceNumber)
        {
        }

        public override void ChangePrice(decimal newPrice)
        {
            Price = newPrice;
        }

        public override void ChangeQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }

        public override decimal CalculateTotalCost()
        {
            return Price * Quantity;
        }

        public override string GetCostAsString()
        {
            return CalculateTotalCost().ToString();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите наименование товара: ");
            string productName = Console.ReadLine();

            Console.Write("Введите дату оформления товара (гггг-мм-дд): ");
            DateTime registrationDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Введите цену товара: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Введите количество единиц товара: ");
            int quantity = int.Parse(Console.ReadLine());

            Console.Write("Введите номер накладной: ");
            string invoiceNumber = Console.ReadLine();

            Goods goods = new ConcreteGoods(productName, registrationDate, price, quantity, invoiceNumber);

            Console.WriteLine("\nИнформация о товаре:");
            Console.WriteLine("Наименование: " + goods.ProductName);
            Console.WriteLine("Дата оформления: " + goods.RegistrationDate.ToShortDateString());
            Console.WriteLine("Цена: " + goods.Price.ToString() + " руб.");
            Console.WriteLine("Количество: " + goods.Quantity);
            Console.WriteLine("Номер накладной: " + goods.InvoiceNumber);
            Console.WriteLine("Общая стоимость: " + goods.GetCostAsString() + " руб.");

            Console.WriteLine("\nИзменение цены товара.");
            Console.Write("Введите новую цену товара: ");
            decimal newPrice = decimal.Parse(Console.ReadLine());
            ((IPriceChangeable)goods).ChangePrice(newPrice);

            Console.WriteLine("\nИзменение количества товара.");
            Console.Write("Введите новое количество товара: ");
            int newQuantity = int.Parse(Console.ReadLine());
            ((IQuantityChangeable)goods).ChangeQuantity(newQuantity);

            Console.WriteLine("\nИнформация о товаре после изменений:");
            Console.WriteLine("Цена: " + goods.Price.ToString() + " руб.");
            Console.WriteLine("Количество: " + goods.Quantity);
            Console.WriteLine("Общая стоимость: " + goods.GetCostAsString() + " руб.");
        }
    }
}
