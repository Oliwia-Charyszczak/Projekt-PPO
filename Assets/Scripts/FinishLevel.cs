using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject leafParticlesPrefab;
    [SerializeField] private TextMeshPro endText;
    [SerializeField] private float fadeInDuration = 1.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.enabled = false;
            ShootLeafParticles();
            StartCoroutine(ShowEndText());
            StartCoroutine(LoadOutLevel());
        }

        IEnumerator LoadOutLevel()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Menu");
        }

        IEnumerator ShowEndText()
        {
            endText.gameObject.SetActive(true);

            float elapsedTime = 0f;

            while (elapsedTime < fadeInDuration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Clamp01(elapsedTime / fadeInDuration);
                endText.alpha = alpha;
                yield return null;
            }

            endText.alpha = 1;
        }

        void ShootLeafParticles()
        {
            GameObject leafParticles = Instantiate(leafParticlesPrefab, transform.position, Quaternion.identity);
            Destroy(leafParticles, 2.5f);
        }
    }
}
