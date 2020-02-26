using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class BattleHandler : MonoBehaviour
{
    private List<IPlayer> players;
    private MoveList moves;
    [SerializeField] private TextAsset playerMonstersJSON;
    [SerializeField] private TextAsset moveListJSON;
    [SerializeField] private DatabaseHandler database;
    [DllImport("__Internal")] private static extern void OnAppLoaded();

    void Start()
    {
        // communicates with browser, basically letting it know thats its been loaded and calling to send data to app
#if !UNITY_EDITOR && UNITY_WEBGL
        OnAppLoaded();
#endif

        moves = new MoveList();
        moves.SetupMoveList(moveListJSON);

        players = new List<IPlayer>
        {
            gameObject.AddComponent<Player>(),
            gameObject.AddComponent<ComputerPlayer>()
        };

        players[0].SetupControls(1);
        players[0].SetupMonsterParty(playerMonstersJSON, moves);
        //players[1].SetupControls(2);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
