using System.Collections.Generic;
using Aula37E_Players_AspNETCore.Models;

namespace Aula37E_Players_AspNETCore.Interfaces
{
    public interface IEquipe
    {
        // Criar
         void Create(Equipe e);
        // Ler
         List<Equipe> ReadAll();
        // Alterar
         void Update(Equipe e);
        // Deletar
         void Delete(int idEquipe);
    }
}