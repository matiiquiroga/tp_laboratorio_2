using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformarEstado;

        EEstado _estado;
        string _direccionEntrega;
        string _trackingID;

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        public string DireccionEntrega
        {
            get { return this._direccionEntrega; }
            set { _direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return this._estado; }
            set { _estado = value; }
        }

        public string TrackingID
        {
            get { return this._trackingID; }
            set { _trackingID = value; }
        }

        public Paquete(string direccionEntrega, string trackingID)
        {
            this._direccionEntrega = direccionEntrega;
            this._trackingID = trackingID;
            this._estado = EEstado.Ingresado;
        }

        public void MockCicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado++;
                this.InformarEstado(this.Estado, EventArgs.Empty);
            }
            PaqueteDAO.Insertar(this);
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", this._trackingID, this._direccionEntrega);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retValue = false;
            if (p1.TrackingID == p2.TrackingID)
            {
                retValue = true;
            }
            return retValue;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

    }
}
