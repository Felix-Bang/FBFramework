//  Felix-Bang：FBDebug
//　　 へ　　　　　／|
//　　/＼7　　　 ∠＿/
//　 /　│　　 ／　／
//　│　Z ＿,＜　／　　 /`ヽ
//　│　　　　　ヽ　　 /　　〉
//　 Y　　　　　`　 /　　/
//　ｲ●　､　●　　⊂⊃〈　　/
//　()　 へ　　　　|　＼〈
//　　>ｰ ､_　 ィ　 │ ／／
//　 / へ　　 /　ﾉ＜| ＼＼
//　 ヽ_ﾉ　　(_／　 │／／
//　　7　　　　　　　|／
//　　＞―r￣￣`ｰ―＿
// Describe：Debug管理类，方便启用和禁止Debug
// Createtime：2018/11/29

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FelixBang
{
    public class FBDebug
    {
        //     Opens or closes developer console.
        public static bool DeveloperConsoleVisible
        {
            get { return Debug.developerConsoleVisible; }
            set { Debug.developerConsoleVisible = value; }
        }

        //     In the Build Settings dialog there is a check box called "Development Build".
        public static bool IsDebugBuild
        {
            get { return Debug.isDebugBuild; }
        }

        //      Pauses the editor.
        public static void Break()
        {
            Debug.Break();
        }

        //      Clears errors from the developer console.  ?????
        public static void ClearDeveloperConsole()
        {
            Debug.ClearDeveloperConsole();
        }

        //      Clears errors from the developer console.  ?????  
        public static void DebugBreak()
        {
            Debug.DebugBreak();
        }

        //     Draws a line from the point start to end with color for a duration of time
        //     and with or without depth testing. If duration is 0 then the line is rendered
        //     1 frame.
        public static void DrawLine(Vector3 start, Vector3 end)
        {
            if (f_debug_bool)
                Debug.DrawLine(start, end);
        }

        //     Draws a line from the point start to end with color for a duration of time
        //     and with or without depth testing. If duration is 0 then the line is rendered
        //     1 frame.
        public static void DrawLine(Vector3 start, Vector3 end, Color color)
        {
            if (f_debug_bool)
                Debug.DrawLine(start, end, color);
        }


        //     Draws a line from the point start to end with color for a duration of time
        //     and with or without depth testing. If duration is 0 then the line is rendered
        //     1 frame.
        public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration)
        {
            if (f_debug_bool)
                Debug.DrawLine(start, end, color, duration);
        }

        //     Draws a line from the point start to end with color for a duration of time
        //     and with or without depth testing. If duration is 0 then the line is rendered
        //     1 frame.
        public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration, bool depthTest)
        {
            if (f_debug_bool)
                Debug.DrawLine(start, end, color, duration, depthTest);
        }

        //     Draws a line from start to start + dir with color for a duration of time
        //     and with or without depth testing. If duration is 0 then the line is rendered
        //     1 frame.
        public static void DrawRay(Vector3 start, Vector3 dir)
        {
            if (f_debug_bool)
                Debug.DrawRay(start, dir);
        }

        //     Draws a line from start to start + dir with color for a duration of time
        //     and with or without depth testing. If duration is 0 then the line is rendered
        //     1 frame.
        public static void DrawRay(Vector3 start, Vector3 dir, Color color)
        {
            if (f_debug_bool)
                Debug.DrawRay(start, dir, color);
        }

        //     Draws a line from start to start + dir with color for a duration of time
        //     and with or without depth testing. If duration is 0 then the line is rendered
        //     1 frame.
        public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration)
        {
            if (f_debug_bool)
                Debug.DrawRay(start, dir, color, duration);
        }

        //     Draws a line from start to start + dir with color for a duration of time
        //     and with or without depth testing. If duration is 0 then the line is rendered
        //     1 frame.
        public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration, bool depthTest)
        {
            if (f_debug_bool)
                Debug.DrawRay(start, dir, color, duration, depthTest);
        }

        //     Logs message to the Unity Console.
        public static void Log(object message)
        {
           if (f_debug_bool)
                Debug.Log(message);
        }

        //     Logs message to the Unity Console.
        public static void Log(object message, UnityEngine.Object context)
        {
            if (f_debug_bool)
                Debug.Log(message, context);
        }

        //     A variant of Debug.Log that logs an error message to the console.
        public static void LogError(object message)
        {
            if (f_debug_bool)
                Debug.LogError(message);
        }

        //     A variant of Debug.Log that logs an error message to the console.
        public static void LogError(object message, UnityEngine.Object context)
        {
            if (f_debug_bool)
                Debug.LogError(message, context);
        }

        //     A variant of Debug.Log that logs an error message from an exception to the
        //     console.
        public static void LogException(Exception exception)
        {
            if (f_debug_bool)
                Debug.LogException(exception);
        }

        //     A variant of Debug.Log that logs an error message from an exception to the
        //     console.
        public static void LogException(Exception exception, UnityEngine.Object context)
        {
            if (f_debug_bool)
                Debug.LogException(exception, context);
        }

        //     A variant of Debug.Log that logs a warning message to the console.
        public static void LogWarning(object message)
        {
            if (f_debug_bool)
                Debug.LogWarning(message);
        }

        //     A variant of Debug.Log that logs a warning message to the console.
        public static void LogWarning(object message, UnityEngine.Object context)
        {
            if (f_debug_bool)
                Debug.LogWarning(message, context);
        }

        /// <summary>
        /// Debug 开关
        /// 默认为开启状态true,false则不输出Debug
        /// </summary>
        public static bool IsDebug
        {
            get { return f_debug_bool; }
            set { f_debug_bool = value; }
        }
        private static bool f_debug_bool = true;


    }

}


