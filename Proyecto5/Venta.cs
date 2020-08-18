/*
 * User: agust
 * Date: 26/6/2020
 * Time: 09:08
 *
 * 
 */
using System;

namespace Proyecto5
{
	/// <summary>
	/// Description of Venta.
	/// </summary>
	public class Venta
	{
		private string nombreComercial, droga, obraSocial, plan;
		private DateTime fecha;
		private int codigoEmpleado;
		private double importe;
		
		private int ticket;
		public Venta(int ticket, int codigoEmpleado, DateTime fecha){
			Console.Write("\tNUEVA VENTA\nIngrese los siguientes datos:\n");
			Console.Write("Nombre del Medicamento: ");
			nombreComercial = Console.ReadLine();
			Console.Write("Droga: ");
			droga = Console.ReadLine();
			Console.Write("Obra Social: ");
			obraSocial = Console.ReadLine();
			Console.Write("Plan:");
			plan = Console.ReadLine();
			Console.Write("Importe: ");
			importe = double.Parse(Console.ReadLine());
			this.codigoEmpleado = codigoEmpleado;
			this.ticket = ticket;
			this.fecha = fecha;
			Console.Clear();
		}
		public Venta(string nombreComercial, string droga, string obraSocial, string plan, int codigoEmpleado, double importe, int ticket, DateTime fecha)
		{
			this.nombreComercial = nombreComercial;
			this.droga = droga;
			this.obraSocial = obraSocial;
			this.plan = plan;
			this.codigoEmpleado = codigoEmpleado;
			this.fecha = fecha;
			this.importe = importe;
			this.ticket = ticket;
		}
		public string _NombreComercial{
			set{nombreComercial=value;}
			get{return nombreComercial;}
		}
		
		public string _Droga{
			set{droga=value;}
			get{return droga;}
		}
		
		public string _ObraSocial{
			set{obraSocial=value;}
			get{return obraSocial;}
		}
		
		public int _CodigoEmpleado{
			set{codigoEmpleado=value;}
			get{return codigoEmpleado;}
		}
		public DateTime _Fecha{
			set{fecha=value;}
			get{return fecha;}
		}
		public Double _Importe{
			set{importe=value;}
			get{return importe;}
		}
		public int _Ticket{
			set{ticket = value;}
			get{return ticket;}
		}
		public string _Plan{
			set{plan = value;}
			get{return plan;}
		}
	}
}