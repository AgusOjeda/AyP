/*
 * User: agust
 * Date: 26/6/2020
 * Time: 09:10
 *
 * 
 */
using System;

namespace Proyecto5
{
	/// <summary>
	/// Description of Empleado.
	/// </summary>
	public class Empleado
	{
		private string nombre, apellido, dni;
		private int idEmpl;
		private double sumaDeImportes;
		public Empleado(int idEmpl)
		{
			Console.Write("\tCARGA DE EMPLEADOS\nIngrese los siguientes datos:\n");
			Console.Write("Nombre: ");
			nombre = Console.ReadLine();
			Console.Write("Apellido: ");
			apellido = Console.ReadLine();
			Console.Write("DNI: ");
			dni = Console.ReadLine();
			Console.WriteLine("Carga de datos finalizada");
			Console.WriteLine("Presione cualquier tecla para continuar...");
			Console.Clear();
			sumaDeImportes = 0;
			this.idEmpl = idEmpl;
		}
		public Empleado(string nombre, string apellido, string dni, int idEmpl, double sumaDeImportes){
		
			this.nombre = nombre;
			this.apellido = apellido;
			this.dni = dni;
			this.idEmpl = idEmpl;
			this.sumaDeImportes = sumaDeImportes;
		}
		public string _Nombre{
			set{nombre=value;}
			get{return nombre;}
		}
		
		public string _Apellido{
			set{apellido=value;}
			get{return apellido;}
		}
		
		public string _Dni{
			set{dni=value;}
			get{return dni;}
		}
		
		public int _idEmpl{
			set{idEmpl=value;}
			get{return idEmpl;}
		}
		
		public Double _SumaDeImportes{
			set{sumaDeImportes=value;}
			get{return sumaDeImportes;}
		}
		
	}
}