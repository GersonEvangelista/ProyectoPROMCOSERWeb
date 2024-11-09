namespace PROMCOSER_API___Rol__Ubigeo.Core.DTO
{
    public class UbigeoDTO
    {
        public int IdUbigeo { get; set; }

        public string? Departamento {  get; set; }
        public string? Provincia { get; set; }
        public string? Distrito { get; set; }
    }
    public class UbigeoListDTO
    {
        public string? Departamento { get; set; }
        public string? Provincia { get; set; }
        public string? Distrito { get; set; }
    }


}
