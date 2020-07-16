using System.Collections.Generic;
using System.IO;

namespace Aula37E_Players_AspNETCore.Models
{
    public class EPlayersBase
    {
        /// <summary>
        /// Cria o diretório e o arquivo "csv".
        /// </summary>
        /// <param name="_path">Caminho onde será criado a pasta e arquivo "csv".</param>
        public void CreateFolderAndFile(string _path){

            string folder = _path.Split("/")[0]; 

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
            }
        }
        /// <summary>
        /// Lê o arquivo para fazer alterações.
        /// </summary>
        /// <param name="PATH">Caminho do arquivo para leitura.</param>
        /// <returns>Conteúdo do arquivo.</returns>
        public List<string> ReadAllLinesCSV(string PATH){

            List<string> linhas = new List<string>();
            using (StreamReader file = new StreamReader(PATH)){
                string linha;
                while ((linha = file.ReadLine()) != null){
                    linhas.Add(linha);
                }
            }
            return linhas;
        }
        /// <summary>
        /// Altera ou apaga algum conteúdo do arquivo.
        /// </summary>
        /// <param name="PATH">Caminho do arquivo.</param>
        /// <param name="linhas">Linhas do arquivo.</param>
        public void RewriteCSV(string PATH, List<string> linhas){
            using (StreamWriter output = new StreamWriter(PATH)){
                foreach (var item in linhas){
                    output.Write(item + "\n");
                }
            }
        }
    }
}