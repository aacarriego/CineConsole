using Domain;

namespace Application.Interface
{
    public interface ISalasService
    {
        public List<Sala> GetAllSalas();

        public string GetSalaNombreById(int salaId);

    }
}
