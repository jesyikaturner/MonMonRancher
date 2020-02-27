using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveList
{
    private Dictionary<string, MoveDetails> moveList;

    public void SetupMoveList(TextAsset json)
    {
        moveList = new Dictionary<string, MoveDetails>();

        // creating an object array from the json
        Moves movesObject = JsonUtility.FromJson<Moves>(json.text);

        // converting the objects into MoveDetails for a more complex object
        foreach(Move move in movesObject.moves)
        {
            moveList.Add(move.name, new MoveDetails(move.name,move.description,move.physicalPower,move.magicPower,move.healthCost,move.manaCost,move.totalHits));
            moveList[move.name].SetTarget(move.targets);
            moveList[move.name].SetElement(move.element);
            Logger.WriteToLog("MoveList: SetupMoveList(): SUCCESS: Created new move: " + moveList[move.name].MoveDetailsString());
        }
    }

    public MoveDetails GetMove(string name)
    {
        Logger.WriteToLog("MoveList: GetMove(): Getting from moveList dictionary: "+ name);
        return moveList[name];
    }

    public class MoveDetails
    {
        public enum TARGET { SINGLE, MULTIPLE, ALL, NOTHING };
        public enum ELEMENT { FIRE, WATER, WIND, EARTH, LIGHT, SHADOW };

        public string Name { get; private set; }
        public string Description { get; private set; }
        public int PhysicalPower { get; private set; }
        public int MagicPower { get; private set; }
        public int HealthCost { get; private set; }
        public int ManaCost { get; private set; }
        public int TotalHits { get; private set; }

        public TARGET Target { get; private set; }
        public ELEMENT Element { get; private set; }


        public MoveDetails(string name, string description, int power, int magicPower, int healthCost, int manaCost, int totalHits)
        {
            Name = name;
            Description = description;
            PhysicalPower = power;
            MagicPower = magicPower;
            HealthCost = healthCost;
            ManaCost = manaCost;
            TotalHits = totalHits;
        }

        public void SetTarget(string targets)
        {
            switch (targets)
            {
                case "single":
                    Target = TARGET.SINGLE;
                    break;
                case "mutiple":
                    Target = TARGET.MULTIPLE;
                    break;
                case "all":
                    Target = TARGET.ALL;
                    break;
                default:
                    Target = TARGET.NOTHING;
                    Logger.WriteToLog("MoveList: MoveDetails: SetTarget(): ERROR: target defaulted!");
                    break;
            }
        }

        public void SetElement(string element)
        {
            Dictionary<string, ELEMENT> elementDictionary = new Dictionary<string, ELEMENT>()
            {
                ["fire"] = ELEMENT.FIRE, 
                ["water"] = ELEMENT.WATER,
                ["wind"] = ELEMENT.WATER,
                ["earth"] = ELEMENT.WATER,
                ["light"] = ELEMENT.WATER,
                ["shadow"] = ELEMENT.WATER
            };

            try
            {
                Element = elementDictionary[element];
            }catch(Exception e)
            {
                Logger.WriteToLog("MoveList: MoveDetails: SetElement(): ERROR: Invalid element: "+e);
            }
        }


        public string MoveDetailsString()
        {
            return string.Format("Name: {0}, Description: {1}, Power: {2}, Magic Power: {3}, Health Cost: {4}, Mana Cost: {5} Total Hits: {6}, Targets: {7}, Element: {8}", 
                Name, Description, PhysicalPower, MagicPower, HealthCost, ManaCost, TotalHits, Target, Element);
        }
    }

    // JSON
#pragma warning disable 0649
    [System.Serializable]
    private class Moves
    {
        public Move[] moves;
    }

    [System.Serializable]
    private class Move
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
