using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
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
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("Menu");
        }
    }
}
