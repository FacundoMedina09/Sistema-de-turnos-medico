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
		
		public Servicios()
		{
			listaPacientes = new ArrayList();
		}
		
		/*----------------------------------SERVICIOS DEL PACIENTE----------------------------------------------------*/
	
		
		public ArrayList ListaPacientes{								//Mostras la lista de pacientes
			get{return listaPacientes;}
		}	
		
		public void AgregarPaciente (Paciente paciente){				//Agregar paciente a la lista de pacientes
		
			listaPacientes.Add(paciente);
			Console.WriteLine("Paciente agregado con exito!.");
		}
		
		public void BorrarPaciente(int dniBuscar){						//Eliminar paciente de la lista de pacientes
																		// usando su dni como referencia
			foreach (Paciente x  in listaPacientes ) {
				
				if (dniBuscar == x.Dni) {
					
					listaPacientes.RemoveAt(listaPacientes.IndexOf(x));
					Console.WriteLine("Paciente eliminado con exito!.");
					break;
					
				}
			}
		}
		
		public void VerPaciente(int dniBuscar){							//Ver paciente desde la lista a traves de su dni	
			
			foreach (Paciente x  in listaPacientes ) {
				
				if (dniBuscar == x.Dni) {
					
					Console.WriteLine("Nombre: "+ x.Nombre + "\nDni: "+ x.Dni + "\nObra Social: "+ x.Obra_social +
					                  "\nNumero de Afiliado: "+ x.Nro_afiliado + "\nDiagnostico: "+x.Diagnostico);
					break;
					
				}
			}
		
		}
		
		
		public void VerTodosPacientes(){								//Ver todos los pacientes
		
			foreach (Paciente x  in listaPacientes ) {
					
				Console.WriteLine("Nombre: "+ x.Nombre + "\nDni: "+ x.Dni + "\nObra Social: "+ x.Obra_social +
					                  "\nNumero de Afiliado: "+ x.Nro_afiliado + "\nDiagnostico: "+x.Diagnostico);
			}
		
		}
		
		
		
	
	}
	
}
