using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitakHubMarketplace
{
    public static class Uteis
    {
        public static string FormataDecimaisComPonto(this string valor)
        {
            if (valor != null && valor.Contains(".") && valor.Contains(","))
            {
                if (valor.IndexOf(",") > valor.IndexOf("."))
                    valor = valor.Replace(",", "").Replace(",", ".");
                else
                    valor = valor.Replace(".", "");
            }
            else if (valor == null)
            {
                return "0";
            }
            else
            {
                valor = valor.Replace(",", ".");
            }

            return valor;
        }
    }
}
