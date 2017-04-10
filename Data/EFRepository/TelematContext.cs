using Data.Interfaz;
using Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System;

namespace Data.EFRepository
{
    public class TelematContext:DbContext, ITelematContext
    {
        public TelematContext()   
            :base("data source=82.98.161.118; initial catalog=telematDB; user id=qualiweb; password = qMove2701")         
        {                    
        }
        
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<BaseRepostaje> Bases { get; set; }
        public DbSet<Deposito> Depositos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new TransaccionMap());
            modelBuilder.Configurations.Add(new VehiculoMap());
            modelBuilder.Configurations.Add(new BaseRepostajeMap());
            modelBuilder.Configurations.Add(new DepositosMap());
            base.OnModelCreating(modelBuilder);
        }

        public TelematContext service()
        {
            throw new NotImplementedException();
        }
    }

    
    public class TransaccionMap : EntityTypeConfiguration<Transaccion>
    {
        public TransaccionMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            ToTable("Transacciones");

        }
    }

    public class VehiculoMap : EntityTypeConfiguration<Vehiculo>
    {
        public VehiculoMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            ToTable("Vehiculos");
        }
    }

    public class BaseRepostajeMap: EntityTypeConfiguration<BaseRepostaje>
    {
        public BaseRepostajeMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            ToTable("Bases");
        }
    }

    public class DepositosMap:EntityTypeConfiguration<Deposito>
    {
        public DepositosMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            ToTable("Depositos");
        }
    }

}
