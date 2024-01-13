using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject player;
    public HealthSystem healthSystem;
    public SpriteRenderer playerSpriteRenderer; 
    Vector2 startPos;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healthSystem.CharacterSpriteRenderer = playerSpriteRenderer;
        startPos = player.transform.position;
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
}