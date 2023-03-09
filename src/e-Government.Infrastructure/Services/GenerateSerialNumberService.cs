using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;

namespace e_Government.Infrastructure.Services
{
    public class GenerateSerialNumberService : IGenerateSerialNumberService
    {
        public string Generate(GenerateSerialNumberServiceModel model)
        {
            return model.EntityId.ToString() + "/" + model.DocumentId.ToString();
        }
    }
}
