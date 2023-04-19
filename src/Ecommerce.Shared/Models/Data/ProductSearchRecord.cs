using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Shared.Models.Data
{
    public class ProductSearchRecord
    {
        public List<ProductsRecord> Products { get; set; } = new();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
