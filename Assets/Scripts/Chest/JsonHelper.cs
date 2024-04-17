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


    

    /*
        Functions Below are specifically meant for the LootTable
    */

    //Returns an array of all Item Json files to be read
    private static string[] getJsonFiles() {
        string path = Application.dataPath + "/Scripts/JsonItems/jsonFiles.txt";
        string[] lines = File.ReadAllLines(path);
        return lines;
    }
    //Returns array of all lines from a given file
    private static string[] getLines(string path){
        string[] lines = File.ReadAllLines(Application.dataPath + path);
        return lines;
    }
    //Combines an array of strings into one string
    private static string combineLines(string[] lines) {
        string jsonStr = "";
        foreach (string l in lines) {
            jsonStr += l;
        }
		return jsonStr;
    }

    //First Function, called in LootTable script
    public static Item[] getLootTable() {
        //Get all filepaths of Item Json files
        string[] filePaths = getJsonFiles();
        //Item array
        Item[] items = new Item[0];
        //For each Item Json File
        foreach (string path in filePaths) {
            //Get the Json string in the file
            string jsonStr = combineLines(getLines(path));
            //Get the substring that tells what type of Item is stroed in the File
            string sub = path.Substring(19);

            //Determine which Item is being read
            switch (sub) {
             
                case "HealthPotions.json":
                    //Convert From Json and concat to Items
                    items = FromJson<HealthPotion>(jsonStr).Concat(items).ToArray();
                    break;
        
                case "AttackBoosts.json":
                    //Convert From Json and concat to Items
                    items = FromJson<AttackBoost>(jsonStr).Concat(items).ToArray();
                    break;

                case "DefenseBoosts.json":
                    //Convert From Json and concat to Items
                    items = FromJson<DefenseBoost>(jsonStr).Concat(items).ToArray();
                    break;

                case "HealthBoosts.json":
                    //Convert From Json and concat to Items
                    items = FromJson<HealthBoost>(jsonStr).Concat(items).ToArray();
                    break;

                case "TripleScoop.json":
                    //Convert From Json and concat to Items
                    items = FromJson<TripleScoop>(jsonStr).Concat(items).ToArray();
                    break;

                case "AttackDefenseTradeOff.json":
                    //Convert From Json and concat to Items
                    items = FromJson<AttackDefenseTradeOff>(jsonStr).Concat(items).ToArray();
                    break;

                case "DefenseAttackTradeOff.json":
                    //Convert From Json and concat to Items
                    items = FromJson<DefenseAttackTradeOff>(jsonStr).Concat(items).ToArray(); 
                    break;

                case "BubbleHealth.json":
                    //Convert From Json and concat to Items
                    items = FromJson<BubbleHealth>(jsonStr).Concat(items).ToArray(); 
                    break;

                case "Shocks.json":
                    //Convert From Json and concat to Items
                    items = FromJson<Shock>(jsonStr).Concat(items).ToArray();
                    break;

                case "TimeWeaknesses.json":
                //Convert From Json and concat to Items
                    items = FromJson<TimeWeakness>(jsonStr).Concat(items).ToArray();
                    break;

                case "OHKO.json":
                    //Convert From Json and concat to Items
                    items = FromJson<OHKO>(jsonStr).Concat(items).ToArray();
                    break;

                case "Freeze.json":
                    //Convert From Json and concat to Items
                    items = FromJson<Freeze>(jsonStr).Concat(items).ToArray();
                    break;

                case "SlipNSlide.json":
                    //Convert From Json and concat to Items
                    items = FromJson<SlipNSlide>(jsonStr).Concat(items).ToArray();
                    break;

                case "SuperHuman.json": 
                    //Convert From Json and concat to Items
                    items = FromJson<SuperHuman>(jsonStr).Concat(items).ToArray();
                    break;

                case "HeavyWeight.json":
                    //Convert From Json and concat to Items
                    items = FromJson<HeavyWeight>(jsonStr).Concat(items).ToArray();
                    break;

                case "LifeSteal.json":
                    //Convert From Json and concat to Items
                    items = FromJson<LifeSteal>(jsonStr).Concat(items).ToArray();
                    break;

                case "XRay.json":
                    //Convert From Json and concat to Items
                    items = FromJson<XRay>(jsonStr).Concat(items).ToArray();
                    break;

                default:
                    Debug.Log("No Items added for Path: " + path);
                    break;
            }

        }

        //Return the array of Items
        return items;

    }

}
