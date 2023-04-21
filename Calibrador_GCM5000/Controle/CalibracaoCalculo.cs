using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearRegression;

namespace Calibrador_GCM5000.Controle
{
    class CalibracaoCalculo
    {
        public int NumeroDeAmostas { get; set; }
        public int[] Temperatura { get; set; }
        public int[] RH { get; set; }
        public int[] Amostra { get; set; }
        public void Calcular()
        {
            double[][] factors = new double[NumeroDeAmostas][];
            factors[0] = new double[] { Temperatura[0], RH[0] };
            factors[1] = new double[] { Temperatura[1], RH[1] };
            factors[2] = new double[] { Temperatura[2], RH[2] };
            factors[3] = new double[] { Temperatura[3], RH[3] };
            factors[4] = new double[] { Temperatura[4], RH[4] };
            factors[5] = new double[] { Temperatura[5], RH[5] };
            factors[6] = new double[] { Temperatura[6], RH[6] };
            factors[7] = new double[] { Temperatura[7], RH[7] };
            double[] predictor = new double[] { Amostra[0], Amostra[1], Amostra[2], Amostra[3], Amostra[4], Amostra[5], Amostra[6], Amostra[7] };

            var fact = Fit.MultiDim(factors, predictor, intercept: true);

            var fact2 = MultipleRegression.QR(factors, predictor, intercept: true);

            return;
        }

    }
}
