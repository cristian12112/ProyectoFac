using Microsoft.EntityFrameworkCore;
using ProyectoFac.Context;
using ProyectoFac.DTOs;
using ProyectoFac.DTOs.Factura;
using ProyectoFac.Interface.Factura;
using ProyectoFac.Models;

namespace ProyectoFac.Services
{
    public class FacturaServices : IFacturaService
    {
        private StoreContext _context;
        public FacturaServices(StoreContext storeContext)
        {
            _context = storeContext;
        }
        public async Task<IEnumerable<FacturaDtos>> Facturas() =>
            await _context.tbl_facturas.Select(x => new FacturaDtos
            {
                prg_int_idfactura = x.prg_int_idfactura,
                prg_int_idcliente = x.prg_int_idcliente,
                prg_vch_numerofactura = x.prg_vch_numerofactura,
                prg_dt_fechaemision = x.prg_dt_fechaemision,
                prg_dt_fechavencimiento = x.prg_dt_fechavencimiento,
                prg_dec_monto = x.prg_dec_monto,
                prg_vch_moneda = x.prg_vch_moneda,
                prg_vch_estado = x.prg_vch_estado,
                prg_txt_descripcion = x.prg_txt_descripcion

            }).ToListAsync();

        public async Task<FacturaDtos> AddFacturas(FacturaAddDtos facturadto)
        {
            var factura = new Factura
            {
                prg_int_idfactura = facturadto.prg_int_idcliente,
                prg_vch_numerofactura = facturadto.prg_vch_numerofactura,
                prg_dt_fechaemision = facturadto.prg_dt_fechaemision,
                prg_dt_fechavencimiento = facturadto.prg_dt_fechavencimiento,
                prg_dec_monto = facturadto.prg_dec_monto,
                prg_vch_moneda = facturadto.prg_vch_moneda,
                prg_vch_estado = facturadto.prg_vch_estado,
                prg_txt_descripcion = facturadto.prg_txt_descripcion
            };

             await _context.tbl_facturas.AddAsync(factura);
             await _context.SaveChangesAsync();

            FacturaDtos facturaDtos = new FacturaDtos
            {
                prg_int_idfactura = factura.prg_int_idfactura,
                prg_int_idcliente = factura.prg_int_idcliente,
                prg_vch_numerofactura = factura.prg_vch_numerofactura,
                prg_dt_fechaemision = factura.prg_dt_fechaemision,
                prg_dt_fechavencimiento = factura.prg_dt_fechavencimiento,
                prg_dec_monto = factura.prg_dec_monto,
                prg_vch_moneda = factura.prg_vch_moneda,
                prg_vch_estado = factura.prg_vch_estado,
                prg_txt_descripcion = factura.prg_txt_descripcion
            };
            return facturaDtos;

        }

        public async Task<FacturaDtos> DeleteFacturas(int factura)
        {
            var elimnar = await _context.tbl_facturas.FindAsync(factura);

            if( elimnar != null)
            {
                var facturaDto = new FacturaDtos
                {
                    prg_int_idfactura = elimnar.prg_int_idfactura,
                    prg_int_idcliente = elimnar.prg_int_idcliente,
                    prg_vch_numerofactura = elimnar.prg_vch_numerofactura,
                    prg_dt_fechaemision = elimnar.prg_dt_fechaemision,
                    prg_dt_fechavencimiento = elimnar.prg_dt_fechavencimiento,
                    prg_dec_monto = elimnar.prg_dec_monto,
                    prg_vch_moneda = elimnar.prg_vch_moneda,
                    prg_vch_estado = elimnar.prg_vch_estado,
                    prg_txt_descripcion = elimnar.prg_txt_descripcion
                };
                _context.Remove(elimnar);
                await _context.SaveChangesAsync();
                return facturaDto;
            }
            return null;
        }


        public async Task<FacturaDtos> UpdateFacturas(FacturaUpdateDtos facturadto, int factura)
        {
            var update = _context.tbl_facturas.Find(factura);
            if( update != null)
            {
                var facturaUpdate = new Factura
                {
                    prg_int_idcliente = facturadto.prg_int_idcliente,
                    prg_vch_numerofactura = facturadto.prg_vch_numerofactura,
                    prg_dt_fechaemision = facturadto.prg_dt_fechaemision,
                    prg_dt_fechavencimiento = facturadto.prg_dt_fechavencimiento,
                    prg_dec_monto = facturadto.prg_dec_monto,
                    prg_vch_moneda = facturadto.prg_vch_moneda,
                    prg_vch_estado = facturadto.prg_vch_estado,
                    prg_txt_descripcion = facturadto.prg_txt_descripcion
                };
                await _context.SaveChangesAsync();

                var fac = new FacturaDtos
                {
                    prg_int_idcliente = facturaUpdate.prg_int_idcliente,
                    prg_vch_numerofactura = facturaUpdate.prg_vch_numerofactura,
                    prg_dt_fechaemision = facturaUpdate.prg_dt_fechaemision,
                    prg_dt_fechavencimiento = facturaUpdate.prg_dt_fechavencimiento,
                    prg_dec_monto = facturaUpdate.prg_dec_monto,
                    prg_vch_moneda = facturaUpdate.prg_vch_moneda,
                    prg_vch_estado = facturaUpdate.prg_vch_estado,
                    prg_txt_descripcion = facturaUpdate.prg_txt_descripcion
                };

                return fac;


            }
            return null;
        }
    }
}
