using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offset;  //Ustawienie kamery w kierunku gracza
    [SerializeField] private float offsetSmoothing;     //Pr�dkosc podazania kamery

    void Update()
    {
        if (player != null)
        {
            float targetX = player.position.x + (player.localScale.x > 0f ? offset : -offset);  //Sprawdzanie w kt�ra strone jest zwrocony gracz
            Vector3 targetPosition = new Vector3(targetX, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, offsetSmoothing * Time.deltaTime);
        }
    }
}
