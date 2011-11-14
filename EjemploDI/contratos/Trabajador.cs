/*
 * Creado por SharpDevelop.
 * Usuario: LUIS.RANGEL
 * Fecha: 14/11/2011
 */
using System;

namespace EjemploDI.contratos
{
	/// <summary>
	/// Ente que trabaja en el zoológico
	/// </summary>
	public interface Trabajador
	{
		/// <summary>
		/// Se revisa que el horario del trabajador se cumpliera correctamente
		/// </summary>
		/// <returns>Horario cumplio correctamente</returns>
		bool revisarHorario();
		
		/// <summary>
		/// Se le paga la quincena al trabajador
		/// </summary>
		/// <param name="dinero">Dinero pagado</param>
		void pagarQuincena(int dinero);
	}
}
