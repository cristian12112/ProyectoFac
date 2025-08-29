using Microsoft.EntityFrameworkCore;

namespace ProyectoFac.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        public DbSet<Models.Cliente> tbl_clientes                       { get; set; }
        public DbSet<Models.ContratoFactoring> tbl_contratosFactoring   { get; set; }
        public DbSet<Models.EntidadFinanciera> tbl_entidadesFinancieras { get; set; }
        public DbSet<Models.Factura> tbl_facturas                       { get; set; }
        public DbSet<Models.Garantia> tbl_garantias                     { get; set; }
        public DbSet<Models.Movimiento> tbl_movimientos                 { get; set; }
        public DbSet<Models.Pago> tbl_pagos                             { get; set; }
        public DbSet<Models.Usuario> tbl_usuarios                       { get; set; }
    }
}
