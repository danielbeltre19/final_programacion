using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capa1;
using capa2;


namespace capa3
{
    public class ventascapa3
    {
        ventascapa2 _capa2 = new ventascapa2();

        public int AgregarVentas(ventas pventas)
        {
            return _capa2.AgregarVenta(pventas);
        }
        public List<ventas> MostrarVentas()
        {
            return _capa2.MostrarVentas();
        }
        public List<ventas> MostrarVentasNombre(ventas pventas)
        {
            return _capa2.MostrarVentasNombre(pventas);
        }
        public int ModificarVentas(ventas pventas)
        {
            return _capa2.ModificarVentas(pventas);
        }
        public int Eliminar(ventas pventas)
        {
            return _capa2.EliminarVentas(pventas);
        }
    }
}
