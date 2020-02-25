using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    private int playerID;
    private DatabaseHandler database;

    private Dictionary<int, MonsterDetails> monsterParty;
    private Dictionary<int, ItemDetails> itemInventory;

    public void SetupControls(int playerID, DatabaseHandler database)
    {
        playerID = this.playerID;
        database = this.database;
        Logger.WriteToLog("Player: SetupControls(): SUCCESSFUL: controls set up.");
    }

    public void SetupItemInventory()
    {
        string response = database.GetFromDatabase("");
        Logger.WriteToLog("Player: SetupItemInventory(): string response: "+ response);
    }

    public void SetupMonsterParty()
    {
        string response = database.GetFromDatabase("");
        Logger.WriteToLog("Player: SetupMonsterParty(): string response: " + response);
    }

    public Dictionary<int, MonsterDetails> GetMonsters()
    {
        Logger.WriteToLog("Player: GetMonsters(): returning Dictionary monsterParty.");
        return monsterParty;
    }

    public Dictionary<int, ItemDetails> GetInventory()
    {
        Logger.WriteToLog("Player: GetInventory(): returning Dictionary itemInventory.");
        return itemInventory;
    }

}
