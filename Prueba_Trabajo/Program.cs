using System;
using System.Collections;
namespace Prueba_Trabajo
{
	class Program
	{
		public static void Main(string[] args)
		{
			Menu();
			Console.ReadKey(true);
		}
	
		public static void Menu(){
			
			ArrayList listaPacientes = new ArrayList();
			ArrayList turnosDisponibles = new ArrayList(){"08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00"};
			ArrayList turnosOcupados = new ArrayList();
			ArrayList obrasSociales  = new ArrayList();
			
			MostrarOpciones();

			int opcion = int.Parse(Console.ReadLine());
			Servicios servicio = new Servicios();
			while (opcion != 0) {
				
				if (opcion == 1) {
					
					VerTodosPacientes(listaPacientes);
					MostrarOpciones();
			
					opcion = int.Parse(Console.ReadLine());
				}
				else if (opcion == 2) {
					
					
					CrearPaciente(listaPacientes,obrasSociales);
					MostrarOpciones();
					opcion = int.Parse(Console.ReadLine());
					
					
				}
				else if (opcion == 3) {
					
					if (listaPacientes.Count > 0) {
						Console.WriteLine("Ingrese dni del paciente que desea eliminar.");
					    int dni = int.Parse(Console.ReadLine());
					    BorrarPaciente(listaPacientes, dni);
				    	
					}
					else{
						Console.WriteLine("Actualmente no hay pacientes, por favor ingrese uno.\n");
					}
					MostrarOpciones();
				    opcion = int.Parse(Console.ReadLine());
					
					
				}
				else if (opcion == 4) {
					if (listaPacientes.Count > 0) {
						Console.WriteLine("Ingrese dni del paciente que desea buscar.");
					    int dni = int.Parse(Console.ReadLine());
					    VerPaciente(listaPacientes,dni);
				    	
					}
					else{
						Console.WriteLine("Actualmente no hay pacientes, por favor ingrese uno.\n");
					}
					MostrarOpciones();
					opcion = int.Parse(Console.ReadLine());
				}
				
				
				
				else if (opcion == 5) {
					
					if (listaPacientes.Count > 0) {
						Console.WriteLine("Ingrese dni del paciente que desea actualizar diagnostico.");
					    int dni = int.Parse(Console.ReadLine());
					    ActualizarDiagnostico(listaPacientes,dni);
				    	
					}
					else{
						Console.WriteLine("Actualmente no hay pacientes, por favor ingrese uno.\n");
					}
					MostrarOpciones();
					opcion = int.Parse(Console.ReadLine());
					
					
					
				}
				else if (opcion == 6) {
					TurnoDisponible(turnosDisponibles);
					MostrarOpciones();
					opcion = int.Parse(Console.ReadLine());
					
				}
				else if (opcion == 7) {
					
					
						if (listaPacientes.Count > 0) {
							Console.WriteLine("El paciente se encuentra en el sistema? Ingrese si/no: ");
							string dato = Console.ReadLine();
							if (dato =="si" ) {
								Console.WriteLine("Ingrese dni del paciente al que desea agregarle un turno.");
						    	int dni = int.Parse(Console.ReadLine());
						    	BuscarPaciente(listaPacientes, dni, turnosDisponibles, turnosOcupados);
							}
							else{
								Console.WriteLine("Por favor ingrese un paciente.\n");
							}
						}
						else{
							Console.WriteLine("Actualmente no hay pacientes, por favor ingrese uno.\n");
						}
						MostrarOpciones();
						opcion = int.Parse(Console.ReadLine());
				}
				
				else if (opcion == 8) {
					
					if (turnosOcupados.Count > 0) {
						Console.WriteLine("Ingrese el horario del turno a eliminar: ");
						string horario = Console.ReadLine();
						ElimiarTurno(turnosDisponibles,turnosOcupados,horario);
					}
					else{
						Console.WriteLine("Actualmente no hay turnos ocupados, por favor ingrese un turno.\n");
					}
					MostrarOpciones();
					opcion = int.Parse(Console.ReadLine());
					
				}
				else if (opcion == 9) {
					VerTurnosOcupados(turnosOcupados);
					MostrarOpciones();
					opcion = int.Parse(Console.ReadLine());
				}
				else if (opcion == 10) {
					VerObrasSociales(obrasSociales);
					MostrarOpciones();
					opcion = int.Parse(Console.ReadLine());
				}
				else{
					Console.WriteLine("Opcion incorrecta, ingrese una opcion valida.");
					MostrarOpciones();
					opcion = int.Parse(Console.ReadLine());
				}
			}
		}
		
		public static Paciente CrearPaciente(ArrayList listaPacientes, ArrayList obraSociales){
			
			Console.WriteLine("Ingrese nombre del paciente");
			string nombre = Console.ReadLine();
			Console.WriteLine("Ingrese dni del paciente");
			int dni = int.Parse(Console.ReadLine());
			Console.WriteLine("Tiene obra social?Ingrese si/no");
			string condicion = Console.ReadLine();
			if (condicion == "si") {
				Console.WriteLine("Ingrese la obra social del paciente");
				string obra_social = Console.ReadLine();
				Console.WriteLine("Ingrese el numero de afiliado del paciente");
				int nro_afiliado = int.Parse(Console.ReadLine());
				Console.WriteLine("Ingrese el diagnostico del paciente");
				string diagnostico = Console.ReadLine();
				Paciente paciente = new Paciente(nombre, dni, obra_social, nro_afiliado, diagnostico);
				listaPacientes.Add(paciente);										//Agregar paciente a la lista de pacientes
				if (!(obraSociales.Contains(paciente.Obra_social))) {				//Agregar obra social del paciente a la lista
					obraSociales.Add(paciente.Obra_social);
				}
				Console.WriteLine("Paciente agregado con exito!.\n");
				return paciente;		
			}
				
			else{
				string obra_social = "No tiene/Particular";
				int nro_afiliado = 00;
				Console.WriteLine("Ingrese el diagnostico del paciente");
				string diagnostico = Console.ReadLine();
				Paciente paciente = new Paciente(nombre, dni, obra_social, nro_afiliado,diagnostico);
			    listaPacientes.Add(paciente);										//Agregar paciente a la lista de pacientes
			    Console.WriteLine("Paciente agregado con exito!.\n");
				return paciente;
			
			}
		}
		
		public static void BorrarPaciente(ArrayList listaPacientes ,int dniBuscar){
																		 //Eliminar paciente de la lista de pacientes
			  									                         // usando su dni como referencia
			foreach (Paciente x  in listaPacientes ) {
				if (dniBuscar == x.Dni) {
				    listaPacientes.RemoveAt(listaPacientes.IndexOf(x));
					Console.WriteLine("Paciente "+ x.Nombre+" eliminado con exito!.\n");
					break;
		        }
																				
				else{
					Console.WriteLine("No se encontro ningun paciente con el dni ingresado.\n");											
				}
			}																
		}
		
		public static void VerPaciente(ArrayList listaPacientes, int dniBuscar){	//Ver paciente desde la lista a traves de su dni	
			
			foreach (Paciente x  in listaPacientes ) {
				if (dniBuscar == x.Dni) {	
					Console.WriteLine("Nombre: "+ x.Nombre + "\nDni: "+ x.Dni + "\nObra Social: "+ x.Obra_social +
					                  "\nNumero de Afiliado: "+ x.Nro_afiliado + "\nDiagnostico: "+x.Diagnostico+"\n");
					break;
				}
			}
		}
		
		public static void VerTodosPacientes(ArrayList listaPacientes){				//Ver todos los pacientes
		
			if (listaPacientes.Count > 0) {
				foreach (Paciente x  in listaPacientes ) {
					
				Console.WriteLine("Nombre: "+ x.Nombre + "\nDni: "+ x.Dni + "\nObra Social: "+ x.Obra_social +
					                  "\nNumero de Afiliado: "+ x.Nro_afiliado + "\nDiagnostico: "+x.Diagnostico+"\n");
			    }
			}
			else{
				Console.WriteLine("Actualmente no hay pacientes, por favor ingrese uno.\n");		
			}	
		}
		
		public static void VerObrasSociales(ArrayList obrasSociales){		 //Ver todas las obras sociales con las que 
																			// trabaja el medico
			
			if (obrasSociales.Count == 0) {
				Console.WriteLine("Actualmente no se trabaja con ninguna obra social.\n");
			}																
			else{
				Console.WriteLine("Las Obras Sociales con las que trabaja el medico son: ");																	
				for (int i = 0; i < obrasSociales.Count; i++) {
				Console.WriteLine(obrasSociales[i]);
				}		
			}
		}
		
		public static void ActualizarDiagnostico(ArrayList listaPacientes,int dniBuscar){//Cambiar el diagnostico de un paciente
			
			foreach (Paciente x in listaPacientes) {
				if (x.Dni == dniBuscar) {
					
					Console.WriteLine("Ingrese el nuevo Diagnostico del paciente: ");
					string diagnostico = Console.ReadLine();
					x.Diagnostico = diagnostico;
					Console.WriteLine("Diagnostico Actualizado.\n");
				}
			}
		}
		
		public static void TurnoDisponible(ArrayList turnosDisponibles){				// Ver los turnos que hay disponibles
		
			if (turnosDisponibles.Count > 0) {
				for (int i = 0; i < turnosDisponibles.Count; i++) {
					Console.WriteLine("Turno disponible: " + turnosDisponibles[i]);
				}
			}
		}
		
		public static void BuscarPaciente(ArrayList listaPacientes, int dniBuscar, ArrayList turnosDisponibles, ArrayList turnosOcupados){
			
			foreach (Paciente x in listaPacientes) {
				
				if (x.Dni == dniBuscar) {
					
					Console.WriteLine("Se encontro el siguiente paciente: "+ x.Nombre);
					Console.WriteLine("Ingrese la hora en la que solicita el turno: ");
					string hora = Console.ReadLine();
					AgregarTurno(x, hora, turnosDisponibles, turnosOcupados);
				}
				else{
					Console.WriteLine("No se encontro ningun paciente con el dni ingresado, por favor ingresar uno.");
				}
			}
		}
		
		public static void AgregarTurno(Paciente paciente,string hora, ArrayList turnosDisponibles, ArrayList turnosOcupados){	// Se comprueba si el horario pedido esta disponible. Caso true,se elimina de la lista
				        							  				// de disponibles y añade a lista de ocupados	        							  	
				if (turnosDisponibles.Contains(hora) ) {
				Turno turno = new Turno(paciente, hora);		
				turnosOcupados.Add(turno);
				turnosDisponibles.RemoveAt(turnosDisponibles.IndexOf(hora));
				Console.WriteLine("Turno de las "+ hora + " agregado exitosamente!");
			}
				        							  				
			else if ((turnosDisponibles.Count == 0) && (turnosOcupados.Count == 9)){ //Si listaDisponible esta vacia y  ListaOcupada completa es 
						                                                             // que ya no hay turnos disponibles
				Console.WriteLine("Horarios no disponibles, llamar próximo día de atencion");	
			}
		}
		
		public static void ElimiarTurno(ArrayList turnosDisponibles,ArrayList turnosOcupados, string horario){
																				//Eliminar un turno que esta ocupado
																				//Una vez eliminado vuelve a estar
			foreach (Turno x in turnosOcupados) {								//disponible
				
				if(x.Horario.Contains(horario)){
					
					turnosOcupados.RemoveAt(turnosOcupados.IndexOf(x));
					turnosDisponibles.Add(horario);
					Console.WriteLine("Turno de las "+ horario +" eliminado");
					break;
				}
				else{
					Console.WriteLine("El turno de las " + horario + " no puede ser eliminado porque esta disponible.");					
					break;
				}
			}
		}
		
		public static void VerTurnosOcupados(ArrayList turnosOcupados){				//Ver todos los turnos que estan
																					//ocupados
			if (turnosOcupados.Count > 0) {
				foreach (Turno x in turnosOcupados) {
			
					for (int i = turnosOcupados.Count; i <= turnosOcupados.Count; i++) {
					
						Console.WriteLine("El turno de las "+ x.Horario + " esta ocupado por "+ x.Paciente.Nombre);
					}
				}
			}
			else{
				Console.WriteLine("Actualmente no hay turnos ocupados, por favor ingrese un turno.\n");
			}
		
		}
		
		public static void MostrarOpciones(){
			
			Console.WriteLine("Opcion 1 para ver lista de pacientes.\nOpcion 2 para agregar paciente." +
			                  "\nOpcion 3 para eliminar paciente.\nOpcion 4 para ver un paciente." +
			                  "\nOpcion 5 para actualizar diagnostico de un paciente." +
			                  "\nOpcion 6 para ver turnos disponibles.\nOpcion 7 para agregar un turno." +
			                  "\nOpcion 8 para eliminar un turno.\nOpcion 9 para ver todos los turnos ocupados." +
			                  "\nOpcion 10 para ver las obras sociales que cubre el medico.\nOpcion 0 para salir\n");
		}
		
	}
}