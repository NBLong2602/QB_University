using System.Data;

namespace QB_University.Models
{
    public class PagingModel 
    {
        public int currentPage {  get; set; }
        public int countPages { get; set; }
        public Func<int?, string> generateUrl { get; set;}
        public DataTable dt { get; set; }
    }
}
