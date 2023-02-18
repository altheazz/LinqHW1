using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqHW1_1
{
    internal class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Num { get; set; }
        public decimal Price { get; set; }
        public string Pdtype { get; set; }

        internal static Product ParseRow(string row)
        {
            var columns = row.Split(',');
            return new Product()
            {
                
                Id = columns[0],
                Name = columns[1],
                Num = int.Parse(columns[2]),
                Price = decimal.Parse(columns[3]),
                Pdtype = columns[4]

            };
        }


    }
}
