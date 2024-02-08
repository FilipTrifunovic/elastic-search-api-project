namespace elastic_search_api.Application.Documents.Queries.GetDocument
{
    public class DocumentDto
    {
        public string Id { get; set; }
        public double? Score { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
