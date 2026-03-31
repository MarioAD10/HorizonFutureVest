namespace Application.ViewModels
{
    public class CountryRankingViewModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public double Score { get; set; }  
        public int Position { get; set; }   
    }
}

