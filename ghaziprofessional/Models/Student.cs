using System;
using System.Text;
using System.Collections.Generic;


namespace ghaziprofessional {
    
    public class Student {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual int? Phone { get; set; }
    }
}
