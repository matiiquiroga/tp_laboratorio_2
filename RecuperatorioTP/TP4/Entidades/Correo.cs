using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        List<Thread> _mockPaquetes;
        List<Paquete> _paquetes;

        public List<Paquete> Paquetes
        {
            get { return this._paquetes; }
            set { this._paquetes = value; }
        }

        public Correo()
        {
            _mockPaquetes = new List<Thread>();
            _paquetes = new List<Paquete>();
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();

            if (elementos.GetType() == typeof(Correo))
            {
                foreach (Paquete p in ((Correo)elementos).Paquetes)
                {
                    sb.AppendFormat("El tracking: {0}. Para la direccion: {1} (En estado: {2}) \n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
                }
            }
            return sb.ToString();
        }

        public static Correo operator +(Correo correo, Paquete paquetes)
        {
            foreach (Paquete item in correo.Paquetes)
            {
                if (item == paquetes)
                {
                    throw new TrackingIdRepetidoException("El tarcking ID" + paquetes.TrackingID + "ya figura en la lista de envios ");
                }
            }

            Thread thread = new Thread(paquetes.MockCicloDeVida);
            correo.Paquetes.Add(paquetes);
            correo._mockPaquetes.Add(thread);
            thread.Start();

            return correo;
        }

        public void FinEntregas()
        {
            foreach (Thread item in this._mockPaquetes)
            {
                if (item.IsAlive)
                    item.Abort();
            }
        }

    }
}
