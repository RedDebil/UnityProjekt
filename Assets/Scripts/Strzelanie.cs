using UnityEngine;
using System.Collections;
public class Strzelanie : MonoBehaviour
{
    public GameObject prefabPocisku;
    public int rozmiarPuli = 10;
    public float czasZyciaPocisku = 5f;

    public float cooldownStrzalu = 0.5f;
    public Transform punktStartowy;
    public float predkoscPocisku = 2f;

    private GameObject[] pulaPociskow;
    private float ostatniStrzal = -10f;
    void Start()
    {
        pulaPociskow = new GameObject[rozmiarPuli];
        for (int i = 0; i < rozmiarPuli; i++)
        {
            pulaPociskow[i] = Instantiate(prefabPocisku);
            pulaPociskow[i].SetActive(false);
        }
    }

    public void Strzal()
    {
        if (Time.time - ostatniStrzal < cooldownStrzalu)
            return;

        ostatniStrzal = Time.time;

        GameObject pocisk = PobierzDostepnyPocisk();
        if (pocisk != null)
        {
            pocisk.transform.position = punktStartowy.position;
            pocisk.transform.rotation = punktStartowy.rotation;
            pocisk.SetActive(true);

            pocisk.GetComponent<Rigidbody>().linearVelocity = punktStartowy.forward * predkoscPocisku;

            StartCoroutine(DezaktywujPoCzasie(pocisk, czasZyciaPocisku));
        }
    }

    private GameObject PobierzDostepnyPocisk()
    {
        for (int i = 0; i < rozmiarPuli; i++)
        {
            if (!pulaPociskow[i].activeInHierarchy)
                return pulaPociskow[i];
        }
        return null;
    }

    private IEnumerator DezaktywujPoCzasie(GameObject pocisk, float czas)
    {
        yield return new WaitForSeconds(czas);
        pocisk.SetActive(false);
    }

}
