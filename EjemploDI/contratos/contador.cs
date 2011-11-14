/*
 * Creado por SharpDevelop.
 * Usuario: LUIS.RANGEL
 * Fecha: 11/11/2011
 */
using System;

namespace EjemploDI.contratos
{
	/// <summary>
	/// Ente que se encarga de mantener la contabilidad del Zoologico
	/// </summary>
	public interface Contador : Trabajador
	{
		/// <summary>
		/// Se le indica el dinero invertido en nomina para su registro
		/// </summary>
		/// <param name="dineroNomina">Dinero recibido en nomina</param>
		/// <returns>Dinero gestionado correctamente</returns>
		bool registraGastos(int dineroNomina);
	}
}
