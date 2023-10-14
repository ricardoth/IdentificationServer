namespace IdentificationServer.Core.QueryFilters
{
    public class MenuQueryFilter
    {
        public int? IdMenu { get; set; }
        public int? IdApp { get; set;}
        public int? Padre { get; set; }
        public string Nombre { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsPadre { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
