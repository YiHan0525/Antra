using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Exercise3
{
    class Program
    {
        public class Account
        {
            private string _ID, _Username, _Password, _Email, _Name;
            private DateTime _Recent_Login, _Creation_Date;
            private object connStr;

            public string ID
            {
                get { return _ID; }
                set { _ID = value; }
            }
            public string Username
            {
                get { return _Username; }
                set { _Username = value; }
            }
            public string Password
            {
                get { return _Password; }
                set { _Password = value; }
            }
            public string Email
            {
                get { return _Email; }
                set { _Email = value; }
            }
            public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }
            public DateTime Recent_Login
            {
                get { return _Recent_Login; }
                set { _Recent_Login = value; }
            }
            public DateTime Creation_Date
            {
                get { return _Creation_Date; }
                set { _Creation_Date = value; }
            }

            public static object Hasher { get; private set; }

            public Account(string pID, string pUsername, DateTime pRecent_Login, DateTime pCreation_date, DateTime pDoB, string pBio, string pEmail, string pName, string pPhone, string pProfilePictureUrl)
            {
                _ID = pID;
                _Username = pUsername;
                _Recent_Login = pRecent_Login;
                _Creation_Date = pCreation_date;
                _Email = pEmail;
                _Name = pName;
            }
            public Account(string pUsername, DateTime pRecent_Login, DateTime pCreation_date, DateTime pDoB, string pBio, string pEmail, string pName, string pPhone, string pProfilePictureUrl)
            {
                _Username = pUsername;
                _Recent_Login = pRecent_Login;
                _Creation_Date = pCreation_date;
                _Email = pEmail;
                _Name = pName;
            }
            public Account(string pUsername, string pPassword, string pEmail, string pName)
            {
                _Username = pUsername;
                _Password = pPassword;
                _Email = pEmail;
                _Name = pName;
            }
            public Account(string pUsername)
            {
                _Username = pUsername;
            }
            public Account()
            {
                //
                // TODO: Add constructor logic here
                //
            }



            /// <summary>
            /// Inserts a new account into the database
            /// </summary>
            /// <returns>Returns 1 if successful</returns>

           

            /// <summary>
            /// Updates the account data-types in the database
            /// Available for update: Name, Phone, DoB, ProfilepictureUrl
            /// </summary>
            /// <returns>Returns 1 if successful</returns>
            public int Update()
            {
                int output = 0;
                string queryStr = "UPDATE Accounts SET Name=@Name, Phone=@Phone, DoB=@DoB, ProfilePictureUrl=@ProfilePictureUrl WHERE Username=@Username";

                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.Parameters.AddWithValue("@Name", Name);
                        output = cmd.ExecuteNonQuery();
                    }
                }
                return output;
            }


            /// <summary>
            /// Updates the recent login of the user to the current time and date now
            /// </summary>
            /// <returns>Returns 1 if successful</returns>
            public int UpdateRecentLogin(string pUsername)
            {
                string queryStr = "UPDATE Accounts SET Recent_Login = @Recent_Login WHERE Username = @Username";
                int output = 0;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", pUsername.ToLower());
                        cmd.Parameters.AddWithValue("@Recent_Login", DateTime.Now);
                        output = cmd.ExecuteNonQuery();
                    }
                }
                return output;
            }


            /// <summary>
            /// Updates the isEmailConfirmed data-type in the database
            /// </summary>
            /// <param name="pEmail"></param>
            /// <returns>Returns 1 if successful</returns>
            public static int UpdateEmailValid(string pEmail)
            {
                int output = 0;
                string queryStr = "UPDATE Accounts SET isEmailConfirmed = 1 WHERE Email = @Email";

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", pEmail);
                        output = cmd.ExecuteNonQuery();
                    }
                }
                return output;
            }


            /// <summary>
            /// Updates the profile picture data-type in the database
            /// </summary>
            /// <returns>Returns 1 if successful</returns>
            public int UpdateProfilePicture()
            {
                string queryStr = "UPDATE Accounts SET ProfilePictureUrl = @ProfilePictureUrl WHERE Username = @Username";
                int output = 0;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.Parameters.AddWithValue("@ProfilePictureUrl", ProfilePictureUrl);
                        output = cmd.ExecuteNonQuery();
                    }
                }
                return output;
            }


            /// <summary>
            /// Updates bio data-type in the database
            /// Does not have a return because it is not needed**
            /// </summary>
            public static void UpdateBio(string pUsername, string pBio)
            {
                string queryStr = "UPDATE Accounts SET Bio=@Bio WHERE Username=@Username";

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", pUsername);
                        cmd.ExecuteNonQuery();
                    }
                }
            }


            /// <summary>
            /// Deletes the account logically through boolean of the datatype
            /// Does not have a return value
            /// </summary>
            public static void UpdateDelete(string pUsername, int command)
            {
                string queryStr = "UPDATE Accounts SET isDeleted=@command WHERE Username=@Username";

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", pUsername);
                        cmd.Parameters.AddWithValue("@command", command.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
            }


            /// <summary>
            /// Updates the account password if the old password entered is validated
            /// </summary>
            /// <returns>
            /// Returns 1 if successful
            /// </returns>
            public int UpdatePassword(string pUsername, string pOldPassword, string pNewPassword)
            {
                int output = 0;
                string currentPassword = "";

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT Password FROM Accounts WHERE Username=@Username", conn))
                    {

                        cmd.Parameters.AddWithValue("@Username", pUsername);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                currentPassword = reader["Password"].ToString();
                            }
                        }
                    }
                }

                if (Hasher.CheckHash(pOldPassword, currentPassword)) // Checks old hash with current hash
                {
                    output = ResetPassword(pUsername, pNewPassword);
                }

                return output;
            }


            /// <summary>
            /// Updates password the account
            /// </summary>
            /// <returns>Returns 1 if successful</returns>
            public int ResetPassword(string pUsername, string pNewPassword)
            {
                int output = 0;
                string queryStr = "UPDATE Accounts SET Password=@Password WHERE Username=@Username";

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", pUsername);
                        output = cmd.ExecuteNonQuery();
                    }
                }
                return output;
            }


            /// <summary>
            /// Checks email data-type from the database
            /// </summary>
            /// <returns>Returns the username of the account if the email exists
            /// Returns "" if the username does not exist</returns>
            public string CheckEmail(string pEmail)
            {
                string output = "";
                string queryStr = "SELECT Username FROM Accounts WHERE Email=@Email";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", pEmail);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                output = reader["Username"].ToString();
                            }
                        }
                    }

                }
                return output;
            }


            /// <summary>
            /// Checks the signing up portion of the website
            /// Validates if the username and email is available to be used
            /// </summary>
            /// <returns>
            /// Returns 1 if username is currently being used
            /// Returns 2 if the email is currently being used
            /// Returns 0 if there is no variables being used
            /// </returns>
            public int CheckSignUp()
            {
                int output = 0;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Accounts WHERE Username = @Username", conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", Username.ToLower());
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return output = 1;
                            }

                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Accounts WHERE Email = @Email", conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", Email.ToLower());
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return output = 2;
                            }

                        }
                    }
                }
                return output;
            }


            /// <summary>
            /// Checks if isEmailConfirmed data-type in the database
            /// </summary>
            /// <returns>Returns the boolean of the datatype</returns>
            public bool CheckEmailValid()
            {
                bool output = false;
                string queryStr = "SELECT isEmailConfirmed FROM Accounts WHERE Username=@Username";

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", Username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    output = Convert.ToBoolean(reader["isEmailConfirmed"]);
                                }
                            }
                        }
                    }
                }
                return output;
            }


            /// <summary>
            /// Checks with the database the Username and the Password
            /// </summary>
            /// <returns>
            /// Returns 0 if the username does not exist or if the password for the username is incorrect
            /// Returns 1 if both the username and the password related to it is validated
            /// </returns>
            public static int CheckAccount(string pUsername, string pPassword)
            {
                int output = 0;

                string queryStr = "SELECT Username, Password FROM Accounts WHERE Username = @Username";

                // Opening SQL connection
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", pUsername.ToLower());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                        }
                    }
                }

                return output;
            }


            /// <summary>
            /// Checks the data-type isDeleted in the databse
            /// </summary>
            /// <returns>
            /// Returns the boolean in the database
            /// </returns>
            public static bool CheckDeleted(string pUsername)
            {
                bool output = false;
                string queryStr = "SELECT isDeleted FROM Accounts WHERE Username=@Username";

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", pUsername);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    output = Convert.ToBoolean(reader["isDeleted"]);
                                }
                            }
                        }
                    }
                }
                return output;
            }
        }
    }
}
