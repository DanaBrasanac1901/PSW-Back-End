namespace IntegrationAPI.DTO
{
    public class ReporttDTO
    {
        private string v1;
        private string v2;

        public ReporttDTO(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public string Id { get; set; }
        public string Period { get; set; }
    }
}
