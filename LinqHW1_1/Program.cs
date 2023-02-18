using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqHW1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Product> products = Creatlist(@"C:\\Users\\azhon\\source\\repos\\LinqHW1\\product.csv");
            //Console.WriteLine(products.Count);
            int pgselect = 0;
            string select = "";
            while (true)
            {
                Console.WriteLine("請任意一數字(1-4)");
                select = Console.ReadLine();
                if ((select == null) || (select == ""))
                {
                    Console.Clear();
                    Console.WriteLine("輸入錯誤，任一鍵重新選擇");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else
                {
                    pgselect = int.Parse(select);
                }
                Console.WriteLine(pgselect);
                if(pgselect <= 5) 
                {
                    Console.Clear() ;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("輸入錯誤，任一鍵重新選擇");
                    Console.ReadKey();
                    Console.Clear();

                    continue;
                }

            }
            
            while(true)
            {
                switch (pgselect)
                {
                    case 1:
                        while(true)
                        {
                            var totalprice = products.Sum((x) => x.Price);
                            Console.WriteLine($"1、所有商品的總價格：{totalprice}");

                            var avgprice = products.Average((x) => x.Price);
                            Console.WriteLine($"2、所有商品的平均價格：{avgprice}");

                            var totalnum = products.Sum((x) => x.Num);
                            Console.WriteLine($"3、商品的總數量：{totalnum}");

                            var avgnum = products.Average((x) => x.Num);
                            Console.WriteLine($"4、商品的平均數量：{avgnum}");

                            Console.WriteLine("請任意一數字(1-4)");
                            select= Console.ReadLine();
                            if ((select == null) || (select == ""))
                                {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤，任一鍵重新選擇");
                                Console.ReadKey();
                                Console.Clear();

                                continue;
                            }
                            else
                            {
                                pgselect = int.Parse(select);
                            }

                            if(pgselect <= 5)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤，任一鍵重新選擇");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            var maxp = products.Max((x) => x.Price);
                            var maxprice = products.Where(x => x.Price == maxp);
                            foreach (var item in maxprice)
                            {
                                Console.WriteLine($"5、商品最貴：{item.Name}");
                            }

                            var minp = products.Min((x) => x.Price);
                            var minprice = products.Where(x => x.Price == minp);
                            foreach (var item in minprice)
                            {
                                Console.WriteLine($"6、商品最便宜：{item.Name}");
                            }

                            var total3c = products.Where((x) => x.Pdtype == "3C").Sum((x) => x.Price);
                            Console.WriteLine($"7、產品類別為 3C 的商品總價：{total3c}");


                            var totald = products.Where((x) => x.Pdtype == "飲料").Sum((x) => x.Price);
                            var totalf = products.Where((x) => x.Pdtype == "食品").Sum((x) => x.Price);
                            Console.WriteLine($"8、產品類別為飲料及食品的商品價格：{totald + totalf}");
                            Console.WriteLine("-----------------");

                            Console.WriteLine("請任意一數字(1-4)");
                            select = Console.ReadLine();
                            if ((select == null)|| (select == ""))
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤，任一鍵重新選擇");
                                Console.ReadKey();
                                Console.Clear();

                                continue;
                            }
                            else
                            {
                                pgselect = int.Parse(select);
                            }

                            if (pgselect <= 5)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤，任一鍵重新選擇");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                        }
                        break;
                    case 3:
                        while (true)
                        {
                            var allfood = products.Where((x) => x.Pdtype == "食品").Where((x) => x.Num > 100);
                            Console.WriteLine($"9、所有商品類別為食品，而且商品數量大於 100 的商品：");
                            foreach (var item in allfood)
                            {
                                Console.WriteLine($"{item.Name}");
                            }
                            Console.WriteLine("-----------------");


                            Console.WriteLine($"10、找出各個商品類別底下有哪些商品的價格是大於 1000 的商品：");
                            var result = products.Where((x) => x.Price > 1000).GroupBy((x) => x.Pdtype);
                            foreach (var item in result)
                            {
                                Console.WriteLine($"{item.Key}");
                                foreach (var item2 in item)
                                {
                                    Console.WriteLine(item2.Name);
                                }


                            }
                            Console.WriteLine("-----------------");


                            Console.WriteLine($"11、呈上題，請計算該類別底下所有商品的平均價格：");
                            var result2 = products.Where((x) => x.Price > 1000).GroupBy((x) => x.Pdtype,
                                (pdtypes, prices) => new
                                {
                                    key = pdtypes,
                                    avg = prices.Average(x => x.Price)
                                });
                            foreach (var item in result2)
                            {
                                Console.WriteLine($"{item.key}");
                                Console.WriteLine(item.avg);

                            }
                            Console.WriteLine("-----------------");


                            Console.WriteLine($"12、依照商品價格由高到低排序：");
                            var order1 = products.OrderByDescending((x) => x.Price);
                            foreach (var item in order1)
                            {
                                Console.WriteLine(item.Name + "_" + item.Price);
                            }
                            Console.WriteLine("-----------------");

                            Console.WriteLine("請任意一數字(1-4)");
                            select = Console.ReadLine();
                            if ((select == null)|| (select == ""))
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤，任一鍵重新選擇");
                                Console.ReadKey();
                                Console.Clear();

                                continue;
                            }
                            else
                            {
                                pgselect = int.Parse(select);
                            }

                            if (pgselect <= 5)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤，任一鍵重新選擇");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                        }
                        break;
                    case 4:
                        while (true)
                        {
                            Console.WriteLine($"13、依照商品數量由低到高排序：");
                            var order2 = products.OrderBy((x) => x.Num);
                            foreach (var item in order2)
                            {
                                Console.WriteLine(item.Name + "_" + item.Num);
                            }
                            Console.WriteLine("-----------------");


                            //Console.WriteLine($"14、各商品類別底下，最貴的商品：");
                            //var exp = products.GroupBy((x) => x.Pdtype,
                            //    (pdtypes, prices) => new
                            //    {
                            //        key = pdtypes,
                            //        max = prices.Max(x => x.Price),
                            //        //name = prices.Where(x => x.Price == max)
                            //    });
                            //foreach (var item in exp)
                            //{
                            //    Console.WriteLine($"{item.key}");
                            //    Console.WriteLine(item.max);

                            //}
                            //Console.WriteLine("-----------------");


                            Console.WriteLine($"14、各商品類別底下，最貴的商品：");
                            var maxquery =
                                from prod in products
                                group prod by prod.Pdtype into gp2
                                select new
                                {
                                    gp2.Key,
                                    mep = from prod2 in gp2
                                          where prod2.Price == gp2.Max((x) => x.Price)
                                          select prod2
                                };
                            foreach (var item in maxquery)
                            {
                                Console.WriteLine(item.Key);
                                foreach (var item2 in item.mep)
                                {
                                    Console.WriteLine(item2.Name);
                                }
                            }
                            Console.WriteLine("-----------------");


                            //Console.WriteLine($"15、各商品類別底下，最便宜的商品：");
                            //var cheap = products.GroupBy((x) => x.Pdtype,
                            //    (pdtypes, prices) => new
                            //    {
                            //        key = pdtypes,
                            //        min = prices.Min(x => x.Price)
                            //    });
                            //foreach (var item in cheap)
                            //{
                            //    Console.WriteLine($"{item.key}");
                            //    Console.WriteLine(item.min);

                            //}
                            //Console.WriteLine("-----------------");


                            Console.WriteLine($"15、各商品類別底下，最便宜的商品：");
                            var minquery =
                                from prod3 in products
                                group prod3 by prod3.Pdtype into gp3
                                select new
                                {
                                    gp3.Key,
                                    mcp = from prod4 in gp3
                                          where prod4.Price == gp3.Min((x) => x.Price)
                                          select prod4
                                };
                            foreach (var item in minquery)
                            {
                                Console.WriteLine(item.Key);
                                foreach (var item2 in item.mcp)
                                {
                                    Console.WriteLine(item2.Name);
                                }
                            }
                            Console.WriteLine("-----------------");



                            var mqprice = products.Where((x) => x.Price <= 10000);
                            Console.WriteLine($"16、找出價格小於等於 10000 的商品：");
                            foreach (var item in mqprice)
                            {
                                Console.WriteLine($"{item.Name}");
                            }
                            Console.WriteLine("-----------------");

                            Console.WriteLine("請任意一數字(1-4)");
                            select = Console.ReadLine();
                            if ((select == null) || (select == ""))
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤，任一鍵重新選擇");
                                Console.ReadKey();
                                Console.Clear();

                                continue;
                            }
                            else
                            {
                                pgselect = int.Parse(select);
                            }

                            if (pgselect <= 5)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤，任一鍵重新選擇");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                        }
                        break;




                }
            }

            





            /*
            string filePath = @"C:\\Users\\azhon\\source\\repos\\LinqHW1\\product.csv";

            try
            {
                using(StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            */

        }

        static List<Product> Creatlist(string path)
        {
            return File.ReadAllLines(path)
                .Skip(1)
                .Where(row => row.Length > 0)
                .Select(Product.ParseRow) .ToList(); 
        
        }
    }
}
