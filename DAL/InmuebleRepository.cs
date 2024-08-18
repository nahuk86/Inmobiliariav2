using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL
{
    public class InmuebleRepository
    {
        private List<Inmueble> _inmuebles = new List<Inmueble>();

        public void AgregarInmueble(Inmueble inmueble)
        {
            _inmuebles.Add(inmueble);
        }

        public List<Inmueble> ObtenerTodos()
        {
            return _inmuebles;
        }

        // Otros métodos para eliminar, actualizar, etc.
    }
}
