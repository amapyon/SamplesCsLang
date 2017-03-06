using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SamplesCsLang
{
    [TestClass]
    public class AttributeSample
    {
        [TestMethod]
        public void TestMyAttribute()
        {
            Console.WriteLine(typeof(MyClazz1).Name);
            var classInfo = typeof(MyClazz1) as MemberInfo;
            foreach (var item in classInfo.GetCustomAttributes<MyClazzAttribute>())
            {
                Console.WriteLine(item.GetName());
                Console.WriteLine(item.Option1);
                Console.WriteLine(item.Option2);

            }

            Console.WriteLine("--GetMethods--");
            foreach (var item in typeof(MyClazz1).GetMethods())
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("--GetMethods with Attribute--");

            var methodInfos = typeof(MyClazz1).GetMethods() as MethodInfo[];
            foreach (var methodInfo in methodInfos)
            {
                Console.WriteLine($"{methodInfo.IsPrivate}/{methodInfo.IsPrivate} {methodInfo.Name}");
                var m = methodInfo.GetCustomAttributes<MyMethodsAttribute>();
                foreach (var a in m)
                {
                    Console.WriteLine(" ↑" + a.ToString());
                }

            }

        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    class MyClazzAttribute : Attribute
    {
        private string _name;
        public string Option1 { get; set; }
        public int Option2 { get; set; }

        public MyClazzAttribute(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }
    }

    [AttributeUsage(AttributeTargets.Method,AllowMultiple = true)]
    class MyMethodsAttribute : Attribute
    {
        private static int count = 0;
        public override string ToString()
        {
            return $"MyMehotds[{count++}]";
        }

    }


    [MyClazz("TEST", Option1 = "Option1の文字", Option2 = 99)]
    class MyClazz1
    {
        [MyMethods]
        public void method1() { }

        [MyMethods]
        public void method2() { }

        [MyMethods]
        [MyMethods]
        public void method3() { }
    }
}
