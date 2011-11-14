/*
 * Creado por SharpDevelop.
 * Usuario: LUIS.RANGEL
 * Fecha: 11/11/2011
 */
using System;

namespace EjemploDI.contratos
{
	/// <summary>
	/// Persona que aporta dinero al zoologico
	/// </summary>
	public interface Inversionista
	{
		/// <summary>
		/// Solicitud de inversion
		/// </summary>
		/// <param name="cantidadMinima">Cantidad minima necesaria a aportar</param>
		/// <returns>Cantidad aportada</returns>
		int solicitarDinero(int cantidadMinima);
		
		/// <summary>
		/// Se muestra estatus del zoologico
		/// </summary>
		/// <param name="status">Estatus del zoologico</param>
		void reportarEstatusZoologico(string status);
	}
}
