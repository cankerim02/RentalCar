﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColourId { get; set; }
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Descriptions { get; set; }
    }
}
