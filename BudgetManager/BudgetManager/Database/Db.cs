using BudgetManager.Database.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetManager.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BudgetManager.Database
{
    public class Db : IDbContext
    {
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString);

        public void OpenCon()
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CloseCon()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private SqlParameter CreateParam(string name, object value, SqlDbType type)
        {
            SqlParameter param = new SqlParameter(name, type)
            {
                Value = value
            };
            return param;
        }

        /// <summary>
        /// Saves a budget to the database and returns the id
        /// </summary>
        /// <param name="budget">Budget to save</param>
        /// <returns>Id of the saved budget</returns>
        public int CreateBudget(Budget budget)
        {
            object id;

            SqlCommand command = new SqlCommand("INSERT INTO Budgets(Purpose, AccountYear, Fk_VisbilityId, BudgetTitle, FK_IntervalTitle) VALUES (@purpose, @accountYear, @visibilty, @title, @interval); SELECT SCOPE_IDENTITY();", connection);
            command.Parameters.Add(CreateParam("@purpose", budget.Purpose, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@accountYear", budget.AccountingYear, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@visibilty", budget.FK_VisibilityId, SqlDbType.Int));
            command.Parameters.Add(CreateParam("@title", budget.BudgetTitle, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@interval", budget.FK_IntervalTitle, SqlDbType.NVarChar));

            try
            {
                OpenCon();
                id = command.ExecuteScalar();
                CloseCon();
            }
            catch (Exception)
            {
                connection.Dispose();
                throw;
            }

            return Convert.ToInt32(id);
        }

        /// <summary>
        /// Finds and returns all the intervals in the database
        /// </summary>
        /// <returns>ICollection filled with intervals</returns>
        public ICollection<Interval> GetIntervals()
        {
            List<Interval> intervals = new List<Interval>();
            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter("select * from Interval", connection);

            try
            {
                adapter.Fill(table);
            }
            catch (Exception)
            {
                connection.Dispose();
                throw;
            }
            foreach (DataRow row in table.Rows)
            {
                intervals.Add(new Interval(row["IntervalTitle"].ToString(), int.Parse(row["IntervalValue"].ToString())));
            }

            return intervals;
        }

        /// <summary>
        /// Finds and returns all the visibilitys in the database
        /// </summary>
        /// <returns>ICollection filled with visibilitys</returns>
        public ICollection<Visibility> GetVisibiltys()
        {
            List<Visibility> visibilitys = new List<Visibility>();
            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter("select * from Visibility", connection);

            try
            {
                adapter.Fill(table);
            }
            catch (Exception)
            {
                connection.Dispose();
                throw;
            }
            foreach (DataRow row in table.Rows)
            {
                visibilitys.Add(new Visibility(row["Title"].ToString(), row["Description"].ToString(), int.Parse(row["Id"].ToString())));
            }

            return visibilitys;
        }
    }
}