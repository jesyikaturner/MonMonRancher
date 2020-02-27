using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList
{
    private Dictionary<string, ItemDetails> itemList;

    public void SetupMoveList(TextAsset json)
    {
        itemList = new Dictionary<string, ItemDetails>();

        // creating an object array from the json
        Items itemsObject = JsonUtility.FromJson<Items>(json.text);

        // converting the objects into MoveDetails for a more complex object
        foreach (Item item in itemsObject.items)
        {
            itemList.Add(item.name, new ItemDetails());
            Logger.WriteToLog("MoveList: SetupMoveList(): SUCCESS: Created new move: " + itemList[item.name].ItemDetailsString());
        }
    }

    public ItemDetails GetMove(string name)
    {
        Logger.WriteToLog("MoveList: GetMove(): Getting from moveList dictionary: " + name);
        return itemList[name];
    }

    public class ItemDetails
    {
        public string Name { get; private set; }

        public ItemDetails()
        {

        }

        public string ItemDetailsString()
        {
            return string.Format("Name: {0}", Name);
        }
    }

    // JSON
#pragma warning disable 0649
    [System.Serializable]
    private class Items
    {
        public Item[] items;
    }

    [System.Serializable]
    private class Item
    {
        public string name;
        public string description;
        public Buff[] buff;
    }

    [System.Serializable]
    private class Buff
    {
        public int value;
        public string type;
    }
}
