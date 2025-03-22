using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public void Odpal( string nazwaSceny)
    {
        SceneManager.LoadScene(nazwaSceny);
    }

    public void WyjscieGry()
    {
        Application.Quit();
        Debug.Log("Gra zosta³a zamkniêta.");
    }

}
