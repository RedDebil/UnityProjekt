using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpcjeManager : MonoBehaviour
{
    public Slider volumeSlider;              // Suwak do regulacji g³oœnoœci
    public Slider brightnessSlider;          // Suwak do regulacji jasnoœci
    public Image brightnessOverlay;          // Nak³adka na ekran (Image)
    public Image brightnessOverlay2;
    public Toggle fpsToggle;                 // Toggle do obs³ugi licznika FPS

    void Start()
    {
        // £aduj zapisane ustawienia
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        brightnessSlider.value = PlayerPrefs.GetFloat("Brightness", 0.5f); // Domyœlna jasnoœæ na 50%
        fpsToggle.isOn = PlayerPrefs.GetInt("FPSCounterEnabled", 0) == 1;

        // Ustaw wstêpne wartoœci
        AdjustVolume();
        AdjustBrightness();
    }

    public void AdjustVolume()
    {
        // Zmieñ globaln¹ g³oœnoœæ i zapisz ustawienie
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        Debug.Log("G³oœnoœæ ustawiona na: " + volumeSlider.value);
    }

    public void AdjustBrightness()
    {
        if (brightnessOverlay != null)
        {
            // Zmieñ przezroczystoœæ nak³adki
            float alpha = 1f - brightnessSlider.value; // Im wiêksza jasnoœæ, tym mniejsza przezroczystoœæ
            brightnessOverlay.color = new Color(0f, 0f, 0f, alpha); // Czarny z przezroczystoœci¹
            brightnessOverlay2.color = new Color(0f, 0f, 0f, alpha);
            PlayerPrefs.SetFloat("Brightness", brightnessSlider.value);
            Debug.Log("Jasnoœæ ustawiona na: " + brightnessSlider.value);
        }
        else
        {
            Debug.LogError("Nak³adka BrightnessOverlay nie jest przypisana!");
        }
    }

    public void ToggleFPSCounter()
    {
        // Zapisz stan licznika FPS w PlayerPrefs
        PlayerPrefs.SetInt("FPSCounterEnabled", fpsToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
        Debug.Log("Licznik FPS: " + (fpsToggle.isOn ? "W³¹czony" : "Wy³¹czony"));
    }

    public void BackToMenu()
    {
        // Powrót do menu g³ównego
        SceneManager.LoadScene("MainMenu");
    }
}