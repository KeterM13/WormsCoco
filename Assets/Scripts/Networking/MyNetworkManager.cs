using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);


        var newPlayer = conn.identity.GetComponent<MyNetworkPlayer>();

       
        newPlayer.SetDisplayName($"Player{newPlayer.name}");
        newPlayer.SetColor(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));

        Debug.Log($"JoinPlayer {numPlayers} the server");
    }
}
