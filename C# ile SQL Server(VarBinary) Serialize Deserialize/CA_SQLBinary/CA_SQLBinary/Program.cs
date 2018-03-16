using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CA_SQLBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductBinaryEkle();
            ProductBinaryListele();
        }

        public static void ProductBinaryListele()
        {
            SqlConnection conn = new SqlConnection("server=DESKTOP-NDB4SQT;database=BinaryDB; trusted_connection=true;");
            SqlCommand cmd = new SqlCommand("select Parametre from BinaryTable where TabloID = (select max(TabloID) from BinaryTable)", conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Product prd = (Product)ToObject((byte[])dr["Parametre"]);
            };
            conn.Close();
        }

        public static void ProductBinaryEkle()
        {
            SqlConnection conn = new SqlConnection("server=DESKTOP-NDB4SQT;database=BinaryDB; trusted_connection=true;");
            SqlCommand cmd = new SqlCommand("insert BinaryTable (ProjeAdi,Parametre) values (@ProjeAdi,@Parametre)", conn);

            Product prdInsert = new Product
            {
                ID = 1,
                Name = "Serif",
                Description = "Aydin",
                RegisterDate = DateTime.Now
            };

            byte[] deneme = ToByteArray(prdInsert);

            conn.Open();
            cmd.Parameters.AddWithValue("@ProjeAdi", "Deneme");

            SqlParameter param = cmd.Parameters.Add("@Parametre", SqlDbType.VarBinary);
            param.Value = deneme;

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static byte[] ToByteArray(object source)
        {
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, source);
                return stream.ToArray();
            }
        }

        public static object ToObject(byte[] source)
        {
            MemoryStream ms = new MemoryStream(source);
            var formatter = new BinaryFormatter();
            return formatter.Deserialize(ms);
        }
    }

    [Serializable]
    public struct Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}