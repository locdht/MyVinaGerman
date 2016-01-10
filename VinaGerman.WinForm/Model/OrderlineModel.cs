using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Model
{
    public class OrderlineModel : VinaGerman.Entity.BusinessEntity.OrderlineEntity
    {
        public OrderlineModel() 
        {
            ChildList = new BindingList<LoanModel>();
        }
        public BindingList<LoanModel> ChildList { get; set; }        
    }
}
