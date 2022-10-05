using System;
using System.Collections;

namespace Prueba_Trabajo
{
	/// <summary>
	/// Description of Turno.
	/// </summary>
	public class Turno 
	{	
		private Paciente paciente;
		private string horario;
		private ArrayList turnosDisponibles;
		private ArrayList turnosOcupados;
		public Turno(Paciente paciente, string horario)
		{
			this.paciente = paciente;
			this.horario = horario;
			turnosDisponibles = new ArrayList(){"08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00"};
			turnosOcupados = new ArrayList();
		}
		
		public string Horario{
			set{horario = value;}
			get{return horario;}
		}
		
		
		public void TurnoDisponible(){
		
			if (turnosDisponibles.Count > 0) {
				
				for (int i = 0; i < turnosDisponibles.Count; i++) {
					Console.WriteLine("Turno disponible: " + turnosDisponibles[i]);
				}
				
			}
		
		}
	}
}
