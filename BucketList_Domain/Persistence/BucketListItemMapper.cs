using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BucketList_Domain.Business;
using MySql.Data.MySqlClient;

namespace BucketList_Domain.Persistence
{
    internal class BucketListItemMapper
    {
        //fields
        private string _connectionstring;

        //constructor
        public BucketListItemMapper(string connectionstring)
        {
            _connectionstring = connectionstring;
        }
        public List<BucketListItemPersonal> GetBLItemsFromDB(int idPersoon)
        {
            //select bucketlistitem.* from bucketlistdatabase.bucketlistitem inner join bucketlistdatabase.persoonlijkebucketlist on bucketlistitem.idBucketListItem=persoonlijkebucketlist.fkBucketListItem where fkPersoon = 1;
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("select bucketlistitem.*, persoonlijkebucketlist.isGedaan from bucketlistdatabase.bucketlistitem " +
                "inner join bucketlistdatabase.persoonlijkebucketlist " +
                "on bucketlistitem.idBucketListItem=" +
                "persoonlijkebucketlist.fkBucketListItem where fkPersoon = @fkPersoon", conn);
            cmd.Parameters.AddWithValue("@fkPersoon", idPersoon);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            List<BucketListItemPersonal> List = new List<BucketListItemPersonal>();
            while (reader.Read())
            {
                BucketListItemPersonal persoon = new BucketListItemPersonal(
                    Convert.ToInt32(reader["idBucketListItem"]),
                    Convert.ToString(reader["naamBucketListItem"]),
                    Convert.ToString(reader["omschrijvingBucketListItem"]),
                    Convert.ToBoolean(reader["isGedaan"]));
                    
                List.Add(persoon);

            }
            conn.Close();
            return List;
        }
        public List<BucketListItem> GetBLItemsFromDB()
        {
            //select bucketlistitem.* from bucketlistdatabase.bucketlistitem inner join bucketlistdatabase.persoonlijkebucketlist on bucketlistitem.idBucketListItem=persoonlijkebucketlist.fkBucketListItem where fkPersoon = 1;
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("select bucketlistitem.* from bucketlistdatabase.bucketlistitem", conn); 

            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            List<BucketListItem> List = new List<BucketListItem>();
            while (reader.Read())
            {
                BucketListItem persoon = new BucketListItem(
                    Convert.ToInt32(reader["idBucketListItem"]),
                    Convert.ToString(reader["naamBucketListItem"]),
                    Convert.ToString(reader["omschrijvingBucketListItem"]));
                List.Add(persoon);

            }
            conn.Close();
            return List;
        }

        public BucketListItem addItemToDB(string name, string description)
        {
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO bucketlistdatabase.bucketlistitem (naamBucketListItem, omschrijvingBucketListItem) VALUES (@name, @description)", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@description", description);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

                // After successfully adding the item to the database, return the corresponding BucketListItem object
                int lastInsertedId = (int)cmd.LastInsertedId; // Assuming idBucketListItem is an auto-increment primary key
                BucketListItem newItem = new BucketListItem(lastInsertedId, name, description);
                return newItem;
            }
            catch (MySqlException ex)
            {
                // Log the exception
                Console.WriteLine("Error adding item to database: " + ex.Message);

                // Handle exceptions if necessary
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
