using Microsoft.EntityFrameworkCore;
using ProyectoFac.Context;
using ProyectoFac.DTOs;
using ProyectoFac.DTOs.ClientesDtos;
using ProyectoFac.Interface.Cliente;
using ProyectoFac.Models;

namespace ProyectoFac.Services
{
    public class ClienteServices : IClientesServices
    {
        private StoreContext _context;
        public ClienteServices(StoreContext storeContext)
        {
            _context = storeContext;
        }

        public async Task<IEnumerable<ClienteDtos>> GetCliente() =>
            await _context.tbl_clientes.Select(x => new ClienteDtos { 
                prg_int_idcliente = x.prg_int_idcliente,
                prg_vch_nombre = x.prg_vch_nombre,
                prg_vch_rut = x.prg_vch_rut,
                prg_vch_direccion = x.prg_vch_direccion,
                prg_vch_telefono = x.prg_vch_telefono,
                prg_vch_email = x.prg_vch_email,
                prg_int_tipo = x.prg_int_tipo,
                prg_dt_fecharegistro = x.prg_dt_fecharegistro
            }).ToListAsync();
        
        public async Task<ClienteDtos> GetIdcliente(int idcliente)
        {
            var cliente = await _context.tbl_clientes.FindAsync(idcliente);

            if( cliente != null)
            {
                var clienteDto = new ClienteDtos
                {
                    prg_int_idcliente = cliente.prg_int_idcliente,
                    prg_vch_nombre = cliente.prg_vch_nombre,
                    prg_vch_rut = cliente.prg_vch_rut,
                    prg_vch_direccion = cliente.prg_vch_direccion,
                    prg_vch_telefono = cliente.prg_vch_telefono,
                    prg_vch_email = cliente.prg_vch_email,
                    prg_int_tipo = cliente.prg_int_tipo,
                    prg_dt_fecharegistro = cliente.prg_dt_fecharegistro

                };
                return clienteDto;
            }

            return null;
        }
        public async Task<ClienteDtos> AddCliente(ClienteInsertDto cliente)
        {
            var nuevoCliente = new Cliente
            {
                prg_vch_nombre = cliente.prg_vch_nombre,
                prg_vch_rut = cliente.prg_vch_rut,
                prg_vch_direccion = cliente.prg_vch_direccion,
                prg_vch_telefono = cliente.prg_vch_telefono,
                prg_vch_email = cliente.prg_vch_email,
                prg_int_tipo = cliente.prg_int_tipo
            };

            await _context.tbl_clientes.AddAsync(nuevoCliente);
            await _context.SaveChangesAsync();

            var ClienteDto = new ClienteDtos
            {
                prg_int_idcliente = nuevoCliente.prg_int_idcliente,
                prg_vch_nombre = nuevoCliente.prg_vch_nombre,
                prg_vch_rut = nuevoCliente.prg_vch_rut,
                prg_vch_direccion = nuevoCliente.prg_vch_direccion,
                prg_vch_telefono = nuevoCliente.prg_vch_telefono,
                prg_vch_email = nuevoCliente.prg_vch_email,
                prg_int_tipo = nuevoCliente.prg_int_tipo,
            };
            return ClienteDto;
        }

        public async Task<ClienteDtos> UpdateCliente(int idcliente, ClienteUpdateDto cliente)
        {
            var update = await _context.tbl_clientes.FindAsync(idcliente);
            if(update != null)
            {
                update.prg_vch_nombre = cliente.prg_vch_nombre;
                update.prg_vch_rut = cliente.prg_vch_rut;
                update.prg_vch_direccion = cliente.prg_vch_direccion;
                update.prg_vch_email= cliente.prg_vch_email;
                update.prg_vch_telefono = cliente.prg_vch_telefono;
                update.prg_int_tipo = cliente.prg_int_tipo;
            
                await _context.SaveChangesAsync();

                var clienteDto = new ClienteDtos
                {
                    prg_int_idcliente = update.prg_int_idcliente,
                    prg_vch_nombre=update.prg_vch_nombre,
                    prg_vch_rut=update.prg_vch_rut,
                    prg_vch_direccion=update.prg_vch_direccion,
                    prg_vch_email=update.prg_vch_email,
                    prg_vch_telefono=update.prg_vch_telefono,
                    prg_int_tipo=update.prg_int_tipo
                };
                return clienteDto;
            }
            return null;
        }

        public async Task<ClienteDtos> DeleteCliene(int idcliente)
        {
            var delete = await _context.tbl_clientes.FindAsync(idcliente);

            if (delete != null) 
            {
                var clientedto = new ClienteDtos
                {
                    prg_int_idcliente = delete.prg_int_idcliente,
                    prg_vch_nombre = delete.prg_vch_nombre,
                    prg_vch_rut = delete.prg_vch_rut,
                    prg_vch_direccion = delete.prg_vch_direccion,
                    prg_vch_telefono = delete.prg_vch_telefono,
                    prg_vch_email = delete.prg_vch_email,
                    prg_int_tipo = delete.prg_int_tipo,
                    prg_dt_fecharegistro = delete.prg_dt_fecharegistro
                };
                _context.Remove(delete);
                await _context.SaveChangesAsync();
                return clientedto;
            }
            return null;
        }
    }
}
