using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.enabled = false;
            //Instancjonowanie konfetti czy coœ?
            StartCoroutine(LoadOutLevel());
        }

        IEnumerator LoadOutLevel()
        {
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("Menu");
        }
    }
}
