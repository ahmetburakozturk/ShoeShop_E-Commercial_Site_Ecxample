using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Entities.Abstract;

namespace ShoeShop.Entities.Concrete
{
    public class Stock : IEntity
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Size { get; set; }
        public int StockNumber { get; set; }
        public Product Product { get; set; }
    }
}
