using Microsoft.EntityFrameworkCore;
using ProyectoFac.Context;
using ProyectoFac.DTOs;
using ProyectoFac.DTOs.Garantia;
using ProyectoFac.Interface.Garantia;
using ProyectoFac.Models;

namespace ProyectoFac.Services
{
    public class GarantiaServices : IGarantias
    {
        private StoreContext _context;
        public GarantiaServices(StoreContext context)
        {
            _context = context;
        }
        public async Task<GarantiasDto> AddGarantia(GarantiaAddDtos add)
        {
            var garantia = new Garantia
            {
                prg_int_idcliente = add.prg_int_idcliente,
                prg_vch_tipo = add.prg_vch_tipo,
                prg_txt_descripcion = add.prg_txt_descripcion,
                prg_dec_valorestimado = add.prg_dec_valorestimado,
                prg_dt_fecharegistro = DateTime.Now
            };
            await _context.tbl_garantias.AddAsync(garantia);
            await _context.SaveChangesAsync();

            GarantiasDto garan = new GarantiasDto
            {
                prg_int_idcliente = garantia.prg_int_idcliente,
                prg_vch_tipo = garantia.prg_vch_tipo,
                prg_txt_descripcion = garantia.prg_txt_descripcion,
                prg_dec_valorestimado = garantia.prg_dec_valorestimado,
                prg_dt_fecharegistro = garantia.prg_dt_fecharegistro
            };

            return garan;
        }

        public Task<GarantiasDto> DeleteGarantia(int idgarantia)
        {
            var req = _context.tbl_garantias.Find(idgarantia);

            if(req != null)
            {
                _context.tbl_garantias.Remove(req);
                _context.SaveChanges();
                return Task.FromResult(new GarantiasDto
                {
                    prg_int_idcliente = req.prg_int_idcliente,
                    prg_vch_tipo = req.prg_vch_tipo,
                    prg_txt_descripcion = req.prg_txt_descripcion,
                    prg_dec_valorestimado = req.prg_dec_valorestimado,
                    prg_dt_fecharegistro = req.prg_dt_fecharegistro
                });
                
            }
            return null;
        }

        public async Task<IEnumerable<GarantiasDto>> ListarGarantia()
        {
            var listar = await _context.tbl_garantias.Select(x => new GarantiasDto
            {
                prg_int_idcliente = x.prg_int_idcliente,
                prg_vch_tipo = x.prg_vch_tipo,
                prg_txt_descripcion = x.prg_txt_descripcion,
                prg_dec_valorestimado = x.prg_dec_valorestimado,
                prg_dt_fecharegistro = x.prg_dt_fecharegistro
            }).ToListAsync();
            return listar;
        }

        public async Task<GarantiasDto> UpdateGarantia(GarantiaUpdateDtos update, int idgarantia)
        {
            var req =  _context.tbl_garantias.Find(idgarantia);

            if( req != null)
            {
                var campoUpdate = new Garantia
                {
                    prg_vch_tipo = update.prg_vch_tipo,
                    prg_txt_descripcion = update.prg_txt_descripcion,
                    prg_dec_valorestimado = update.prg_dec_valorestimado,
                    prg_dt_fecharegistro = DateTime.Now
                };

                await _context.SaveChangesAsync();

                return new GarantiasDto
                {
                    prg_int_idcliente = req.prg_int_idcliente,
                    prg_vch_tipo = campoUpdate.prg_vch_tipo,
                    prg_txt_descripcion = campoUpdate.prg_txt_descripcion,
                    prg_dec_valorestimado = campoUpdate.prg_dec_valorestimado,
                    prg_dt_fecharegistro = campoUpdate.prg_dt_fecharegistro
                };

            }

            return null;
        }
    }
}
