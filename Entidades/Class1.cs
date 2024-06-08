using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoIncorrectoException
        : Exception
    {
        // campos
        string nombreClase;
        string nombreMetodo;

        // Propiedad para obtener el nombre de la clase
        public string NombreClase
        {
            get => nombreClase;
        }

        // Propiedad para obtener el nombre del método
        public string NombreMetodo
        {
            get => nombreMetodo;
        }

        // Constructor sin InnerException
        public TipoIncorrectoException(string mensaje, string nombreClase, string nombreMetodo)
        : base(mensaje) // Llama al constructor base de Exception con el mensaje
        {
            this.nombreClase = nombreClase;
            this.nombreMetodo = nombreMetodo;
        }

        // Constructor con InnerException
        public TipoIncorrectoException(string mensaje, string nombreClase, string nombreMetodo, Exception innerException)
            : base(mensaje, innerException) // Llama al constructor base de Exception con el mensaje y la innerException
        {
            this.nombreClase = nombreClase;
            this.nombreMetodo = nombreMetodo;
        }

        // Sobrescribe el método ToString para proporcionar detalles de la excepción
        public override string ToString()
        {
            // Mensaje base de la excepción
            string mensaje = $"Excepción en el método {NombreMetodo} de la clase {NombreClase}.\n" +
                             "Algo salió mal, revisa los detalles.\n";

            // Si hay una InnerException, añade sus detalles al mensaje
            if (InnerException != null)
            {
                mensaje += $"Detalles: {InnerException.Message}";
            }

            return mensaje; // Retorna el mensaje completo
        }
    }

}
