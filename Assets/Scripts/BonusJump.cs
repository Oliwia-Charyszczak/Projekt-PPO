using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusJump : MonoBehaviour
{
    GameObject objectWithScript;
    Movement movement;

    private EdgeCollider2D edgeCollider;
    private Renderer objectRenderer;

    private void Start()
    {
        objectWithScript = GameObject.FindWithTag("Player");
        movement = objectWithScript.GetComponent<Movement>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        objectRenderer = GetComponent<Renderer>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (movement != null)
            {
                movement.AddJump();
            }
            if (edgeCollider != null)
            {
                edgeCollider.enabled = false;
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
        yield return new WaitForSeconds(5);
        objectRenderer.enabled = true;
        edgeCollider.enabled = true;
    }
}
