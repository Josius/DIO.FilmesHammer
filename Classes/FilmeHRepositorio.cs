using System;
using System.Collections.Generic;
using DIO.FilmesHammer.Interfaces;

namespace DIO.FilmesHammer
{
    public class FilmeHRepositorio : IRepositorio<FilmesHammer>
    {
        private List<FilmesHammer> listaFilmesHammer = new List<FilmesHammer>();
		public void Atualiza(int id, FilmesHammer objeto)
		{
			listaFilmesHammer[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaFilmesHammer[id].Excluir();
		}

		public void Insere(FilmesHammer objeto)
		{
			listaFilmesHammer.Add(objeto);
		}

		public List<FilmesHammer> Lista()
		{
			return listaFilmesHammer;
		}

		public int ProximoId()
		{
			return listaFilmesHammer.Count;
		}

		public FilmesHammer RetornaPorId(int id)
		{
			return listaFilmesHammer[id];
		}
    }
}