using System;
using System.Collections.Generic;

namespace Receipe.Data
{
    public class Receipe
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TimeSpan PrepareTime { get; set; }

        //Properties
        public bool? Healthy { get; set; }
        public bool? Delicious { get; set; }

        public virtual ICollection<Requirement> Requirements { get; set; }
    }

    public class Requirement {
        public int Id { get; set; }

        public int ReceipeId { get; set; }
        public virtual Receipe Receipe { get; set; }

        public int ResourceId { get; set; }
        public virtual Resource Resource { get; set; }


        //Properties
        public VolumeType VolumeType { get; set; }
        public int Quantity { get; set; }

        public bool? Optional { get; set; }
    }

    public enum VolumeType {
        Ones = 0,
        Litres = 1,
        WeightGramm = 2
    }

    public class Resource {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
