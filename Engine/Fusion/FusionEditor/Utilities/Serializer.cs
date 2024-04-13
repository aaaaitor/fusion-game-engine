using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Xml.Schema;

namespace FusionEditor.Utilities
{
	/// <summary>
	/// Class for file serialization.
	/// </summary>
    public static class Serializer
    {
		/// <summary>
		/// Writes the given data to the specified path.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="instance">Data instance.</param>
		/// <param name="path">Writing path.</param>
        public static void ToFile<T>(T instance, string path)
        {
			try
			{
				using var fs = new FileStream(path, FileMode.Create);
				var serializer = new DataContractSerializer(typeof(T));
				serializer.WriteObject(fs, instance);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($@"Error in data serialization on file writing: {ex.Message}");
				//TODO: log error
			}
        }

		/// <summary>
		/// Reads the data from a specified path.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="path">Reading path.</param>
		/// <returns></returns>
		public static T FromFile<T>(string path)
		{
            try
            {
                using var fs = new FileStream(path, FileMode.Open);
                var serializer = new DataContractSerializer(typeof(T));
                T instance = (T)serializer.ReadObject(fs);
				Debug.Assert(instance != null);
				
				return instance;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($@"Error in data serialization on file reading: {ex.Message}");
				//TODO: log error
				return default;
            }
        }
    }
}
