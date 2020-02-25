using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    void SetupControls(int playerID, DatabaseHandler database);
}
