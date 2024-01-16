using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public float volume;

    public PlayerData(GameManager player)
    {
        volume = player.volumeChanger.volume;
    }
}
