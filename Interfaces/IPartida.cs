using System.Collections.Generic;
using Aula37E_Players_AspNETCore.Models;

namespace Aula37E_Players_AspNETCore.Interfaces
{
    public interface IPartida
    {
        void Create(Partida p);
        // Ler
        List<Partida> ReadAll();
        // Alterar
        void Update(Partida p);
        // Deletar
        void Delete(int idPartida);
    }
}