using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class CourseSQLDAO : ICourseDAO
    {
        private readonly string connectionString;

        public CourseSQLDAO (string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Course SelectCourse(int courseID)
        {
            List<Course> courses = new List<Course>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("select * from location", connection);
                    cmd.Parameters.AddWithValue("@courseID", courseID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Course course = ConvertReaderToCourse(reader);
                        return course;                        
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while selecting a course.");
                Console.WriteLine(ex.Message);
                throw;
            }
            return null;
        }

        public Course AddCourse(Course course)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO location (course_name, holes, address) VALUES (@course_name, @holes, @address)", conn);
                    cmd.Parameters.AddWithValue("@course_name", course.CourseName);
                    cmd.Parameters.AddWithValue("@holes", course.Holes);
                    cmd.Parameters.AddWithValue("@address", course.Address);
                    
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {

                        course = ConvertReaderToCourse(reader);
                    }

                }
            }
            catch (SqlException)
            {
                throw;
            }

            return course;
        }

        private Course ConvertReaderToCourse(SqlDataReader reader)
        {
            Course course = new Course();
            course.CourseId = Convert.ToInt32(reader["course_Id"]);
            course.CourseName = Convert.ToString(reader["course_name"]);
            course.Holes = Convert.ToInt32(reader["holes"]);
            course.Address = Convert.ToString(reader["address"]);

            return course;
        }
    }
}
