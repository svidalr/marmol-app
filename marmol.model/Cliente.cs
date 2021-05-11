using System.Collections.Generic;

namespace MarmolApp.Model
{
    /// <summary>
    /// cliente de marmol
    /// </summary>
    public class Cliente : EntityBase
    {
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public int Celular { get; set; }

        /// <summary>
        /// relacion con los tratos a traves de id
        /// </summary>
        public List<string> TratosId { get; set; }


    }
}
