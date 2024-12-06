using System;
using System.Linq;

namespace will
{
    public class Departamento
    {
        public int NroPartida { get; set; }
        public string Distrito { get; set; }
        public double PrecioVenta { get; set; }

        public override string ToString()
        {
            return $"Partida: {NroPartida}, Distrito: {Distrito}, Precio: {PrecioVenta}";
        }
    }

    public class Propietario
    {
        public int Ruc { get; set; }
        public string RazonSocial { get; set; }
        public double Ahorros { get; set; }

        public override string ToString()
        {
            return $"RUC: {Ruc}, Razón Social: {RazonSocial}, Ahorros: {Ahorros}";
        }
    }

    public class Venta
    {
        public int Codigo { get; set; }
        public Departamento Vivienda { get; set; }
        public Propietario Contratante { get; set; }
        public double PrecioContrato { get; set; }

        public override string ToString()
        {
            return $"Código: {Codigo}, Vivienda: [{Vivienda}], Contratante: [{Contratante}], Precio Contrato: {PrecioContrato}";
        }
    }

   