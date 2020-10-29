using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OG.BLAZOR.ENTITIES
{
    public class EPersona
    {
        public EPersona()
        {

        }
        public EPersona(DataRow r)
        {
            Id = Convert.ToInt32(r["Id"]);
            Nombre = Convert.ToString(r["Nombre"]);
            AP = Convert.ToString(r["APaterno"]);
            AM = Convert.ToString(r["AMaterno"]);
            Edad = Convert.ToInt32(r["Edad"]);
            Estatura = Convert.ToDecimal(r["Estatura"]);
            Peso = Convert.ToDecimal(r["Peso"]);
            FechaN = Convert.ToDateTime(r["FechaN"]);
            Activo = Convert.ToBoolean(r["Activo"]);
        }
        public Nullable<int> Id { get; set; }
        public string Nombre { get; set; }
        public string AP { get; set; }
        public string AM { get; set; }
        public Nullable<int> Edad { get; set; }
        public Nullable<decimal> Estatura { get; set; }
        public Nullable<decimal> Peso { get; set; }
        public Nullable<DateTime> FechaN { get; set; }
        public bool Activo { get; set; }
    }
}
