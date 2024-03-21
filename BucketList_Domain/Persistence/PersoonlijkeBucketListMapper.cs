using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BucketList_Domain.Persistence
{
    internal class PersoonlijkeBucketListMapper
    {
        //fields
        private string _connectionString;

        //constructor
        public PersoonlijkeBucketListMapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        //UPDATE `bucketlistdatabase`.`persoonlijkebucketlist` SET `isGedaan` = '1' WHERE (`fkPersoon` = '1') and (`fkBucketListItem` = '1');
        public void setAsDoneInDB(int fkPersoon, int fkItem)
        {

            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("UPDATE bucketlistdatabase.persoonlijkebucketlist SET isGedaan = '1' WHERE (fkPersoon = @fkpers) and (fkBucketListItem = @fkIt)", conn);

            cmd.Parameters.AddWithValue("@fkpers", fkPersoon);
            cmd.Parameters.AddWithValue("@fkIt", fkItem);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void addFromGeneralList(int fkPersoon, int fkItem)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            //INSERT INTO bucketlistdatabase.persoonlijkebucketlist (fkPersoon, fkBucketListItem) VALUES (@fkpers, @fkIt)

            MySqlCommand cmd = new MySqlCommand("INSERT INTO bucketlistdatabase.persoonlijkebucketlist (fkPersoon, fkBucketListItem) VALUES (@fkpers, @fkIt)", conn);

            cmd.Parameters.AddWithValue("@fkpers", fkPersoon);
            cmd.Parameters.AddWithValue("@fkIt", fkItem);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
