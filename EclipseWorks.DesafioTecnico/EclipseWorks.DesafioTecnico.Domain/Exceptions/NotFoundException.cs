using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseWorks.DesafioTecnico.Domain.Exceptions
{
    public class NotFoundException(string message) : Exception(message)
    {
        public static void ThrowIfNull(object obj, string message = "Não foi possivel localizar o item solicitado.")
        {
            if (obj is null)
            {
                Throw(message);
            }
        }

        public static void LancarExcecaoSeNullOuVazio<T>(IEnumerable<T> collection, string message = "Não foi possível localizar os itens solicitados.")
        {
            if (collection is null || !collection.Any())
            {
                Throw(message);
            }
        }

        private static void Throw(string message) => throw new NotFoundException(message);
    }
}
