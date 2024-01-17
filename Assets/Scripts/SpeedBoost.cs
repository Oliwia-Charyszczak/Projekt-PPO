using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    GameObject objectWithScript;
    Movement movement;

    private PolygonCollider2D polygonCollider;
    private Renderer objectRenderer;

    private void Start()
    {
        objectWithScript = GameObject.FindWithTag("Player");
        movement = objectWithScript.GetComponent<Movement>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        objectRenderer = GetComponent<Renderer>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("wow");
            if (movement != null)
            {
                Debug.Log("nie jest pusty");
                movement.AddSpeed(20f);
}
            if (polygonCollider != null)
            {
                polygonCollider.enabled = false;
            }
            if (objectRenderer != null)
            {
                objectRenderer.enabled = false;
            }
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(8);
        movement.AddSpeed(-20f);
        objectRenderer.enabled = true;
        polygonCollider.enabled = true;
    }
}

