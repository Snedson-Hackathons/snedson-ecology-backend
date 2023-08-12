namespace snedson_ecology_backend.core.Models.Dtos
{
    public record EventNeedDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsChecked { get; set; }
    }
}
