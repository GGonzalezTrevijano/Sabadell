using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaSabadell
{
    public class DatosFichero
    {
        public int NoAccount { get; set; }
        public string Name { get; set; }
        public int Pass { get; set; }
        public decimal Balance { get; set; }

        public DatosFichero()
        {

        }

        public DatosFichero(int noCuenta)
        {
            NoAccount = noCuenta;
        }
        public DatosFichero(int noCuenta, string name) : this(noCuenta)
        {
            Name = name;
        }

        public DatosFichero(int noCuenta, string name, int pass) : this(noCuenta, name)
        {
            Pass = pass;
        }
        public DatosFichero(int noCuenta, string name, int pass, decimal balance) : this(noCuenta, name, pass)
        {
            Balance = balance;
        }
    }
}