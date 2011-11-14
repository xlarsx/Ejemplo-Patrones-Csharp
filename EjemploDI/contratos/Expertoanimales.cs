/*
 * Creado por SharpDevelop.
 * Usuario: LUIS.RANGEL
 * Fecha: 11/11/2011
 */
using System;

namespace EjemploDI.contratos
{
	/// <summary>
	/// Ente que esta en contacto continuo con los animales
	/// </summary>
	public interface Expertoanimales : Trabajador
	{
		/// <summary>
		/// Retroalimentacion si animales estan saludables y en buen estado
		/// </summary>
		/// <returns>Estado de animales</returns>
		bool obtenerEstadoDeAnimales();
	}
}
