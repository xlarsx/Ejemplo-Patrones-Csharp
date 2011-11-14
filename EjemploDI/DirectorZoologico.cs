/*
 * Creado por SharpDevelop.
 * Usuario: LUIS.RANGEL
 * Fecha: 11/11/2011
 */
using System;
using System.Collections;
using System.Collections.Generic;
using EjemploDI.contratos;

namespace EjemploDI
{
	/// <summary>
	/// Encargado del zoologico
	/// </summary>
	public class DirectorZoologico : Retroalimentable
	{
		// Elementos a inyectar para que el Director del zoologico trabaje, notese que solo se usan interfaces
		// Polimorfismo basado en Interfaces
		public IList<Inversionista> inversionistas {set; get;}
		public IList<Trabajador> trabajadores { get; set; }

		// Elementos de control interno es recomendable iniciarlos con _
		private IList<string> _comentarios;
		private bool _diaAnteriorCorrecto = true;
		
		// Constructor
		public DirectorZoologico()
		{
			// Instancia de controles internos
			_comentarios = new List<string>();
		}
		
		/// <summary>
		///  Funcionalidad expuesta del Director del Zoologico, representa su rutina diaria
		/// </summary>
		/// <returns>La rutina fue satisfactoria</returns>
		public bool rutina() {
			string comentarios = string.Format("Status: {0} comentarios - Dia anterior correcto {1}", _comentarios.Count, _diaAnteriorCorrecto);
			int dineroRecibido = obtenerDineroInversionistas(comentarios, 100);
			
			repartirDinero(dineroRecibido);
			_diaAnteriorCorrecto = asegurarOrdenInstalaciones(dineroRecibido);
			 return _diaAnteriorCorrecto;
		}
		
		private int obtenerDineroInversionistas(string status, int cantidadMinima) {
			int dineroRecibido = 0;
			foreach(Inversionista inversionista in this.inversionistas) {
				inversionista.reportarEstatusZoologico(status);
				dineroRecibido += inversionista.solicitarDinero(cantidadMinima);
			}
			
			return dineroRecibido;
		}
		
		private void repartirDinero(int dineroRecibido)
		{
			foreach(Trabajador trabajador in this.trabajadores) {
				trabajador.pagarQuincena(dineroRecibido / trabajadores.Count);
			}
		}
		
		private bool asegurarOrdenInstalaciones(int dineroNomina) {
			bool animalesCorrectos = true;
			bool dineroCorrecto = true;
			int numTrabajador = 0;
			
			// Delegacion de trabajo dependiendo de actividades de cada trabajador (Reflexión)
			foreach(Trabajador trabajador in this.trabajadores)
			{
				bool horarioCompleto = trabajador.revisarHorario();
				
				Expertoanimales expertoEnAnimales = trabajador as Expertoanimales;
				if (expertoEnAnimales != null) { // Si el trabajador es Experto en Animales
					bool animalesSaludables = expertoEnAnimales.obtenerEstadoDeAnimales();
					animalesCorrectos = animalesCorrectos && animalesSaludables;
				}
				
				Contador contador = trabajador as Contador;
				if(contador != null) { // Si el trabajador es Contador
					bool registroSinProblemas = contador.registraGastos(dineroNomina);
					dineroCorrecto = dineroCorrecto && registroSinProblemas;
				}
				
				// Invoca una autoretroalimentacion
				comentarRetroalimentacion(string.Format("Trabajador {0} horarioCompleto: {1}", ++numTrabajador, horarioCompleto));
			}
			
			return animalesCorrectos && dineroCorrecto;
		}
		
		// Implementacion implicita de Interfaz Retroalimentable
		public void comentarRetroalimentacion(string retroalimentacion)
		{
			_comentarios.Add(retroalimentacion);
		}
	}
}
