﻿using System;
using System.Collections.Generic;

namespace FunkyCode.AdventureWorks.EntityFramework.Model
{
    public partial class ContactType
    {
        public ContactType()
        {
            BusinessEntityContact = new HashSet<BusinessEntityContact>();
        }

        public int ContactTypeId { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<BusinessEntityContact> BusinessEntityContact { get; set; }
    }
}
