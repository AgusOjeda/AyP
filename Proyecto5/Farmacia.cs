/*
 * User: agust
 * Date: 26/6/2020
 * Time: 09:32
 *
 * 
 */
using System;
using System.Collections;
using System.IO;
namespace Proyecto5
{
	/// <summary>
	/// Description of Farmacia.
	/// </summary>
	public class TicketNotFoundException: Exception{}
	public class Farmacia
	{	//Atributos
		private ArrayList vecEmpleados;
		private ArrayList vecVentas;
		
		//Constructor
		public Farmacia()
		{
			//Se crea la farmacia y se lee el txt que contiene los empleados
			vecEmpleados = new ArrayList();
			leerEmpleados();
			//Se crea la farmacia con un Array de ventas y se cargan las ventas que contiene el archivo
			vecVentas = new ArrayList();
			leerVentas();
			
		}
		
		//Funcion que crea un nuevo empleado
		public void nuevoEmpleado(){
			string verificacion;
			int id = vecEmpleados.Count;//tomo el tamaño de la lista para tomar el id
			do{
				Console.Clear();
				id++;//aumento el id en 1
				Empleado a = new Empleado(id);
				agregarEmpleado(a);//Llamo a la funcion agregarEmpleado y le paso por paremetro al nuevo empleado
				Console.WriteLine("Desea agregar otro empleado? s/N");
				verificacion = Console.ReadLine();
			}while(verificacion.ToUpper() == "S");
		}
		
		//Funcion que recibe por paremtro un empleado y lo agrega al vector
		public void agregarEmpleado(Empleado empl){
			vecEmpleados.Add(empl);
			Console.WriteLine("Se agrego al empleado correctamente.");
		}
		
		//Funcion que imprime todos los empleados.
		public void todosEmp(){
			//Recorro el array e imprimo todos los empleados
			foreach (Empleado persona in vecEmpleados) {
				Console.WriteLine("ID: "+persona._idEmpl+"\t Nombre: "+persona._Nombre+"\t Apellido: "+persona._Apellido+"\t DNI: "+persona._Dni +"\n Ventas totales: "+persona._SumaDeImportes);
			}
		}
		//Muestra la cantidad de Empleados
		public void cantidadEm(){
			Console.Clear();
			Console.WriteLine("Hay un total de {0} empleados.",vecEmpleados.Count);//Imprimo la totalidad de empleados
			Console.WriteLine("\nPresione cualquier tecla para volver atras");
		}
		//Funcion para cambiar el nombre a un empleado por su id
		public void cambiarNombreEmpleado(){
			string nombreNuevo;
			Console.WriteLine("id del empleado:");
			int numId = int.Parse(Console.ReadLine());
			foreach (Empleado persona in vecEmpleados) {
				if(numId == persona._idEmpl ){//si el id pertenece a un empleado
					Console.WriteLine("Ingrese nuevo nombre: ");
					nombreNuevo = Console.ReadLine();
					persona._Nombre = nombreNuevo;//se produce el cambio de nombre
					Console.WriteLine("Nombre cambiado correctamente");
				}
			}
		}
		//Funcion que realiza una nueva venta
		public void ventaNueva(){
			string verificacion;
			int ticket = vecVentas.Count;
			DateTime fecha;
			Console.WriteLine("Ingrese su numero de Empleado");
			int idEmpl = int.Parse(Console.ReadLine());
			foreach (Empleado persona in vecEmpleados){//RECORRO LA LISTA DE EMPLEADOS
				if (idEmpl == persona._idEmpl) {//SI EXISTE ESE EMPLEADO
					do {
						Console.Clear();
						Console.WriteLine("Empleado: {0} {1}", persona._Nombre, persona._Apellido);
						ticket++;
						fecha = DateTime.Now;
						Venta a = new Venta(ticket, idEmpl, fecha);
						vecVentas.Add(a);//agrego la venta al vector
						persona._SumaDeImportes += a._Importe;//le sumo el importe de la venta al empleado
						Console.WriteLine("venta finalizada");
						Console.WriteLine("Desea realizar otra venta? s/N");
						verificacion = Console.ReadLine();
					} while(verificacion.ToUpper() == "S");
				}
			}
		}
		//Imprime por pantalla todas las ventas hechas
		public void verVentas(){
			Console.WriteLine("<<<LISTA DE Ventas");
			foreach (Venta element in vecVentas) {
				Console.WriteLine("\nVendedor: "+element._CodigoEmpleado+"\nTICKET: "+element._Ticket+"   Medicamento: "+element._NombreComercial+"   Droga: "+element._Droga+"\n PLAN: "+element._Plan+"   Obra Social: "+element._ObraSocial+"   Fecha: "+element._Fecha+"   IMPORTE: $"+element._Importe);
			}
			Console.WriteLine("Presione cualquier tecla para volver atras...");
				
			
		}
		//MODIFICA AL VENDEDOR MEDIANTE EL TICKET DE LA COMPRA
		public void modificarVendedor(){
			Console.WriteLine("Ingrese el Nro de Ticket de la venta que desea modificar: ");
			int ticket = int.Parse(Console.ReadLine());
			int oldVendedor;
			int newVendedor;
			bool verificacion = false;
			try{
				foreach (Venta producto in vecVentas) {//RECORRO LA LISTA DE VENTAS
					if(ticket == producto._Ticket){//SI EL TICKET CORRESPONDE A UNA VENTA
						verificacion = true;
						oldVendedor = producto._CodigoEmpleado;
						foreach(Empleado element2 in vecEmpleados){//RECORRO LA LISTA DE EMPLEADOS
							if(oldVendedor == element2._idEmpl){
								element2._SumaDeImportes -= producto._Importe;
							}
						}
						//Pido el nuevo id y lo ingreso en la variable
						Console.WriteLine("Ingrese el nuevo id del vendedor");
						newVendedor = int.Parse(Console.ReadLine());
						producto._CodigoEmpleado = newVendedor;
						//Recorro el array de emleados y reemplazo en el id ingresado el nuevo importe.
						foreach(Empleado element2 in vecEmpleados){
							if(element2._idEmpl == newVendedor){
								element2._SumaDeImportes += producto._Importe;
							}
						}
						Console.WriteLine("Vendedor cambiado con exito");
						Console.WriteLine("\nPresione cualquier tecla para volver atras");
					}
				}
				if(verificacion == false){
					throw new TicketNotFoundException();
				}
			}catch(TicketNotFoundException){
				Console.Clear();
				Console.WriteLine("Nro de ticket no encontrado");
				Console.WriteLine("\nPresione cualquier tecla para volver atras");
			}
		}
		//elimina una venta mediante su ticket
		public void eliminarVentaTicket(){
			
			int numTicket;
			double importe;
			int idEmpl;
			int ventaId = 0;
			bool verificacion = false;
			Console.Write("Ingrese el numero de ticket de la venta a eliminar: ");
			numTicket = int.Parse(Console.ReadLine());
			try{
				foreach(Venta producto in vecVentas){//RECORRO EL ARRAY 
					if(numTicket == producto._Ticket){//SI SE CUMPLE LA CONDICION TOMO LOS SIGUIENTES DATOS
						idEmpl = producto._CodigoEmpleado;
						importe = producto._Importe;
						ventaId = vecVentas.IndexOf(producto);
						verificacion = true;
						foreach(Empleado emplea in vecEmpleados){//Elimino el importe de esa venta del empleado
							if(idEmpl == emplea._idEmpl){
								emplea._SumaDeImportes -= importe;
							}
						}			
					}
				}
			if(verificacion == true){//si la verificacion es verdadera, borro la venta, si es falsa LANZAR EXCEPTION
				vecVentas.RemoveAt(ventaId);
				Console.WriteLine("La venta se elimino exitosamente\npulse cualquier tecla para volver atras...");
			}else				
					throw new TicketNotFoundException ();
								
			}catch(TicketNotFoundException){
				Console.Clear();
				Console.WriteLine("Numero de Ticket no encontrado");
				Console.WriteLine("No se pudo proceder con la eliminacion de la venta, comprueba el nro de ticket ingresado");
			}
		}
		//Genera un informe de las ventas realizadas por obra social
		public void informeQuincena(){
		int contador = 0;
		int resultado;
		foreach(Venta producto in vecVentas){
			if(producto._ObraSocial.ToLower() != "particular"){//si un producto coincide con particular, aumento el contador
				contador++;	
			}
		}
		resultado = (contador*100)/vecVentas.Count;//realizo un porcentaje
		Console.WriteLine("En la primer Quincena, el {0}% de las ventas se realizan por obra social",resultado);
		}
		//Genera un informe de las ventas por una determinada droga y que sea de un plan determinado
		public void informeVentasxDroga(){
			string droga;
			string plan;
			int index;
			bool verificacion = false;
			Console.WriteLine("Ingrese el nombre de la droga:");
			droga = Console.ReadLine();
			Console.WriteLine("Ingrese el plan:");
			plan = Console.ReadLine();
			//Verifico que haya un producto con ese nombre y plan
			verificacion = contieneProducto(droga,plan);
			//si la verificacion es verdadera
			if(verificacion == true){
				Console.Clear();
				Console.WriteLine("Lista de productos vendidos con droga: {0} y plan {1}",droga,plan);
				foreach(Venta producto in vecVentas){//Recorro el array de ventas e imprimo los productos que correspondan
					if(producto._Droga == droga && producto._Plan == plan){
						Console.WriteLine(producto._NombreComercial);
					}
				}
			//CASO CONTRARIO
			}else{
				Console.WriteLine("No se encontraron datos\n");
			}
			
		}
		//Funcion que devuelve un booleano si se da la condicion ingresada.
		private bool contieneProducto(string droga, string plan){
			bool verificacion = false;
			foreach(Venta producto in vecVentas){
				if(producto._Droga == droga && producto._Plan == plan){
					verificacion = true;
				}
			}
			return verificacion;
		}
		//Genera un informe del empleado con mayor monto vendido
		public void informeMayorMontoVendido(){
			double monto1, monto2=0;
			string nombre="";
			string apellido="";
			foreach(Empleado empl in vecEmpleados){
				monto1 = empl._SumaDeImportes;//tomo el importeTotal del un empleado
				if(monto1>monto2){//si el monto1 es mayor que monto2, se toma su nombre y apellido y monto2 toma el valor de monto1
					monto2 = monto1;
					nombre = empl._Nombre;
					apellido = empl._Apellido;
				}
			}
			Console.WriteLine("El empleado que mas vendio es: {0} {1} con un monto de: {2}",nombre,apellido,monto2);
		}
		//llama a guardarEmpleados y guarda todos los empleados que se encuentran en el array
		public void guardadoFinalEmpleados(){
			foreach(Empleado emple in vecEmpleados){//recorro el array de empleados
				guardarEmpleados(emple._Nombre,emple._Apellido,emple._Dni,emple._idEmpl,emple._SumaDeImportes);//Llamo a la funcion guardarEmpleados
			}
			Console.WriteLine("Guardado finalizado");
		}
		//Vacia el archivo de empleados
		public void vaciarDBEmpleados(){
			StreamWriter Escribir;//creo un nuevo stremwriter
			Escribir = new StreamWriter(@"db_empleados.txt");//declaro el path 
			Escribir.WriteLine("");//escribo un espacio en el archivo para eliminar todo el contenido
			Escribir.Close();//cierro el archivo
		}
		//Guarda los empleados en una txt
		public void guardarEmpleados(string nombre, string apellido, string dni, int idEmpl, double sumaDeImportes)
		{
			StreamWriter Escribir;//creo un nuevo stremwriter
			Escribir = new StreamWriter(@"db_empleados.txt",true);//declaro el path y le ingreso como segundo parametro un TRUE para que escriba sin borrar el archivo
	
			Escribir.WriteLine(idEmpl + ";" + nombre + ";" +  apellido + ";" + dni + ";" + sumaDeImportes);//Escribo el archivo
			
			Escribir.WriteLine("");//separo mediante un renglon en blanco
			
			Escribir.Close();//Cierro el archivo
		}
		//Lee los empleados desde un txt
		public void leerEmpleados(){
			StreamReader Leer;//creo un nuevo streamreader
			Leer = new StreamReader(@"db_empleados.txt");//declaro el path
			string[] datos_empleado;//creo un array de tipo string
			
			while (Leer.Peek() > -1){//mientras que haya contenido en el archivo
				string linea = Leer.ReadLine();//agarro un renglon del archivo
				if (!String.IsNullOrEmpty(linea)){//si ese renglon no esta vacio
					datos_empleado = linea.Split(';');//separo las palabras mediante ;
					
					//Agrego todos los datos al array de empleados
					vecEmpleados.Add(new Empleado(datos_empleado[1],datos_empleado[2],datos_empleado[3],int.Parse(datos_empleado[0]),double.Parse(datos_empleado[4])));
					
				}
			}
			Leer.Close();//cierro el archivo
		}
		//vacia el archivo para poder guardar datos nuevos
		public void vaciarDBVentas(){
			StreamWriter Escribir;//creo un nuevo stremwriter
			Escribir = new StreamWriter(@"db_ventas.txt");//declaro el path 
			Escribir.WriteLine("");//escribo un espacio en el archivo para eliminar todo el contenido
			Escribir.Close();//cierro el archivo
		}
		//llama a guardarVentas y guarda todas las ventas que se encuentran en el array
		public void guardadoFinalVentas(){
			foreach(Venta vent in vecVentas){//recorro el array de ventas
				//llamo a guardarVentas
				guardarVentas(vent._NombreComercial,vent._Droga,vent._ObraSocial,vent._Plan,vent._CodigoEmpleado,vent._Fecha,vent._Importe,vent._Ticket);
			}
		}
		//guarda las ventas en un archivo
		public void guardarVentas(string nombreComercial, string droga, string obraSocial, string plan, int codigoEmpleado,DateTime fecha ,double importe, int ticket)
		{
			StreamWriter Escribir;//creo un nuevo stremwriter
			Escribir = new StreamWriter(@"db_ventas.txt", true);//declaro el path y le ingreso como segundo parametro un TRUE para que escriba sin borrar el archivo
	
			Escribir.WriteLine(codigoEmpleado + ";" + nombreComercial + ";" +  droga + ";" + obraSocial + ";" + plan + ";" + importe+ ";"+ fecha +";" + ticket);//Escribo el archivo
			
			Escribir.WriteLine("");//separo mediante un renglon en blanco
			
			Escribir.Close();//Cierro el archivo
		}
		//Lee el archivo txt de ventas
		public void leerVentas(){
			StreamReader Leer;
			Leer = new StreamReader(@"db_ventas.txt");
			string[] datos_ventas;
			
			while (Leer.Peek() > -1){
				string linea = Leer.ReadLine();
				if (!String.IsNullOrEmpty(linea)){//si ese renglon no esta vacio
					datos_ventas = linea.Split(';');//separo el renglon
					//Agrego todos los datos al array de ventas
					vecVentas.Add(new Venta(datos_ventas[1],datos_ventas[2],datos_ventas[3],datos_ventas[4],int.Parse(datos_ventas[0]),double.Parse(datos_ventas[5]),int.Parse(datos_ventas[7]),DateTime.Parse(datos_ventas[6])));
					
				}
			}
			Leer.Close();//cierro el archivo
		}
	}
}
