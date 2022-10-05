using System;

namespace Prueba_Trabajo
{
	class Program
	{
		public static void Main(string[] args)
		{
			Menu();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	
		public static void Menu(){
			
			MostrarOpciones();

			int opcion = int.Parse(Console.ReadLine());
			Servicios servicio = new Servicios();
			while (opcion != 0) {
				
				if (opcion == 1) {
					
					servicio.VerTodosPacientes();
					MostrarOpciones();
			
					opcion = int.Parse(Console.ReadLine());
				}
				else if (opcion == 2) {
					
					
					servicio.AgregarPaciente(NuevoPaciente());
					MostrarOpciones();
					opcion = int.Parse(Console.ReadLine());
					
					
				}
				else if (opcion == 3) {
					Console.WriteLine("Ingrese dni del paciente que desea eliminar.");
					int dni = int.Parse(Console.ReadLine());
					servicio.BorrarPaciente(dni);
					MostrarOpciones();
			
					opcion = int.Parse(Console.ReadLine());
					
				}
				else if (opcion == 4) {
					
					Console.WriteLine("Ingrese dni del paciente que desea diagnosticar.");
					int dni = int.Parse(Console.ReadLine());
					servicio.ActualizarDiagnostico(dni);
					MostrarOpciones();
			
					opcion = int.Parse(Console.ReadLine());
				}
				else if (opcion == 5) {
					servicio.TurnoDisponible();
					MostrarOpciones();
			
					opcion = int.Parse(Console.ReadLine());
					
				}
				else if (opcion == 6) {
					
					Console.WriteLine("El paciente se encuentra en el sistema? Ingrese si/no: ");
					string dato = Console.ReadLine();
					if (dato =="si" ) {
						Console.WriteLine("Ingrese dni del paciente para crear turno: ");
						int dni = int.Parse(Console.ReadLine());
						servicio.BuscarPaciente(dni);
						MostrarOpciones();
						opcion = int.Parse(Console.ReadLine());
					}
					
					else if(dato == "no"){
						MostrarOpciones();
						opcion = int.Parse(Console.ReadLine());
					}
					
				}
				else if (opcion == 7) {
					Console.WriteLine("Ingrese el horario del turno a eliminar: ");
					string horario = Console.ReadLine();
					servicio.ElimiarTurno(horario);
					MostrarOpciones();
					opcion = int.Parse(Console.ReadLine());
					
				}
				else if (opcion == 8) {
					
					servicio.VerTurnos();
					MostrarOpciones();
					opcion = int.Parse(Console.ReadLine());
				}
				else if (opcion == 9) {
					servicio.VerObrasSociales();
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
		
		public static Paciente NuevoPaciente(){
			
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
				return paciente;
			
			}
				
			else{
				string obra_social = "No tiene/Particular";
				int nro_afiliado = 00;
				Console.WriteLine("Ingrese el diagnostico del paciente");
				string diagnostico = Console.ReadLine();
				Paciente paciente = new Paciente(nombre, dni, obra_social, nro_afiliado,diagnostico);
			
				return paciente;
			
			}
			
		}
		
		public static void MostrarOpciones(){
			
			Console.WriteLine("Opcion 1 para ver lista de pacientes.\nOpcion 2 para agregar paciente." +
			                  "\nOpcion 3 para eliminar paciente.\nOpcion 4 actualizar diagnostico de un paciente." +
			                  "\nOpcion 5 para ver turnos disponibles.\nOpcion 6 para agregar un turno." +
			                  "\nOpcion 7 para eliminar un turno.\nOpcion 8 para ver todos los turnos ocupados." +
			                  "\nOpcion 9 para ver las obras sociales que cubre el medico.\nOpcion 0 para salir\n");
		}
		
	}
}