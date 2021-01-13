using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WinFormTool
{
    /// <summary>
    /// mysql数据库操作
    /// </summary>
    class ToolMysqlDbHelper
    {
        private int _con;
        private string _dbType;
        public ToolMysqlDbHelper() { }
        /// <summary>
        /// 是否用config文件
        /// </summary>
        /// <param name="con">值为1：databaseType为配置文件中的数据库类型名称；值为0：databaseType参数为数据库连接字符串</param>
        /// <param name="databaseType">数据库类型：mysql、sqlserver、连接字符串等</param>
        public ToolMysqlDbHelper(int con, string databaseType) { _con = con; _dbType = databaseType; }
        private string dbConnectionSring;
        private string DbConnectionString
        {
            get
            {
                if (_con == 1)
                {
                    dbConnectionSring = ToolAppConfig.getConfigForConnectionStrings(_dbType).ObjResult.ToString();
                }
                else
                {
                    dbConnectionSring = _dbType;
                }
                return dbConnectionSring;
            }
            set { dbConnectionSring = value; }
        }
        #region MySql
        private MySqlConnection mySql_Connection;
        private MySqlConnection MySql_Connection
        {
            get
            {
                if (this.mySql_Connection == null)
                {
                    this.mySql_Connection = new MySqlConnection(this.DbConnectionString);
                    this.mySql_Connection.Open();
                }
                else if (this.mySql_Connection.State == ConnectionState.Broken)
                {
                    this.mySql_Connection.Close();
                    this.mySql_Connection.Open();
                }
                else if (this.mySql_Connection.State == ConnectionState.Closed)
                {
                    this.mySql_Connection.Open();
                }
                return this.mySql_Connection;
            }
            set
            {
                this.mySql_Connection = value;
            }
        }
        /// <summary>
        /// 执行insert,update,delete,返回影响的行数
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <returns>int类型：影响的行数</returns>
        public ToolResult MysqlExecuteNonQuery(string cmdText)
        {
            ToolResult _result = new ToolResult();
            try
            {
                MySqlCommand cmd = new MySqlCommand(cmdText, MySql_Connection);
                _result.ObjResult = cmd.ExecuteNonQuery();
                _result.IsSucess = true;
            }
            catch (Exception ex)
            {
                _result.IsSucess = false;
                _result.StrErrMessage = ex.Message;
            }
            return _result;
        }
        /// <summary>
        /// 执行insert,update,delete,返回影响的行数
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="cmdType">sql语句类型：文本、存储过程</param>
        /// <returns>int类型：影响的行数</returns>
        public ToolResult MysqlExecuteNonQuery(string cmdText, CommandType cmdType)
        {
            ToolResult _result = new ToolResult();
            try
            {
                MySqlCommand cmd = new MySqlCommand(cmdText, MySql_Connection);
                cmd.CommandType = cmdType;
                _result.ObjResult = cmd.ExecuteNonQuery();
                _result.IsSucess = true;
            }
            catch (Exception ex)
            {
                _result.IsSucess = false;
                _result.StrErrMessage = ex.Message;
            }
            return _result;
        }
        /// <summary>
        /// 执行insert,update,delete,返回影响的行数
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="cmdType">sql语句类型：文本、存储过程</param>
        /// <param name="strError">错误信息</param>
        /// <returns>int类型：影响的行数</returns>
        public ToolResult MysqlExecuteNonQuery(string cmdText, CommandType cmdType, ref string strError, params MySqlParameter[] values)
        {
            ToolResult _result = new ToolResult();
            try
            {
                MySqlCommand cmd = new MySqlCommand(cmdText, MySql_Connection);                cmd.CommandType = cmdType;
                if (values != null)
                {
                    cmd.Parameters.AddRange(values);
                }
                _result.ObjResult = cmd.ExecuteNonQuery();
                _result.IsSucess = true;
            }
            catch (Exception ex)
            {
                _result.IsSucess = false;
                _result.StrErrMessage = ex.Message;
            }
            return _result;
        }
        /// <summary>
        /// 执行select,返回第一行第一列数据
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="strError">错误信息</param>
        /// <returns>object类型：第一行第一列</returns>
        public ToolResult MysqlExcuteScalar(string cmdText, ref string strError)
        {
            ToolResult _result = new ToolResult();
            try
            {
                MySqlCommand cmd = new MySqlCommand(cmdText, MySql_Connection);
                _result.ObjResult = cmd.ExecuteScalar();
                _result.IsSucess = true;
            }
            catch (Exception ex)
            {
                _result.IsSucess = false;
                _result.StrErrMessage = ex.Message;
            }
            return _result;
        }
        /// <summary>
        /// 执行select,返回第一行第一列数据
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="cmdType">sql语句类型：文本、存储过程</param>
        /// <param name="strError">错误信息</param>
        /// <returns>object类型：第一行第一列</returns>
        public ToolResult MysqlExcuteScalar(string cmdText, CommandType cmdType, ref string strError)
        {
            ToolResult _result = new ToolResult() ;
            try
            {
                MySqlCommand cmd = new MySqlCommand(cmdText, MySql_Connection);
                cmd.CommandType = cmdType;
                _result.ObjResult = cmd.ExecuteScalar();
                _result.IsSucess = true;
            }
            catch (Exception ex)
            {
                _result.IsSucess = false;
                _result.ObjResult = ex.Message;
            }
            return _result;
        }
        /// <summary>
        /// 执行select,返回第一行第一列数据
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="cmdType">sql语句类型：文本、存储过程</param>
        /// <param name="strError">错误信息</param>
        /// <param name="values">sql语句参数</param>
        /// <returns>object类型：第一行第一列</returns>
        public ToolResult MysqlExcuteScalar(string cmdText, CommandType cmdType, ref string strError, params MySqlParameter[] values)
        {
            ToolResult _result = new ToolResult();
            try
            {
                MySqlCommand cmd = new MySqlCommand(cmdText, MySql_Connection);
                cmd.CommandType = cmdType;
                if (values != null)
                {
                    cmd.Parameters.AddRange(values);
                }
                _result.ObjResult = cmd.ExecuteScalar();
                _result.ObjResult = true;
            }
            catch (Exception ex)
            {
                _result.IsSucess = false;
                _result.StrErrMessage = ex.Message;
            }
            return _result;
        }
        /// <summary>
        /// 执行select,返回MySqlDataReader对象
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="strError">错误信息</param>
        /// <returns>MySqlDataRader对象</returns>
        public ToolResult MysqlExecuteReader(string cmdText, ref string strError)
        {
            ToolResult _result = new ToolResult();
            try
            {
                MySqlCommand cmd = new MySqlCommand(cmdText, MySql_Connection);
                _result.ObjResult = cmd.ExecuteReader();
                _result.IsSucess = true;
            }
            catch (Exception ex)
            {
                _result.IsSucess = false;
                _result.StrErrMessage = ex.Message;
            }
            return _result;
        }
        /// <summary>
        /// 执行select,返回MySqlDataReader对象
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="cmdType">sql语句类型：文本、存储过程</param>
        /// <param name="strError">错误信息</param>
        /// <returns>MySqlDataRader对象</returns>
        public ToolResult MysqlExecuteReader(string cmdText, CommandType cmdType, ref string strError)
        {
            ToolResult _result = new ToolResult();
            try
            {
                MySqlCommand cmd = new MySqlCommand(cmdText, MySql_Connection);
                cmd.CommandType = cmdType;
                _result.ObjResult = cmd.ExecuteReader();
                _result.IsSucess = true;
            }
            catch (Exception ex)
            {
                _result.IsSucess = false;
                _result.StrErrMessage = ex.Message;
            }
            return _result;
        }
        /// <summary>
        /// 执行select,返回MySqlDataReader对象
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="cmdType">sql语句类型：文本、存储过程</param>
        /// <param name="strError">错误信息</param>
        /// <param name="values">sql参数</param>
        /// <returns>MySqlDataRader对象</returns>
        public ToolResult MysqlExecuteReader(string cmdText, CommandType cmdType, ref string strError, params MySqlParameter[] values)
        {
            ToolResult _result = new ToolResult();
            try
            {
                MySqlCommand cmd = new MySqlCommand(cmdText, MySql_Connection);
                cmd.CommandType = cmdType;
                if (values != null)
                {
                    cmd.Parameters.AddRange(values);
                }
                _result.ObjResult = cmd.ExecuteReader();
                _result.IsSucess = true;
            }
            catch (Exception ex)
            {
                _result.IsSucess = false;
                _result.StrErrMessage = ex.Message;
            }
            return _result;
        }
        /// <summary>
        /// 执行select,返回DataTable
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="strError">错误信息</param>
        /// <returns>DataTable</returns>
        public ToolResult MysqlDataSet(string cmdText, ref string strError)
        {
            ToolResult _result = new ToolResult();
            try
            {
                DataSet dataSet = new DataSet();
                MySqlCommand cmd = new MySqlCommand(cmdText, MySql_Connection);
                new MySqlDataAdapter(cmd).Fill(dataSet);
                _result.ObjResult = dataSet.Tables[0];
                _result.IsSucess = true;
            }
            catch (Exception ex)
            {
                _result.IsSucess = false;
                _result.StrErrMessage = ex.Message;
            }
            return _result;
        }
        /// <summary>
        /// 执行select,返回DataTable
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="cmdType">sql语句类型：文本、存储过程</param>
        /// <param name="strError">错误信息</param>
        /// <returns>DataTable</returns>
        public ToolResult MysqlDataSet(string cmdText, CommandType cmdType, ref string strError)
        {
            ToolResult _result = new ToolResult();
            try
            {
                DataSet dataSet = new DataSet();
                MySqlCommand cmd = new MySqlCommand(cmdText, MySql_Connection);
                cmd.CommandType = cmdType;
                new MySqlDataAdapter(cmd).Fill(dataSet);
                _result.ObjResult = dataSet.Tables[0];
                _result.IsSucess = true;
            }
            catch (Exception ex)
            {
                _result.IsSucess = false;
                _result.StrErrMessage = ex.Message;
            }
            return _result;
        }
        /// <summary>
        /// 执行select,返回DataTable
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="cmdType">sql语句类型：文本、存储过程</param>
        /// <param name="strError">错误信息</param>
        /// <returns>DataTable</returns>
        public ToolResult MysqlDataSet(string cmdText, CommandType cmdType, ref string strError, params MySqlParameter[] values)
        {
            ToolResult _result = new ToolResult();
            try
            {
                DataSet dataSet = new DataSet();
                MySqlCommand cmd = new MySqlCommand(cmdText, MySql_Connection);
                cmd.CommandType = cmdType;
                if (values != null)
                {
                    cmd.Parameters.AddRange(values);
                }
                new MySqlDataAdapter(cmd).Fill(dataSet);
                _result.ObjResult = dataSet.Tables[0];
                _result.IsSucess = true;
            }
            catch (Exception ex)
            {
                _result.IsSucess = false;
                _result.StrErrMessage = ex.Message;
            }
            return _result;
        }
        #endregion

    }
}
