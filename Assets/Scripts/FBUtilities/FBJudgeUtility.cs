//  Felix-Bang：FBJudgeUtility
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
// Describe：常用判断工具返回bool
// Createtime：2018/11/29

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace FelixBang
{
	public class FBJudgeUtility
	{
        #region 方法
        /// <summary>
        /// 判段是否为邮箱
        /// </summary>
        /// <param name="value">要判断的字符串</param>
        /// <returns></returns>
        public static bool IsEmail(string value)
        {
            return Regex.IsMatch(value, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }

        /// <summary>
        /// 判断字符串是否为正整数
        /// </summary>
        /// <param name="value">判断的字符串</param>
        /// <returns>整数返回true，非整数 返回false</returns>
        public static bool IsInteger(string value)
        {
            string pattern = @"^[0-9]*[1-9][0-9]*$";
            return Regex.IsMatch(value, pattern);
        }

        /// <summary>
        /// 判断字符串是否为正数（包括小数）
        /// </summary>
        /// <param name="value"></param>
        /// <returns>正数返回true,负数返回false</returns>
        public static bool IsPositiveNumByRegex(string value)
        {
            string pattern = @"^[1-9]\d*\.\d*|0\.\d*[1-9]\d*$";
            return Regex.IsMatch(value, pattern);
        }

        /// <summary>
        /// 判断奇偶数
        /// </summary>
        /// <param name="n">要判断的整数</param>
        /// <returns>奇数返回true，偶数返回false</returns>
        public static bool IsOdd(int n)
        {
            return Convert.ToBoolean(n % 2);
        }

        #endregion
    }
}
