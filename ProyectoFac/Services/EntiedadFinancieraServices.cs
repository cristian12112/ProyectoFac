using Microsoft.EntityFrameworkCore;
using ProyectoFac.Context;
using ProyectoFac.DTOs;
using ProyectoFac.Interface;
using ProyectoFac.Models;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;

namespace ProyectoFac.Services
{
    public class EntiedadFinancieraServices : IEntidadFinanciera
    {
        private StoreContext _context;

        public EntiedadFinancieraServices(StoreContext context)
        {
            _context = context;
        }

        public async Task<EntidadFinancieraDtos> AgregarDatos(EntidadFinancieraDtos add)
        {
            var entidad = new EntidadFinanciera
            {
                prg_vch_nombre = add.Nombre,
                prg_vch_ruc = add.RUT,
                prg_vch_direccion = add.Direccion,
                prg_vch_telefono = add.Telefono,
                prg_vch_email = add.Email
            };

            await _context.tbl_entidadesFinancieras.AddAsync(entidad);
            await _context.SaveChangesAsync();

            var req = new EntidadFinancieraDtos
            {
                IdEntidad = entidad.prg_int_identidad,
                Nombre = entidad.prg_vch_nombre,
                RUT = entidad.prg_vch_ruc,
                Direccion = entidad.prg_vch_direccion,
                Telefono = entidad.prg_vch_telefono,
                Email = entidad.prg_vch_email
            };

            return req;

        }

        public async Task<EntidadFinancieraDtos> DeleteEntidad(int identidad)
        {
            var enF = _context.tbl_entidadesFinancieras.Find(identidad);
            if(enF != null)
            {
                var entidad = new EntidadFinancieraDtos
                {
                    IdEntidad = enF.prg_int_identidad,
                    Nombre = enF.prg_vch_nombre,
                    RUT = enF.prg_vch_ruc,
                    Direccion = enF.prg_vch_direccion,
                    Telefono = enF.prg_vch_telefono,
                    Email = enF.prg_vch_email
                };
                _context.tbl_entidadesFinancieras.Remove(enF);
                _context.SaveChanges();
                return entidad;
            }
            return null;
        }

        public async Task<IEnumerable<EntidadFinancieraDtos>> MostrarDatos()
        {
            var listar = await _context.tbl_entidadesFinancieras.Select(x => new EntidadFinancieraDtos
            {
                IdEntidad = x.prg_int_identidad,
                Nombre = x.prg_vch_nombre,
                RUT = x.prg_vch_ruc,
                Direccion = x.prg_vch_direccion,
                Telefono = x.prg_vch_telefono,
                Email = x.prg_vch_email
            }).ToListAsync();
            return listar;
        }

        public async Task<EntidadFinancieraDtos> UpdateEntidad(EntidadFinancieraDtos req, int identidad)
        {
            var ef = _context.tbl_entidadesFinancieras.Find(identidad);
            if ( ef != null ) 
            { 
                var entidad = new EntidadFinanciera
                {
                    prg_vch_nombre = req.Nombre,
                    prg_vch_ruc = req.RUT,
                    prg_vch_direccion = req.Direccion,
                    prg_vch_telefono = req.Telefono,
                    prg_vch_email = req.Email
                };
                await _context.SaveChangesAsync();

                var campo = new EntidadFinancieraDtos
                {
                    Nombre = entidad.prg_vch_nombre,
                    RUT = entidad.prg_vch_ruc,
                    Direccion = entidad.prg_vch_direccion,
                    Telefono = entidad.prg_vch_telefono,
                    Email = entidad.prg_vch_email
                };
                return campo;
            }
            return null;
        }
    }
}
