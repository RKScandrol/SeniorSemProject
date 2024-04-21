using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor.Search;

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

    public static Item[] getLootTable() {

        string[] filePaths = getJsonFiles();

        Item[] items = new Item[0];

        foreach (string path in filePaths) {

            string jsonStr = compineLines(getLines(path));
            string sub = path.Substring(19);

            switch (sub) {
             
                case "HealthPotions.json":
                    items = FromJson<HealthPotion>(jsonStr).Concat(items).ToArray();
                    break;
        
                case "AttackBoosts.json":
                    items = FromJson<AttackBoost>(jsonStr).Concat(items).ToArray();
                    break;

                case "DefenseBoosts.json":
                    items = FromJson<DefenseBoost>(jsonStr).Concat(items).ToArray();
                    break;

                case "HealthBoosts.json":
                    items = FromJson<HealthBoost>(jsonStr).Concat(items).ToArray();
                    break;

                case "TripleScoop.json":
                    items = FromJson<TripleScoop>(jsonStr).Concat(items).ToArray();
                    break;

                case "AttackDefenseTradeOff.json":
                    items = FromJson<AttackDefenseTradeOff>(jsonStr).Concat(items).ToArray();
                    break;

                case "Shocks.json":
                    items = FromJson<Shock>(jsonStr).Concat(items).ToArray();
                    break;

                case "TimeWeaknesses.json":
                    items = FromJson<TimeWeakness>(jsonStr).Concat(items).ToArray();
                    break;

                case "OHKO.json":
                    items = FromJson<OHKO>(jsonStr).Concat(items).ToArray();
                    break;

                case "Freeze.json":
                    items = FromJson<Freeze>(jsonStr).Concat(items).ToArray();
                    break;

                case "SuperHuman.json": 
                    items = FromJson<SuperHuman>(jsonStr).Concat(items).ToArray();
                    break;

                case "HeavyWeight.json":
                    items = FromJson<HeavyWeight>(jsonStr).Concat(items).ToArray();
                    break;

                case "XRay.json":
                    items = FromJson<XRay>(jsonStr).Concat(items).ToArray();
                    break;

                case "DefenseAttackTradeOff.json":
                    items = FromJson<DefenseAttackTradeOff>(jsonStr).Concat(items).ToArray();
                    break;

                case "LifeSteal.json":
                    items = FromJson<LifeSteal>(jsonStr).Concat(items).ToArray();
                    break;

                case "BubbleHealth.json":
                    items = FromJson<BubbleHealth>(jsonStr).Concat(items).ToArray();
                    break;

                case "SlipNSlide.json":
                    items = FromJson<SlipNSlide>(jsonStr).Concat(items).ToArray();
                    break;

                default:
                    Debug.Log("No Items added for Path: " + path);
                    break;
            }

        }

        return items;

    }

}
