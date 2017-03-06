using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SamplesCsLang;

namespace SamplesCsLang
{
    // 拡張メソッド C#3.0より

    public static class ExtensionsString
    {
        // staticクラスに、staticメソッドを宣言する
        // 第一引数にthisと型を指定する、引数名は何でもよい
        public static string Me(this string temp)
        {
            return "I'm Me.";
        }

        public static string Me(this string temp, string name)
        {
            return "I'm Me." + name;
        }

        public static DateTime NextDay(this DateTime temp)
        {
            var t = DateTime.Today;
            return new DateTime(t.Year, t.Month, t.Day + 1);
        }
    }

    [TestClass]
    public class ExtensionMethod
    {
        [TestMethod]
        public void TestExtensionMethod()
        {
            Console.WriteLine("".Me());
            Console.WriteLine("".Me("Taro"));

            Console.WriteLine(DateTime.Today.NextDay());
        }

    }

}
