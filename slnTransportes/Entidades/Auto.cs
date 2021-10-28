using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto
    {
        public int ID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Matricula { get; set; }
        public Decimal Precio { get; set; }

        public Auto() { }

        public Auto(int iD, string marca, string modelo, string matricula, decimal precio)
        {
            ID = iD;
            Marca = marca;
            Modelo = modelo;
            Matricula = matricula;
            Precio = precio;
        }
    }
}
