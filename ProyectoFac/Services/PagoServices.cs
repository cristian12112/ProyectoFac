using Microsoft.EntityFrameworkCore;
using ProyectoFac.Context;
using ProyectoFac.DTOs;
using ProyectoFac.DTOs.Pago;
using ProyectoFac.Interface.Pago;
using ProyectoFac.Models;

namespace ProyectoFac.Services
{
    public class PagoServices : IPago
    {

        private StoreContext _context;

        public PagoServices(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PagoDtos>> ListarPagos() => await _context.tbl_pagos.Select(x => new PagoDtos
        {
            prg_int_idpago = x.prg_int_idpago,
            prg_dt_fechapago = x.prg_dt_fechapago,
            prg_dec_montopagado = x.prg_dec_montopagado,
            prg_vch_metodopago = x.prg_vch_metodopago,
            prg_txt_observacion = x.prg_txt_observacion,
        }).ToListAsync();

        public async Task<PagoDtos> AddPago(PagoAddDtos add)
        {
            var pago = new Pago
            {
                prg_dt_fechapago = add.prg_dt_fechapago,
                prg_dec_montopagado = add.prg_dec_montopagado,
                prg_vch_metodopago = add.prg_vch_metodopago,
                prg_txt_observacion = add.prg_txt_observacion,
            };
            await _context.tbl_pagos.AddAsync(pago);
            await _context.SaveChangesAsync();

            PagoDtos pagoDtos = new PagoDtos
            {
                prg_int_idpago = pago.prg_int_idpago,
                prg_dt_fechapago = pago.prg_dt_fechapago,
                prg_dec_montopagado = pago.prg_dec_montopagado,
                prg_vch_metodopago = pago.prg_vch_metodopago,
                prg_txt_observacion = pago.prg_txt_observacion,
            };

            return pagoDtos;
        }
        public async Task<PagoDtos> UpdatePagos(PagoUpdateDtos updatePago, int idpago)
        {
            var req = await _context.tbl_pagos.FindAsync(idpago);
            if( req != null)
            {
                var pagosUpdate = new Pago
                {
                    prg_dt_fechapago = updatePago.prg_dt_fechapago,
                    prg_dec_montopagado = updatePago.prg_dec_montopagado,
                    prg_vch_metodopago = updatePago.prg_vch_metodopago,
                    prg_txt_observacion = updatePago.prg_txt_observacion,
                };

                await _context.SaveChangesAsync();

                var update = new PagoDtos
                {
                    prg_dt_fechapago = pagosUpdate.prg_dt_fechapago,
                    prg_dec_montopagado = pagosUpdate.prg_dec_montopagado,
                    prg_vch_metodopago = pagosUpdate.prg_vch_metodopago,
                    prg_txt_observacion = pagosUpdate.prg_txt_observacion,
                };

                return update;
            }
            return null;
        }
        public async Task<PagoDtos> DeletePagos(int idpago)
        {
            var deletePago = await _context.tbl_pagos.FindAsync(idpago);

            if (deletePago != null)
            {
                var eliminarDto = new PagoDtos
                {
                    prg_int_idpago = deletePago.prg_int_idpago,
                    prg_dt_fechapago = deletePago.prg_dt_fechapago,
                    prg_dec_montopagado = deletePago.prg_dec_montopagado,
                    prg_vch_metodopago = deletePago.prg_vch_metodopago,
                    prg_txt_observacion = deletePago.prg_txt_observacion,
                };
                _context.Remove(deletePago);
                await _context.SaveChangesAsync();
                return eliminarDto;
            }

            return null;




        }
    }
}
