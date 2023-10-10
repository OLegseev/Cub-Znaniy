using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Авторассылка
{
    internal class CheckBd
    {
        public class Check
        {
            string connstring = MainWindow.connstringmain1;
            string connstringDog = MainWindow.connstringmainDog;
          
            public class BdGoup
            {
                public string IdGroup { get; set; }
                public string Name { get; set; }
                public string Duration { get; set; }
                public string NumbeMounth { get; set; }
            }
            public List<BdGoup> groupdata = new List<BdGoup>();
            public List<BdGoup> checkmygroup = new List<BdGoup>();  
            public class BdDog
            {
                public string IdAgree { get; set; }
                public string IdChild { get; set; }
                public string DateStart { get; set; }
                public string DateEnd { get; set; }
                public string IdParent { get; set; }
                public string IdGenderChild { get; set; }
                public string FioChild { get; set; }
                public string BirthdayChild { get; set; }
                public string PhoneChild { get; set; }
                public string EmailChild { get; set; }
                public string IdGenderPar { get; set; }
                public string FioPar { get; set; }
                public string BirthdayPar { get; set; }
                public string PhonePar { get; set; }
                public string EmailPar { get; set; }
            }
            public List<BdDog> fulldata = new List<BdDog>();
            public List<BdDog> JustDog = new List<BdDog>();
            public List<BdDog> checkmybd = new List<BdDog>();

            public void Fulling()
            {

                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = connstringDog;
                SqlCommand sqlCmd = new SqlCommand();
                try
                {

                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = @"select Agreement.ID_Agreement,Agreement.ID_Child,Agreement.Date_Of_Conclusion,Agreement.Date_End_Of_Action,[Child].ID_Parent,[Child].[ID_Gender],[Child].[Last_Name],[Child].[First_Name] ,[Child].[Middle_Name],[Child].[Date_Birthday],[Child].[Number_Phone],[Child].[Email] , Parent.[ID_Gender], Parent.[Last_Name], Parent.[First_Name] , Parent.[Middle_Name],Parent.[Date_Birtday], Parent.[Number_Phone], Parent.[Email] from Agreement join [Child] on Agreement.ID_Child = [Child].ID_Child join Parent on Child.ID_Parent = Parent.ID_Parent";

                    sqlCmd.Connection = myConnection;
                    myConnection.Open();
                    //sqlCmd.ExecuteNonQuery();
                    SqlDataReader dr = sqlCmd.ExecuteReader();


                    while (dr.Read())
                    {
                        JustDog.Add(new BdDog { IdAgree = Convert.ToString(dr[0]), DateStart = Convert.ToString(dr[2]), DateEnd = Convert.ToString(dr[3]), });
                        fulldata.Add(new BdDog
                        {
                            IdAgree = Convert.ToString(dr[0]),
                            IdChild = Convert.ToString(dr[1]),
                            DateStart = Convert.ToString(dr[2]),
                            DateEnd = Convert.ToString(dr[3]),
                            IdParent = Convert.ToString(dr[4]),
                            IdGenderChild = Convert.ToString(dr[5]),
                            FioChild = Convert.ToString(dr[6])+" "+ Convert.ToString(dr[7]) + " "+Convert.ToString(dr[8]),
                            BirthdayChild = Convert.ToString(dr[9]),
                            PhoneChild = Convert.ToString(dr[10]),
                            EmailChild = Convert.ToString(dr[11]),
                            IdGenderPar = Convert.ToString(dr[12]),
                            FioPar = Convert.ToString(dr[13]) + " " + Convert.ToString(dr[14]) + " "+Convert.ToString(dr[15]),
                            BirthdayPar = Convert.ToString(dr[16]),
                            PhonePar = Convert.ToString(dr[17]),
                            EmailPar = Convert.ToString(dr[18])
                        });
                    }
                    myConnection.Close();
                }
                catch
                {
                    myConnection.Close();
                }

                try
                {

                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = @"select * from Section";

                    sqlCmd.Connection = myConnection;
                    myConnection.Open();
                    //sqlCmd.ExecuteNonQuery();
                    SqlDataReader dr = sqlCmd.ExecuteReader();


                    while (dr.Read())
                    {
                        groupdata.Add(new BdGoup { IdGroup = Convert.ToString(dr[0]), Name = Convert.ToString(dr[1]), Duration = Convert.ToString(dr[3]), NumbeMounth = Convert.ToString(dr[4]) });
                    }
                    myConnection.Close();
                }
                catch
                {
                    myConnection.Close();
                }
                SqlConnection myConnection1 = new SqlConnection();
                myConnection1.ConnectionString = connstring;
                SqlCommand sqlCmd1 = new SqlCommand();

                try
                {

                    sqlCmd1.CommandType = CommandType.Text;
                    sqlCmd1.CommandText = @"Select * from treaty";

                    sqlCmd1.Connection = myConnection1;
                    myConnection1.Open();
                    //sqlCmd.ExecuteNonQuery();
                    SqlDataReader dr = sqlCmd1.ExecuteReader();


                    while (dr.Read())
                    {
                        checkmybd.Add(new BdDog { IdAgree = Convert.ToString(dr[0]), DateStart = Convert.ToString(dr[1]), DateEnd = Convert.ToString(dr[2])});
                    }
                    myConnection1.Close();
                }
                catch
                {
                    myConnection1.Close();
                }

                try
                {

                    sqlCmd1.CommandType = CommandType.Text;
                    sqlCmd1.CommandText = @"select * from Section";

                    sqlCmd1.Connection = myConnection1;
                    myConnection1.Open();
                    //sqlCmd.ExecuteNonQuery();
                    SqlDataReader dr = sqlCmd1.ExecuteReader();


                    while (dr.Read())
                    {
                        checkmygroup.Add(new BdGoup { IdGroup = Convert.ToString(dr[0]), Name = Convert.ToString(dr[1]), Duration = Convert.ToString(dr[2]), NumbeMounth = Convert.ToString(dr[3]) });
                    }
                    myConnection1.Close();
                }
                catch
                {
                    myConnection1.Close();
                }
                if(!groupdata.SequenceEqual(checkmygroup))
                {
                    try
                    {

                        sqlCmd1.CommandType = CommandType.Text;
                        sqlCmd1.CommandText = $"delete from direction ";

                        sqlCmd1.Connection = myConnection1;
                        myConnection1.Open();
                        //sqlCmd.ExecuteNonQuery();
                        SqlDataReader dr = sqlCmd1.ExecuteReader();



                        myConnection1.Close();
                    }
                    catch
                    {
                        myConnection1.Close();
                    }
                    for (int i = 0; i < groupdata.Count; i++)
                    {
                        try
                        {

                            sqlCmd1.CommandType = CommandType.Text;
                            sqlCmd1.CommandText = $"insert into  direction(id_direction,Name_group,Lessons_long,Lessons_count) Values({groupdata[i].IdGroup},'{groupdata[i].Name}',{groupdata[i].Duration},{groupdata[i].NumbeMounth})";

                            sqlCmd1.Connection = myConnection1;
                            myConnection1.Open();
                            //sqlCmd.ExecuteNonQuery();
                            SqlDataReader dr = sqlCmd1.ExecuteReader();



                            myConnection1.Close();
                        }
                        catch
                        {
                            myConnection1.Close();
                        }
                    }
                }
                if (!JustDog.SequenceEqual(checkmybd))
                {
                    try
                    {

                        sqlCmd1.CommandType = CommandType.Text;
                        sqlCmd1.CommandText = $"delete from student  delete from treaty delete from parents";

                        sqlCmd1.Connection = myConnection1;
                        myConnection1.Open();
                        //sqlCmd.ExecuteNonQuery();
                        SqlDataReader dr = sqlCmd1.ExecuteReader();



                        myConnection1.Close();
                    }
                    catch
                    {
                        myConnection1.Close();
                    }

                    for (int i = 0; i < fulldata.Count; i++)
                    {
                        try
                        {
                            
                            sqlCmd1.CommandType = CommandType.Text;
                            sqlCmd1.CommandText = $"insert into treaty([id_treaty],[Traty_date],[Traty_date_of_end])  values({fulldata[i].IdAgree},'{fulldata[i].DateStart}','{fulldata[i].DateEnd}')  insert into [Parents]([id_parents],[id_gender],[Fio_parents],[Parents_phone],[Birthday_parants],[Mail]) values({fulldata[i].IdParent},{fulldata[i].IdGenderPar},'{fulldata[i].FioPar}','{fulldata[i].PhonePar}','{fulldata[i].BirthdayPar}','{fulldata[i].EmailPar}') insert into Student([id_student],[id_parents],[Fio],[Birthday],[Phone],[Mail],[id_gender],[id_treaty],[Traty_date])values({fulldata[i].IdChild},{fulldata[i].IdParent},'{fulldata[i].FioChild}','{fulldata[i].BirthdayChild}','{fulldata[i].PhoneChild}','{fulldata[i].EmailChild}',{fulldata[i].IdGenderChild},{fulldata[i].IdAgree},'{fulldata[i].DateStart}')";

                            sqlCmd1.Connection = myConnection1;
                            myConnection1.Open();
                            //sqlCmd.ExecuteNonQuery();
                            SqlDataReader dr = sqlCmd1.ExecuteReader();



                            myConnection1.Close();
                        }
                        catch
                        {
                            myConnection1.Close();
                        }
                    }
                }



            }

        }


    }
}
