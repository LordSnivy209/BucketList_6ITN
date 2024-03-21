using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketList_Domain.Business
{
    public class Persoon
    {
        private int _idPersoon;
        public int IdPersoon 
        { 
            get { return _idPersoon; } 
            set { _idPersoon = value; }
        }
        
        private string _naamPersoon;

        public string NaamPersoon
        {
            get { return _naamPersoon; }
            set { _naamPersoon = value; }
        }

        private string _paswoordPersoon;

        public string PaswoordPersoon
        {
            get { return _paswoordPersoon; }
            set { _paswoordPersoon = value; }
        }

        //constructors (1 met id en 1 zonder)

        public Persoon(int id, string naam, string paswoord)
        {
            _idPersoon = id;
            _naamPersoon = naam;
            _paswoordPersoon = paswoord;
        }

        public Persoon(string naam, string paswoord)
        {
            _idPersoon = 0;
            _naamPersoon = naam;
            _paswoordPersoon = paswoord;
        }

        //methods
        public override string ToString()
        {
            return _naamPersoon;
        }
    }
}
