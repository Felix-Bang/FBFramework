//  Felix-Bang：FBAndroidUtility
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
// Describe：android常用方法
// CreateTime：2018/12/20

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace FelixBang
{
	public sealed class FBAndroidUtility
	{
        // 配置文件权限：
        //      GPS定位：<uses-permission android:name="android.permission.ACCESS_FINE_LOCATION" />
        //     粗略位置：<uses-permission android:name="android.permission.ACCESS_COARSE_LOCATION" />
        //         网络：<uses-permission android:name="android.permission.INTERNET" />
        //         相机：<uses-permission android:name="android.permission.CAMERA" />
        //     写入SD卡：<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
        //   读取通讯录：<uses-permission android:name="android.permission.READ_CONTACTS" />
        //         震动：<uses-permission android:name="android.permission.VIBRATE" />
        //         电话：<uses-permission android:name="android.permission.CALL_PHONE" />
        // 安装应用程序：<uses-permission android:name="android.permission.INSTALL_PACKAGES" />
        // WiFi网络状态：<uses-permission android:name="android.permission.ACCESS_WIFI_STATE" />
       
        #region Method
        public static void ShowToast(string text)
        {
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
            AndroidJavaObject CurrentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); ;
            AndroidJavaObject Context = CurrentActivity.Call<AndroidJavaObject>("getApplicationContext");

            CurrentActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", text);
                Toast.CallStatic<AndroidJavaObject>("makeText", Context, javaString, Toast.GetStatic<int>("LENGTH_SHORT")).Call("show");
            }));
        }

        /// <summary>
        /// 调用Android设备的相机进行拍照。
        /// </summary>
        /// <param name="photoNameWithoutExtension">照片名称（不含扩展名）。</param>
        public static void TakePhoto(string photoNameWithoutExtension)
        {
            // 获取Android类实例。
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaClass MediaStore = new AndroidJavaClass("android.provider.MediaStore");
            AndroidJavaClass Uri = new AndroidJavaClass("android.net.Uri");
            AndroidJavaClass Environment = new AndroidJavaClass("android.os.Environment");

            // 获取当前Activity.
            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            // 相当于Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
            AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent", MediaStore.GetStatic<AndroidJavaObject>("ACTION_IMAGE_CAPTURE"));

            // 获取sd卡路径，相当于String sdPath = Environment.getExternalStorageDirectory().getAbsolutePath();
            AndroidJavaObject sdPath = new AndroidJavaObject("java.lang.String", Environment.CallStatic<AndroidJavaObject>("getExternalStorageDirectory").Call<AndroidJavaObject>("getAbsolutePath"));

            // 将路径转化为java String。
            AndroidJavaObject imagePath = new AndroidJavaObject("java.lang.String", "/Android/data/" + Application.productName + "/files/" + photoNameWithoutExtension + ".jpg");

            // 相当于imagePath = sdPath + imagePath；
            imagePath = sdPath.Call<AndroidJavaObject>("concat", imagePath);

            // 相当于File targetImageFile = new File(imagePath);
            AndroidJavaObject targetImageFile = new AndroidJavaObject("java.io.File", imagePath);

            // 相当于intent.putExtra(MediaStore.EXTRA_OUTPUT,Uri.fromFile(targetImgFile));
            intent.Call<AndroidJavaObject>("putExtra", MediaStore.GetStatic<AndroidJavaObject>("EXTRA_OUTPUT"), Uri.CallStatic<AndroidJavaObject>("fromFile", targetImageFile));
            currentActivity.Call("startActivity", intent);
        }

        public static void SaveToGallery(Texture2D tex2D)
        {
            var dir = "/mnt/sdcard/DCIM/" + Application.productName + "/";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var bytes = tex2D.EncodeToJPG(100);
            var path = dir + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            File.WriteAllBytes(path, bytes);

            // ======================================================
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaClass Intent = new AndroidJavaClass("android.content.Intent");
            AndroidJavaClass Uri = new AndroidJavaClass("android.net.Uri");

            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
            context.Call("sendBroadcast", new AndroidJavaObject("android.content.Intent", Intent.GetStatic<AndroidJavaObject>("ACTION_MEDIA_SCANNER_SCAN_FILE"), Uri.CallStatic<AndroidJavaObject>("parse", "file://" + path)));
            // ======================================================
        }

        /// <summary>
        /// 打开网页连接
        /// </summary>
        /// <param name="url">网址</param>
        public static void OpenURL(string url)
        {
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaClass Intent = new AndroidJavaClass("android.content.Intent");
            AndroidJavaClass Uri = new AndroidJavaClass("android.net.Uri");

            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent", Intent.GetStatic<AndroidJavaObject>("ACTION_VIEW"), Uri.CallStatic<AndroidJavaObject>("parse", url));
            currentActivity.Call("startActivity", intent);
        }

        /// <summary>
        /// 打开电话拨号界面，不直接拨打电话。
        /// </summary>
        /// <param name="phoneNumber"></param>
        public static void DialPhone(string phoneNumber)
        {
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaClass Intent = new AndroidJavaClass("android.content.Intent");
            AndroidJavaClass Uri = new AndroidJavaClass("android.net.Uri");

            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent", Intent.GetStatic<AndroidJavaObject>("ACTION_DIAL"), Uri.CallStatic<AndroidJavaObject>("parse", "tel:" + phoneNumber));
            currentActivity.Call("startActivity", intent);
        }

        /// <summary>
        /// 直接拨打电话，不打开拨号界面。
        /// </summary>
        /// <param name="phoneNumber"></param>
        public static void CallPhone(string phoneNumber)
        {
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaClass Intent = new AndroidJavaClass("android.content.Intent");
            AndroidJavaClass Uri = new AndroidJavaClass("android.net.Uri");

            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent", Intent.GetStatic<AndroidJavaObject>("ACTION_CALL"), Uri.CallStatic<AndroidJavaObject>("parse", "tel:" + phoneNumber));
            currentActivity.Call("startActivity", intent);
        }

        /// <summary>
        /// 在应用市场打开App。
        /// </summary>
        /// <param name="appId">
        /// appId 为 "Bundle Identifier" 的值（一般为 "com.公司名.应用名"）。
        /// 如果是本应用，可用 Application.bundleIdentifier 来获取。
        /// 如果应用正在研发，还没有投放到应用市场上，可用新浪微博的 appId 即 "com.sina.weibo" 来测试。
        /// </param>
        public static void OpenAppInMarket(string appId)
        {
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); ;
            AndroidJavaClass Intent = new AndroidJavaClass("android.content.Intent");
            AndroidJavaClass Uri = new AndroidJavaClass("android.net.Uri");

            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject jstr_content = new AndroidJavaObject("java.lang.String", "market://details?id=" + appId);
            AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent", Intent.GetStatic<AndroidJavaObject>("ACTION_VIEW"), Uri.CallStatic<AndroidJavaObject>("parse", jstr_content));
            currentActivity.Call("startActivity", intent);
        }

        /// <summary>
        /// APK安装。
        /// </summary>
        /// <param name="filePath">filePath 是 apk 文件的本地路径（包含 .apk 后缀名）。</param>
        public static void APKInstall(string filePath)
        {
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); ;
            AndroidJavaClass Intent = new AndroidJavaClass("android.content.Intent");
            AndroidJavaClass Uri = new AndroidJavaClass("android.net.Uri");

            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent", Intent.GetStatic<AndroidJavaObject>("ACTION_VIEW"));
            intent.Call<AndroidJavaObject>("setDataAndType", Uri.CallStatic<AndroidJavaObject>("fromFile", new AndroidJavaObject("java.io.File", new AndroidJavaObject("java.lang.String", filePath))), new AndroidJavaObject("java.lang.String", "application/vnd.android.package-archive"));
            currentActivity.Call("startActivity", intent);
        }

        /// <summary>
        /// 打开安卓设备的其它应用
        /// </summary>
        /// <param name="bundleID">目标apk的包名</param>
        public static void OpenApk(string bundleID)
        {
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject packageManager = currentActivity.Call<AndroidJavaObject>("getPackageManager");
            AndroidJavaObject intent = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage", bundleID);
            if (null != intent)
            {
                currentActivity.Call("startActivity", intent);
            }
            else
            {
                Debug.LogError("intent is null,please check the bundleID!");
            }
        }

        /// <summary>
        /// 返回桌面。
        /// </summary>
        public static void OnBackHome()
        {
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); ;
            AndroidJavaClass Intent = new AndroidJavaClass("android.content.Intent");

            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent", Intent.GetStatic<AndroidJavaObject>("ACTION_MAIN"));
            intent.Call<AndroidJavaObject>("addCategory", Intent.GetStatic<AndroidJavaObject>("CATEGORY_HOME"));
            currentActivity.Call("startActivity", intent);
        }

   



        #endregion
    }
}
