using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Monster
{
    public Dictionary<string, MonsterDetails> monsterList;

    public Monster(TextAsset json, MoveList moves)
    {
#if UNITY_EDITOR
        MonstersRoot monstersObject = JsonUtility.FromJson<MonstersRoot>(json.text);
#endif

        foreach(MonsterRoot monster in monstersObject.monsters)
        {
            // TODO create monsterdetails from json
            //monsterList.Add(monster.name, new MonsterDetails(monster));
        }
    }

    [System.Serializable]
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
    }

    [System.Serializable]
    public class MonstersRoot
    {
        public MonsterRoot[] monsters;
    }

    [System.Serializable]
    public class MonsterRoot
    {
        public string name;
        public string species;
        public string element;
        public MonsterAttributes attributes;
        public string[] moveset;
    }

    [System.Serializable]
    public class MonsterAttributes
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
    public class MonsterEquipment
    {
        public string armour;
        public string weapon;
        public string shield;
        public string trinket;
    }
}
