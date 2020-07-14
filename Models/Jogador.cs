using System;
using System.Collections.Generic;
using System.IO;
using Aula37E_Players_AspNETCore.Interfaces;

namespace Aula37E_Players_AspNETCore.Models
{
    public class Jogador : EPlayersBase , IJogador
    {
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public int IdEquipe { get; set; }
        private const string PATH = "Database/jogador.csv";
        public Jogador(){
            CreateFolderAndFile(PATH);
        }
        private string PrepararLinha(Jogador j){
            return $"{j.IdJogador};{j.Nome}";
        }
        public void Create(Jogador j){
            string[] linha = { PrepararLinha(j) };
            File.AppendAllLines(PATH, linha);
        }

        public void Delete(int idJogador){
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(';')[0] == IdJogador.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Jogador> ReadAll(){
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Jogador jogador = new Jogador();
                jogador.IdJogador = Int32.Parse(linha[0]);
                jogador.Nome = linha[1];

                jogadores.Add(jogador);
            }
            return jogadores;
        }

        public void Update(Jogador j){
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
            linhas.Add(PrepararLinha(j));
            RewriteCSV(PATH, linhas);
        }
    }
}