using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnlinearEquals
{
    class SolveEquals
    {
        private int ier;
        public string IER
        {
            get
            {
                switch (ier)
                {
                    case 0:
                        return "Ошибок нет";
                    case 1:
                        return "Превышено число итераций";
                    case 2:
                        return "Деление на \"0\"";
                    case 3:
                        return "Не удалось вычислить X";
                    default:
                        return "Неизвестная ошибка";
                }
            }
        }

        public bool OnError
        {
            get
            {
                return ier != 0;
            }
        }

        public double l;
        public double xx;
        public double fx;

        private double F(double x)
        {
            return x * x * x - 3 * x + 4;
            //return Math.Sin(x);
            //return Math.Exp(x)-5*x;
        }

        private double DF(double x)
        {
            return 3 * x * x - 3;
            //return Math.Cos(x);
            //return Math.Exp(x)-5;
        }

        public SolveEquals(double x0, double E, double k)
        {
            xx = x0;
            var df0 = DF(x0);
            if (df0 == 0)
            {
                ier = 2;
                return;
            }
            for (int i = 1; i <= k; i++)
            {
                var lxx = xx;
                xx = lxx - F(lxx) / df0;
                if (Double.IsNaN(xx) || Double.IsInfinity(xx))
                {
                    ier = 3;
                    return;
                }

                var Eps = Math.Abs(xx - lxx);
                l = i;
                if (Eps <= E)
                {
                    fx = F(xx);
                    return;
                }
            }
            ier = 1;
        }
    }
}
