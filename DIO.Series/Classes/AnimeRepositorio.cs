using System;
using System.Collections.Generic;
using System.Text;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class AnimeRepositorio : IRepositorio<Anime>
    {
        private List<Anime> listaAnime = new List<Anime>();
        public void Atualiza(int id, Anime objetoAnime)
        {
            listaAnime[id] = objetoAnime;
        }

        public void Exclui(int id)
        {
            listaAnime[id].Excluir();
        }

        public void Insere(Anime objetoAnime)
        {
            listaAnime.Add(objetoAnime);
        }

        public List<Anime> Lista()
        {
            return listaAnime;
        }

        public int ProximoId()
        {
            return listaAnime.Count;
        }

        public Anime RetornaPorId(int id)
        {
            return listaAnime[id];
        }
    }
}
