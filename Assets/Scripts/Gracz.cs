using UnityEngine;

public class Gracz : MonoBehaviour
{
    public float szybkoscGracza = 20f;
    public float szybkoscObrotu = 10f;
    public Camera kameraGracza;
    public Strzelanie strzelanie;
    public Unik unik;
    public Animator animator;

    void Update()
    {
        if (!unik.czyUnika)
        {
            float ruchPoziomo = Input.GetAxis("Horizontal");
            float ruchPionowy = Input.GetAxis("Vertical");

            Vector3 ruch = new Vector3(ruchPoziomo, 0.0f, ruchPionowy);

            bool bieg = (ruch.magnitude > 0);
            bool strzela = true;

            animator.SetBool("run", bieg);

            strzela = false;
            animator.SetBool("shoot", strzela);

            transform.Translate(ruch * szybkoscGracza * Time.deltaTime, Space.World);

            ObrotdoKursora();
            
        }

        if(Input.GetMouseButton(0))
        {
            bool strzela = true;
            strzelanie.Strzal();
            animator.SetBool("shoot",strzela);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            unik.Unikanie();
            bool bieg = false;
            animator.SetBool("run", bieg);
        }
    }

    void ObrotdoKursora()
    {
        Vector3 pozycjaMyszy = Input.mousePosition;

        pozycjaMyszy.z = kameraGracza.transform.position.y;

        Vector3 swiatPozycja = kameraGracza.ScreenToWorldPoint(pozycjaMyszy);

        Vector3 kierunek = swiatPozycja - transform.position;
        kierunek.y = 0f;

        if (kierunek != Vector3.zero)
        {
            Quaternion docelowyObrot = Quaternion.LookRotation(kierunek);
            transform.rotation = Quaternion.Lerp(transform.rotation, docelowyObrot, szybkoscObrotu * Time.deltaTime);
        }
    }
}
