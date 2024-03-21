using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BucketList_Domain.Business;

namespace BucketList_Domain.Persistence
{
    internal class PersoonMapper
    {
        //fields
        private string _connectionstring;

        //constructor
        public PersoonMapper(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public List<Persoon> GetPersonenFromDB()
        {
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("Select * from bucketlistdatabase.persoon", conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Persoon> List = new List<Persoon>();
            while (reader.Read())
            {
                Persoon persoon = new Persoon(
                    Convert.ToInt32(reader["idPersoon"]),
                    Convert.ToString(reader["namePersoon"]),
                    Convert.ToString(reader["paswoordPersoon"]));
                List.Add(persoon);

            }
            conn.Close();
            return List;
        }
        //INSERT INTO `bucketlistdatabase`.`persoon` (`naamPersoon`, `paswoordPersoon`) VALUES ('jos', '1234');
        public Persoon addPersoonToDB(string name, string pasWord)
        {
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO bucketlistdatabase.persoon (naamPersoon, paswoordPersoon) VALUES (@name, @pasWord)", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@pasWord", pasWord);
            conn.Open();
            try
            {
                
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                conn.Close() ;
                return null;
            }

            conn.Close();              
            return GetPersoonFromDB(name, pasWord);
        }
        //select * from bucketlistdatabase.persoon where naamPersoon = 'TestNaam' and paswoordPersoon = '1234';

        public Persoon GetPersoonFromDB(string name, string pasWord)
        {
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("Select * from bucketlistdatabase.persoon" +
                " where naamPersoon = @name and paswoordPersoon = @pasWord", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@pasWord", pasWord);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            Persoon result = null;
            while (reader.Read())
            {
                result = new Persoon(
                    Convert.ToInt32(reader["idPersoon"]),
                    Convert.ToString(reader["naamPersoon"]),
                    Convert.ToString(reader["paswoordPersoon"]));
                

            }
            conn.Close();
            return result;
        }
    }
}
