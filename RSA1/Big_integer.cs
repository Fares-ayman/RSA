using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace RSA1
{
    class Big_Integer
    {
        string Data;
        int Data_size;

        public Big_Integer()
        {

        }
        public Big_Integer(string s)
        {
            Data = s;
            Data_size = s.Length;
        }
        public Big_Integer(int[] arr)
        {
            Data = string.Join("", arr);
            Data_size = arr.Length;
        }

        public string Add(string A, string B)
        {

            if (A.Length < B.Length)
            {
                string temp = A;
                A = B;
                B = temp;
            }

            StringBuilder result = new StringBuilder(A);
           

            int Length_A = A.Length;
            int Length_B = B.Length;

            int Diffrence = Length_A - Length_B;

            int carry = 0;
            for (int i = B.Length - 1; i >= 0; i--)
            {
                int x = ((int)(A[i + Diffrence] - '0') + (int)(B[i] - '0') + carry);

                result[i+Diffrence]=(char)(x % 10 + '0');
                carry = x / 10;
            }

            for (int i = Diffrence - 1; i >= 0; i--)
            {
                int x = ((int)(A[i] - '0') + carry);

                result[i]=(char)(x % 10 + '0');
                carry = x / 10;
            }

            if (carry > 0)
            {
                return (carry + result.ToString());
            }
            else if (result[0] != '0')
            {
                return result.ToString();
            }


            StringBuilder res = new StringBuilder();
            bool zero = true;
            int result_length = result.Length;

            for (int i = 0; i < result_length; i++)
            {
                if (zero && result[i] == '0')
                {
                    continue;
                }
                else
                {
                    zero = false;
                    res.Append(result[i]);

                }
            }
            if (zero)
            {
                res.Append("0");
                return res.ToString();
            }
            else
            {
                return res.ToString();
            }
        }

        public bool isSmaller(string str1, string str2)
        {
            if (str1.Length < str2.Length)
                return true;
            else if (str1.Length > str2.Length)
                return false;

            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] < str2[i])
                    return true;
                else if (str1[i] > str2[i])
                    return false;
            }

            return false;
        }

        public string Sub(string str1, string str2)
        {
            if (isSmaller(str1, str2))
            {
                string temp = str1;
                str1 = str2;
                str2 = temp;
            }

            StringBuilder result = new StringBuilder(str1);
            int Diffrence = str1.Length - str2.Length;
            int str2_length = str2.Length;
            int carry = 0;
            for (int i = str2_length - 1; i >= 0; i--)
            {
                int x = ((int)(str1[i + Diffrence] - '0') - (int)(str2[i] - '0') - carry);

                if (x < 0)
                {
                    x = x + 10;
                    carry = 1;
                }
                else
                    carry = 0;

                result[i+Diffrence]=(char)(x + '0');
            }

            for (int i = Diffrence - 1; i >= 0; i--)
            {
                int x = ((int)(str1[i] - '0') - carry);
                if (x < 0)
                {
                    x = x + 10;
                    carry = 1;
                }
                else
                    carry = 0;

                result[i]=(char)(x + '0');
            }

            if (result[0] != '0')
            {
                return result.ToString();
            }

            StringBuilder res = new StringBuilder();
            bool zero = true;
            int result_length = result.Length;
        

            for (int i = 0; i < result_length; i++)
            {
                if (zero && result[i] == '0')
                {
                    continue;
                }
                else
                {
                    zero = false;
                    res.Append(result[i]);
                }
            }
            if (zero)
            {
                res.Append("0");
                return res.ToString();
            }
            else
            {
                return res.ToString();
            }

        }

        public string Multiply(string A, string B)
        {
            int n;
            int Length_A = A.Length;
            int Length_B = B.Length;
            StringBuilder a = new StringBuilder();
            StringBuilder b = new StringBuilder();
            if (Length_A < Length_B)
            {
                for (int i = 0; i < Length_B - Length_A; i++)
                    a.Append("0");
                a.Append(A);
                b.Append(B);
                n = Length_B;
            }
            else
            {
                for (int i = 0; i < Length_A - Length_B; i++)
                    b.Append("0");
                a.Append(A);
                b.Append(B);
                n = Length_A;
            }

            A = a.ToString();
            B = b.ToString();
            //base cases
            if (n == 0)
            {
                return "0";
            }

            if (n <= 1)
            {
                return ((A[0] - '0') * (B[0] - '0')).ToString();
            }

            int first_half = n / 2;
            int second_half = n - first_half;

            string A_left = "", A_right = "", B_left = "", B_right = "";

            A_left = A.Substring(0, first_half);
            A_right = A.Substring(first_half, second_half);

            B_left = B.Substring(0, first_half);
            B_right = B.Substring(first_half, second_half);

            string m1 = Multiply(A_left, B_left); //bd
            string m2 = Multiply(A_right, B_right); //ac
            string m3 = Multiply(Add(A_left, A_right), Add(B_left, B_right));

            string Lama = Multiply_By_10(m1, 2 * (n - n / 2));
            Lama = Add(Lama, m2);
            string Fares = Sub(m3, m1);
            m3 = Fares;
            Fares = Sub(m3, m2);
            string Alyaa = Multiply_By_10(Fares, (n - n / 2));

            return Add(Lama, Alyaa);
        }

        public string Multiply_By_10(string s, int N)
        {
            StringBuilder S = new StringBuilder();
            S.Append(s);
            for (int i = 0; i < N; i++)
            {
                S.Append("0");
            }
            return S.ToString();
        }

        public string[] div(string a, string b)
        {
            int Length_a = a.Length;
            int Length_b = b.Length;
            if (Length_b > Length_a)
            {
                string[] q_r = new string[2];
                q_r[0] = "0";
                q_r[1] = a;
                return q_r;
            }
            else if (Length_b == Length_a)
            {
                for (int i = 0; i < Length_a; i++)
                {
                    if (b[i] > a[i])
                    {
                        string[] q_r = new string[2];
                        q_r[0] = "0";
                        q_r[1] = a;
                        return q_r;
                    }
                    else if (b[i] < a[i])
                    {
                        break;
                    }
                }
            }
            string[] q_r1 = new string[2];
            q_r1 = div(a, Add(b, b));
            q_r1[0] = Add(q_r1[0], q_r1[0]);
            int Length_r = q_r1[1].Length;
            if (Length_r < Length_b)
            {
                return q_r1;
            }
            else if (Length_r == Length_b)
            {
                string r = q_r1[1];
                for (int i = 0; i < Length_r; i++)
                {
                    if (r[i] < b[i])
                    {
                        return q_r1;
                    }
                    else if (r[i] > b[i])
                        break;

                    
                }
            }


            q_r1[0] = Add(q_r1[0], "1");
            q_r1[1] = Sub(q_r1[1], b);

            return q_r1;


        }

        public string mod_of_pow(string B, string P, string M)
        {
            bool odd;
            int length_p = P.Length;
            string new_p;
    
            //base case
            if (length_p == 1)
                if (P[0] == '1')
                {
                    string[] res = div(B, M);
                    return res[1];
                }
            string[] result = div(P, "2");

            if (result[1] == "0")
            {
                odd = false;
                new_p = result[0];
            }
            else
            {
                odd = true;
                new_p = result[0];
            }

            string mod = mod_of_pow(B, new_p, M);

            if (odd == true)
            {
                string mul = Multiply(mod, mod);
                string[] rem = div(B, M);
                string mul1 = Multiply(mul, rem[1]);
                string[] rem1 = div(mul1, M);
                return rem1[1];
            }
            else
            {
                string mul = Multiply(mod, mod);
                string[] rem = div(mul, M);
                return rem[1];
            }
        }
        public string encrypt(string B, string P, string M)
        {
            return mod_of_pow(B, P, M);
        }
        public string decrypt(string B, string P, string M)
        {
            return mod_of_pow(B, P, M);
        }
    }
}