using System.Text;

namespace Entidades
{
    
    public abstract class Documento
    {   //campos
        int anio;
        string autor;
        string barcode;
        Paso estado;
        string numNormalizado;
        string titulo;

        /// <summary>
        /// Constructor: inicializa un nuevo documento con los datos especificados.
        /// </summary>
        /// <param name="titulo">Título del documento.</param>
        /// <param name="autor">Autor del documento.</param>
        /// <param name="anio">Año de publicación del documento.</param>
        /// <param name="numNormalizado">Número normalizado del documento.</param>
        /// <param name="barcode">Código de barras del documento.</param>
        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio;
        }

        public enum Paso // enum: representa los distintos estados de un documento.
        {         
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }

        // propiedades de solo lectura para los datos del documento
        public int Anio 
        {
            get => this.anio;
        }
        
        public string Autor 
        {
            get => this.autor;
        }
        
        public string Barcode 
        {
            get => this.barcode;          
        }

        public Paso Estado 
        { 
            get => this.estado;
        }

        protected string NumNormalizado 
        { 
            get => this.numNormalizado;
        }
        
        public string Titulo 
        {
            get => this.titulo;
        }


        /// <summary>
        /// Avanza el estado del documento al siguiente paso del proceso.
        /// </summary>
        /// <returns> True si el estado fue avanzado, False si el documento 
        /// ya estaba en el estado Terminado.</returns>
        public bool AvanzarEstado()
        {
            bool retorno = true;
            if (this.estado == Paso.Terminado) // Comprueba si el estado actual del documento es 'Terminado'
            {   // Si el estado es 'Terminado', no se puede avanzar más, por lo que
                // establece 'retorno' en false.
                retorno = false;
            }
            else
            {   // Si el estado no es 'Terminado', incrementa el estado actual
                this.estado++;
            }
            return retorno;
        }

        /// <summary>
        /// Devuelve una cadena que representa el documento con todos sus datos.
        /// </summary>
        /// <returns>Una cadena que contiene los datos del documento.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Título: {Titulo}");
            sb.AppendLine($"Autor: {Autor}");
            sb.AppendLine($"Año: {Anio}");
            sb.AppendLine($"Cód. de barras: {Barcode}");
            return sb.ToString();
        }
    }
}    
