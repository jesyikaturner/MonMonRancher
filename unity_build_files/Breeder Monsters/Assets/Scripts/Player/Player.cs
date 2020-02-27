using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    private int playerID;

    private Dictionary<int, Monster.MonsterDetails> monsterParty;
    // TODO Inventory
    // TODO Player Clothes - jsonobject parsed into a clothing object?

    public void SetupControls(int playerID)
    {
        playerID = this.playerID;
        Logger.WriteToLog("Player: SetupControls(): SUCCESSFUL: controls set up.");
    }

    public void SetupItemInventory()
    {
        //string response = database.GetFromDatabase("");
        //Logger.WriteToLog("Player: SetupItemInventory(): string response: "+ response);
    }

    public void SetupMonsterParty(TextAsset monstersJSON, MoveList moves)
    {
        monsterParty = new Dictionary<int, Monster.MonsterDetails>();
        Monster monster = new Monster(monstersJSON, moves);

        //string response = database.GetFromDatabase("");
        //Logger.WriteToLog("Player: SetupMonsterParty(): string response: " + response);
    }

    //public Dictionary<int, MonsterDetails> GetMonsters()
    //{
    //    Logger.WriteToLog("Player: GetMonsters(): returning Dictionary monsterParty.");
    //    return monsterParty;
    //}

    //public Dictionary<int, ItemDetails> GetInventory()
    //{
    //    Logger.WriteToLog("Player: GetInventory(): returning Dictionary itemInventory.");
    //    return itemInventory;
    //}

}
