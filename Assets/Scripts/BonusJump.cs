using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusJump : MonoBehaviour
{
    GameObject objectWithScript;
    Movement movement;

    private BoxCollider2D boxCollider;
    private Renderer objectRenderer;

    private void Start()
    {
        objectWithScript = GameObject.FindWithTag("Player");
        movement = objectWithScript.GetComponent<Movement>();
        boxCollider = GetComponent<BoxCollider2D>();
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
                movement.AddJump();
            }
            if (boxCollider != null)
            {
                boxCollider.enabled = false;
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
        objectRenderer.enabled = true;
        boxCollider.enabled = true;
    }
}
