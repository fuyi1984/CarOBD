using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Photos
    {
        public virtual int ID { get; set; }

        public virtual string Name { get; set; }

        public virtual string Des { get; set; }

        public virtual string Src { get; set; }

        public virtual DateTime PublishTime { get; set; }
    }
}
