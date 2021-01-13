using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace WinFormTool
{
    /// <summary>
    /// 日期时间类工具
    /// </summary>
    class ToolDate
    {
        /// <summary>
        /// 中国农历日期
        /// </summary>
        public static ToolChineseDateTime toolChineseDateTime;
        /// <summary>
        /// 计算两个日期间相差的天数
        /// </summary>
        /// <param name="_beginDate">开始日期</param>
        /// <param name="_endDate">结束日期</param>
        /// <returns>ToolResult对象</returns>
        public static ToolResult CalculateDays(DateTime _beginDate, DateTime _endDate)
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                if (_beginDate == null || _endDate == null)
                {
                    toolResult.IsSucess = false;
                    toolResult.StrErrMessage = "日期变量未赋值。";
                    toolResult.ObjResult = null;
                }
                else
                {
                    TimeSpan span = _endDate - _beginDate;
                    if (span.Days < 0)
                    {
                        toolResult.IsSucess = false;
                        toolResult.StrErrMessage = "起始日期大于结束日期。";
                        toolResult.ObjResult = null;
                    }
                    else
                    {
                        toolResult.ObjResult = span.Days + 1;
                        toolResult.IsSucess = true;
                        toolResult.StrErrMessage = "";
                    }
                }
            }catch(Exception ex)
            {
                toolResult.IsSucess = false;
                toolResult.StrErrMessage = ex.Message;
                toolResult.ObjResult = null;
            }
            return toolResult;
        }
        /// <summary>
        /// 返回当前日期yyyy-MM-dd
        /// </summary>
        /// <returns></returns>
        public static ToolResult GetDate()
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                toolResult.ObjResult = DateTime.Now.ToString("yyyy-MM-dd");
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
        /// 返回自定义样式的当前日期
        /// </summary>
        /// <param name="strFormat">日期样式</param>
        /// <returns></returns>
        public static ToolResult GetDate(string strFormat)
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                toolResult.ObjResult = DateTime.Now.ToString(strFormat);
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
        /// 返回自定义样式的自定义日期
        /// </summary>
        /// <param name="dateTime">日期时间</param>
        /// <param name="strFormat">日期样式</param>
        /// <returns></returns>
        public static ToolResult GetDate(DateTime dateTime,string strFormat)
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                toolResult.ObjResult = dateTime.ToString(strFormat);
                toolResult.IsSucess = true;
            }
            catch (Exception ex)
            {
                toolResult.IsSucess = false;
                toolResult.StrErrMessage = ex.Message;
            }
            return toolResult;
        }

    }
}
