namespace Entities
{

    public class Transaccion:BaseEntity
    {               
        public int CodCuentaKms { get; set; }
        public string Fecha { get; set; }
        public int HorasMotor { get; set; }
        public int IdEstacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdManguera { get; set; }        
        public decimal Importe { get; set; }
        public int Kms { get; set; }
        public decimal Litros { get; set; }
        public int ModoUso { get; set; }
        public decimal PPV { get; set; }
        public int NumRegistro { get; set; }
        public int SCU { get; set; }
        public int TipoCarburante { get; set; }
        public int TipoTransaccion { get; set; }

        public virtual Vehiculo vehiculo { get; set; }
        public virtual Manguera Manguera { get; set; }

    }
}
