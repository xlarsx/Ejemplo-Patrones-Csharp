﻿/*
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
	class Program
	{
		/// <summary>
		/// Ejemplo que muestra buenos patrones de Programacion Orientada a Objetos.
		/// Referencia:
		/// <list type="bullet">
		/// 	<item> 
		/// 		<term> Interfaces (Guia de programacion de C#) </term>
		/// 		<description> http://msdn.microsoft.com/es-es/library/ms173156(v=vs.80).aspx </description>
		/// 	</item>
		/// 	<item>
		/// 		<term> Inheritance and Polymorphism </term>
		/// 		<description> http://www.expresscomputeronline.com/20021118/techspace2.shtml </description>
		/// 	</item>
		/// 	<item>
		/// 		<term> Dependency Injection for Loose Coupling </term>
		/// 		<description> http://www.codeproject.com/KB/architecture/DependencyInjection.aspx </description>
		/// 	</item>
		/// 	<item>
		/// 		<term> C# is and as operators </term>
		/// 		<description> http://ekrishnakumar.wordpress.com/2006/07/08/c-is-and-as-operators/ </description>
		/// 	</item>
		/// 	<item>
		/// 		<term> An Introduction to Reflection in C# </term>
		/// 		<description>	http://www.codeguru.com/csharp/csharp/cs_misc/reflection/article.php/c4257 </description>
		/// 	</item>
		/// </list>
		/// </summary>
		/// <param name="args"></param>
		public static void Main(string[] args)
		{
			// Se asigna/inyecta nómina dinámicamente
			IList<Inversionista> _inversionistas = new List<Inversionista>();
			IList<Trabajador> _trabajadores = new List<Trabajador>();
			
			DirectorZoologico director = new DirectorZoologico() {
				inversionistas = _inversionistas,
				trabajadores = _trabajadores
			};
			
			// Se agregan inversionistas
			_inversionistas.Add(new InversionistaContable());
			_inversionistas.Add(new InversionistaExterno() {retroalimentable = director} );
			
			// Se agregan Trabajadores
			_trabajadores.Add(new Cuidador());
			_trabajadores.Add(new VendedorExtranjero() { retroalimentable = director });
			
			// Rutina director por 10 dias
			for(int i = 1; i <= 10; ++i) {
				bool diaCorrecto = director.rutina();
				Console.WriteLine(string.Format("Director: Dia {0} correcto: {1}", i, diaCorrecto));
			}
			
			Console.ReadKey(true);
		}
	}
	
	#region Implementa Mocks (Clases ejemplo para inversionistas/trabajadores)
	class InversionistaContable : Inversionista, Contador
	{
		int Inversionista.solicitarDinero(int cantidadMinima)
		{
			Console.WriteLine("InversionistaContable: solicitarDinero");
			return cantidadMinima + 10;
		}
		
		void Inversionista.reportarEstatusZoologico(string status)
		{
			Console.WriteLine(string.Format("InversionistaContable: status {0}", status));
		}
		
		bool Contador.registraGastos(int dineroNomina)
		{
			Console.WriteLine(string.Format("InversionistaContable: registraGastos {0}", dineroNomina));
			return dineroNomina > 0;
		}
		
		bool Trabajador.revisarHorario()
		{
			Console.WriteLine("InversionistaContable: revisarHorario {0}");
			return true;
		}
		
		void Trabajador.pagarQuincena(int dinero)
		{
			Console.WriteLine(string.Format("InversionistaContable: registraGastos {0}", dinero));
		}
	}
	
	class InversionistaExterno : Inversionista {
		
		public Retroalimentable retroalimentable {get; set;}
		
		int Inversionista.solicitarDinero(int cantidadMinima)
		{
			Console.WriteLine("InversionistaExterno: solicitarDinero");
			return cantidadMinima;
		}
		
		void Inversionista.reportarEstatusZoologico(string status)
		{
			Console.WriteLine(string.Format("InversionistaExterno: status {0}", status));
			if(retroalimentable != null) {  // Sin saber que es el director del zoologico, se retroalimenta
				retroalimentable.comentarRetroalimentacion(string.Format("InversionistaExterno: status {0} recibido", status));
			}
		}
	}
	
	class Cuidador : Expertoanimales {
		
		
		bool Expertoanimales.obtenerEstadoDeAnimales()
		{
			Console.WriteLine("Cuidador: obtenerEstadoDeAnimales");
			return true;
		}
		
		bool Trabajador.revisarHorario()
		{
			Console.WriteLine("Cuidador: revisarHorario");
			return true;
		}
		
		void Trabajador.pagarQuincena(int dinero)
		{
			Console.WriteLine(string.Format("Cuidador: pagarQuincena {0}", dinero));
		}
	}
	
	class VendedorExtranjero : Vendedor {
		int i = 0;
		public Retroalimentable retroalimentable { get; set; }
		
		bool Trabajador.revisarHorario()
		{
			Console.WriteLine("VendedorExtranjero: revisarHorario");
			if(retroalimentable != null) { // Sin saber que es el director del zoologico, se retroalimenta
				retroalimentable.comentarRetroalimentacion( string.Format("VendedorExtranjero: revisarHorario {0}", ++i));
				return true;
			}
			return false;
		}
		
		void Trabajador.pagarQuincena(int dinero)
		{
			Console.WriteLine(string.Format("VendedorExtranjero: pagarQuincena {0}", dinero));
		}
	}
	
	#endregion
}