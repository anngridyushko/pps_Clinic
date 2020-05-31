using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Clinic.Entities;
using System.Windows.Forms;

namespace Clinic.Database
{
    public class DBConnector
    {
        public enum Mode
        {
            Doctors,
            Registrars
        }

        private static List<Doctor> RetreiveDoctors(SQLiteCommand command)
        {
            DataTable table = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(table);

            List<Doctor> docs= new List<Doctor>();

            foreach (DataRow row in table.Rows)
            {
                Doctor doc = new Doctor()
                {
                    id = Convert.ToInt32(row["id"]),
                    Name = row["Name"].ToString(),
                    Surname = row["Surname"].ToString(),
                    DateOfBirth = Convert.ToDateTime(row["DateOfBirth"].ToString()),
                    Experience = row["Experience"].ToString(),
                    Specialty = row["Specialty"].ToString(),
                    Email = row["Email"].ToString(),
                    PhoneNumber = row["Phonenumber"].ToString()

                };

                docs.Add(doc);
            }

            return docs;
        }


        private static Doctor RetreiveDoctor(SQLiteCommand command)
        {
            DataTable table = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(table);

            Doctor docs = new Doctor();

            foreach (DataRow row in table.Rows)
            {
                Doctor doc = new Doctor()
                {
                    id = Convert.ToInt32(row["id"]),
                    Name = row["Name"].ToString(),
                    Surname = row["Surname"].ToString(),
                    DateOfBirth = Convert.ToDateTime(row["DateOfBirth"].ToString()),
                    Experience = row["Experience"].ToString(),
                    Specialty = row["Specialty"].ToString(),
                    Email = row["Email"].ToString(),
                    PhoneNumber = row["Phonenumber"].ToString()

                };
                docs = doc;
                
            }

            return docs;
        }

        private static List<Client> RetreiveClients(SQLiteCommand command)
        {
            DataTable table = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(table);

            List<Client> docs = new List<Client>();

            foreach (DataRow row in table.Rows)
            {
                Client cl = new Client()
                {
                    id = Convert.ToInt32(row["id"]),
                    Name = row["Name"].ToString(),
                    Surname = row["Surname"].ToString(),
                    Address = row["Address"].ToString(),
                    Email = row["Email"].ToString(),
                    PhoneNumber = row["Phonenumber"].ToString(),
                    PersonalRelief = Convert.ToInt32(row["PersonalRelief"])
                };

                docs.Add(cl);
            }

            return docs;
        }

        private static Client RetreiveClient(SQLiteCommand command)
        {
            DataTable table = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(table);

            Client docs = new Client();

            foreach (DataRow row in table.Rows)
            {
                Client cl = new Client()
                {
                    id = Convert.ToInt32(row["id"]),
                    Name = row["Name"].ToString(),
                    Surname = row["Surname"].ToString(),
                    Address = row["Address"].ToString(),
                    Email = row["Email"].ToString(),
                    PhoneNumber = row["Phonenumber"].ToString(),
                    PersonalRelief = Convert.ToInt32(row["PersonalRelief"])
                };

                docs = cl;
            }

            return docs;
        }

        private static List<Pet> RetreivePets(SQLiteCommand command)
        {
            DataTable table = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(table);

            List<Pet> docs = new List<Pet>();

            foreach (DataRow row in table.Rows)
            {
                Pet cl = new Pet()
                {
                    id = Convert.ToInt32(row["id"]),
                    Name = row["Name"].ToString(),
                    Type = row["Type"].ToString(),
                    Gender = row["Gender"].ToString(),
                    DateOfBirth = Convert.ToDateTime(row["DateOfBirth"].ToString()),
                    Owner_id = Convert.ToInt32(row["Owner_id"])
                };

                docs.Add(cl);
            }

            return docs;
        }

        private static void ExecuteCommand(SQLiteConnection connection, SQLiteCommand command)
        {
            connection.Open();

            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<Doctor> LoadDoctors()
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "select * from Doctors";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                return RetreiveDoctors(command);
            }
        }
        public static List<Client> LoadClients()
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "select * from Clients";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                return RetreiveClients(command);
            }
        }

        public static List<Pet> LoadPets(string id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "select * from Pets where Owner_id=@id";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                return RetreivePets(command);
            }
        }

        public static Doctor LoadDoctor(string name, string surname)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "select * from Doctors where name=@name, surname=@surname";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("surname", surname);
                return RetreiveDoctor(command);
            }
        }
        public static Client LoadClient(string name, string surname)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "select * from Clients where name=@name, surname=@surname";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("surname", surname);
                return RetreiveClient(command);
            }
        }


        public static void DeleteDoctor(Doctor doctor)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "delete from Doctors where id=@id";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("id", doctor.id);

                ExecuteCommand(connection, command);
                
              
            }
        }

        public static void DeletePet(Pet p)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "delete from Pets where id=@id";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("id", p.id);

                ExecuteCommand(connection, command);


            }
        }


        public static void DeleteClient(Client client)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "delete from Clients where id=@id";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("id", client.id);

                ExecuteCommand(connection, command);


            }
        }

        public static void UpdateDoctor(Doctor doctor, string fieldName, string value)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "update Doctors set " + fieldName + "=" + value + " where id=@id";


                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("id", doctor.id);

                ExecuteCommand(connection, command);


            }
        }

        public static void UpdatePet(Pet p, string fieldName, string value)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "update Pets set " + fieldName + "=" + value + " where id=@id";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("id", p.id);
                ExecuteCommand(connection, command);


            }
        }

        public static void UpdateClient(Client client, string fieldName, string value)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
               
                string query = "update Clients set " + fieldName + "=" + value + " where id=@id";
               // MessageBox.Show(query);
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("id", client.id);

                ExecuteCommand(connection, command);


            }
        }

        public static int ContainsDoctor(Doctor doctor)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "select * from Doctors where Name=@name";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("name", doctor.Name);

                DataTable table = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(table);

                if (table.Rows.Count != 0)
                    return Convert.ToInt32(table.Rows[0]["id"]);
                else
                    return 0;
            }
        }
        public static int ContainsClient(Client client)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "select * from Clients where Name=@name";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("name", client.Name);

                DataTable table = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(table);

                if (table.Rows.Count != 0)
                    return Convert.ToInt32(table.Rows[0]["id"]);
                else
                    return 0;
            }
        }

        public static int InsertDoctor(Doctor doctor)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "insert into Doctors(Name, Surname, DateOfBirth, Email, PhoneNumber, Experience, Specialty) values(@name, @surname," +
                     "@dateofbirth, @email, @phone, @experience, @specialty)";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("name", doctor.Name);
                command.Parameters.AddWithValue("surname", doctor.Surname);
                command.Parameters.AddWithValue("dateofbirth", doctor.DateOfBirth);
                command.Parameters.AddWithValue("email", doctor.Email);
                command.Parameters.AddWithValue("phone", doctor.PhoneNumber);
                command.Parameters.AddWithValue("experience", doctor.Experience);
                command.Parameters.AddWithValue("specialty", doctor.Specialty);

                ExecuteCommand(connection, command);

                query = "select id from Doctors where Name=@name";
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("name", doctor.Name);

                DataTable table = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(table);

                int count = table.Rows.Count;

                if (count == 0)
                    return 0;
                else
                    return Convert.ToInt32(table.Rows[count - 1]["id"]);
            }
        }

        public static int InsertClient(Client client)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "insert into Clients(Name, Surname, Address, Email, PhoneNumber, PersonalRelief) values(@name, @surname," +
                    "@address, @email, @phone, @relief)";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("name", client.Name);
                command.Parameters.AddWithValue("surname", client.Surname);
                command.Parameters.AddWithValue("address", client.Address);
                command.Parameters.AddWithValue("email", client.Email);
                command.Parameters.AddWithValue("phone", client.PhoneNumber);
                command.Parameters.AddWithValue("relief", client.PersonalRelief);

                ExecuteCommand(connection, command);

                query = "select id from Clients where Name=@name";
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("name", client.Name);

                DataTable table = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(table);

                int count = table.Rows.Count;

                if (count == 0)
                    return 0;
                else
                    return Convert.ToInt32(table.Rows[count - 1]["id"]);
            }
        }

        public static int InsertPet(Pet p)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "insert into Pets(Name, Type, DateOfBirth, Gender, Owner_id) values(@name, @type," +
                     "@dateofbirth, @gender, @owner_id)";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("name", p.Name);
                command.Parameters.AddWithValue("type", p.Type);
                command.Parameters.AddWithValue("dateofbirth", p.DateOfBirth);
                command.Parameters.AddWithValue("gender", p.Gender);
                command.Parameters.AddWithValue("owner_id", p.Owner_id);


                ExecuteCommand(connection, command);

                query = "select id from Doctors where Name=@name";
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("name", p.Name);

                DataTable table = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(table);

                int count = table.Rows.Count;

                if (count == 0)
                    return 0;
                else
                    return Convert.ToInt32(table.Rows[count - 1]["id"]);
            }
        }




        public static bool CheckLogin(User user)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "select * from Users where Username=@name";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("name", user.UserName);

                DataTable table = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(table);

                if (table.Rows.Count == 0)
                    return false;
                else
                {
                    if (user.Password != table.Rows[0]["password"].ToString())
                        return false;
                    else
                    {
                        user.id = Convert.ToInt32(table.Rows[0]["id"]);
                        user.TypeOfUser = Convert.ToInt32(table.Rows[0]["TypeOfUser"]);
                        return true;
                    }
                }
            }
        }

        public static int ContainsUsername(User user)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "select * from Users where Username=@name";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("name", user.UserName);

                DataTable table = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(table);

                if (table.Rows.Count != 0)
                    return Convert.ToInt32(table.Rows[0]["id"]);
                else
                    return 0;
            }
        }

        public static void AddUser(User user)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "insert into Users(Name, Username, Password, TypeOfUser) values(@name, @uname, @passw, @type)";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("name", user.Name);
                command.Parameters.AddWithValue("uname", user.UserName);
                command.Parameters.AddWithValue("passw", user.Password);
                command.Parameters.AddWithValue("type", user.TypeOfUser);

                ExecuteCommand(connection, command);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
