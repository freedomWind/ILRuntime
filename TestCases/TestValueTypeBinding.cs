using System;
using ILRuntimeTest.TestFramework;

namespace TestCases
{
    public class TestValueTypeBinding
    {
        class TestValueTypeCls
        {
            public TestVectorStruct A;
            public Vector3 B;
        }
        public static void Test00()
        {
            var a = TestVector3.One;
            a.X += 100;

            Console.WriteLine(a.ToString());
        }

        public static void Test01()
        {
            TestVector3 vec = new TestVector3(100, 1, 0);
            TestVector3.One.X += vec.X;

            Console.WriteLine(TestVector3.One.ToString());
        }

        public static void Test02()
        {
            TestVector3 vec = new TestVector3(100, 1, 0);
            vec += TestVector3.One;

            Console.WriteLine(vec.ToString());
        }

        public static object Test03()
        {
            TestVector3[] a = new TestVector3[10000];
            for (int i = 0; i < 10000; i++)
            {
                a[i] = TestVector3.One;
            }

            return a;
        }

        public static void UnitTest_10022()
        {
            TestVector3 pos = TestVector3.One;

            pos.X += 1;
            pos.Y += 2;

            if (pos.X > 10)
                pos.X = 10;
            if (pos.X < -10)
                pos.X = -10;
            if (pos.Y > 10)
                pos.Y = 10;
            if (pos.Y < -10)
                pos.Y = -10;

            var pos2 = tttt(pos);
            Console.WriteLine("pos.x = " + pos.X);
            Console.WriteLine("pos2.x = " + pos2.X);

            if (pos.X == pos2.X)
                throw new Exception("Value Type Violation");
        }

        static TestVector3 tttt(TestVector3 a)
        {
            a.X = 12345;
            return a;
        }

        public static void UnitTest_10023()
        {
            TestVectorStruct a;
            a = Sub10023();
            TestVector3 pos = a.C;
            pos.X += 123;

            TestVector3 pos2 = a.B.Vector;
            pos2.X -= 120;

            Console.WriteLine("pos.x=" + pos.X);
            Console.WriteLine("a.C.x=" + a.C.X);
            if (pos.X == a.C.X)
                throw new Exception("Value Type Violation");
            Console.WriteLine("pos2.x=" + pos2.X);
            Console.WriteLine("a.B.Vector.x=" + a.B.Vector.X);
            if (pos2.X == a.B.Vector.X)
                throw new Exception("Value Type Violation");

        }

        static TestVectorStruct Sub10023()
        {
            TestVectorStruct a;
            a.A = 123;
            a.C = TestVector3.One;
            a.B = new TestVectorStruct2();
            a.B.Vector = TestVector3.One * 123;
            return a;
        }

        public static void UnitTest_10024()
        {
            TestVectorStruct a;
            a = Sub10023();

            Sub10024(a);
        }

        static void Sub10024(object obj)
        {
            TestVectorStruct a = (TestVectorStruct)obj;
            Console.WriteLine("a.B.Vector.x=" + a.B.Vector.X);
        }

        public static void UnitTest_10025()
        {
            TestValueTypeCls cls = new TestValueTypeCls();
            cls.A = Sub10023();
            cls.B = Vector3.One;

            Console.WriteLine("a.B.Vector.x=" + cls.A.B.Vector.X);
            Console.WriteLine("cls.B.x=" + cls.B.x);
        }
    }
}