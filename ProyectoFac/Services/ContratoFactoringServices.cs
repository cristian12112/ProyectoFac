using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using ProyectoFac.Context;
using ProyectoFac.DTOs;
using ProyectoFac.Interface;
using ProyectoFac.Models;

namespace ProyectoFac.Services
{
    public class ContratoFactoringServices : IContratoFactoring
    {
        private StoreContext _context;

        public ContratoFactoringServices(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContratoFacturaDTOs>> ListarContrato()
        {
            var listar = await _context.tbl_contratosFactoring.Select(x => new ContratoFacturaDTOs
            {
                Idcontrato =x.prg_int_idcontrato,
                Idfactura = x.prg_int_idfactura,
                Identidad = x.prg_int_identidad,
                Fechacesion = x.prg_dt_fechacesion,
                Montocedido = x.prg_dec_montocedido,
                Tasainteres = x.prg_dec_tasainteres,
                Plazodias = x.prg_int_plazodias,
                Estado = x.prg_vch_estado
            }).ToListAsync();
            return listar;
        }
        public async Task<ContratoFacturaDTOs> AddContrato(ContratoFacturaDTOs add)
        {
            var contrato = new ContratoFactoring
            {
                prg_int_idfactura = add.Idfactura,
                prg_int_identidad = add.Identidad,
                prg_dt_fechacesion = add.Fechacesion,
                prg_dec_montocedido = add.Montocedido,
                prg_dec_tasainteres = add.Tasainteres,
                prg_int_plazodias = add.Plazodias,
                prg_vch_estado = add.Estado
            };
             await _context.tbl_contratosFactoring.AddAsync(contrato);
             await _context.SaveChangesAsync();

            var req = new ContratoFacturaDTOs
            {
                Idcontrato = contrato.prg_int_idcontrato,
                Idfactura = contrato.prg_int_idfactura,
                Identidad = contrato.prg_int_identidad,
                Fechacesion = contrato.prg_dt_fechacesion,
                Montocedido = contrato.prg_dec_montocedido,
                Tasainteres = contrato.prg_dec_tasainteres,
                Plazodias = contrato.prg_int_plazodias,
                Estado = contrato.prg_vch_estado
            };

            return req;
        }

        public async Task<ContratoFacturaDTOs> DeleteContrato(int idcontrato)
        {
            var req = _context.tbl_contratosFactoring.Find(idcontrato);
            
            if( req != null)
            {
                var campo = new ContratoFacturaDTOs
                {
                    Idcontrato = req.prg_int_idcontrato,
                    Idfactura = req.prg_int_idfactura,
                    Identidad = req.prg_int_identidad,
                    Fechacesion = req.prg_dt_fechacesion,
                    Montocedido = req.prg_dec_montocedido,
                    Tasainteres = req.prg_dec_tasainteres,
                    Plazodias = req.prg_int_plazodias,
                    Estado = req.prg_vch_estado
                };
                _context.tbl_contratosFactoring.Remove(req);
                _context.SaveChanges();
                return campo;
            }
            return null;
        }


        public async Task<ContratoFacturaDTOs> UpdateContrato(ContratoFacturaDTOs update, int idcontrato)
        {

            var req = _context.tbl_contratosFactoring.Find(idcontrato);
            if(req != null)
            {
                var contrato = new ContratoFactoring
                {
                    prg_int_idfactura = update.Idfactura,
                    prg_int_identidad = update.Identidad,
                    prg_dt_fechacesion = update.Fechacesion,
                    prg_dec_montocedido = update.Montocedido,
                    prg_dec_tasainteres = update.Tasainteres,
                    prg_int_plazodias = update.Plazodias,
                    prg_vch_estado = update.Estado
                };
                await _context.SaveChangesAsync();
                
                var campos = new ContratoFacturaDTOs
                {
                    Idcontrato = contrato.prg_int_idcontrato,
                    Idfactura = contrato.prg_int_idfactura,
                    Identidad = contrato.prg_int_identidad,
                    Fechacesion = contrato.prg_dt_fechacesion,
                    Montocedido = contrato.prg_dec_montocedido,
                    Tasainteres = contrato.prg_dec_tasainteres,
                    Plazodias = contrato.prg_int_plazodias,
                    Estado = contrato.prg_vch_estado
                };
                return campos;
            }

            return null;



        }
    }
}
