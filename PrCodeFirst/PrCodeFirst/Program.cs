// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using PrCodeFirst.Models;
int r = 0;
void Print(Product product)
{
    Console.ForegroundColor = ConsoleColor.White;
    if (product.Count == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }
    Console.WriteLine(product.ProductName);
    Console.WriteLine(product.ImagePath);
    Console.WriteLine(product.Description);
    Console.WriteLine(product.Category.CategoryName);
    Console.WriteLine(product.Count);
    Console.WriteLine(product.PriceWithDiscount);
    Console.WriteLine(" ");
}
void PrintCategory(Category category)
{
    Console.WriteLine($"{category.CategoryId} {category.CategoryName}");
}
while (r != 1)
{
    Console.WriteLine("Выберите действие: ");
    Console.WriteLine("1. Выход - 1");
    Console.WriteLine("2. Вывод товаров - 2");
    Console.WriteLine("3. Вывод первых N товаров - 3");
    Console.WriteLine("4. Поиск товара - 4");
    Console.WriteLine("5. Вывод товаров определенной категории - 5");
    Console.WriteLine("6. Добавление товара - 6");
    Console.WriteLine("7. Удаление товара - 7");
    Console.WriteLine("8. Изменение товара - 8");
    r = Convert.ToInt32(Console.ReadLine());
    var context = new ProductsContext();
    switch (r)
    {
        case 1:
            Console.WriteLine("Выход");
            break;
        case 2:
            foreach (Product product in context.Products.Include(p=>p.Category))
            {
                Print(product);
            }
            break;
        case 3:
            Console.WriteLine("Введите количество для вывода:");
            int N = Convert.ToInt32(Console.ReadLine());
            foreach (Product product in context.Products.Include(p => p.Category).OrderByDescending(p=>p.Price).Take(N))
            {
                Print(product);
            }
            break;
        case 4:
            Console.WriteLine("Введите слово для поиска:");
            string search = Console.ReadLine();
            foreach (Product product in context.Products.Include(p => p.Category))
            {
                if (!product.ProductName.Contains(search))
                {
                    break;
                }
                else
                {
                    Print(product);
                }
            }
            break;
        case 5:
            
            int id = 1;
            while (true)
            {
                Console.WriteLine("Категории:");
                foreach (Category category in context.Categories)
                {
                    PrintCategory(category);
                }
                id = Convert.ToInt32(Console.ReadLine());
                if (id >= 1 & id <= 5)
                {
                    foreach (Product product in context.Products.Include(p => p.Category).Where(p => p.CategoryId == id))
                    {
                        if (product.ProductName!="")
                        {
                            Print(product);
                        }
                        else
                        {
                            Console.WriteLine("Список пуст.");
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Не та категория...");
                }
            }
            break;
        case 6:
            Product pr = new Product();
            Console.WriteLine("Введите название:");
            pr.ProductName = Console.ReadLine();
            Console.WriteLine("Введите путь изображения:");
            pr.ImagePath = Console.ReadLine();
            Console.WriteLine("Введите описание:");
            pr.Description = Console.ReadLine();
            Console.WriteLine("Введите количество:");
            pr.Count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите стоимость:");
            pr.Price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите скидку:");
            pr.Discount= Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Выберите категорию:");
            foreach (Category category in context.Categories)
            {
                PrintCategory(category);
            }
            pr.CategoryId = Convert.ToInt32(Console.ReadLine());
            context.Products.Add(pr);
            try
            {
                context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Произошла ошибка");
                context.Products.Remove(pr);
            }
            break;
        case 7:
            Product prod = new Product();
            Console.WriteLine("Введите идентификатор товара:");
            int b= Convert.ToInt32(Console.ReadLine());
            prod = context.Products.Include(p => p.Category).FirstOrDefault(s=>s.ProductId==b);
            if (prod == null)
            {
                Console.WriteLine("Нет.");
            }
            try
            {
                context.Products.Remove(prod);
                context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Произошла ошибка");
            }
            break;
        case 8:
            Product produ = new Product();
            Console.WriteLine("Введите идентификатор товара:");
            int d = Convert.ToInt32(Console.ReadLine());
            produ = context.Products.Find(d);
            if (produ == null)
            {
                Console.WriteLine("Нет.");
            }
            else
            {
                Console.WriteLine("Введите новое количество товаров:");
                produ.Count = Convert.ToInt32(Console.ReadLine());
            }
            try
            {
                context.Products.Update(produ);
                context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Произошла ошибка");
            }
            break;
    }
}