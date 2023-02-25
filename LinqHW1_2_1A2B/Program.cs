using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqHW1_2_1A2B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int x = 1; x != 0; x++)
            {
                string[] ranarr = new string[4];
                string[] userarr = new string[4];
                Random rnd = new Random();//產生亂數初始值

                for (int i = 0; i < 4; i++)
                {
                    ranarr[i] = Convert.ToString(rnd.Next(1, 10));//亂數產生1~9

                    for (int j = 0; j < i; j++)
                    {
                        while (ranarr[j] == ranarr[i])//檢查是否與前面產生數重複
                        {
                            j = 0;//如有重複，j回歸於0再次檢查
                            ranarr[i] = Convert.ToString(rnd.Next(1, 10));//重新產生，存回陣列
                        }
                    }
                    Console.WriteLine(ranarr[i]);
                }

                Console.WriteLine("歡迎來到 1A2B 猜數字的遊戲～");

                for (int k = 1; k < 4; k++)
                {
                    int a = 0;
                    int b = 0;
                    Console.WriteLine("請輸入4個數字：");
                    string user = Console.ReadLine();

                    for (int i = 0; i < 4; i++)
                    {
                        userarr[i] = Convert.ToString(user[i]);
                    }
                    var list1 = userarr.Intersect(ranarr);
                    foreach(var item in list1)
                    {
                        if(Array.IndexOf(ranarr, item) == Array.IndexOf(userarr, item))
                        {
                            a++;
                        }
                        else
                        {
                            b++;
                        }
                    }
                    
                    Console.WriteLine($"判定結果是：{a}A{b}B");

                    if (a == 4)
                    {
                        Console.WriteLine("恭喜你！猜對了！！");
                        break;
                    }

                }
                Console.WriteLine("你要繼續玩嗎？(y)");
                string y = Console.ReadLine();
                if (y != "y")
                {
                    break;
                }
            }


        }
    }
}
