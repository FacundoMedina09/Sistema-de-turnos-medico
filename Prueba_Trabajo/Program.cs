using System;

namespace Prueba_Trabajo
{
	class Program
	{
		public static void Main(string[] args)
		{
			Paciente paciente1 = new Paciente("Facu", 44620625, "Ioma", 123456, "Puto");
			
			Turno turno1 = new Turno(paciente1, "08:30");
			
			turno1.TurnoDisponible();
			
			
			
			
			/*
			Console.WriteLine("Hello World!");
			
			Servicios server = new Servicios();
			
			Paciente paciente1 = new Paciente("Facu", 44620625, "Ioma", 123456, "Puto");
			
			Paciente paciente2 = new Paciente("Pau", 111111111, "Galeno", 654321, "Hermosa");
			
			server.AgregarPaciente(paciente1);
			
			server.AgregarPaciente(paciente2);
			
			server.VerPaciente(44620625);
			Console.WriteLine("aaaaaaaaaaaaaaaaaaaa\n \n");
			server.VerPaciente(111111111);
			
			server.BorrarPaciente(44620625);
			Console.WriteLine("aaaaaaaaaaaaaaaaaaaa\n \n");
			
			server.VerTodosPacientes();
			*/
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	
		/*
			ArrayList turnosDisponibles = new ArrayList {"08:00", "08:30", "09:00", "09:30", "10:00", "10:30" ,"11:00", "11:30", "12:00"};
            
			ArrayList turnosOcupados = new ArrayList();
			
			ArrayList listaPacientes = new ArrayList();
			
			
			Paciente paciente1 = new Paciente("Facundo", 44620625, "Particular", 0 , "Puto");
            Paciente paciente2 = new Paciente("Paula", 44645170, "Galeno", 0154664014, "Dazai");
            
           
            agregarPaciente(paciente1, listaPacientes );
			
            verPacientes(listaPacientes);
			
            //nuevoTurno(paciente1, "08:00", turnosOcupados);
		
            horariosDisponibles(turnosDisponibles);
            
            //validarHorarios("08:00", turnosDisponibles );
            
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
			
		}
		
		/*--------------------------------------------------------------------------------------------------------------*/
		
		/*
		public static void agregarPaciente(Paciente paciente, ArrayList lista){

			lista.Add(paciente);
            
        }

        public static void verPacientes(ArrayList lista){

            foreach (Paciente paciente in lista) {

                Console.WriteLine("Dni: " + paciente.Dni + "\nNombre: " + paciente.Nombre);
            }
        }
		
		/*--------------------------------------------------------------------------------------------------------------*/
	/*
        public static void horariosDisponibles(ArrayList turnosD){
			
			if (turnosD.Count >= 0) {
				foreach (int x in turnosD) {
					Console.WriteLine("Turno disponible: " + turnosD[x]);
				}
			}
	
        }
		

        public static void  nuevoTurno(Paciente paciente, string horario, ArrayList turnosDispo , ArrayList turnosOcu){

			if (turnosDispo.Contains(horario) ) { // Se comprueba si el horario pedido esta disponible. Caso true,se elimina de la lista 
				turnosOcu.Add(horario);           // de disponibles y añade a lista de ocupados
				turnosDispo.IndexOf(horario);
			}
			else if ((turnosDispo.Count == 0) && (turnosOcu.Count == 9)){	//Si listaDisponible esta vacia y  ListaOcupada completa es 
				                                                            // que ya no hay turnos disponibles
				Console.WriteLine("Horarios no disponibles, llamar próximo día de atencion");
				
			}
			
			
            Turno turno = new Turno(paciente, horario);

            if ( !lista.Contains(turno.Horario) ) {
            	
            	lista.Add(turno.Horario);
            }
		}
		*/
	
	
	}
}