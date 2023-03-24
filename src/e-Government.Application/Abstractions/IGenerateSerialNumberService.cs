using e_Government.Application.DIOs;

namespace e_Government.Application.Abstractions
{
    public interface IGenerateSerialNumberService
    {
        string Generate(GenerateSerialNumberServiceModel model);
    }
}
