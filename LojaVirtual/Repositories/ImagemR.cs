using LojaVirtual.Data;
using LojaVirtual.Models.Produto;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LojaVirtual.Repositories
{
    public class ImagemR
    {
        private readonly DatabaseContext _banco;

        public ImagemR(DatabaseContext banco)
        {
            _banco = banco;
        }

        public static bool MoveImagem(string temp, string destino)
        {
            if (File.Exists(temp))
            {
                if (!File.Exists(destino))
                {
                    File.Move(temp, destino);
                    File.Delete(temp);

                    return true;
                }
            }

            return false;
        }

        public static void RemoveImagem(string caminho)
        {
            if (File.Exists(caminho)) 
                File.Delete(caminho);
        }

        public int Inserir(Imagem imagem)
        {
            _banco.Imagem.Add(imagem);
            return _banco.SaveChanges();
        }

        public int Remover(Imagem imagem)
        {
            _banco.Imagem.Remove(imagem);
            return _banco.SaveChanges();
        }

        public List<Imagem> BuscaLista(uint id)
        {
            return _banco.Imagem.Where(i => i.IdProduto == id).ToList();
        }
    }
}
