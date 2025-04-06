using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
<<<<<<< HEAD

    public GameObject OpcjeMenu;
    public GameObject MenuOpcje;
=======
>>>>>>> dd55213e4e09e665fa73002a87d6a03e8edc17c5
    public void Odpal( string nazwaSceny)
    {
        SceneManager.LoadScene(nazwaSceny);
    }

<<<<<<< HEAD
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
        Debug.Log("Gra zostaï¿½a zamkniï¿½ta.");
=======
    public void WyjscieGry()
    {
        Application.Quit();
        Debug.Log("Gra zosta³a zamkniêta.");
>>>>>>> dd55213e4e09e665fa73002a87d6a03e8edc17c5
    }

}
