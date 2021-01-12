using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormTool
{
    /// <summary>
    /// 语句执行结果实体类
    /// </summary>
    class ToolResult
    {
        private bool isSucess = false;
        private object objResult=null;
        private string strErrMessage="";

        public ToolResult() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isSucess">j是否执行成功</param>
        /// <param name="objResult">执行结果</param>
        /// <param name="strErrMessage">错误消息</param>
        public ToolResult(bool isSucess, object objResult, string strErrMessage)
        {
            this.isSucess = isSucess;
            this.objResult = objResult;
            this.strErrMessage = strErrMessage;
        }

        /// <summary>
        /// 是否执行成功
        /// </summary>
        public bool IsSucess { get => isSucess; set => isSucess = value; }
        /// <summary>
        /// 执行结果
        /// </summary>
        public object ObjResult { get => objResult; set => objResult = value; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string StrErrMessage { get => strErrMessage; set => strErrMessage = value; }
    }
}
