using Domain;

namespace Application.Interface
{
    public interface ISalasQuery
    {
        List<Sala> GetListSalas();
        Sala GetById(int salaId);
    }
}
