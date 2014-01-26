using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Net.Sockets
{
    public static class Extensions
    {
        /// <summary>
        /// Leia dados a serem recebidos através da Stream
        /// </summary>
        /// <typeparam name="T">Tipo do valor a ser lido</typeparam>
        /// <param name="networkStream">Extension</param>
        /// <param name="Sucess">Indica se a leitura de dados foi bem sucedida</param>
        /// <returns>Retorna o valor lido através da Stream</returns>
        public static T ReadSpecific<T>(this NetworkStream networkStream, out bool Sucess)
            where T : IComparable, IConvertible, IComparable<T>, IEquatable<T>
        {
            try
            {
                Sucess = true;
                byte[] buffer;
                Type typeReturn = typeof(T);
                if (typeReturn == typeof(byte))
                {
                    byte Value = (byte)(networkStream.ReadByte() & 0xFF);
                    return (T)(object)(Value);
                }
                else if (typeReturn == typeof(int))
                {
                    buffer = new byte[4];
                    if (networkStream.Read(buffer, 0, 4) == 0) { Sucess = false; }
                    int Value = BitConverter.ToInt32(buffer, 0);
                    return (T)(object)(Value);
                }
                else if (typeReturn == typeof(uint))
                {
                    buffer = new byte[4];
                    if (networkStream.Read(buffer, 0, 4) == 0) { Sucess = false; }
                    uint Value = BitConverter.ToUInt32(buffer, 0);
                    return (T)(object)(Value);
                }
                else if (typeReturn == typeof(short))
                {
                    buffer = new byte[2];
                    if (networkStream.Read(buffer, 0, 2) == 0) { Sucess = false; }
                    short Value = BitConverter.ToInt16(buffer, 0);
                    return (T)(object)(Value);
                }
                else if (typeReturn == typeof(ushort))
                {
                    buffer = new byte[2];
                    if (networkStream.Read(buffer, 0, 2) == 0) { Sucess = false; }
                    ushort Value = BitConverter.ToUInt16(buffer, 0);
                    return (T)(object)(Value);
                }
                else if (typeReturn == typeof(long))
                {
                    buffer = new byte[8];
                    if (networkStream.Read(buffer, 0, 8) == 0) { Sucess = false; }
                    long Value = BitConverter.ToInt64(buffer, 0);
                    return (T)(object)(Value);
                }
                else if (typeReturn == typeof(ulong))
                {
                    buffer = new byte[8];
                    if (networkStream.Read(buffer, 0, 8) == 0) { Sucess = false; }
                    ulong Value = BitConverter.ToUInt64(buffer, 0);
                    return (T)(object)(Value);
                }
                else if (typeReturn == typeof(double))
                {
                    buffer = new byte[8];
                    if (networkStream.Read(buffer, 0, 8) == 0) { Sucess = false; }
                    double Value = BitConverter.ToDouble(buffer, 0);
                    return (T)(object)(Value);
                }
                else if (typeReturn == typeof(char))
                {
                    buffer = new byte[2];
                    if (networkStream.Read(buffer, 0, 2) == 0) { Sucess = false; }
                    char Value = BitConverter.ToChar(buffer, 0);
                    return (T)(object)(Value);
                }
                else if (typeReturn == typeof(bool))
                {
                    bool Value = (networkStream.ReadByte() & 0x01) == 0x01;
                    return (T)(object)(Value);
                }
                else if (typeReturn == typeof(string))
                {
                    buffer = new byte[4];
                    if (networkStream.Read(buffer, 0, 4) == 0) { Sucess = false; }
                    buffer = new byte[BitConverter.ToInt32(buffer, 0)];
                    if (networkStream.Read(buffer, 0, buffer.Length) == 0) { Sucess = false; }
                    string Value = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                    return (T)(object)(Value);
                }
                else
                {
                    Sucess = false;
                    return default(T);
                }
            }
            catch
            {
                Sucess = false;
                return default(T);
            }
        }

        /// <summary>
        /// Enviar informação através da Stream
        /// </summary>
        /// <typeparam name="T">Tipo da informação a ser enviado</typeparam>
        /// <param name="networkStream">Extension</param>
        /// <param name="Value">Valor a ser enviado</param>
        /// <returns>Indica se o envio de dados foi bem sucedido</returns>
        public static bool WriteSpecific<T>(this NetworkStream networkStream, T Value)
             where T : IComparable, IConvertible, IComparable<T>, IEquatable<T>
        {
            try
            {
                Type typeReturn = typeof(T);
                if (typeReturn == typeof(byte))
                {
                    networkStream.WriteByte((byte)Convert.ChangeType(Value, typeReturn));
                }
                else if (typeReturn == typeof(int))
                {
                    byte[] Data = BitConverter.GetBytes((int)(Convert.ChangeType(Value, typeReturn)));
                    networkStream.Write(Data, 0, 4);
                }
                else if (typeReturn == typeof(uint))
                {
                    byte[] Data = BitConverter.GetBytes((int)(Convert.ChangeType(Value, typeReturn)));
                    networkStream.Write(Data, 0, 4);
                }
                else if (typeReturn == typeof(short))
                {
                    byte[] Data = BitConverter.GetBytes((short)(Convert.ChangeType(Value, typeReturn)));
                    networkStream.Write(Data, 0, 2);
                }
                else if (typeReturn == typeof(ushort))
                {
                    byte[] Data = BitConverter.GetBytes((ushort)(Convert.ChangeType(Value, typeReturn)));
                    networkStream.Write(Data, 0, 2);
                }
                else if (typeReturn == typeof(long))
                {
                    byte[] Data = BitConverter.GetBytes((long)(Convert.ChangeType(Value, typeReturn)));
                    networkStream.Write(Data, 0, 8);
                }
                else if (typeReturn == typeof(ulong))
                {
                    byte[] Data = BitConverter.GetBytes((ulong)(Convert.ChangeType(Value, typeReturn)));
                    networkStream.Write(Data, 0, 8);
                }
                else if (typeReturn == typeof(double))
                {
                    byte[] Data = BitConverter.GetBytes((double)(Convert.ChangeType(Value, typeReturn)));
                    networkStream.Write(Data, 0, 8);
                }
                else if (typeReturn == typeof(char))
                {
                    byte[] Data = BitConverter.GetBytes((char)(Convert.ChangeType(Value, typeReturn)));
                    networkStream.Write(Data, 0, 2);
                }
                else if (typeReturn == typeof(bool))
                {
                    byte Data = Convert.ToByte((bool)(Convert.ChangeType(Value, typeReturn)));
                    networkStream.WriteByte(Data);
                }
                else if (typeReturn == typeof(string))
                {
                    String value = Convert.ChangeType(Value, typeReturn) as string;
                    byte[] valuebyte = Encoding.UTF8.GetBytes(value);
                    byte[] sizevalue = BitConverter.GetBytes(valuebyte.Length);
                    networkStream.Write(sizevalue, 0, sizevalue.Length);
                    networkStream.Write(valuebyte, 0, valuebyte.Length);
                }
                else
                { return false; }

                return true;
            }
            catch
            { return false; }
        }
    }
}
