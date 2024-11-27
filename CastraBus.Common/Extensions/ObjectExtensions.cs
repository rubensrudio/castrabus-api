using System.ComponentModel;
using System.Reflection;

namespace CastraBus.Common.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Realiza a conversao de qualquer objeto para um Tipo "T" do generics
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks>Caso o objeto seja nulo é retornado o valor Default para o objeto</remarks>
        public static T Parse<T>(this object value)
        {
            T result;

            // we are not going to handle exception here
            // if you need SafeParse then you should create
            // another method specially for that.
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));

            if (string.IsNullOrEmpty(value?.ToString()) || DBNull.Value.Equals(value))
            {
                if (typeof(T) == int.MinValue.GetType())
                    result = (T)tc.ConvertFrom(int.MinValue.ToString());
                else if (typeof(T) == long.MinValue.GetType())
                    result = (T)(long.MinValue as object);
                else if (typeof(T) == double.MinValue.GetType())
                    result = (T)(double.MinValue as object);
                else if (typeof(T) == decimal.MinValue.GetType())
                    result = (T)(decimal.MinValue as object);
                else if (typeof(T) == float.MinValue.GetType())
                    result = (T)(float.MinValue as object);
                else if (typeof(T) == DateTime.MinValue.GetType())
                    result = (T)tc.ConvertFrom(DateTime.MinValue.ToString());
                else if (typeof(T) == true.GetType())
                    result = (T)tc.ConvertFrom("false");
                else
                    result = (T)tc.ConvertFrom(string.Empty);

                return result;
            }

            if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                try
                {
                    result = (T)tc.ConvertFrom(value.ToString());
                }
                catch
                {
                    result = (T)tc.ConvertFrom("");
                }
            }
            else
            {
                try
                {
                    result = (T)tc.ConvertFrom(value.ToString());
                }
                catch
                {
                    var converted = Convert.ToString(value);
                    result = (T)tc.ConvertFrom(converted);
                }
            }

            return result;
        }

        /// <summary>
        /// Verifica se a conversao de um valor para um Tipo T e possivel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public static bool CanConvertTo<T>(this object objeto)
        {
            try
            {
                TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
                tc.ConvertFrom(objeto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Verify if a number is between 2 values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static bool IsBetween<T>(this T item, T start, T end)
        {
            return Comparer<T>.Default.Compare(item, start) >= 0
                && Comparer<T>.Default.Compare(item, end) <= 0;
        }

        public static object Parse(this object value, PropertyInfo property)
        {
            object finalObj = null;
            if (property == null) return null;
            finalObj = Parse(value, property.PropertyType);
            return finalObj;
        }

        public static object Parse(this object value, Type type)
        {
            object finalObj;

            var typecode = Type.GetTypeCode(type);
            var isGeneric = type.IsGenericType;
            if (isGeneric &&
                type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // If it is NULLABLE, then get the underlying type. eg if "Nullable<int>" then this will return just "int"
                var genericType = type.GetGenericArguments()[0];
                typecode = Type.GetTypeCode(genericType);
            }
            switch (typecode)
            {
                case TypeCode.Boolean:
                    finalObj = (Type.GetTypeCode(value.GetType()) == TypeCode.Boolean) ?
                        isGeneric ? value.Parse<bool?>() : value.Parse<bool>() :
                        isGeneric ? value.Parse<int?>() == 1 : value.Parse<int>() == 1;
                    break;
                case TypeCode.Byte:
                    finalObj = isGeneric ? value.Parse<byte?>() : value.Parse<byte>();
                    break;
                case TypeCode.Char:
                    finalObj = isGeneric ? value.Parse<char?>() : value.Parse<char>();
                    break;
                case TypeCode.DateTime:
                    finalObj = isGeneric ? value.Parse<DateTime?>() : value.Parse<DateTime>();
                    break;
                case TypeCode.DBNull:
                    return null;
                //break;
                case TypeCode.Decimal:
                    finalObj = isGeneric ? value.Parse<decimal?>() : value.Parse<decimal>();
                    break;
                case TypeCode.Double:
                    finalObj = isGeneric ? value.Parse<double?>() : value.Parse<double>();
                    break;
                case TypeCode.Int16:
                    finalObj = isGeneric ? value.Parse<Int16?>() : value.Parse<Int16>();
                    break;
                case TypeCode.Int32:
                    finalObj = isGeneric ? value.Parse<int?>() : value.Parse<int>();
                    break;
                case TypeCode.Int64:
                    finalObj = isGeneric ? value.Parse<long?>() : value.Parse<long>();
                    break;
                case TypeCode.Object:
                    finalObj = value.Parse<object>();
                    break;
                case TypeCode.SByte:
                    finalObj = isGeneric ? value.Parse<sbyte?>() : value.Parse<sbyte>();
                    break;
                case TypeCode.Single:
                    finalObj = isGeneric ? value.Parse<Single?>() : value.Parse<Single>();
                    break;
                case TypeCode.String:
                    finalObj = value.Parse<string>();
                    break;
                case TypeCode.UInt16:
                    finalObj = isGeneric ? value.Parse<UInt16?>() : value.Parse<UInt16>();
                    break;
                case TypeCode.UInt32:
                    finalObj = isGeneric ? value.Parse<UInt32?>() : value.Parse<UInt32>();
                    break;
                case TypeCode.UInt64:
                    finalObj = isGeneric ? value.Parse<UInt64?>() : value.Parse<UInt64>();
                    break;
                default:
                    finalObj = value.Parse<object>();
                    break;
            }

            return finalObj;
        }
    }
}
