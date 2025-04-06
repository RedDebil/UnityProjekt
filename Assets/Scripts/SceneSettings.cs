using UnityEngine;
using UnityEngine.UI;

public class SceneSettings : MonoBehaviour
{
    public Image brightnessOverlay;

    private static SceneSettings instance;

    void Start()
    {
        if (brightnessOverlay != null)
        {
            // Ustaw nak³adkê na podstawie zapisanych ustawieñ
            float brightness = PlayerPrefs.GetFloat("Brightness", 0.5f); // Domyœlnie 50%
            float alpha = 1f - brightness;
            brightnessOverlay.color = new Color(0f, 0f, 0f, alpha);
            Debug.Log("Za³adowano jasnoœæ: " + brightness);
        }
        else
        {
            Debug.LogError("BrightnessOverlay nie jest przypisana w tej scenie!");
        }
    }
}