/*
 * MIT License
 * 
 * Copyright (c) 2020 plexdata.de
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using Plexdata.Utilities.Attributes.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Plexdata.Utilities.Attributes.Tester
{
    class Program
    {
        static void Main(String[] args)
        {
            args = null;

            Program.TestMyClass();
            Program.TestMyStruct();
            Program.TestMyEnum();
            Program.TestMyEnumLoopByName();
            Program.TestMyEnumLoopByValue();

            Console.Write("Hit any key to finish... ");
            Console.ReadKey();
            Console.Write(Environment.NewLine);
        }

        #region Private Helpers

        [Annotation("my-class", "my-class-remarks")]
        private class MyClass
        {
            public MyClass()
            {
                // Just to suppress warnings etc.
                // Just to suppress warnings etc.
                var dummy = this.MyField;
            }

            [Annotation("my-string", "my-string-remarks")]
            public String MyString { get; set; }

            [Annotation("my-field", "my-field-remarks")]
            private readonly String MyField = "";

            [Annotation("my-const", "my-const-remarks")]
            protected const String MyConst = "my-const";

            [Annotation("my-static", "my-static-remarks")]
            public static String MyStatic = "my-static";
        }

        [Annotation("my-struct", "my-struct-remarks")]
        private struct MyStruct
        {
            public MyStruct(String privateField = "")
                           : this()
            {
                // Just to suppress warnings etc.
                this.MyField = privateField;
                var dummy = this.MyField;
            }

            [Annotation("my-string", "my-string-remarks")]
            public String MyString { get; set; }

            [Annotation("my-field", "my-field-remarks")]
            private readonly String MyField;

            [Annotation("my-static", "my-static-remarks")]
            public static String MyStatic = "my-static";
        }

        [Annotation("my-enum", "my-enum-remarks")]
        private enum MyEnum
        {
            [Annotation("my-value-1", "my-enum-remarks", MyEnum.Value1)]
            Value1,
            [Annotation("my-value-2", "my-enum-remarks", MyEnum.Value2)]
            Value2,
            [Annotation("my-value-3", "my-enum-remarks", MyEnum.Value3)]
            Value3
        }

        private static void TestMyClass()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);

            MyClass foo = null;

            var resA1 = foo.GetAnnotation<MyClass>();
            var resA2 = foo.GetAnnotation<MyClass>(nameof(MyClass.MyString));
            var resA3 = foo.GetAnnotation<MyClass>("MyField");
            var resA4 = foo.GetAnnotation<MyClass>("MyConst");
            var resA5 = foo.GetAnnotation<MyClass>(nameof(MyClass.MyStatic));

            Console.WriteLine($"{nameof(resA1)}: {resA1}");
            Console.WriteLine($"{nameof(resA2)}: {resA2}");
            Console.WriteLine($"{nameof(resA3)}: {resA3}");
            Console.WriteLine($"{nameof(resA4)}: {resA4}");
            Console.WriteLine($"{nameof(resA5)}: {resA5}");

            foo = new MyClass();

            var resB1 = foo.GetAnnotation<MyClass>();
            var resB2 = foo.GetAnnotation<MyClass>(nameof(MyClass.MyString));
            var resB3 = foo.GetAnnotation<MyClass>("MyField");
            var resB4 = foo.GetAnnotation<MyClass>("MyConst");
            var resB5 = foo.GetAnnotation<MyClass>(nameof(MyClass.MyStatic));

            Console.WriteLine($"{nameof(resB1)}: {resB1}");
            Console.WriteLine($"{nameof(resB2)}: {resB2}");
            Console.WriteLine($"{nameof(resB3)}: {resB3}");
            Console.WriteLine($"{nameof(resB4)}: {resB4}");
            Console.WriteLine($"{nameof(resB5)}: {resB5}");

            var resC1 = typeof(MyClass).GetAnnotation();
            var resC2 = foo.GetType().GetAnnotation();
            var resC3 = typeof(MyClass).GetAnnotation("MyString");
            var resC4 = foo.GetType().GetAnnotation("MyString");

            Console.WriteLine($"{nameof(resC1)}: {resC1}");
            Console.WriteLine($"{nameof(resC2)}: {resC2}");
            Console.WriteLine($"{nameof(resC3)}: {resC3}");
            Console.WriteLine($"{nameof(resC4)}: {resC4}");
        }

        private static void TestMyStruct()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);

            MyStruct foo = new MyStruct();

            var resA1 = foo.GetAnnotation<MyStruct>();
            var resA2 = foo.GetAnnotation<MyStruct>(nameof(MyStruct.MyString));
            var resA3 = foo.GetAnnotation<MyStruct>("MyField");

            Console.WriteLine($"{nameof(resA1)}: {resA1}");
            Console.WriteLine($"{nameof(resA2)}: {resA2}");
            Console.WriteLine($"{nameof(resA3)}: {resA3}");

            foo = new MyStruct();

            var resB1 = foo.GetAnnotation<MyStruct>();
            var resB2 = foo.GetAnnotation<MyStruct>(nameof(MyStruct.MyString));
            var resB3 = foo.GetAnnotation<MyStruct>("MyField");

            Console.WriteLine($"{nameof(resB1)}: {resB1}");
            Console.WriteLine($"{nameof(resB2)}: {resB2}");
            Console.WriteLine($"{nameof(resB3)}: {resB3}");

            var resC1 = typeof(MyStruct).GetAnnotation();
            var resC2 = foo.GetType().GetAnnotation();
            var resC3 = typeof(MyStruct).GetAnnotation("MyString");
            var resC4 = foo.GetType().GetAnnotation("MyString");

            Console.WriteLine($"{nameof(resC1)}: {resC1}");
            Console.WriteLine($"{nameof(resC2)}: {resC2}");
            Console.WriteLine($"{nameof(resC3)}: {resC3}");
            Console.WriteLine($"{nameof(resC4)}: {resC4}");
        }

        private static void TestMyEnum()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);

            MyEnum foo = default;

            var resA1 = foo.GetAnnotation<MyEnum>();
            var resA2 = MyEnum.Value1.GetAnnotation<MyEnum>();
            var resA3 = foo.GetAnnotation<MyEnum>("Value2");

            Console.WriteLine($"{nameof(resA1)}: {resA1}");
            Console.WriteLine($"{nameof(resA2)}: {resA2}");
            Console.WriteLine($"{nameof(resA3)}: {resA3}");

            var resB1 = typeof(MyEnum).GetAnnotation();
            var resB2 = foo.GetType().GetAnnotation();
            var resB3 = typeof(MyEnum).GetAnnotation("Value3");
            var resB4 = foo.GetType().GetAnnotation("Value1");

            Console.WriteLine($"{nameof(resB1)}: {resB1}");
            Console.WriteLine($"{nameof(resB2)}: {resB2}");
            Console.WriteLine($"{nameof(resB3)}: {resB3}");
            Console.WriteLine($"{nameof(resB4)}: {resB4}");
        }

        private static void TestMyEnumLoopByName()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);

            List<AnnotationAttribute> annotations = new List<AnnotationAttribute>();

            foreach (String current in Enum.GetNames(typeof(MyEnum)))
            {
                var attrib = typeof(MyEnum).GetAnnotation(current);
                Console.WriteLine($"{current}: {attrib}");
            }
        }

        private static void TestMyEnumLoopByValue()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);

            List<AnnotationAttribute> annotations = new List<AnnotationAttribute>();

            foreach (MyEnum current in Enum.GetValues(typeof(MyEnum)))
            {
                var attrib = current.GetAnnotation();

                Console.WriteLine($"{current}: {attrib}");
            }
        }

        #endregion
    }
}
