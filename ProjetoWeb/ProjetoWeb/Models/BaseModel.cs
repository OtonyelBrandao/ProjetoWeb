using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ProjetoWeb.Models
{
    [DataContract]
    public class BaseModel : IComparable
    {
        [DataMember]
        public int ID { get; set; }

        public int CompareTo(object obj)
        {
            if (!(obj is BaseModel outro)) return 1;

            return ID.CompareTo(outro.ID);
        }

        public override bool Equals(object obj)
        {
            return obj is BaseModel model &&
                   ID == model.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }
    }
}
