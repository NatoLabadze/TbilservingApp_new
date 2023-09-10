namespace Core.Domain.Model
{
    public class Document
    {
        public int Id { get; set; }
        public string ObjectName { get; set; }
        public string FilePath { get; set; }

        public Statement Statement { get; set; }
        public int StatementId { get; set; }


       
    }
}
