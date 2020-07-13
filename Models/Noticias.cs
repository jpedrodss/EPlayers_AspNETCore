using System;
using System.Collections.Generic;
using System.IO;
using Aula37E_Players_AspNETCore.Interfaces;

namespace Aula37E_Players_AspNETCore.Models
{
    public class Noticias : EPlayersBase , INoticias
    {
        public int IdNoticias { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        private const string PATH = "Database/noticias.csv";
        public Noticias(){
            CreateFolderAndFile(PATH);
        }
        private string PrepararLinha(Noticias news){
            return $"{news.IdNoticias};{news.Titulo};{news.Imagem}";
        }
        public void Create(Noticias news){
            string[] linha = { PrepararLinha(news) };
            File.AppendAllLines(PATH, linha);
        }

        public void Delete(int idNoticias){
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == idNoticias.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Noticias> ReadAll(){
            List<Noticias> noticias = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas){
                string[] linha = item.Split(";");
                Noticias noticia = new Noticias();
                noticia.IdNoticias = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Imagem = linha[2];

                noticias.Add(noticia);
            }
            return noticias;
        }

        public void Update(Noticias news){
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == news.IdNoticias.ToString());
            linhas.Add(PrepararLinha(news));
            RewriteCSV(PATH, linhas);
        }
    }
}