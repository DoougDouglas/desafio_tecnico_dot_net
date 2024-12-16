namespace EclipseWorks.DesafioTecnico.Domain
{
    public class ExclusaoLogica : EntidadeBase
    {
        public ExclusaoLogica()
        {
            isExcluido = false;
        }

        public bool isExcluido { get; set; }
    }
}