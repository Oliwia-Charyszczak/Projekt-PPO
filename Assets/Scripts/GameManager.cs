using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject player;
    public HealthSystem healthSystem;
    public VolumeChanger volumeChanger;
    public SpriteRenderer playerSpriteRenderer;
    private int level = 1;
    Vector2 startPos;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healthSystem.CharacterSpriteRenderer = playerSpriteRenderer;
        startPos = player.transform.position;
        LoadVolumeData();
    }

    void Update()
    {
        if (healthSystem != null && healthSystem.IsDead)
        {
            player.transform.position = startPos;
            player.SetActive(true);
            healthSystem.IsDead = false;
        }
    }
    public void SetSpawnPointActive(Vector2 position)
    {
        startPos = position;
    }
    public int GetLevel()
    {
        return level;
    }

    public void SavePlayerData()
    {
        PlayerData playerData = new PlayerData(this);
        string json = JsonUtility.ToJson(playerData);

        PlayerPrefs.SetString("PlayerData", json);
        PlayerPrefs.Save();
    }

    public void LoadVolumeData()
    {
        string savedData = PlayerPrefs.GetString("PlayerData", "");

        if (!string.IsNullOrEmpty(savedData))
        {
            PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(savedData);
            UseVolumeData(loadedPlayerData);
        }
    }

    private void UseVolumeData(PlayerData playerData)
    {
        volumeChanger.volume = playerData.volume;
        AudioListener.volume = volumeChanger.volume;
    }
}
