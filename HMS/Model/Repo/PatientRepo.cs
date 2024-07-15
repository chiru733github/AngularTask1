using System.Data;
using System.Data.SqlClient;
using HMS.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Model.Repo
{
    public class PatientRepo
    {
        readonly SqlConnection conn = new SqlConnection();
        readonly string connString;
        readonly IConfiguration config;

        public PatientRepo(IConfiguration configuration)
        {
            this.config = configuration;
            connString = configuration.GetConnectionString("BookStoreDBConn");
            conn.ConnectionString = connString;
        }
        public PatientBill Save_Button(PatientBill patient)
        {
            try
            {
                conn.Open();
                SqlCommand Insertcmd = new SqlCommand("usp_InsertBill", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Insertcmd.Parameters.AddWithValue("@Bill_No", patient.Bill_No);
                Insertcmd.Parameters.AddWithValue("@Bill_Date", patient.Bill_Date);
                Insertcmd.Parameters.AddWithValue("@PatientName", patient.Patient_Name);
                Insertcmd.Parameters.AddWithValue("@Gender", patient.Gender);
                Insertcmd.Parameters.AddWithValue("@DOB", patient.DOB);
                Insertcmd.Parameters.AddWithValue("@Address", patient.Address);
                Insertcmd.Parameters.AddWithValue("@Email_Id", patient.Email_Id);
                Insertcmd.Parameters.AddWithValue("@Mobile_No", patient.Mobile_No);
                Insertcmd.ExecuteNonQuery();
                return patient;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }


        public List<PatientBill> GetAllPatient()
        {
            try
            {
                conn.Open();
                SqlCommand Insertcmd = new SqlCommand("select * from HospitalBill", conn);
                List<PatientBill> getAll = new List<PatientBill>();
                SqlDataReader sqlDataReader = Insertcmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    PatientBill patientBill = new PatientBill()
                    {
                        Bill_No = sqlDataReader.GetInt32(0),
                        Bill_Date = sqlDataReader.GetDateTime(1),
                        Patient_Name = sqlDataReader.GetString(2),
                        Gender = sqlDataReader.GetString(3),
                        DOB = sqlDataReader.GetDateTime(4),
                        Address = sqlDataReader.GetString(5),
                        Email_Id = sqlDataReader.GetString(6),
                        Mobile_No = sqlDataReader.GetString(7),
                    };
                    getAll.Add(patientBill);
                }
                return getAll;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }
        public PatientBill GetById(int BillNumber)
        {
            try
            {
                conn.Open();
                SqlCommand FillDetail = new SqlCommand("select * from HospitalBill where Bill_No=" + BillNumber, conn);
                SqlDataReader reader = FillDetail.ExecuteReader();
                if (reader.Read())
                {
                    PatientBill patientBill = new PatientBill()
                    {
                        Bill_No = reader.GetInt32(0),
                        Bill_Date = reader.GetDateTime(1),
                        Patient_Name = reader.GetString(2),
                        Gender = reader.GetString(3),
                        DOB = reader.GetDateTime(4),
                        Address = reader.GetString(5),
                        Email_Id = reader.GetString(6),
                        Mobile_No = reader.GetString(7),
                    };
                    return patientBill;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool Grid_Button(int billNo,int investId)
        {
            conn.Open();
            SqlCommand Insertcmd = new SqlCommand("usp_Inserting_Into_Grid", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            Insertcmd.Parameters.AddWithValue("@Bill_No", billNo);
            Insertcmd.Parameters.AddWithValue("@Investigation_Id", investId);
            Insertcmd.ExecuteNonQuery();
            return true;
            conn.Close();
        }
        public List<Investigations> ViewGrid(int billNo)
        {
            try
            {
                conn.Open();
                SqlCommand FillDetail = new SqlCommand("exec usp_ShowGrid " + billNo, conn);
                SqlDataReader reader = FillDetail.ExecuteReader();
                List<Investigations> investigations = new List<Investigations>();
                if (reader.Read())
                {
                    Investigations invest = new Investigations()
                    {
                        Investigation_Name = reader.GetString(0),
                        Fees = reader.GetDecimal(1),
                    };
                    investigations.Add(invest);
                }
                return investigations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
