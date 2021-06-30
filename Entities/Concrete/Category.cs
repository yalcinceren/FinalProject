﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category:IEntity

    {
        public int CategoryId { get; set; }

         
        //public string CategoryTime { get; set; }

        public string CategoryName { get; set; }
        public string Description { get; set; }
       

    }
}
