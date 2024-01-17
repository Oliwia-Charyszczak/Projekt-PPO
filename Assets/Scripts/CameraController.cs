using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float offset;  //Ustawienie kamery w kierunku gracza
    [SerializeField] private float smoothTime = 0.1f;

    private SpriteRenderer playerSpriteRenderer;
    private Transform player;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        FindPlayer();
    }

    void FindPlayer()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
            playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        if (player != null && playerSpriteRenderer != null)
        {
            float targetX = player.position.x + (playerSpriteRenderer.flipX ? -offset : offset);
            Vector3 targetPosition = new Vector3(targetX, player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        else
        {
            FindPlayer();
        }
    }
}
