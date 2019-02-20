//  Felix-Bang：FBDateTimeUtility
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
// Describe：日期操作类：时间戳与普通时间的相互转换
// Createtime：2018/11/29

using UnityEngine;
using System;

namespace FelixBang
{
    public sealed class FBDateTimeUtility
    {
        /// <summary>
        /// 时间戳转换为普通时间，如：2018-01-01 12:00:00。
        /// </summary>
        /// <param name="timeStamp">Unix时间戳格式。</param>
        /// <param name="isAll"> 是否返回完整时间戳 </param>
        /// <returns>返回普通时间格式。</returns>
        public static string ConvertToUniversalTime(string timeStamp, bool isAll = true)
        {
            DateTime dtResult = ConvertToDateTime(timeStamp);
            if (isAll)
                return dtResult.ToString("yyyy-MM-dd HH:mm:ss");
            else
                return dtResult.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 时间戳转换为DateTime，如：12/12/2018 12:30:28 PM
        /// </summary>
        /// <param name="timeStamp">Unix时间戳格式。</param>
        /// <returns>返回C#格式时间。</returns>
        public static DateTime ConvertToDateTime(string timeStamp)
        {
            if (string.IsNullOrEmpty(timeStamp))
                return default(DateTime);

            long time;

            if (timeStamp.Length < 18)
                time = long.Parse(timeStamp + "0000000");
            else
                time = long.Parse(timeStamp);

            TimeSpan toNow = new TimeSpan(time);
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return startTime.Add(toNow);
        }

        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式。
        /// </summary>
        /// <param name="time">DateTime时间格式。</param>
        /// <returns>Unix时间戳格式。</returns>
        public static int ConvertToTimeStamp(DateTime time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        /// <summary>
        /// 根据单位将时间转换为毫秒
        /// </summary>
        /// <param name="time">要转化的时间</param>
        /// <param name="unit">要转化的时间单位</param>
        /// <returns>毫秒</returns>
        public static double SwitchTimeToMS(double time, FBTimeUnit unit = FBTimeUnit.Millisecond)
        {
            double millisecond;

            switch (unit)
            {
                case FBTimeUnit.Millisecond:
                    millisecond = time;
                    break;
                case FBTimeUnit.Second:
                    millisecond = time * 1000;
                    break;
                case FBTimeUnit.Minute:
                    millisecond = time * 1000 * 60;
                    break;
                case FBTimeUnit.Hour:
                    millisecond = time * 1000 * 60 * 60;
                    break;
                case FBTimeUnit.Day:
                    millisecond = time * 1000 * 60 * 60 * 24;
                    break;
                default:
                    Debug.Log("Add Task unit type error...");
                    millisecond = time;
                    break;
            }

            return millisecond;
        }
    }

    public enum FBTimeUnit
    {
        Millisecond,
        Second,
        Minute,
        Hour,
        Day
    }
}
