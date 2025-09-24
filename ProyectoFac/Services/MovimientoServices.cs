using Microsoft.EntityFrameworkCore;
using ProyectoFac.Context;
using ProyectoFac.DTOs;
using ProyectoFac.DTOs.Movimiento;
using ProyectoFac.Interface.Movimiento;
using ProyectoFac.Models;

namespace ProyectoFac.Services
{
    public class MovimientoServices : IMovimiento
    {
        private StoreContext _context;

        public MovimientoServices(StoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MovimientosDtos>> ListarMovimientos()
        {
            var req = await _context.tbl_movimientos.Select(x => new MovimientosDtos 
            { 
                Idmovimiento = x.prg_int_idmovimiento,
                Idusuario = x.prg_int_idusuario,
                Idfactura = x.prg_int_idfactura,
                Idcontrato = x.prg_int_idcontrato,
                Accion = x.prg_vch_accion,
                Descripcion = x.prg_txt_descripcion,
                Fecha = x.prg_dt_fecha
            }).ToListAsync();

            return req;
        }
        public async Task<MovimientosDtos> AddMovimiento(MovimientoAddDtos add)
        {
            var req = new Movimiento
            {
                prg_int_idusuario = add.Idusuario,
                prg_int_idfactura = add.Idfactura,
                prg_int_idcontrato = add.Idcontrato,
                prg_vch_accion = add.Accion,
                prg_txt_descripcion = add.Descripcion
            };

            await _context.tbl_movimientos.AddAsync(req);
            await _context.SaveChangesAsync();

            MovimientosDtos movimientoDtos = new MovimientosDtos
            {
                Idmovimiento = req.prg_int_idmovimiento,
                Idusuario = req.prg_int_idusuario,
                Idfactura = req.prg_int_idfactura,
                Idcontrato = req.prg_int_idcontrato,
                Accion = req.prg_vch_accion,
                Descripcion = req.prg_txt_descripcion,
                Fecha = req.prg_dt_fecha
            };

            return movimientoDtos;

        }

        public async Task<MovimientosDtos> DeleteMovimiento(int idmovimiento)
        {
            var req = await _context.tbl_movimientos.FindAsync(idmovimiento);
            
            if( req != null)
            {
                var delete = new MovimientosDtos
                {
                    Idmovimiento = req.prg_int_idmovimiento,
                    Idusuario = req.prg_int_idusuario,
                    Idfactura = req.prg_int_idfactura,
                    Idcontrato = req.prg_int_idcontrato,
                    Accion = req.prg_vch_accion,
                    Descripcion = req.prg_txt_descripcion,
                    Fecha = req.prg_dt_fecha
                };

                _context.Remove(delete);
                await _context.SaveChangesAsync();
                return delete;
            }
            return null;
        }


        public async Task<MovimientosDtos> UpdateMovimiento(MovimientoUpdateDtos update, int idmovimiento)
        {
            var req = await _context.tbl_movimientos.FindAsync(idmovimiento);
            if( req != null)
            {
                var up = new Movimiento
                {
                    prg_vch_accion = update.Accion,
                    prg_txt_descripcion = update.Descripcion
                };

                await _context.SaveChangesAsync();

                var updateCampos = new MovimientosDtos
                {
                    Accion = up.prg_vch_accion,
                    Descripcion = up.prg_txt_descripcion,
                    Fecha = DateTime.Now
                };
                
            }
            return null;
        }
    }
}
