using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VisualFeedbackManager : MonoBehaviour
{
    private static VisualFeedbackManager instance;

    public static VisualFeedbackManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<VisualFeedbackManager>();

                if (instance == null)
                {
                    GameObject go = new GameObject("VisualFeedbackManager");
                    instance = go.AddComponent<VisualFeedbackManager>();
                }
            }
            return instance;
        }
    }

    private Dictionary<Renderer, Color> originalColors = new Dictionary<Renderer, Color>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void CacheOriginalColor(Renderer rend)
    {
        if (!originalColors.ContainsKey(rend))
        {
            originalColors[rend] = rend.material.color;
        }
    }

    private Color GetOriginalColor(Renderer rend)
    {
        if (originalColors.ContainsKey(rend))
        {
            return originalColors[rend];
        }
        return rend.material.color;
    }

    public void ShowInvincibilityFeedback(GameObject target, float duration)
    {
        Renderer[] renderers = target.GetComponentsInChildren<Renderer>();
        if (renderers.Length == 0) return;

        foreach (Renderer rend in renderers)
        {
            CacheOriginalColor(rend);
        }

        ParticleSystem particles = target.GetComponentInChildren<ParticleSystem>();
        StartCoroutine(InvincibilityEffect(renderers, particles, duration));
    }

    public void ShowSpeedBoostFeedback(GameObject target, float duration)
    {
        Renderer[] renderers = target.GetComponentsInChildren<Renderer>();
        if (renderers.Length > 0)
        {
            foreach (Renderer rend in renderers)
            {
                CacheOriginalColor(rend);
            }
            StartCoroutine(SpeedBoostEffect(renderers, duration));
        }
    }

    public void ShowDamageFeedback(GameObject target)
    {
        Renderer[] renderers = target.GetComponentsInChildren<Renderer>();
        if (renderers.Length > 0)
        {
            foreach (Renderer rend in renderers)
            {
                CacheOriginalColor(rend);
            }
            StartCoroutine(DamageEffect(renderers));
        }
    }

    public void ShowHealFeedback(GameObject target)
    {
        Renderer[] renderers = target.GetComponentsInChildren<Renderer>();
        if (renderers.Length > 0)
        {
            foreach (Renderer rend in renderers)
            {
                CacheOriginalColor(rend);
            }
            StartCoroutine(HealEffect(renderers));
        }
    }

    // ---- EFECTOS VISUALES ----

    private IEnumerator InvincibilityEffect(Renderer[] renderers, ParticleSystem particles, float duration)
    {
        float blinkSpeed = 0.15f;
        float elapsed = 0f;

        if (particles != null) particles.Play();

        while (elapsed < duration)
        {
            float hue = (elapsed / duration) % 1f;
            Color rainbowColor = Color.HSVToRGB(hue, 1f, 2f);

            foreach (Renderer rend in renderers)
            {
                rend.material.color = rainbowColor;
            }
            yield return new WaitForSeconds(blinkSpeed);

            foreach (Renderer rend in renderers)
            {
                rend.material.color = GetOriginalColor(rend);
            }
            yield return new WaitForSeconds(blinkSpeed);

            elapsed += blinkSpeed * 2;
        }

        if (particles != null) particles.Stop();

        foreach (Renderer rend in renderers)
        {
            rend.material.color = GetOriginalColor(rend);
        }
    }

    private IEnumerator SpeedBoostEffect(Renderer[] renderers, float duration)
    {
        Color speedColor = new Color(0f, 1.5f, 2f, 1f);
        float elapsed = 0f;
        float blinkSpeed = 0.2f;

        while (elapsed < duration)
        {
            foreach (Renderer rend in renderers)
            {
                rend.material.color = speedColor;
            }
            yield return new WaitForSeconds(blinkSpeed);

            foreach (Renderer rend in renderers)
            {
                rend.material.color = GetOriginalColor(rend);
            }
            yield return new WaitForSeconds(blinkSpeed);

            elapsed += blinkSpeed * 2;
        }

        foreach (Renderer rend in renderers)
        {
            rend.material.color = GetOriginalColor(rend);
        }
    }

    private IEnumerator DamageEffect(Renderer[] renderers)
    {
        Color damageColor = new Color(2f, 0f, 0f, 1f);

        for (int flash = 0; flash < 3; flash++)
        {
            foreach (Renderer rend in renderers)
            {
                rend.material.color = damageColor;
            }
            yield return new WaitForSeconds(0.1f);

            foreach (Renderer rend in renderers)
            {
                rend.material.color = GetOriginalColor(rend);
            }
            yield return new WaitForSeconds(0.1f);
        }

        foreach (Renderer rend in renderers)
        {
            rend.material.color = GetOriginalColor(rend);
        }
    }

    private IEnumerator HealEffect(Renderer[] renderers)
    {
        Color healColor = new Color(0f, 2f, 0f, 1f);

        for (int flash = 0; flash < 2; flash++)
        {
            foreach (Renderer rend in renderers)
            {
                rend.material.color = healColor;
            }
            yield return new WaitForSeconds(0.15f);

            foreach (Renderer rend in renderers)
            {
                rend.material.color = GetOriginalColor(rend);
            }
            yield return new WaitForSeconds(0.15f);
        }

        foreach (Renderer rend in renderers)
        {
            rend.material.color = GetOriginalColor(rend);
        }
    }
}