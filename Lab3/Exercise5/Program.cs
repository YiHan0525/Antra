﻿using System;
using System.Globalization;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Numerics;

namespace Exercise5
{
    class Program
    {
        public struct Complex
        {


            private Double m_real;
            private Double m_imaginary;


            private const Double LOG_10_INV = 0.43429448190325;

            public Double Real
            {
                get
                {
                    return m_real;
                }
            }

            public Double Imaginary
            {
                get
                {
                    return m_imaginary;
                }
            }

            public Double Magnitude
            {
                get
                {
                    return Complex.Abs(this);
                }
            }

            public Double Phase
            {
                get
                {
                    return Math.Atan2(m_imaginary, m_real);
                }
            }


            public static readonly Complex Zero = new Complex(0.0, 0.0);
            public static readonly Complex One = new Complex(1.0, 0.0);
            public static readonly Complex ImaginaryOne = new Complex(0.0, 1.0);


            public Complex(Double real, Double imaginary)  /* Constructor to create a complex number with rectangular co-ordinates  */
            {
                this.m_real = real;
                this.m_imaginary = imaginary;
            }

            public static Complex FromPolarCoordinates(Double magnitude, Double phase) /* Factory method to take polar inputs and create a Complex object */
            {
                return new Complex((magnitude * Math.Cos(phase)), (magnitude * Math.Sin(phase)));
            }

            public static Complex Negate(Complex value)
            {
                return -value;
            }

            public static Complex Add(Complex left, Complex right)
            {
                return left + right;
            }

            public static Complex Subtract(Complex left, Complex right)
            {
                return left - right;
            }

            public static Complex Multiply(Complex left, Complex right)
            {
                return left * right;
            }

            public static Complex Divide(Complex dividend, Complex divisor)
            {
                return dividend / divisor;
            }

            public static Complex operator -(Complex value)  /* Unary negation of a complex number */
            {

                return (new Complex((-value.m_real), (-value.m_imaginary)));
            }

            public static Complex operator +(Complex left, Complex right)
            {
                return (new Complex((left.m_real + right.m_real), (left.m_imaginary + right.m_imaginary)));

            }

            public static Complex operator -(Complex left, Complex right)
            {
                return (new Complex((left.m_real - right.m_real), (left.m_imaginary - right.m_imaginary)));
            }

            public static Complex operator *(Complex left, Complex right)
            {
                // Multiplication:  (a + bi)(c + di) = (ac -bd) + (bc + ad)i
                Double result_Realpart = (left.m_real * right.m_real) - (left.m_imaginary * right.m_imaginary);
                Double result_Imaginarypart = (left.m_imaginary * right.m_real) + (left.m_real * right.m_imaginary);
                return (new Complex(result_Realpart, result_Imaginarypart));
            }

            public static Complex operator /(Complex left, Complex right)
            {
                // Division : Smith's formula.
                double a = left.m_real;
                double b = left.m_imaginary;
                double c = right.m_real;
                double d = right.m_imaginary;

                if (Math.Abs(d) < Math.Abs(c))
                {
                    double doc = d / c;
                    return new Complex((a + b * doc) / (c + d * doc), (b - a * doc) / (c + d * doc));
                }
                else
                {
                    double cod = c / d;
                    return new Complex((b + a * cod) / (d + c * cod), (-a + b * cod) / (d + c * cod));
                }
            }



            public static Double Abs(Complex value)
            {

                if (Double.IsInfinity(value.m_real) || Double.IsInfinity(value.m_imaginary))
                {
                    return double.PositiveInfinity;
                }

                // |value| == sqrt(a^2 + b^2)
                // sqrt(a^2 + b^2) == a/a * sqrt(a^2 + b^2) = a * sqrt(a^2/a^2 + b^2/a^2)
                // Using the above we can factor out the square of the larger component to dodge overflow.


                double c = Math.Abs(value.m_real);
                double d = Math.Abs(value.m_imaginary);

                if (c > d)
                {
                    double r = d / c;
                    return c * Math.Sqrt(1.0 + r * r);
                }
                else if (d == 0.0)
                {
                    return c;  // c is either 0.0 or NaN
                }
                else
                {
                    double r = c / d;
                    return d * Math.Sqrt(1.0 + r * r);
                }
            }
            public static Complex Conjugate(Complex value)
            {
                // Conjugate of a Complex number: the conjugate of x+i*y is x-i*y 

                return (new Complex(value.m_real, (-value.m_imaginary)));

            }
            public static Complex Reciprocal(Complex value)
            {
                // Reciprocal of a Complex number : the reciprocal of x+i*y is 1/(x+i*y)
                if ((value.m_real == 0) && (value.m_imaginary == 0))
                {
                    return Complex.Zero;
                }

                return Complex.One / value;
            }


            public static bool operator ==(Complex left, Complex right)
            {
                return ((left.m_real == right.m_real) && (left.m_imaginary == right.m_imaginary));


            }
            public static bool operator !=(Complex left, Complex right)
            {
                return ((left.m_real != right.m_real) || (left.m_imaginary != right.m_imaginary));

            }


            public override bool Equals(object obj)
            {
                if (!(obj is Complex)) return false;
                return this == ((Complex)obj);
            }
            public bool Equals(Complex value)
            {
                return ((this.m_real.Equals(value.m_real)) && (this.m_imaginary.Equals(value.m_imaginary)));

            }


            public static implicit operator Complex(Int16 value)
            {
                return (new Complex(value, 0.0));
            }
            public static implicit operator Complex(Int32 value)
            {
                return (new Complex(value, 0.0));
            }
            public static implicit operator Complex(Int64 value)
            {
                return (new Complex(value, 0.0));
            }
            public static implicit operator Complex(UInt16 value)
            {
                return (new Complex(value, 0.0));
            }
            public static implicit operator Complex(UInt32 value)
            {
                return (new Complex(value, 0.0));
            }
            public static implicit operator Complex(UInt64 value)
            {
                return (new Complex(value, 0.0));
            }
            public static implicit operator Complex(SByte value)
            {
                return (new Complex(value, 0.0));
            }
            public static implicit operator Complex(Byte value)
            {
                return (new Complex(value, 0.0));
            }
            public static implicit operator Complex(Single value)
            {
                return (new Complex(value, 0.0));
            }
            public static implicit operator Complex(Double value)
            {
                return (new Complex(value, 0.0));
            }
            public static explicit operator Complex(BigInteger value)
            {
                return (new Complex((Double)value, 0.0));
            }
            public static explicit operator Complex(Decimal value)
            {
                return (new Complex((Double)value, 0.0));
            }



            public override String ToString()
            {
                return (String.Format(CultureInfo.CurrentCulture, "({0}, {1})", this.m_real, this.m_imaginary));
            }

            public String ToString(String format)
            {
                return (String.Format(CultureInfo.CurrentCulture, "({0}, {1})", this.m_real.ToString(format, CultureInfo.CurrentCulture), this.m_imaginary.ToString(format, CultureInfo.CurrentCulture)));
            }

            public String ToString(IFormatProvider provider)
            {
                return (String.Format(provider, "({0}, {1})", this.m_real, this.m_imaginary));
            }

            public String ToString(String format, IFormatProvider provider)
            {
                return (String.Format(provider, "({0}, {1})", this.m_real.ToString(format, provider), this.m_imaginary.ToString(format, provider)));
            }


            public override Int32 GetHashCode()
            {
                Int32 n1 = 99999997;
                Int32 hash_real = this.m_real.GetHashCode() % n1;
                Int32 hash_imaginary = this.m_imaginary.GetHashCode();
                Int32 final_hashcode = hash_real ^ hash_imaginary;
                return (final_hashcode);
            }


            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
            }
        }
    }

}
