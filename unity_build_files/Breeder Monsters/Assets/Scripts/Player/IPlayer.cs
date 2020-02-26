using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    void SetupControls(int playerID);
    void SetupMonsterParty(TextAsset monstersJSON, MoveList moves);
}
