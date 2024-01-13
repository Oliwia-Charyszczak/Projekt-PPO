using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HealthSystem healthSystem;
    public SpriteRenderer playerSpriteRenderer; // Assign the player's sprite renderer in the Inspector

    void Start()
    {
        healthSystem.CharacterSpriteRenderer = playerSpriteRenderer;
    }

    // Rest of the GameManager script...
}