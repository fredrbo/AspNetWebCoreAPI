namespace SmartSchool.WebAPI.Helpers
{
    public class PageParams
    {
        public const int MaxPageSize = 50;
        public int PgeNumber { get; set; }
        private int pageSize = 10;
        public int PageSize {
            get{ return pageSize;}
            set{ pageSize = (value > MaxPageSize) ? MaxPageSize: value;}
            // pageSize nunca será maios que MaxPage
        }
    }
}