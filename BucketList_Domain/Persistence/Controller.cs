using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BucketList_Domain.Business;

namespace BucketList_Domain.Persistence
{
    internal class Controller
    {
        private string _connectionsString;

        public Controller(string connString) 
        {
            _connectionsString = connString;
        }
        public List<Persoon> getPersonen()
        {
            PersoonMapper mapper = new PersoonMapper(_connectionsString);
            return mapper.GetPersonenFromDB();
        }
        public Persoon getPersoon(string name, string pasWord)
        {
            PersoonMapper mapper = new PersoonMapper(_connectionsString);
            return mapper.GetPersoonFromDB(name, pasWord);
        }
        public Persoon addPersoon(string name, string pasWord)
        {
            PersoonMapper mapper = new PersoonMapper(_connectionsString);
            return mapper.addPersoonToDB(name, pasWord);
        }

        public List<BucketListItemPersonal> getBucketListItems(int idPersoon)
        {
            BucketListItemMapper mapper = new BucketListItemMapper(_connectionsString);
            return mapper.GetBLItemsFromDB(idPersoon);
        }
        public List<BucketListItem> getAllBucketListItems()
        {
            BucketListItemMapper mapper = new BucketListItemMapper(_connectionsString);
            return mapper.GetBLItemsFromDB();
        }
        public void setAsDone(int fkPersoon, int fkItem)
        {
            PersoonlijkeBucketListMapper mapper = new PersoonlijkeBucketListMapper(_connectionsString);
            mapper.setAsDoneInDB(fkPersoon, fkItem);
        }
        public BucketListItem addItemToDB(string name, string description)
        {
            BucketListItemMapper mapper = new BucketListItemMapper(_connectionsString);
            return mapper.addItemToDB(name, description);
        }
        
        public void addFromGeneralList(int fkPersoon, int fkItem)
        {
            PersoonlijkeBucketListMapper mapper = new PersoonlijkeBucketListMapper(_connectionsString);
            mapper.addFromGeneralList(fkPersoon, fkItem);
        }
    }
}
