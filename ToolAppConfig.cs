using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WinFormTool
{
    class ToolAppConfig
    {        
        // Methods
        /// <summary>
        /// 根据键值取得Config文件里的AppSetting里的数据
        /// </summary>
        /// <param name="appKey">键值</param>
        ///<returns>ToolResult对象</returns>
        public static ToolResult getConfigForAppSettings(string appKey)
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                toolResult.ObjResult = ConfigurationManager.AppSettings[appKey].ToString();
                toolResult.IsSucess = true;
            }catch(Exception ex)
            {
                toolResult.IsSucess = false;
                toolResult.ObjResult = null;
                toolResult.StrErrMessage = ex.Message;
            }
            return toolResult;
        }
        /// <summary>
        /// 根据键值取得Config文件里的ConnectionStrings里的数据
        /// </summary>
        /// <param name="appKey">键值</param>
        /// <returns>ToolResult对象</returns>
        public static ToolResult getConfigForConnectionStrings(string appKey)
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                toolResult.ObjResult = ConfigurationManager.ConnectionStrings[appKey].ConnectionString;
                toolResult.IsSucess = true;
            }
            catch (Exception ex)
            {
                toolResult.IsSucess = false;
                toolResult.ObjResult = null;
                toolResult.StrErrMessage = ex.Message;
            }
            return toolResult;
        }
        /// <summary>
        /// 根据键值设置Config文件里的AppSetting里的数据
        /// </summary>
        /// <param name="appKey">键值</param>
        /// <param name="appKeyValue">应用程序信息</param>
        /// <returns>ToolResult对象</returns>
        public static ToolResult setConfigForAppSettings(string appKey, string appKeyValue)
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                bool flag = false;
                foreach (string str in ConfigurationManager.AppSettings)
                {
                    if (string.Compare(str, appKey) == 0)
                    {
                        flag = true;
                    }
                }
                System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (flag)
                {
                    configuration.AppSettings.Settings.Remove(appKey);
                }
                configuration.AppSettings.Settings.Add(appKey, appKeyValue);
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                toolResult.IsSucess = true;
            }catch(Exception ex)
            {
                toolResult.IsSucess = false;
                toolResult.StrErrMessage = ex.Message;
            }
            return toolResult;
        }
        /// <summary>
        /// 根据键值设置Config文件里的ConnectionString里的数据
        /// </summary>
        /// <param name="appKey">键值</param>
        /// <param name="appKeyValue">连接字符串</param>
        /// <returns>ToolResult对象</returns>
        public static ToolResult setConfigForConnectionStrings(string appKey, string appKeyValue)
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                bool flag = false;
                for (int i = 0; i < ConfigurationManager.ConnectionStrings.Count; i++)
                {
                    if (string.Compare(appKey, ConfigurationManager.ConnectionStrings[i].Name) == 0)
                    {
                        flag = true;
                    }
                }
                System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (flag)
                {
                    configuration.ConnectionStrings.ConnectionStrings.Remove(appKey);
                }
                ConnectionStringSettings settings = new ConnectionStringSettings(appKey, appKeyValue);
                configuration.ConnectionStrings.ConnectionStrings.Add(settings);
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
                toolResult.IsSucess = true;
            }catch(Exception ex)
            {
                toolResult.IsSucess = false;
                toolResult.StrErrMessage = ex.Message;
            }
            return toolResult;
        }
    }
}
