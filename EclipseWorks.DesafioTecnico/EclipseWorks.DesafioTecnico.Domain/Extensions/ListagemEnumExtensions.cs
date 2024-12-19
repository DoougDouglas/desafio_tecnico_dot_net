using EclipseWorks.DesafioTecnico.Domain.Tarefas.Enum;
using System.ComponentModel;
using System.Reflection;

namespace EclipseWorks.DesafioTecnico.Domain.Extensions
{
    public static class ListagemEnumExtensions
    {
        public static List<EnumViewModel> LitarPrioridadeTarefaEnum()
        {
            return Enum.GetValues(typeof(PrioridadeTarefaEnum))
               .Cast<PrioridadeTarefaEnum>()
               .Select(e => new EnumViewModel
               {
                   Valor = (int)e,
                   Nome = e.GetDescription()
               }).ToList();
        }

        public static List<EnumViewModel> LitarStatusTarefaEnum()
        {
            return Enum.GetValues(typeof(StatusTarefaEnum))
               .Cast<StatusTarefaEnum>()
               .Select(e => new EnumViewModel
               {
                   Valor = (int)e,
                   Nome = e.GetDescription()
               }).ToList();
        }

        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attribute = fieldInfo?.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? value.ToString();
        }

        public class EnumViewModel
        {
            public int Valor { get; set; }
            public string Nome { get; set; }
        }
    }


}
