using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entidades
{
    public static class Informes
    {
        /// <summary>
        /// Muestra los documentos por un estado específico en el escáner.
        /// </summary>
        /// <param name="e">Escáner.</param>
        /// <param name="estado">Estado de los documentos a mostrar.</param>
        /// <param name="extension">Total de la extensión procesada.</param>
        /// <param name="cantidad">Cantidad de ítems únicos procesados.</param>
        /// <param name="resumen">Resumen de los datos de los ítems.</param>
        private static void MostrarDocumentosPorEstado(Escaner e, Documento.Paso estado, out int extension, out int cantidad, out string resumen)
        {   // Inicializa los valores de salida.
            extension = 0;
            cantidad = 0;
            resumen = "";

            foreach (Documento d in e.ListaDocumentos)
            {
                if (d.Estado == estado) // Comprueba si el estado del documento coincide con el estado especificado
                {
                    if ((e.Tipo == Escaner.TipoDoc.libro)) // Si el tipo de documento es 'libro', convierte el documento a 'Libro' y suma el número de páginas.
                    {
                        Libro libro = (Libro)d;
                        extension += libro.NumPaginas;
                    }
                    else if ((e.Tipo == Escaner.TipoDoc.mapa))

                    {
                        Mapa mapa = (Mapa)d;
                        extension += mapa.Superficie;
                    }
                    resumen += d.ToString(); // Añade la representación en cadena del documento al resumen.
                    cantidad++; // Incrementa la cantidad de documentos que coinciden con el estado especificado.
                }
            }
        }


        /// <summary>
        /// Muestra los documentos distribuidos en el escáner.
        /// </summary>
        /// <param name="e">Escáner.</param>
        /// <param name="extension">Total de la extensión procesada.</param>
        /// <param name="cantidad">Cantidad de ítems únicos procesados.</param>
        /// <param name="resumen">Resumen de los datos de los ítems.</param>
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {   // Llama a la función MostrarDocumentosPorEstado con el estado Documento.Paso.Distribuido
            // para obtener la extensión total, la cantidad de documentos y el resumen de los documentos distribuidos.
            MostrarDocumentosPorEstado(e, Documento.Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra los documentos en el escáner.
        /// </summary>
        /// <param name="e">Escáner.</param>
        /// <param name="extension">Total de la extensión procesada.</param>
        /// <param name="cantidad">Cantidad de ítems únicos procesados.</param>
        /// <param name="resumen">Resumen de los datos de los ítems.</param>
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra los documentos terminados en el escáner.
        /// </summary>
        /// <param name="e">Escáner.</param>
        /// <param name="extension">Total de la extensión procesada.</param>
        /// <param name="cantidad">Cantidad de ítems únicos procesados.</param>
        /// <param name="resumen">Resumen de los datos de los ítems.</param>
        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Terminado, out extension, out cantidad, out resumen);
        }
        
    }
}
