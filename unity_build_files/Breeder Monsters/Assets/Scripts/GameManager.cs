using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class GameManager : MonoBehaviour
{
    // JSON Files
    [SerializeField] private TextAsset playerMonstersJSON, moveListJSON;
    //[SerializeField] private TextAsset playerClothesJSON;

    [SerializeField] private Player player;
    private MoveList moves;

    [DllImport("__Internal")] private static extern void OnAppLoaded();

    // Start is called before the first frame update
    void Start()
    {
        // communicates with browser, basically letting it know thats its been loaded and calling to send data to app
#if !UNITY_EDITOR && UNITY_WEBGL
        OnAppLoaded();
#endif
        moves = new MoveList();
        moves.SetupMoveList(moveListJSON);

        player = gameObject.AddComponent<Player>();
        player.SetupControls(1);
        player.SetupMonsterParty(playerMonstersJSON, moves);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Javascript Hooks
    public void PlayerMonstersJSONHook(string json)
    {
        playerMonstersJSON = new TextAsset(json);
    }

    public void MoveListJSONHook(string json)
    {
        moveListJSON = new TextAsset(json);
    }
}
