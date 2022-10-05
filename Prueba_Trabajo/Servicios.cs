using System;
using System.Collections;

namespace Prueba_Trabajo
{
	/// <summary>
	/// Description of Servicios.
	/// </summary>
	public class Servicios
	{	
		private ArrayList listaPacientes;
		private ArrayList turnosDisponibles;
		private ArrayList turnosOcupados;
		private ArrayList obrasSociales;
		
		public Servicios()
		{
			listaPacientes = new ArrayList();
			turnosDisponibles = new ArrayList(){"08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00"};
			turnosOcupados = new ArrayList();
			obrasSociales  = new ArrayList();
		}
		
		/*----------------------------------SERVICIOS DEL PACIENTE----------------------------------------------------*/
	
		
		public ArrayList ListaPacientes{								//Mostras la lista de pacientes
			get{return listaPacientes;}
		}	
		
	
		
		public void AgregarPaciente (Paciente paciente){				//Agregar paciente a la lista de pacientes
		
			listaPacientes.Add(paciente);
			Console.WriteLine("Paciente agregado con exito!.\n");
			if (paciente.Obra_social != "No tiene/Particular") {
				if ( !(obrasSociales.Contains(paciente.Obra_social))) {       //Agregar obra social del paciente a la lista
					obrasSociales.Add(paciente.Obra_social);
				}
			}
				
		}
		
		public void BorrarPaciente(int dniBuscar){						//Eliminar paciente de la lista de pacientes
																		// usando su dni como referencia
			foreach (Paciente x  in listaPacientes ) {
				
				if (dniBuscar == x.Dni) {
					
					listaPacientes.RemoveAt(listaPacientes.IndexOf(x));
					Console.WriteLine("Paciente eliminado con exito!.\n");
					break;
					
				}
			}
		}
		
		public void VerPaciente(int dniBuscar){							//Ver paciente desde la lista a traves de su dni	
			
			foreach (Paciente x  in listaPacientes ) {
				
				if (dniBuscar == x.Dni) {
					
					Console.WriteLine("Nombre: "+ x.Nombre + "\nDni: "+ x.Dni + "\nObra Social: "+ x.Obra_social +
					                  "\nNumero de Afiliado: "+ x.Nro_afiliado + "\nDiagnostico: "+x.Diagnostico+"\n");
					break;
					
				}
			}
		
		}
		
		
		public void VerTodosPacientes(){								//Ver todos los pacientes
		
			if (listaPacientes.Count != 0) {
				foreach (Paciente x  in listaPacientes ) {
					
				Console.WriteLine("Nombre: "+ x.Nombre + "\nDni: "+ x.Dni + "\nObra Social: "+ x.Obra_social +
					                  "\nNumero de Afiliado: "+ x.Nro_afiliado + "\nDiagnostico: "+x.Diagnostico+"\n");
			    }
			}
			else{
				Console.WriteLine("Actualmente no hay pacientes, por favor ingrese uno.\n");
				
			}
			
		}
		
		
		public void VerObrasSociales(){									//Ver todas las obras sociales con las que 
																		// trabaja el medico
			Console.WriteLine("Las Obras Sociales con las que trabaja el medico son: ");
			
			for (int i = 0; i < obrasSociales.Count; i++) {
				Console.WriteLine(obrasSociales[i]);
				
			}
		
		}
		
		public void ActualizarDiagnostico(int dniBuscar){				//Cambiar el diagnostico de un paciente
			
			foreach (Paciente x in listaPacientes) {
				if (x.Dni == dniBuscar) {
					
					Console.WriteLine("Ingrese el nuevo Diagnostico del paciente: ");
					string diagnostico = Console.ReadLine();
					x.Diagnostico = diagnostico;
					Console.WriteLine("Diagnostico Actualizado.\n");
				
				}
			}
		
		
		}
		
		/*----------------------------------SERVICIOS DE TURNOS----------------------------------------------------*/
		
		public void TurnoDisponible(){									// Ver los turnos que hay disponibles
		
			if (turnosDisponibles.Count > 0) {
				for (int i = 0; i < turnosDisponibles.Count; i++) {
					Console.WriteLine("Turno disponible: " + turnosDisponibles[i]);
				}
			}
		}
		
		
		public void BuscarPaciente(int dniBuscar){
			
			foreach (Paciente x in listaPacientes) {
				
				if (x.Dni == dniBuscar) {
					
					Console.WriteLine("Se encontro el siguiente paciente: "+ x.Nombre);
					Console.WriteLine("Ingrese la hora en la que solicita el turno: ");
					string hora = Console.ReadLine();
					AgregarTurno(x, hora);
					
				}
			}
		}
		
		public void AgregarTurno(Paciente paciente,string hora){	// Se comprueba si el horario pedido esta disponible. Caso true,se elimina de la lista
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
		
		
		public void VerTurnos(){													//Ver todos los turnos que estan
																					//ocupados
			foreach (Turno x in turnosOcupados) {
			
				for (int i = turnosOcupados.Count; i <= turnosOcupados.Count; i++) {
					
					Console.WriteLine("El turno de las "+ x.Horario + " esta ocupado por "+ x.Paciente.Nombre);
					
				}
			}
		
		}
		
		public void ElimiarTurno(string horario){									//Eliminar un turno que esta ocupado
																					//Una vez eliminado vuelve a estar
			foreach (Turno x in turnosOcupados) {									//disponible
				
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

		
	}
}
