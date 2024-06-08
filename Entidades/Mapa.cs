using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        int alto;
        int ancho;

        public int Alto 
        {
            get => this.alto; // Obtiene el alto del mapa.
        } 

        public int Ancho 
        {
            get => this.ancho; // Obtiene el ancho del mapa.
        } 

        public int Superficie => Alto * Ancho; // Obtiene la superficie del mapa.

        /// <summary>
        /// Constructor de la clase Mapa.
        /// </summary>
        /// <param name="titulo">Título del mapa.</param>
        /// <param name="autor">Autor del mapa.</param>
        /// <param name="anio">Año de publicación del mapa.</param>
        /// <param name="barcode">Código de barras del mapa.</param>
        /// <param name="ancho">Ancho del mapa.</param>
        /// <param name="alto">Alto del mapa.</param>
        public Mapa(string titulo, string autor, int anio, string numNormalizado, string barcode, int ancho, int alto)
            : base(titulo, autor, anio, "", barcode) // Los mapas no tienen NumNormalizado
        {   // Inicializa las propiedades específicas de la clase Mapa
            this.ancho = ancho; // Asigna el valor del parámetro ancho a la propiedad ancho del objeto Mapa
            this.alto = alto; // Asigna el valor del parámetro alto a la propiedad alto del objeto Mapa
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad para comparar dos mapas.
        /// </summary>
        /// <param name="m1">Primer mapa a comparar.</param>
        /// <param name="m2">Segundo mapa a comparar.</param>
        /// <returns>True si los mapas son iguales, de lo contrario, false.</returns>
        public static bool operator ==(Mapa m1, Mapa m2)
        {   // Verifica si los códigos de barras son iguales, si los títulos son iguales
            //si los autores son iguales, si los años son iguales, si las superficies son iguales
            return m1.Barcode == m2.Barcode ||
                   (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor && m1.Anio == m2.Anio && m1.Superficie == m2.Superficie);
        }

        /// <summary>
        /// Sobrecarga del operador de desigualdad para comparar dos mapas.
        /// </summary>
        /// <param name="m1">Primer mapa a comparar.</param>
        /// <param name="m2">Segundo mapa a comparar.</param>
        /// <returns>True si los mapas son diferentes, de lo contrario, false.</returns>
        public static bool operator !=(Mapa m1, Mapa m2)
        {
            return !(m1 == m2); // Retorna la negación del resultado de la comparación de igualdad
        }

        /// <summary>
        /// Sobrescritura del método ToString para representar el mapa como una cadena.
        /// </summary>
        /// <returns>Cadena que representa el mapa.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"Superficie: {Ancho} * {Alto}  =  {Superficie} cm2.");
            return sb.ToString();
        }
    }
}
