using UnityEngine;

public class Kamera : MonoBehaviour
{
    public Transform graczCel;
    public Vector3 przesuniecie = new Vector3(0f, 10f, -10f);
    public float mnoznikDodatkowy = 2f;
    public float szybkoscKamery = 5f;
    private Quaternion stalyObrot;

    void Start()
    {
        stalyObrot = transform.rotation;
    }
    void LateUpdate()
    {
        float ruchPoziomo = Input.GetAxis("Horizontal");
        float ruchPionowy = Input.GetAxis("Vertical");

        Vector3 dodatkowePrzesuniecie = new Vector3(ruchPoziomo * mnoznikDodatkowy, 0f, ruchPionowy * mnoznikDodatkowy);

        Vector3 docelowaPozycja = graczCel.position + przesuniecie + dodatkowePrzesuniecie;

        transform.position = Vector3.Lerp(transform.position, docelowaPozycja, szybkoscKamery * Time.deltaTime);
        

        transform.rotation = stalyObrot;
    }
}
