using PROMCOSER_DOMAIN.Core.DTO;
using PROMCOSER_DOMAIN.Core.Entities;
using PROMCOSER_DOMAIN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROMCOSER_DOMAIN.Core.Services
{
    public class DetalleParteDiarioService : IDetalleParteDiarioService
    {
        private readonly IDetalleParteDiarioRepository _detalleParteDiarioRepository;

        public DetalleParteDiarioService(IDetalleParteDiarioRepository detalleParteDiarioRepository)
        {
            _detalleParteDiarioRepository = detalleParteDiarioRepository;
        }

        // Obtener todos los detalles
        public async Task<IEnumerable<DetalleParteDiarioListDTO>> GetDetalles()
        {
            var detalles = await _detalleParteDiarioRepository.GetDetalles();
            return detalles.Select(d => new DetalleParteDiarioListDTO
            {
                IdDetalleParteDiario = d.IdDetalleParteDiario,
                TrabajoEfectuado = d.TrabajoEfectuado
            }).ToList();
        }

        // Obtener un detalle por ID
        public async Task<DetalleParteDiarioDTO> GetDetalleById(long id)
        {
            var detalle = await _detalleParteDiarioRepository.GetDetalleById(id);
            if (detalle == null)
            {
                return null;
            }

            return new DetalleParteDiarioDTO
            {
                IdDetalleParteDiario = detalle.IdDetalleParteDiario,
                ParteDiarioId = detalle.IdDetalleParteDiario,
                Horas = (int)detalle.Horas,
                TrabajoEfectuado = detalle.TrabajoEfectuado,
                Descripcion = detalle.Descripcion
            };
        }

        // Obtener detalles por ID de parte diario
        public async Task<IEnumerable<DetalleParteDiarioListDTO>> GetDetallesByParteDiarioId(long parteDiarioId)
        {
            var detalles = await _detalleParteDiarioRepository.GetDetallesByParteDiarioId(parteDiarioId);
            return detalles.Select(d => new DetalleParteDiarioListDTO
            {
                IdDetalleParteDiario = d.IdDetalleParteDiario,
                TrabajoEfectuado = d.TrabajoEfectuado
            }).ToList();
        }

        // Insertar un nuevo detalle
        public async Task<long> Insert(DetalleParteDiarioDTO detalleParteDiarioDTO)
        {
            var detalle = new DetalleParteDiario
            {
                ParteDiarioId = detalleParteDiarioDTO.ParteDiarioId,
                Horas = detalleParteDiarioDTO.Horas,
                TrabajoEfectuado = detalleParteDiarioDTO.TrabajoEfectuado,
                Descripcion = detalleParteDiarioDTO.Descripcion
            };

            return await _detalleParteDiarioRepository.Insert(detalle);
        }

        // Actualizar un detalle existente
        public async Task<bool> Update(DetalleParteDiarioDTO detalleParteDiarioDTO)
        {
            var detalle = new DetalleParteDiario
            {
                IdDetalleParteDiario = detalleParteDiarioDTO.IdDetalleParteDiario,
                ParteDiarioId = detalleParteDiarioDTO.ParteDiarioId,
                Horas = detalleParteDiarioDTO.Horas,
                TrabajoEfectuado = detalleParteDiarioDTO.TrabajoEfectuado,
                Descripcion = detalleParteDiarioDTO.Descripcion
            };

            return await _detalleParteDiarioRepository.Update(detalle);
        }

        // Eliminar un detalle
        public async Task<bool> Delete(long id)
        {
            return await _detalleParteDiarioRepository.Delete(id);
        }
    }

}
