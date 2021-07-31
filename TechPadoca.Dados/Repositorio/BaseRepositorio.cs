using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPadoca.Dominio.Interface;

namespace TechPadoca.Dados.Repositorio
{
    public class BaseRepositorio<T> where T: class, IEntity
    {
        protected readonly Contexto contexto;

        public BaseRepositorio()
        {
            contexto = new Contexto();
        }

        public virtual bool Incluir(T entity)
        {
            try
            {
                contexto.Set<T>().Add(entity);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                // criar um log do erro log.salvar(e.Message);                
                return false;
            }

        }

        public virtual bool Alterar(T entity)
        {
            contexto.Set<T>().Update(entity);
            contexto.SaveChanges();
            return true;
        }

        public T SelecionarPorId(int id)
        {
            return contexto.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public virtual List<T> SelecionarTudo()
        {
            return contexto.Set<T>().ToList();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
