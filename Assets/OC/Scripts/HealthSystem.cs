using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int numberOfHearts;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    private bool isDead = false;
    private SpriteRenderer characterSpriteRenderer;
    private Coroutine blinkCoroutine;

    void Start()
    {
        characterSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++) 
        { 
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (health <= 0 && !isDead)
        {
            HandleDeath();
        }
    }

    public void TakeDamage(int amount)
    {
        if (blinkCoroutine != null) return;

        health -= amount;

        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
        }
        blinkCoroutine = StartCoroutine(BlinkEffect());
    }

    public void Heal(int amount)
    {
        if (isDead) return;
        health += amount;
        if (health > numberOfHearts)
        {
            health = numberOfHearts;
        }
    }

    private void HandleDeath()
    {
        isDead = true;
        enabled = false;
        gameObject.SetActive(false);
    }

    private IEnumerator BlinkEffect()
    {
        float blinkDuration = 1.5f;
        float blinkInterval = 0.1f;

        while (blinkDuration > 0f)
        {
            characterSpriteRenderer.enabled = !characterSpriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
            blinkDuration -= blinkInterval;
        }

        characterSpriteRenderer.enabled = true;
        blinkCoroutine = null;
    }
}
