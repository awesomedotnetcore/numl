﻿// file:	Utils\Xml.cs
//
// summary:	Implements the XML class
using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace numl.Utils
{
    /// <summary>Xml serialization helper.</summary>
    public static class Xml
    {
        /// <summary>Save object to file.</summary>
        /// <tparam name="T">Generic type parameter.</tparam>
        /// <param name="stream">The stream.</param>
        /// <param name="o">object.</param>
        public static void Save<T>(Stream stream, T o)
        {
            Save(stream, o, typeof(T));
        }
        /// <summary>Save object to file.</summary>
        /// <param name="stream">The stream.</param>
        /// <param name="o">object.</param>
        /// <param name="t">type.</param>
        public static void Save(Stream stream, object o, Type t)
        {
            XmlSerializer serializer = new XmlSerializer(t);

            serializer.Serialize(stream, o);
        }
        /// <summary>Converts an o to an XML string.</summary>
        /// <tparam name="T">Generic type parameter.</tparam>
        /// <param name="o">object.</param>
        /// <returns>o as a string.</returns>
        public static string ToXmlString<T>(T o)
        {
            return ToXmlString(o, typeof(T));
        }
        /// <summary>Converts this object to an XML string.</summary>
        /// <param name="o">object.</param>
        /// <param name="t">type.</param>
        /// <returns>The given data converted to a string.</returns>
        public static string ToXmlString(object o, Type t)
        {
            XmlSerializer serializer = new XmlSerializer(t);
            StringWriter textWriter = new StringWriter();

            serializer.Serialize(textWriter, o);
            return textWriter.ToString();
        }
        /// <summary>Loads the given stream.</summary>
        /// <tparam name="T">Generic type parameter.</tparam>
        /// <param name="stream">The stream.</param>
        /// <returns>A T.</returns>
        public static T Load<T>(Stream stream)
        {
            var o = Load(stream, typeof(T));
            return (T)o;
        }
        /// <summary>Loads.</summary>
        /// <param name="stream">The stream.</param>
        /// <param name="t">type.</param>
        /// <returns>An object.</returns>
        public static object Load(Stream stream, Type t)
        {
            XmlSerializer serializer = new XmlSerializer(t);
            var o = serializer.Deserialize(stream);
            return o;
        }
        /// <summary>Loads XML string.</summary>
        /// <tparam name="T">Generic type parameter.</tparam>
        /// <param name="xml">The XML.</param>
        /// <returns>The XML string.</returns>
        public static T LoadXmlString<T>(string xml)
        {
            var o = LoadXmlString(xml, typeof(T));
            return (T)o;
        }
        /// <summary>Loads XML string.</summary>
        /// <param name="xml">The XML.</param>
        /// <param name="t">type.</param>
        /// <returns>The XML string.</returns>
        public static object LoadXmlString(string xml, Type t)
        {
            TextReader reader = new StringReader(xml);
            XmlSerializer serializer = new XmlSerializer(t);
            var o = serializer.Deserialize(reader);
            return o;
        }
        /// <summary>Writes.</summary>
        /// <tparam name="T">Generic type parameter.</tparam>
        /// <param name="writer">The writer.</param>
        /// <param name="thing">The thing.</param>
        public static void Write<T>(XmlWriter writer, T thing)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(writer, thing);
        }
        /// <summary>Reads the given reader.</summary>
        /// <tparam name="T">Generic type parameter.</tparam>
        /// <param name="reader">The reader.</param>
        /// <returns>A T.</returns>
        public static T Read<T>(XmlReader reader)
        {
            XmlSerializer dserializer = new XmlSerializer(typeof(T));
            T item = (T)dserializer.Deserialize(reader);
            // move to next thing
            reader.Read();
            return item;
        }
    }
}
