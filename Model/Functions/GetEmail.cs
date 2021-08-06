namespace Model.Functions
{
    public class GetEmail : SqlFunction
    {
        public string Subject { get; set; }
        public string EmailBodyHtml { get; set; }
        public string EmailBodyPlainText { get; set; }
        public bool IsHtml { get; set; } = false;
        public string From { get; set; }
        public string SystemIdentificator { get; set; }
    }
}
