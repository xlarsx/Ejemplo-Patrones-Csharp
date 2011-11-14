/*
 * Creado por SharpDevelop.
 * Usuario: LUIS.RANGEL
 * Fecha: 14/11/2011
 */
using System;

namespace EjemploDI.contratos
{
	/// <summary>
	/// Ente que mantiene una referencia de las retroalimentaciones
	/// </summary>
	public interface Retroalimentable
	{
		/// <summary>
		/// Solicitud de registrar comentario
		/// </summary>
		/// <param name="retroalimentacion">comentario a retroalimentar</param>
		void comentarRetroalimentacion(string retroalimentacion);
	}
}
