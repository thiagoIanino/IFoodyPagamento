using System;
using System.Collections.Generic;
using System.Text;

namespace IFoodyPagamento.Domain
{
    public class Parametros
    {
        public static string STRIPE_KEY => Environment.GetEnvironmentVariable("TEST_KEY_STRIPE");
    }
}
