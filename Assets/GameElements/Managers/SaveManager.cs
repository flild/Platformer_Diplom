using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Platformer
{
    public static class SaveManager
    {
        public static void SaveData<T>(T data, string filePath) where T : class
        {
            var formatter = new BinaryFormatter();
            var file = File.OpenWrite(Application.persistentDataPath + filePath);
            formatter.Serialize(file, data);
            file.Close();
        }
        public static T LoadData<T>(string filePath) where T : class, new()
        {
            var formatter = new BinaryFormatter();
            T data;
            if(File.Exists(Application.persistentDataPath + filePath))
            {
                var file = File.OpenRead(Application.persistentDataPath + filePath);
                //проверку на exist
                data = (T)formatter.Deserialize(file);
                file.Close();
            }
            else
            {
                data = new();
            }

            return data;
        }
    }
}

