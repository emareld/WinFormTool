using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WinFormTool
{
    /// <summary>
    /// SQLServer数据库操作其类
    /// </summary>
    class ToolSQLDbHelper
    {
        #region 属性
        private string dbConnKey = "";//数据库连接字符串键值
        /// <summary>
        /// 数据库连接字符串键值
        /// </summary>
        public string DbConnKey
        {
            get { return dbConnKey; }
            set { dbConnKey = value; }
        }

        private string server = "";//服务器地址
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string Server
        {
            get { return server; }
            set { server = value; }
        }
        private string portNum = "1433";//默认端口号
        /// <summary>
        /// 端口号,默认为1433
        /// </summary>
        public string PortNum
        {
            get { return portNum; }
            set { portNum = value; }
        }
        private string dataBase;//数据库名
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DataBase
        {
            get { return dataBase; }
            set { dataBase = value; }
        }

        private string uid = "";//数据库登陆用户名
        /// <summary>
        /// 数据库登陆用户名
        /// </summary>
        public string Uid
        {
            get { return uid; }
            set { uid = value; }
        }
        private string pwd = "";//数据库登陆密码
        /// <summary>
        /// 数据库登陆密码
        /// </summary>
        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }
        #endregion

        #region 变量
        private SqlConnection connection;
        private string dbConnString = "";//数据库连接字符串
        #endregion

        #region 构造方法

        public ToolSQLDbHelper() { }
        public ToolSQLDbHelper(string server, string database, string uid, string pwd, string portNum = "1433")
        {
            this.Server = server;//服务器地址
            this.PortNum = portNum;//端口号
            this.DataBase = database;//数据库名称
            this.Uid = uid;//用户名
            this.Pwd = pwd;//密码
        }
        #endregion

        #region ConnectionString
        //获取数据库连接字符串
        public string strSQLConnection
        {
            get
            {
                if (!string.IsNullOrEmpty(DbConnKey))
                {
                    dbConnString = ConfigurationManager.ConnectionStrings[DbConnKey].ConnectionString.ToString();
                }
                else
                {
                    dbConnString = string.Format("Server={0},{1};database={2};UID={3};Pwd={4}", this.Server, this.PortNum, this.DataBase, this.Uid, this.Pwd);
                }
                return dbConnString;
            }
        }
        // 获取数据库连接，并打开数据库链接
        private SqlConnection Connection
        {
            get
            {

                if (connection == null)
                {
                    connection = new SqlConnection(strSQLConnection);
                    connection.Open();
                }
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                if (connection.State == ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }
        #endregion

        #region 方法
        //执行插入、更新、删除操作
        /// <summary>
        /// 执行插入、更新、删除操作，参数cmtText为SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <returns>影响的行数</returns>
        public ToolResult ExecuteNoQuery(string cmdText)
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                SqlCommand command = new SqlCommand(cmdText, Connection);
                toolResult.ObjResult= command.ExecuteNonQuery();
                toolResult.IsSucess = true;
            }catch(Exception ex)
            {
                toolResult.IsSucess = false;
                toolResult.StrErrMessage = ex.Message;
            }
            return toolResult;
        }
        /// <summary>
        /// 执行插入、更新、删除操作，参数cmtText为SQL语句,values为SQL语句中的参数
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="values">SQL语句中的参数</param>
        /// <returns>受影响的行数</returns>
        public ToolResult ExecuteNoQuery(string cmdText, params SqlParameter[] values)
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                SqlCommand command = new SqlCommand(cmdText, Connection);
                command.Parameters.AddRange(values);
                toolResult.ObjResult = command.ExecuteNonQuery();
                toolResult.IsSucess = true;
            }catch (Exception ex)
            {
                toolResult.IsSucess = false;
                toolResult.StrErrMessage = ex.Message;
            }
            return toolResult;
        }
        /// <summary>
        /// 执行插入、更新、删除操作，参数cmtText为SQL语句,cmdType为System.Data.SqlCommand的CommandType类型，values为SQL语句中的参数
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="cmdType">System.Data.SqlCommand的CommandType类型</param>
        /// <param name="values">SQL语句中的参数</param>
        /// <returns>受影响的行数</returns>
        public ToolResult ExecuteNoQuery(string cmdText, CommandType cmdType, params SqlParameter[] values)
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                SqlCommand command = new SqlCommand(cmdText, Connection);
                command.Parameters.AddRange(values);
                command.CommandType = cmdType;
                toolResult.ObjResult = command.ExecuteNonQuery();
                toolResult.IsSucess = true;
            }catch (Exception ex)
            {
                toolResult.IsSucess = false;
                toolResult.StrErrMessage = ex.Message;
            }
            return toolResult;
        }
        //返回一行一列
        /// <summary>
        /// 返回一行一列，cmdText为SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <returns></returns>
        public ToolResult ExecuteScalar(string cmdText)
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                SqlCommand command = new SqlCommand(cmdText, Connection);
                toolResult.ObjResult = command.ExecuteScalar();
                toolResult.IsSucess = true;
            }catch (Exception ex)
            {
                toolResult.IsSucess = false;
                toolResult.StrErrMessage = ex.Message;
            }
            return toolResult;
        }
        /// <summary>
        /// 返回一行一列,cmdText为SQL语句，values为SQL语句中的参数
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="values">SQL语句中的参数</param>
        /// <returns></returns>
        public ToolResult ExecuteScalar(string cmdText, params SqlParameter[] values)
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                SqlCommand command = new SqlCommand(cmdText, Connection);
                command.Parameters.AddRange(values);
                toolResult.ObjResult = command.ExecuteScalar();
                toolResult.IsSucess = true;
            }catch (Exception ex)
            {
                toolResult.IsSucess = false;
                toolResult.StrErrMessage = ex.Message;
            }
            return toolResult;
        }
        //返回DataReader
        /// <summary>
        /// 返回DataReader，cmdText为SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <returns>SqlDataReader对象的实例对象</returns>
        public ToolResult ExecuteReader(string cmdText)
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                SqlCommand command = new SqlCommand(cmdText, Connection);
                toolResult.ObjResult= command.ExecuteReader();
                toolResult.IsSucess = true;
            }catch (Exception ex)
            {
                toolResult.IsSucess = false;
                toolResult.StrErrMessage = ex.Message;
            }
            return toolResult;
        }
        /// <summary>
        /// 返回DataReader，cmdText为SQL语句，values为SQL语句中的参数
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="values">SQL语句中的参数</param>
        /// <returns>SqlDataReader对象的实例对象</returns>
        public ToolResult ExecuteReader(string cmdText, params SqlParameter[] values)
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                SqlCommand command = new SqlCommand(cmdText, Connection);
                command.Parameters.AddRange(values);
                toolResult.ObjResult = command.ExecuteReader();
                toolResult.IsSucess = true;
            }catch (Exception ex)
            {
                toolResult.IsSucess = false;
                toolResult.StrErrMessage = ex.Message;
            }
            return toolResult;
        }
        //返回DataTable
        /// <summary>
        /// 返回DataTable，cmdText为SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <returns>DataTable</returns>
        public ToolResult GetDataSet(string cmdText)
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmdText, Connection);
                da.Fill(ds);
                toolResult.ObjResult = ds.Tables[0];
                toolResult.IsSucess = true;
            }catch (Exception ex)
            {
                toolResult.IsSucess = false;
                toolResult.StrErrMessage = ex.Message;
            }
            return toolResult;
        }
        /// <summary>
        /// 返回DataTable，cmdText为SQL语句，values为SQL语句中的参数
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="values">SQL语句中的参数</param>
        /// <returns>DataTable</returns>
        public ToolResult GetDataSet(string cmdText, params SqlParameter[] values)
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand command = new SqlCommand(cmdText, Connection);
                command.Parameters.AddRange(values);
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                toolResult.ObjResult = ds.Tables[0];
                toolResult.IsSucess = true;
            }
            catch (Exception ex)
            {
                toolResult.IsSucess = false;
                toolResult.StrErrMessage = ex.Message;
            }
            return toolResult;
        }

        /// <summary>
        /// 数据库连接测试
        /// </summary>
        /// <param name="Server">服务器地址</param>
        /// <param name="PortNum">端口号,默认为1433</param>
        /// <param name="Database">数据库名称</param>
        /// <param name="UID">用户名</param>
        /// <param name="Pwd">密码</param>
        /// <returns>BOOl值，True为连接成功，False为连接失败</returns>
        public ToolResult databaseTest(string Server, string PortNum, string Database, string UID, string Pwd)
        {
            ToolResult toolResult = new ToolResult();

            if (string.IsNullOrEmpty(PortNum))
            {
                PortNum = "1433";
            }
            SqlConnection connection = new SqlConnection(string.Format("server={0},{1};database={2};UID={3};pwd={4}", Server, PortNum, Database, UID, Pwd));
            try
            {
                connection.Open();
                toolResult.ObjResult = true;
                toolResult.IsSucess = true;
            }catch (Exception ex)
            {
                toolResult.IsSucess = false;
                toolResult.StrErrMessage = ex.Message;
            }finally
            {
                connection.Close();
            }
            return toolResult;
        }
        #endregion
    }
}
