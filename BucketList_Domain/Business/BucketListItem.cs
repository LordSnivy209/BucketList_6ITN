using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketList_Domain.Business
{
    public class BucketListItem
    {
        //fields
        protected int _idBucketListItem;
        protected string _nameBucketListItem;
        protected string _descriptionBucketListItem;

        //properties
        public int IdBucketListItem
        {
            get { return _idBucketListItem; } set { _idBucketListItem = value; }
        }

        public string NameBucketListItem
        { get { return _nameBucketListItem; }
            set { _nameBucketListItem = value; } }

        public string DescriptionBucketListItem
        {   get { return _descriptionBucketListItem; }
            set { _descriptionBucketListItem = value; }
        }

        //constructor
        public BucketListItem(int id, string name, string description)
        {
            _idBucketListItem = id;
            _nameBucketListItem = name;
            _descriptionBucketListItem = description;
        }

        public BucketListItem(string name, string description)
        {
            _idBucketListItem = 0;
            _nameBucketListItem = name;
            _descriptionBucketListItem = description;
        }
        //methods
        public override string ToString()
        {
            return _nameBucketListItem + ": " + _descriptionBucketListItem;
        }
    }
}
