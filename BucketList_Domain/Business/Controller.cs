using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BucketList_Domain.Persistence;

namespace BucketList_Domain.Business
{
    public class Controller
    {
        //fields
        private Persistence.Controller _persCon;
        private string _connectionString;
        private Persoon _loggedInUser;
        

        //eigenschap
        public Persoon LoggedInUser { get { return _loggedInUser; } }

        //constructor
        public Controller()
        {
            _connectionString = "server=localhost; user id=root; password=1234;database=bucketlistdatabase";
            _persCon = new Persistence.Controller(_connectionString);
            _loggedInUser = null;
        }

        //this method should not keep existing, it's purely for demonstrating purposes

        private List<Persoon> getPersonen()
        {
            return _persCon.getPersonen();
        }

        //methods
        public bool Login(string name, string pasWord)
        {
            _loggedInUser =  _persCon.getPersoon(name, pasWord);
            if (_loggedInUser == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Register(string name, string pasWord)
        {
            if(_persCon.addPersoon(name, pasWord) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<BucketListItemPersonal> getPersonalItems()
        {
            if (_loggedInUser == null)
            {
                return null;
            }
            else
            {
                return _persCon.getBucketListItems(_loggedInUser.IdPersoon);
            }
            
        }
        public List<BucketListItem> getItems()
        {
            return _persCon.getAllBucketListItems();
        }
        public void setAsCheckedInPL(int index)
        {
            int fkPersoon = _loggedInUser.IdPersoon;
            int fkBucketlistItem = _persCon.getBucketListItems(_loggedInUser.IdPersoon)[index].IdBucketListItem;
            _persCon.setAsDone(fkPersoon, fkBucketlistItem);
        }
        public bool addItemToDB(string name, string description)
        {
            if (_persCon.addItemToDB(name, description) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void addFromGeneralList(int index)
        {
            int fkPersoon = _loggedInUser.IdPersoon;
            int fkItem = _persCon.getAllBucketListItems()[index].IdBucketListItem;
            _persCon.addFromGeneralList(fkPersoon, fkItem);
        }


    }
}
