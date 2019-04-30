using System;
using System.Collections.Generic;
using System.Text;

namespace rfmagalhaes.aspnetcoreweb_efcore.domain
{
    public class CodigoPostal
    {
        public int Id { get; private set; }

        public string CEP { get; private set; }
        public string Logradouro { get; private set; }

        protected CodigoPostal() { }

        public CodigoPostal(string cEP, string logradouro)
        {
            CEP = cEP;
            Logradouro = logradouro;
        }
    }
}
