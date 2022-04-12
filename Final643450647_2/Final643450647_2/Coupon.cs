using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final643450647_2
{
    public class Coupon
    {
        public string _coupon;
        public int _minimumprice;
        public Coupon()
        {
            int length = 10;

            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            _coupon = str_build.ToString();
        }

        public void _createcoupon(double min, int discountRate)
        {
            Coupon coupon = new Coupon();
            Console.WriteLine(coupon);
        }
        public double getdiscount()
        {
            return 0;
        }
    }
}
