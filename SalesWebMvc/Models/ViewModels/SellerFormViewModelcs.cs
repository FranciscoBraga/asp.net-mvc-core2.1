using System.Collections.Generic;


namespace SalesWebMvc.Models.ViewModels
{
    public class SellerFormViewModelcs
    {
        public Seller  Seller { get; set; }
        public ICollection<Departament> Departaments { get; set; }
    }
}
