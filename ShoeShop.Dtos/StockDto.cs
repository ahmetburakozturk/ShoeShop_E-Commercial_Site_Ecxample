using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Dtos
{
    public class StockDto
    {
        public int StockID { get; set; }
        public string SizeName { get; set; }
    }
}
