using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {   //campos
        List<Documento> listaDocumentos;
        Departamento locacion;
        string marca;
        TipoDoc tipo;
        
        public enum Departamento // Enumeración para los departamentos
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }

        public enum TipoDoc // Enumeración para los tipos de documentos
        {
            libro,
            mapa
        }

        // Propiedades del escáner
        public List<Documento> ListaDocumentos 
        { 
            get => this.listaDocumentos; // iniciaza  lista de documentos

        } 

        public Departamento Locacion
        { 
            get => this.locacion; // obtiene el valor del enum Departamento
        } 


        public string Marca 
        {
            get => this.marca;
        }

        public TipoDoc Tipo 
        {
            get => this.tipo;   // obtiene valor del enum TipoDoc
        } 

        /// <summary>
        /// Constructor de la clase Escaner.
        /// </summary>
        /// <param name="marca">Marca del escáner.</param>
        /// <param name="tipo">Tipo de documento que maneja el escáner.</param>
        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();

            // asigna la ubicación en base al tipo de documento
            // Si el tipo de documento es 'libro', asigna 'Departamento.procesosTecnicos'
            // De lo contrario (si no es 'libro'), asigna 'Departamento.mapoteca'
            this.locacion = tipo == TipoDoc.libro ? Departamento.procesosTecnicos : Departamento.mapoteca;
        }

        /// <summary>
        /// Cambia el estado de un documento al siguiente estado.
        /// </summary>
        /// <param name="d">Documento al que se le va a cambiar el estado.</param>
        /// <returns>True si se pudo cambiar el estado, false si el documento ya está terminado.</returns>
        public bool CambiarEstadoDocumento(Documento d)
        {
            bool avanzar = false; // Inicializa una variable booleana 'avanzar' en false.

            // Comprueba si el tipo de documento actual es 'libro' y el documento 'd' es una instancia de 'Libro'
            // o si el tipo de documento actual es 'mapa' y el documento 'd' es una instancia de 'Mapa'.
            if ((this.Tipo == TipoDoc.libro && d is Libro) || (this.Tipo == TipoDoc.mapa && d is Mapa))
            {
                // Recorre cada documento en la lista de documentos
                foreach (Documento doc in this.listaDocumentos)
                {
                    // Comprueba si la ubicación actual es 'procesosTecnicos' y ambos documentos son iguales como 'Libro'
                    // o si la ubicación actual es 'mapoteca' y ambos documentos son iguales como 'Mapa'.
                    if (((this.locacion == Departamento.procesosTecnicos) && ((Libro)doc == (Libro)d))
                        || ((this.locacion == Departamento.mapoteca) && ((Mapa)doc == (Mapa)d)))
                    {
                        // Intenta avanzar el estado del documento y asigna el resultado a 'avanzar'.
                        avanzar = doc.AvanzarEstado();
                        break; // Sale del bucle una vez que encuentra el documento y cambia su estado.
                    }
                }
            }
            return avanzar; // Devuelve true si el estado del documento fue avanzado, false en caso contrario

        }

        /// <summary>
        /// Sobrecarga del operador de igualdad para verificar si un documento ya está en el escáner.
        /// </summary>
        /// <param name="e">Escáner.</param>
        /// <param name="d">Documento.</param>
        /// <returns>True si el documento está en el escáner, false en caso contrario.</returns>
        //public static bool operator ==(Escaner e, Documento d)
        //{
        //    bool esIgual = false; // inicializa la variable que almacenará el resultado

        //    if ((e.tipo == TipoDoc.libro && d is Libro) || (e.tipo == TipoDoc.mapa && d is Mapa)) //verifica si el documento es del tipo adecuado para el escáner
        //    {
        //        foreach (Documento doc in e.listaDocumentos) //recorre los objetos de la lista
        //        {   // si el documento que pase es de tipo libro y ese libro es igual a un libro existente
        //            if (d is Libro && doc is Libro && ((Libro)d == (Libro)doc)) 
        //            {
        //                esIgual = true;
        //            } // si el documento que pase es de tipo mapa y ese mapa es igual a un mapa existente
        //            else if (d is Mapa && doc is Mapa && ((Mapa)d == (Mapa)doc))
        //            {
        //                esIgual = true;
        //            }
        //        }
        //    }
        //    return esIgual;
        //}


        public static bool operator ==(Escaner e, Documento d)
        {
            bool esIgual = false; // inicializa la variable que almacenará el resultado

            if (!((e.tipo == TipoDoc.libro && d is Libro) || (e.tipo == TipoDoc.mapa && d is Mapa)))
            {
                throw new TipoIncorrectoException("Este escáner no acepta este tipo de documento", nameof(Escaner), "operator ==");
            }

            foreach (Documento doc in e.listaDocumentos)
            {
                if (d is Libro && doc is Libro && ((Libro)d == (Libro)doc))
                {
                    esIgual = true;
                }
                else if (d is Mapa && doc is Mapa && ((Mapa)d == (Mapa)doc))
                {
                    esIgual = true;
                }
            }
            return esIgual;
        }



        /// <summary>
        /// Sobrecarga del operador de desigualdad para verificar si un documento no está en el escáner.
        /// </summary>
        /// <param name="e">Escáner.</param>
        /// <param name="d">Documento.</param>
        /// <returns>True si el documento no está en el escáner, false en caso contrario.</returns>
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e==d); //llama al método de arriba
        }

        /// <summary>
        /// Sobrecarga del operador de adición para agregar un documento al escáner.
        /// </summary>
        /// <param name="e">Escáner.</param>
        /// <param name="d">Documento.</param>
        /// <returns>True si el documento se agregó correctamente, false en caso contrario.</returns>
        //public static bool operator +(Escaner e, Documento d)
        //{
        //    bool puedeAgregar = false;
        //    //verificar que los documentos correspondan a tipo libro o tipo mapa para q no se guarde donde no corresponda
        //    if ((e.tipo == TipoDoc.libro && d is Libro) || (e.tipo == TipoDoc.mapa && d is Mapa))
        //    {
        //        if (e != d && d.Estado == Documento.Paso.Inicio)
        //        {
        //            d.AvanzarEstado();
        //            e.ListaDocumentos.Add(d);
        //            puedeAgregar = true;
        //        }
        //    }

        //    return puedeAgregar;

        //}


        public static bool operator +(Escaner e, Documento d)
        {
            bool puedeAgregar = false;
            try
            {
                if (e != d && d.Estado == Documento.Paso.Inicio)
                {
                    d.AvanzarEstado();
                    e.ListaDocumentos.Add(d);
                    puedeAgregar = true;
                }
            }
            catch (TipoIncorrectoException ex)
            {
                throw new TipoIncorrectoException("El documento no se pudo añadir a la lista", nameof(Escaner), "operator +", ex);
            }

            return puedeAgregar;
        }

    }

}
