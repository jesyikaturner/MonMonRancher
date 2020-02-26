using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveList
{
    private Dictionary<string, MoveDetails> moveList;

    public void SetupMoveList(TextAsset json)
    {
        /*
        moveList.Add("Fire Ball", new MoveDetails("Fire Ball","Magic. Fire. Single Target",0,5,0,3,1,MoveDetails.TARGETS.SINGLE,MoveDetails.ELEMENTS.FIRE));
        moveList.Add("Water Blast", new MoveDetails("Water Blast", "Magic. Water. Single Target", 0, 5, 0, 3, 1, MoveDetails.TARGETS.SINGLE, MoveDetails.ELEMENTS.WATER));
        moveList.Add("Wind Fury", new MoveDetails("Wind Fury", "Magic. Wind. Single Target", 0, 5, 0, 3, 1, MoveDetails.TARGETS.SINGLE, MoveDetails.ELEMENTS.WIND));
        moveList.Add("Earth Blast", new MoveDetails("Earth Blast", "Magic. Earth. Single Target", 0, 5, 0, 3, 1, MoveDetails.TARGETS.SINGLE, MoveDetails.ELEMENTS.EARTH));
        moveList.Add("Light Beam", new MoveDetails("Light Beam", "Magic. Light. Single Target", 0, 10, 0, 5, 1, MoveDetails.TARGETS.SINGLE, MoveDetails.ELEMENTS.LIGHT));
        moveList.Add("Shadow Bolt", new MoveDetails("Shadow Bolt", "Magic. Shadow. Single Target", 0, 10, 0, 5, 1, MoveDetails.TARGETS.SINGLE, MoveDetails.ELEMENTS.SHADOW));
        */
        Moves movesObject = JsonUtility.FromJson<Moves>(json.text);
        foreach(Move move in movesObject.moves)
        {
            Debug.Log(move.name);
        }
    }

    public MoveDetails GetMove(string name)
    {
        Logger.WriteToLog("MoveList: GetMove(): Getting from moveList dictionary: "+ name);
        return moveList[name];
    }

    // TODO Rewrite to account for reading from json
    public class MoveDetails
    {
        public enum TARGETS { SINGLE, MULTIPLE, ALL };
        public enum ELEMENTS { FIRE, WATER, WIND, EARTH, LIGHT, SHADOW };
        public string name;
        public string description;
        public int power;
        public int magicPower;
        public int healthCost;
        public int manaCost;
        public int totalHits;
        public TARGETS target;
        public ELEMENTS element;

        public MoveDetails(string name, string description, int power, int magicPower, int healthCost, int manaCost, int totalHits, TARGETS target, ELEMENTS element)
        {
            this.name = name;
            this.description = description;
            this.power = power;
            this.magicPower = magicPower;
            this.healthCost = healthCost;
            this.manaCost = manaCost;
            this.totalHits = totalHits;
            this.target = target;
            this.element = element;

            string moveDetailsString = string.Format("Name: {0}, Description: {1}, Power: {2}, Magic Power: {3}, Health Cost: {4}, Total Hits: {5}, Targets: {6}, Element: {7}", 
                name, description, power, magicPower, healthCost, manaCost, totalHits, target, element);
            Logger.WriteToLog("MoveList: MoveDetails: MoveDetails(): SUCCESS: Created new move: "+ moveDetailsString);
        }
    }

    public class Moves
    {
        public Move[] moves;
    }

    public class Move
    {
        public string name;
        public string description;
        public int physicalPower;
        public int magicPower;
        public int healthCost;
        public int manaCost;
        public int totalHits;
        public string targets;
        public string element;
    }
}
