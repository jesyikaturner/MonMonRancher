using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    private List<IPlayer> players;
    [SerializeField] private DatabaseHandler database;

    private void Awake()
    {
        Logger.SetUpLogger();
        database.SetupDatabaseHandler();
    }

    void Start()
    {
        players = new List<IPlayer>
        {
            gameObject.AddComponent<Player>(),
            gameObject.AddComponent<ComputerPlayer>()
        };

        players[0].SetupControls(1, database);
        players[1].SetupControls(2, database);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
