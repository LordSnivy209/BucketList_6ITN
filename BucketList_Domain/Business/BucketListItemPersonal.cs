using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketList_Domain.Business
{
    public class BucketListItemPersonal:BucketListItem
    {
        //fields
        private bool _isDone;

        //properties
        public bool IsDone { get { return _isDone; } }

        //constructor(s)
        public BucketListItemPersonal(int id, string name, string description, bool isDone):base(id,name,description) 
        {
            _isDone = isDone;
        }
        public BucketListItemPersonal(string name, string description, bool isDone) : base(name, description)
        {
            _isDone = isDone;
        }
        public override string ToString()
        {
            if (_isDone)
                return base.ToString() + " already done";
            else
                return base.ToString() + " yet to be done";
        }
    }
}
