namespace ZhijieLi.CommonUtility.Logger
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DbLogger : ILogger
    {

        public DbLogger()
        {

        }
        public  DataSet ExecuteDb()
        {
            var ds = new DataSet();
            var startTime = DateTimeOffset.UtcNow;
            var success = false;

            using (var cnn = new SqlConnection("Data Source=.;Initial Catalog=test;Integrated Security=True"))
            using (var cmd = new SqlCommand())
            using (var adapter = new SqlDataAdapter(cmd))
            {
                cmd.Connection = cnn;
                cmd.CommandTimeout = 14400; // 4 hours = 4 * 3600 seconds
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from TraceDb";
                cnn.Open();
                adapter.Fill(ds);
                success = true;
            }

            return ds;
        }

        public string LoggerName { get; set; }
        public void LogInfo(string message)
        {
            throw new NotImplementedException();
        }

        public void LogMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void LogVerbose(string message)
        {
            throw new NotImplementedException();
        }

        public void LogError(string message)
        {
            throw new NotImplementedException();
        }

        public void LogException(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
