/*
 * User: agust
 * Date: 26/6/2020
 * Time: 09:05
 *
 * 
 */
using System;

namespace Proyecto5
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			Farmacia farm = new Farmacia();//INICIALIZO UNA NUEVA FARMACIA
			bool showMenu = true;
		    while (showMenu)//Mientras sea verdadero, se ejecuta el menu principal.
		    {
		        showMenu = MainMenu(farm);
		    }
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		//METODO PRIVADO DEL MENU PRINCIPAL, RECIBE UNA FARMACIA COMO PARAMETRO.
		private static bool MainMenu(Farmacia farm){
			Console.Clear();
			Console.WriteLine("Farmacia");
			Console.WriteLine("1) Empleados");
			Console.WriteLine("2) Ventas");
			Console.WriteLine("3) Informes");
			Console.WriteLine("4) Guardar y Salir");
            Console.Write("\r\nSeleccione una opción: ");
            switch(Console.ReadLine()){
            	case "1":
			        bool showMenu1 = true;
					while (showMenu1)
					{
						showMenu1 = EmpleadosMenu(farm);
					}
            		return true;
            	case "2":
            		bool showMenu2 = true;
            		while (showMenu2)
            		{
            			showMenu2 = VentasMenu(farm);
            		}
            		return true;
            	case "3":
            		bool showMenu3 = true;
            		while(showMenu3)
            		{
            			showMenu3 = InformesMenu(farm);
            		}
            		return true;
            	case "4":
            		//Se vacian los 2 archivos
            		farm.vaciarDBEmpleados();
            		farm.vaciarDBVentas();
            		//Guardamos los nuevos datos
            		farm.guardadoFinalVentas();
            		farm.guardadoFinalEmpleados();
            		return false;
            	default:
                    return true;
            }
			
		}
		//MENU DE ADMINISTRACION DE EMPLEADOS
		private static bool EmpleadosMenu(Farmacia farm)
        {
            Console.Clear();
            Console.WriteLine("ADMINISTRACION DE EMPLEADOS");
            Console.WriteLine("1) Lista de Empleados");
            Console.WriteLine("2) Agregar empleados");
            Console.WriteLine("3) Cantidad de Empleados");
            Console.WriteLine("4) Cambiar Nombre Empleado");
            Console.WriteLine("7) Atras");
            Console.Write("\r\nSeleccione una opción: ");
 
            switch (Console.ReadLine())
            {
            	case "1":
            		Console.Clear();
            		farm.todosEmp();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey(true);
                    return true;
                case "2":
                    farm.nuevoEmpleado();
                    
                    return true;
                case "3":
                    farm.cantidadEm();
                    Console.ReadKey(true);
                    return true;
                case "4":
                    farm.cambiarNombreEmpleado();
                    Console.ReadKey(true);
                    return true;
            	case "7":
                    return false;
                default:
                    return true;
            }
        }
		//MENU DE ADMINISTRACION DE VENTAS.
		private static bool VentasMenu(Farmacia farm)
		{
			Console.Clear();
            Console.WriteLine("ADMINISTRACION DE VENTAS");
            Console.WriteLine("1) Nueva venta");
            Console.WriteLine("2) Eliminar Venta");
            Console.WriteLine("3) Modificar Vendedor");
            Console.WriteLine("4) Ver ventas");
            Console.WriteLine("7) Atras");
            Console.Write("\r\nSeleccione una opción:");
 
            switch (Console.ReadLine())
            {
            	case "1":
            		farm.ventaNueva();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey(true);
                    return true;
                case "2":
                    farm.eliminarVentaTicket();
                    Console.ReadKey(true);
                    return true;
                case "3":
                    farm.modificarVendedor();
                    Console.ReadKey(true);
                    return true;
                case "4":
                    farm.verVentas();
                    Console.ReadKey(true);
                    return true;
            	case "7":
                    return false;
                default:
                    return true;
            }
		}
		private static bool InformesMenu(Farmacia farm)
		{
			Console.Clear();
            Console.WriteLine("INFORMES");
            Console.WriteLine("1) Porcentaje de ventas en la primer quincena");
            Console.WriteLine("2) Ventas por droga y plan");
            Console.WriteLine("3) Empleado con mayor importe vendido");
            Console.WriteLine("7) Atras");
            Console.Write("\r\nSeleccione una opción: ");
 
            switch (Console.ReadLine())
            {
            	case "1":
            		farm.informeQuincena();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey(true);
                    return true;
                case "2":
                    Console.Clear();
                    farm.informeVentasxDroga();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey(true);
                    return true;
                case "3":    
                    farm.informeMayorMontoVendido();
                    Console.WriteLine("Presione una tecla para volver al menu...");
                    Console.ReadKey(true);
                    return true;
            	case "7":
                    return false;
                default:
                    return true;
            }
		}
    }
}