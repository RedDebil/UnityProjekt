using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpcjeManager : MonoBehaviour
{
    public Slider volumeSlider;              // Suwak do regulacji g�o�no�ci
    public Slider brightnessSlider;          // Suwak do regulacji jasno�ci
    public Image brightnessOverlay;          // Nak�adka na ekran (Image)
    public Image brightnessOverlay2;
    public Toggle fpsToggle;                 // Toggle do obs�ugi licznika FPS

    void Start()
    {
        // �aduj zapisane ustawienia
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        brightnessSlider.value = PlayerPrefs.GetFloat("Brightness", 0.5f); // Domy�lna jasno�� na 50%
        fpsToggle.isOn = PlayerPrefs.GetInt("FPSCounterEnabled", 0) == 1;

        // Ustaw wst�pne warto�ci
        AdjustVolume();
        AdjustBrightness();
    }

    public void AdjustVolume()
    {
        // Zmie� globaln� g�o�no�� i zapisz ustawienie
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        Debug.Log("G�o�no�� ustawiona na: " + volumeSlider.value);
    }

    public void AdjustBrightness()
    {
        if (brightnessOverlay != null)
        {
            // Zmie� przezroczysto�� nak�adki
            float alpha = 1f - brightnessSlider.value; // Im wi�ksza jasno��, tym mniejsza przezroczysto��
            brightnessOverlay.color = new Color(0f, 0f, 0f, alpha); // Czarny z przezroczysto�ci�
            brightnessOverlay2.color = new Color(0f, 0f, 0f, alpha);
            PlayerPrefs.SetFloat("Brightness", brightnessSlider.value);
            Debug.Log("Jasno�� ustawiona na: " + brightnessSlider.value);
        }
        else
        {
            Debug.LogError("Nak�adka BrightnessOverlay nie jest przypisana!");
        }
    }

    public void ToggleFPSCounter()
    {
        // Zapisz stan licznika FPS w PlayerPrefs
        PlayerPrefs.SetInt("FPSCounterEnabled", fpsToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
        Debug.Log("Licznik FPS: " + (fpsToggle.isOn ? "W��czony" : "Wy��czony"));
    }

    public void BackToMenu()
    {
        // Powr�t do menu g��wnego
        SceneManager.LoadScene("MainMenu");
    }
}