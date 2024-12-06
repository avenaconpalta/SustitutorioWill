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
    public static class DepartamentoUtil
    {
        public static void Crear(ref Departamento[] departamentos)
        {
            Console.Write("Ingrese el número de partida: ");
            int nroPartida = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el distrito: ");
            string distrito = Console.ReadLine();
            Console.Write("Ingrese el precio de venta: ");
            double precio = double.Parse(Console.ReadLine());

            Array.Resize(ref departamentos, departamentos.Length + 1);
            departamentos[^1] = new Departamento { NroPartida = nroPartida, Distrito = distrito, PrecioVenta = precio };

            Console.WriteLine("Departamento agregado exitosamente.");
        }

        public static void Listar(Departamento[] departamentos)
        {
            Console.WriteLine("Lista de Departamentos:");
            foreach (var depto in departamentos)
                Console.WriteLine(depto);
        }

        public static void Eliminar(ref Departamento[] departamentos)
        {
            Console.Write("Ingrese el número de partida del departamento a eliminar: ");
            int nroPartida = int.Parse(Console.ReadLine());
            departamentos = departamentos.Where(d => d.NroPartida != nroPartida).ToArray();
            Console.WriteLine("Departamento eliminado si existía.");
        }
    }

    public static class PropietarioUtil
    {
        public static void Crear(ref Propietario[] propietarios)
        {
            Console.Write("Ingrese el RUC: ");
            int ruc = int.Parse(Console.ReadLine());
            Console.Write("Ingrese la razón social: ");
            string razonSocial = Console.ReadLine();
            Console.Write("Ingrese los ahorros: ");
            double ahorros = double.Parse(Console.ReadLine());

            Array.Resize(ref propietarios, propietarios.Length + 1);
            propietarios[^1] = new Propietario { Ruc = ruc, RazonSocial = razonSocial, Ahorros = ahorros };

            Console.WriteLine("Propietario agregado exitosamente.");
        }

        public static void Listar(Propietario[] propietarios)
        {
            Console.WriteLine("Lista de Propietarios:");
            foreach (var propietario in propietarios)
                Console.WriteLine(propietario);
        }

        public static void Eliminar(ref Propietario[] propietarios)
        {
            Console.Write("Ingrese el RUC del propietario a eliminar: ");
            int ruc = int.Parse(Console.ReadLine());
            propietarios = propietarios.Where(p => p.Ruc != ruc).ToArray();
            Console.WriteLine("Propietario eliminado si existía.");
        }
    }

    public static class VentaUtil
    {
        public static void Crear(ref Venta[] ventas, Departamento[] departamentos, Propietario[] propietarios)
        {
            Console.WriteLine("Seleccione el departamento:");
            DepartamentoUtil.Listar(departamentos);
            Console.Write("Ingrese el número de partida del departamento: ");
            int nroPartida = int.Parse(Console.ReadLine());
            var depto = departamentos.FirstOrDefault(d => d.NroPartida == nroPartida);
            if (depto == null)
            {
                Console.WriteLine("Departamento no encontrado.");
                return;
            }

            Console.WriteLine("Seleccione el propietario:");
            PropietarioUtil.Listar(propietarios);
            Console.Write("Ingrese el RUC del propietario: ");
            int ruc = int.Parse(Console.ReadLine());
            var propietario = propietarios.FirstOrDefault(p => p.Ruc == ruc);
            if (propietario == null)
            {
                Console.WriteLine("Propietario no encontrado.");
                return;
            }

            Console.Write("Ingrese el precio del contrato: ");
            double precioContrato = double.Parse(Console.ReadLine());

            Array.Resize(ref ventas, ventas.Length + 1);
            ventas[^1] = new Venta { Codigo = ventas.Length, Vivienda = depto, Contratante = propietario, PrecioContrato = precioContrato };

            Console.WriteLine("Venta registrada exitosamente.");
        }

        public static void Listar(Venta[] ventas)
        {
            Console.WriteLine("Lista de Ventas:");
            foreach (var venta in ventas)
                Console.WriteLine(venta);
        }

        public static void BusquedaPorDistritos(Departamento[] departamentos)
        {
            Console.Write("Ingrese los distritos separados por comas: ");
            var distritos = Console.ReadLine().Split(',').Select(d => d.Trim()).ToArray();
            var encontrados = departamentos.Where(d => distritos.Contains(d.Distrito)).ToArray();

            Console.WriteLine("Departamentos encontrados:");
            foreach (var depto in encontrados)
                Console.WriteLine(depto);
        }
    }
    class Program
    {
        static Departamento[] departamentos = new Departamento[0];
        static Propietario[] propietarios = new Propietario[0];
        static Venta[] ventas = new Venta[0];

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("\nMenú Principal:");
                Console.WriteLine("1. Gestión de Departamentos");
                Console.WriteLine("2. Gestión de Propietarios");
                Console.WriteLine("3. Gestión de Ventas");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        MenuDepartamentos();
                        break;
                    case 2:
                        MenuPropietarios();
                        break;
                    case 3:
                        MenuVentas();
                        break;
                }
            } while (opcion != 4);
        }

        static void MenuDepartamentos()
        {
            int opcion;
            do
            {
                Console.WriteLine("\nGestión de Departamentos:");
                Console.WriteLine("1. Crear");
                Console.WriteLine("2. Listar");
                Console.WriteLine("3. Eliminar");
                Console.WriteLine("4. Volver");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        DepartamentoUtil.Crear(ref departamentos);
                        break;
                    case 2:
                        DepartamentoUtil.Listar(departamentos);
                        break;
                    case 3:
                        DepartamentoUtil.Eliminar(ref departamentos);
                        break;
                }
            } while (opcion != 4);
        }

        static void MenuPropietarios()
        {
            int opcion;
            do
            {
                Console.WriteLine("\nGestión de Propietarios:");
                Console.WriteLine("1. Crear");
                Console.WriteLine("2. Listar");
                Console.WriteLine("3. Eliminar");
                Console.WriteLine("4. Volver");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        PropietarioUtil.Crear(ref propietarios);
                        break;
                    case 2:
                        PropietarioUtil.Listar(propietarios);
                        break;
                    case 3:
                        PropietarioUtil.Eliminar(ref propietarios);
                        break;
                }
            } while (opcion != 4);
        }

        static void MenuVentas()
        {
            int opcion;
            do
            {
                Console.WriteLine("\nGestión de Ventas:");
                Console.WriteLine("1. Crear");
                Console.WriteLine("2. Listar");
                Console.WriteLine("3. Búsqueda por Distritos");
                Console.WriteLine("4. Volver");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        VentaUtil.Crear(ref ventas, departamentos, propietarios);
                        break;
                    case 2:
                        VentaUtil.Listar(ventas);
                        break;
                    case 3:
                        VentaUtil.BusquedaPorDistritos(departamentos);
                        break;
                }
            } while (opcion != 4);
        }
    }
}


