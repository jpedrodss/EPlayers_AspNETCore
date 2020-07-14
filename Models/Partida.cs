using System;
using System.Collections.Generic;
using System.IO;
using Aula37E_Players_AspNETCore.Interfaces;

namespace Aula37E_Players_AspNETCore.Models
{
    public class Partida : EPlayersBase , IPartida
    {
        public int IdPartida { get; set; }
        public int IdEquipe1 { get; set; }
        public int IdEquipe2 { get; set; }
        public DateTime Horario { get; set; }
        private const string PATH = "Database/partida.csv";
        public Partida(){
            CreateFolderAndFile(PATH);
        }
        private string PrepararLinha(Partida p)
        {
            return $"{p.IdPartida};{p.Horario};{p.IdEquipe1};{p.IdEquipe2}";
        }
        public void Create(Partida p){
            string[] linha = { PrepararLinha(p) };
            File.AppendAllLines(PATH, linha);
        }

        public void Delete(int idPartida){
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(';')[0] == IdPartida.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Partida> ReadAll(){
            List<Partida> partidas = new List<Partida>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Partida partida   = new Partida();
                partida.IdPartida = Int32.Parse(linha[0]);
                partida.Horario   = DateTime.Parse(linha[1]);
                partida.IdEquipe1 = Int32.Parse(linha[2]);
                partida.IdEquipe2 = Int32.Parse(linha[3]);

                partidas.Add(partida);
            }
            return partidas;
        }

        public void Update(Partida p){
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == p.IdPartida.ToString());
            linhas.Add(PrepararLinha(p));
            RewriteCSV(PATH, linhas);
        }
    }
}