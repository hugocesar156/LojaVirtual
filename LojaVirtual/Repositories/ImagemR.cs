using LojaVirtual.Data;
using LojaVirtual.Models.Produto;
using System;
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
            try
            {
                _banco.Imagem.Add(imagem);
                return _banco.SaveChanges();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return 0;
            }
        }

        public int Remover(Imagem imagem)
        {
            try
            {
                _banco.Imagem.Remove(imagem);
                return _banco.SaveChanges();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return 0;
            }
        }

        public List<Imagem> BuscaLista(uint id)
        {
            try
            {
                return _banco.Imagem.Where(i => i.IdProduto == id).ToList();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return new List<Imagem>();
            }
        }
    }
}
