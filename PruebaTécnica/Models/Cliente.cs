using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace PruebaTécnica.Models
{
    [TableName("clientes")]
    [PrimaryKey("id")]
    class Cliente
    {
        public Cliente(int id, string nombres, string apellidos, string dui, DateTime fecha_nacimiento)
        {
            this.id = id;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.dui = dui;
            this.fecha_nacimiento = fecha_nacimiento;
        }

        public Cliente() { }

        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string dui { get; set; }
        public DateTime? fecha_nacimiento { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
