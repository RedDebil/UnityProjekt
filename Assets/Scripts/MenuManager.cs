using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{

    public GameObject OpcjeMenu;
    public GameObject MenuOpcje;
    public void Odpal( string nazwaSceny)
    {
        SceneManager.LoadScene(nazwaSceny);
    }

    public void PokazOpcje()
    {
        OpcjeMenu.SetActive(true);
        MenuOpcje.SetActive(false);
    }

    public void PokazMenu()
    {
        OpcjeMenu.SetActive(false);
        MenuOpcje.SetActive(true);
    }

    public void WyjscieGry()
    {
        Application.Quit();
        Debug.Log("Gra zosta�a zamkni�ta.");
    }

}
