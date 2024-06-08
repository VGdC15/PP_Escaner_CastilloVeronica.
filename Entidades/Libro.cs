using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {   // campo
        int numPaginas;

        public string ISBN => NumNormalizado; // obtiene el ISBN del libro, que es igual al número normalizado.

        public int NumPaginas 
        {
            get => this.numPaginas; // obtiene el número de páginas del libro.
        } 

        /// <summary>
        /// Constructor de la clase Libro.
        /// </summary>
        /// <param name="titulo">Título del libro.</param>
        /// <param name="autor">Autor del libro.</param>
        /// <param name="anio">Año de publicación del libro.</param>
        /// <param name="numNormalizado">Número normalizado del libro (ISBN).</param>
        /// <param name="barcode">Código de barras del libro.</param>
        /// <param name="numPaginas">Número de páginas del libro.</param>
        public Libro(string titulo, string autor, int anio, string numNormalizado, string barcode, int numPaginas)
            : base(titulo, autor, anio, numNormalizado, barcode) // llama al constructor de la clase base Documento
        {
            this.numPaginas = numPaginas; // asigna el número de páginas al campo 'numPaginas' del libro
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad para comparar dos libros.
        /// </summary>
        /// <param name="libro1">Primer libro a comparar.</param>
        /// <param name="libro2">Segundo libro a comparar.</param>
        /// <returns>True si los libros son iguales, de lo contrario, false.</returns>
        public static bool operator ==(Libro libro1, Libro libro2)
        {
            // Retorna true si:
            // - Los códigos de barras de ambos libros son iguales, o
            // - Los números ISBN de ambos libros son iguales, o
            // - Ambos libros tienen el mismo título y el mismo autor.
            return libro1.Barcode == libro2.Barcode ||
                   libro1.ISBN == libro2.ISBN ||
                   (libro1.Titulo == libro2.Titulo && libro1.Autor == libro2.Autor);
        }

        /// <summary>
        /// Sobrecarga del operador de desigualdad para comparar dos libros.
        /// </summary>
        /// <param name="libro1">Primer libro a comparar.</param>
        /// <param name="libro2">Segundo libro a comparar.</param>
        /// <returns>True si los libros son diferentes, de lo contrario, false.</returns>
        public static bool operator !=(Libro libro1, Libro libro2)
        {   // Retorna el valor opuesto de la comparación usando el operador ==
            // retorna true si los libros no son iguales, y false si son iguales.
            return !(libro1 == libro2);
        }

        /// <summary>
        /// Sobrescritura del método ToString para representar el libro como una cadena.
        /// </summary>
        /// <returns>Cadena que representa el libro.</returns>
        public override string ToString()
        {
            // heredo el ToString de documento y lo divido en líneas
            string[] lineasDocumento = base.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            // inserto el ISBN antes del código de barras
            foreach (string linea in lineasDocumento) // Recorre cada línea del resultado del ToString() de la clase base
            {
                if (linea.Contains("Cód. de barras:")) // si la línea contiene "Cód. de barras:", insertamos el ISBN antes de esa línea
                {
                    sb.AppendLine($"ISBN: {ISBN}");
                }
                sb.AppendLine(linea);
            }
            sb.AppendLine($"Número de páginas: {NumPaginas}."); // inserto el número de páginas al final
            return sb.ToString();
        }
    }

}

