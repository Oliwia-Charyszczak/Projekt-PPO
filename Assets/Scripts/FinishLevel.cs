using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject leafParticlesPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.enabled = false;
            ShootLeafParticles();
            StartCoroutine(LoadOutLevel());
        }

        IEnumerator LoadOutLevel()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Menu");
        }

        void ShootLeafParticles()
        {
            GameObject leafParticles = Instantiate(leafParticlesPrefab, transform.position, Quaternion.identity);
            Destroy(leafParticles, 2.5f);
        }
    }
}
