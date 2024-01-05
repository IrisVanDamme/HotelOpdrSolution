using HotelOpdrSolution.BL.Model;
using HotelOpdrSolution.BL.Repositories;
using HotelOpdrSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelOpdrSolution.DL.Mappers
{
    public class CustomerMapper : ICustomerRepository
    {
        private readonly DataContext _dataContext;

        public CustomerMapper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddCustomer(Customer customer)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(_dataContext.connectionString))
                {
                    string insertCustomerQuery = "INSERT INTO Customer (name, email, phone, street, houseNr, zipcode, city) VALUES (@name, @email, @phone, @street, @houseNr, @zipcode, @city)";
                    connection.Open();
                    // put evenement in evenement table
                    using (SqlCommand insertCustomerCommand = new SqlCommand(insertCustomerQuery, connection))
                    {
                        insertCustomerCommand.Parameters.AddWithValue("@name", customer.Name);
                        insertCustomerCommand.Parameters.AddWithValue("@email", customer.ContactInfoCustomer.Email);
                        insertCustomerCommand.Parameters.AddWithValue("@phone", customer.ContactInfoCustomer.Phone);
                        insertCustomerCommand.Parameters.AddWithValue("@street", customer.ContactInfoCustomer.AddressInfo.Street);
                        insertCustomerCommand.Parameters.AddWithValue("@houseNr", customer.ContactInfoCustomer.AddressInfo.HouseNr);
                        insertCustomerCommand.Parameters.AddWithValue("@zipcode", customer.ContactInfoCustomer.AddressInfo.ZipCode);
                        insertCustomerCommand.Parameters.AddWithValue("@city", customer.ContactInfoCustomer.AddressInfo.City);


                        // Execute the command
                        int rowsAffected1 = insertCustomerCommand.ExecuteNonQuery();

                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // niets doen
            }
        }


        //public List<Customer> GetAllCustomers()
        //{
        //    List<Customer> customers = new List<Customer>();
        //    using (SqlConnection connection = new(_dataContext.connectionString))
        //    {
        //        connection.Open();


        //        SqlCommand command = new("SELECT (id, name, email, phone, street, houseNr, zipcode, city) FROM Customer;", connection);

        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            Console.WriteLine();
        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    int id = (int)reader["id"];
        //                    string naam = reader["name"].ToString();
        //                    string email = reader["email"].ToString();
        //                    string phone = reader["phone"].ToString();
        //                    string street = reader["street"].ToString();
        //                    string houseNr = reader["houseNr"].ToString();
        //                    string zipcode = reader["zipcode"].ToString();
        //                    string city = reader["city"].ToString();

        //                    Address addressCustomer = new Address(street, houseNr, zipcode, city);
        //                    ContactInfo contactInfoCustomer = new ContactInfo(email, phone, addressCustomer);
        //                    Customer customer = new Customer(id, name, contactInfoCustomer);
        //                }
        //            }
        //            else { Console.WriteLine("Geen gebruikers gevonden."); }
        //        }

        //        connection.Close();
        //        return gebruikers;
        //    }
        //}

        //public Gebruiker GetGebruiker(int id)
        //{
        //    using (SqlConnection connection = new(_databeheer.ConnectionString))
        //    {
        //        connection.Open();

        //        string query = "SELECT Naam, Email, TelefoonNr, Postcode, Gemeente, Straat, HuisNr FROM Gebruiker WHERE  Id = @Id";

        //        using (SqlCommand gebruikerCommand = new SqlCommand(query, connection))
        //        {
        //            gebruikerCommand.Parameters.AddWithValue("@Id", id);

        //            try
        //            {
        //                SqlDataReader reader = gebruikerCommand.ExecuteReader();

        //                if (reader.Read())
        //                {
        //                    string naam = reader["Naam"].ToString();
        //                    string email = reader["Email"].ToString();
        //                    string telefoon = reader["TelefoonNr"].ToString();
        //                    string postcode = reader["Postcode"].ToString();
        //                    string gemeente = reader["Gemeente"].ToString();
        //                    string straat = reader["Straat"].ToString();
        //                    string huisNr = reader["HuisNr"].ToString();

        //                    Locatie locatie = new Locatie(postcode, gemeente, straat, huisNr);
        //                    Gebruiker gebruiker = new Gebruiker(id, naam, email, telefoon, locatie);
        //                    return gebruiker;
        //                }
        //                else
        //                {
        //                    return null;
        //                }

        //                reader.Close();
        //            }
        //            catch (Exception ex)
        //            {
        //                // Handle any exceptions that occur during database operations
        //                Console.WriteLine("Error: " + ex.Message);
        //            }
        //        }

        //        connection.Close();
        //        return null;
        //    }
        //}


        public List<CustomerListDTO> GetAllCustomerListDTOs()
        {
            List<CustomerListDTO> customerDTOs = new List<CustomerListDTO>();
            using (SqlConnection connection = new(_dataContext.connectionString))
            {
                connection.Open();


                SqlCommand command = new("select c.id, c.name, c.email, c.street, c.houseNr, c.zipcode, c.city, c.phone, count(m.name) as 'AmountOfMembers' from Customer c join Member m on c.id = m.customerId group by m.customerId, c.id, c.name, c.email, c.street, c.houseNr, c.zipcode, c.city, c.phone;", connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader[0];
                            string name = reader[1].ToString();
                            string email = reader[2].ToString();
                            string street = reader[3].ToString();
                            string houseNr = reader[4].ToString();
                            string zipcode = reader[5].ToString();
                            string city = reader[6].ToString();
                            string phone = reader[7].ToString();
                            int nrOfMembers = (int)reader[8];

                            string address = $"({city} [{zipcode}] - {street} - {houseNr})";
                            CustomerListDTO cDTO = new CustomerListDTO(id, name, email, address, phone, nrOfMembers);
                            customerDTOs.Add(cDTO);
                        }
                    }
                    else { Console.WriteLine("Geen klanten gevonden."); }
                }

                connection.Close();
                return customerDTOs;
            }
        }







        public Customer GetCustomer(int id)
        {
            using (SqlConnection connection1 = new(_dataContext.connectionString))
            using (SqlConnection connection2 = new(_dataContext.connectionString))
            {
                connection1.Open();



                // get members  ALGEMEEN
                // er kunnen members zijn die niet deelnemen aan een activiteit
                Dictionary<string, Member> members = new Dictionary<string, Member>();
                SqlCommand memberCommand = new("select name, birthday from Member where customerId = @Id", connection1);
                memberCommand.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader memberReader = memberCommand.ExecuteReader())
                {


                    if (memberReader.HasRows)
                    {
                        while (memberReader.Read())
                        {
                            string name = memberReader["name"].ToString();
                            DateOnly birthday = DateOnly.FromDateTime(DateTime.Parse(memberReader["birthday"].ToString()));


                            Member member = new Member(name, birthday);
                            members.Add(name, member);
                        }

                    }
                    else { Console.WriteLine("Geen klanten gevonden."); }
                }




                // get registrations

                List<Registration> registrations = new List<Registration>();

                SqlCommand registrationCommand = new("select id, activityId, memberName from Registration where customerId = @Id", connection1);
                registrationCommand.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader registrationReader = registrationCommand.ExecuteReader())
                {
                    if (registrationReader.HasRows)
                    {
                        connection2.Open();
                        while (registrationReader.Read())
                        {
                            int registrationId = (int)registrationReader["id"];
                            int activityId = (int)registrationReader["activityId"];
                            string memberName = registrationReader["memberName"].ToString();

                            // get members in registration
                            Dictionary<string, Member> membersForRegistration = new Dictionary<string, Member>();

                            membersForRegistration.Add(memberName, members[memberName]);

                            // get activities 
                            Dictionary<int, Activity> activities = new Dictionary<int, Activity>();

                            SqlCommand activityCommand = new("select id, fixture, nrOfPlaces, adultPrice, childPrice, discount, adultAge, duration, location, description, name, organizerId from Activity where id = @Id", connection2);
                            activityCommand.Parameters.AddWithValue("@Id", activityId);

                            using (SqlDataReader activityReader = activityCommand.ExecuteReader())
                            {

                                if (activityReader.HasRows)
                                {
                                    while (activityReader.Read())
                                    {
                                        DateTime fixture = DateTime.Parse(activityReader["fixture"].ToString());
                                        int nrOfPlaces = (int)activityReader["nrOfPlaces"];
                                        decimal adultPrice = (decimal)activityReader["adultPrice"];
                                        decimal childPrice = (decimal)activityReader["childPrice"];
                                        int discount = (int)activityReader["discount"];
                                        int adultAge = (int)activityReader["adultAge"];
                                        int duration = (int)activityReader["duration"];
                                        string location = activityReader["location"].ToString();
                                        string descriptionStr = activityReader["description"].ToString();
                                        string activityName = activityReader["name"].ToString();
                                        int organizerId = (int)activityReader["organizerId"];

                                        PriceInfo priceInfo = new PriceInfo(adultPrice, childPrice, discount, adultAge);
                                        Description description = new Description(duration, location, descriptionStr, activityName);
                                        Activity activity = new Activity(activityId, fixture, nrOfPlaces, description, priceInfo);

                                        activities.Add(activityId, activity);

                                    }

                                }
                                else { Console.WriteLine("Geen activiteiten gevonden."); }
                            }

                            Registration registration = new Registration(registrationId, membersForRegistration.Values.ToList(), activities[activityId]);
                            registrations.Add(registration);
                        }

                    }
                    else { Console.WriteLine("Geen registraties gevonden."); }
                }















                





                // get customer
                string customerQuery = "SELECT name, email, phone, street, houseNr, zipcode, city FROM Customer WHERE  id = @Id";

                using (SqlCommand customerCommand = new SqlCommand(customerQuery, connection1))
                {
                    customerCommand.Parameters.AddWithValue("@Id", id);

                    try
                    {
                        SqlDataReader reader = customerCommand.ExecuteReader();

                        if (reader.Read())
                        {
                            string name = reader["name"].ToString();
                            string email = reader["email"].ToString();
                            string phone = reader["phone"].ToString();
                            string street = reader["street"].ToString();
                            string houseNr = reader["houseNr"].ToString();
                            string zipcode = reader["zipcode"].ToString();
                            string city = reader["city"].ToString();

                            Address address = new Address(street, houseNr, zipcode, city);
                            ContactInfo contactInfo = new ContactInfo(email, phone, address);
                            return new Customer(id, name, members.Values.ToList(), registrations, contactInfo);
                        }
                        else
                        {
                            return null;
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that occur during database operations
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                return null;
            }

        }
    }
}
