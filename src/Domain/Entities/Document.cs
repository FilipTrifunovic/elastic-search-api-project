namespace elastic_search_api.Domain.Entities
{
    public class Document
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
    }
}
