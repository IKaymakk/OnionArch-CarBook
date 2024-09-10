using CarBook.Application.Features.Commands.BrandCommands;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBrandCommand command)
        {
            // Veriyi id'ye göre al
            var value = await _repository.GetByIdAsync(command.id);

            // Eğer değer null ise uygun bir işlem yap (örneğin bir exception fırlat veya hata mesajı döndür)
            if (value == null)
            {
                // İstenilen işleme göre burayı düzenleyebilirsiniz
                throw new Exception("Güncellenecek veri bulunamadı.");
            }

            // Değeri güncelle
            value.Name = command.name;

            // Güncellenmiş değeri kaydet
            await _repository.UpdateAsync(value);
        }

    }
}
