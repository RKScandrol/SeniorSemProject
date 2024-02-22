using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }

    public static string getJsonString() {
        string[] paths = getJsonFiles();

        string[] lines = new string[0];

        foreach (string path in paths){
            lines = getLines(path).Concat(lines).ToArray();
        }

        return compineLines(lines);
    }

    private static string[] getJsonFiles() {
        string path = Application.dataPath + "/Scripts/JsonItems/jsonFiles.txt";
        string[] lines = File.ReadAllLines(path);
        return lines;
    }

    private static string[] getLines(string path){
        string[] lines = File.ReadAllLines(Application.dataPath + path);
        return lines;
    }

    private static string compineLines(string[] lines) {
        string jsonStr = "";
        foreach (string l in lines) {
            jsonStr += l;
        }
		return jsonStr;
    }

}
