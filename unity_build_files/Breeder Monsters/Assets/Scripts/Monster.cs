using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    public Dictionary<string, MonsterDetails> monsterList;

    public Monster(TextAsset json, MoveList moves)
    {
#if UNITY_EDITOR
        MonsterRoots monstersObject = JsonUtility.FromJson<MonsterRoots>(json.text);
#endif

        foreach(MonsterRoot monster in monstersObject.monsters)
        {
            // TODO create monsterdetails from json
            //monsterList.Add(monster.name, new MonsterDetails(monster));
        }
    }

    public class MonsterDetails
    {
        private string name;
        private string species;
        private string element;
        private Dictionary<string, int> attributes;
        private Dictionary<string, string> equipment;
        private List<MoveList.MoveDetails> moveList;

        public MonsterDetails(string name, string species, string element, Dictionary<string, int> attributes, Dictionary<string, string> equipment)
        {

        }

        public void SetMoveList(string[] names)
        {

        }
    }

#pragma warning disable 0649
    [System.Serializable]
    private class MonsterRoots
    {
        public MonsterRoot[] monsters;
    }

    [System.Serializable]
    private class MonsterRoot
    {
        public string name;
        public string species;
        public string element;
        public MonsterAttributes attributes;
        public string[] moveset;
    }

    [System.Serializable]
    private class MonsterAttributes
    {
        public int level;
        public int experience;
        public int health;
        public int mana;
        public int strength;
        public int agility;
        public int intellect;
        public int defense;
        public MonsterEquipment equipment;
    }

    [System.Serializable]
    private class MonsterEquipment
    {
        public string armour;
        public string weapon;
        public string shield;
        public string trinket;
    }
}
