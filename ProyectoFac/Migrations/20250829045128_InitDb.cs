using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFac.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_clientes",
                columns: table => new
                {
                    prg_int_idcliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    prg_vch_nombre = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_vch_rut = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_vch_direccion = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_vch_telefono = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_vch_email = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_int_tipo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_dt_fecharegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_clientes", x => x.prg_int_idcliente);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_contratosFactoring",
                columns: table => new
                {
                    prg_int_idcontrato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    prg_int_idfactura = table.Column<int>(type: "int", nullable: false),
                    prg_int_identidad = table.Column<int>(type: "int", nullable: false),
                    prg_dt_fechacesion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    prg_dec_montocedido = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    prg_dec_tasainteres = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    prg_int_plazodias = table.Column<int>(type: "int", nullable: false),
                    prg_vch_estado = table.Column<string>(type: "enum('activo','finalizado','cancelado')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_contratosFactoring", x => x.prg_int_idcontrato);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_entidadesFinancieras",
                columns: table => new
                {
                    prg_int_identidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    prg_vch_nombre = table.Column<string>(type: "varchar(150)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_vch_ruc = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_vch_direccion = table.Column<string>(type: "varchar(200)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_vch_telefono = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_vch_email = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_entidadesFinancieras", x => x.prg_int_identidad);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_facturas",
                columns: table => new
                {
                    prg_int_idfactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    prg_int_idcliente = table.Column<int>(type: "int", nullable: false),
                    prg_vch_numerofactura = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_dt_fechaemision = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    prg_dt_fechavencimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    prg_dec_monto = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    prg_vch_moneda = table.Column<string>(type: "enum('PEN','USD','EUR')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_vch_estado = table.Column<string>(type: "enum('pendiente','cedida','pagada','vencida')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_txt_descripcion = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_facturas", x => x.prg_int_idfactura);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_garantias",
                columns: table => new
                {
                    prg_int_idgarantia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    prg_int_idcliente = table.Column<int>(type: "int", nullable: false),
                    prg_vch_tipo = table.Column<string>(type: "enum('hipoteca','prenda','aval','fianza')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_txt_descripcion = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_dec_valorestimado = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    prg_dt_fecharegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_garantias", x => x.prg_int_idgarantia);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_movimientos",
                columns: table => new
                {
                    prg_int_idmovimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    prg_int_idusuario = table.Column<int>(type: "int", nullable: false),
                    prg_int_idfactura = table.Column<int>(type: "int", nullable: true),
                    prg_int_idcontrato = table.Column<int>(type: "int", nullable: true),
                    prg_vch_accion = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_txt_descripcion = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_dt_fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_movimientos", x => x.prg_int_idmovimiento);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_pagos",
                columns: table => new
                {
                    prg_int_idpago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    prg_int_idcontrato = table.Column<int>(type: "int", nullable: false),
                    prg_dt_fechapago = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    prg_dec_montopagado = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    prg_vch_metodopago = table.Column<string>(type: "enum('transferencia','efectivo','cheque')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_txt_observacion = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_pagos", x => x.prg_int_idpago);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_usuarios",
                columns: table => new
                {
                    prg_int_idusuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    prg_vch_nombreusuario = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_vch_clave = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_vch_rol = table.Column<string>(type: "enum('administrador','analista','cobranzas')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_int_estado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prg_dt_fechacreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_usuarios", x => x.prg_int_idusuario);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_clientes");

            migrationBuilder.DropTable(
                name: "tbl_contratosFactoring");

            migrationBuilder.DropTable(
                name: "tbl_entidadesFinancieras");

            migrationBuilder.DropTable(
                name: "tbl_facturas");

            migrationBuilder.DropTable(
                name: "tbl_garantias");

            migrationBuilder.DropTable(
                name: "tbl_movimientos");

            migrationBuilder.DropTable(
                name: "tbl_pagos");

            migrationBuilder.DropTable(
                name: "tbl_usuarios");
        }
    }
}
