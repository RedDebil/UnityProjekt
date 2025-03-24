using UnityEngine;

public class Gracz : MonoBehaviour
{
    public float szybkoscGracza = 20f;
    public float szybkoscObrotu = 10f;
    public Camera kameraGracza;
    public Strzelanie strzelanie;
    public Unik unik;
    public Animator animator;
    public float zasiegUnik = 1.5f;
    void Update()
    {
        if (!unik.czyUnika)
        {
            float ruchPoziomo = Input.GetAxis("Horizontal");
            float ruchPionowy = Input.GetAxis("Vertical");

            Vector3 ruch = new Vector3(ruchPoziomo, 0, ruchPionowy);

            bool poruszaSie = (ruch.magnitude > 0f);

            bool biegPrzod = false;
            bool biegTyl = false;
            bool biegLewo = false;
            bool biegPrawo = false;

            if (poruszaSie)
            {
                Vector3 ruchZnormalizowany = ruch.normalized;

                float dotPrzod = Vector3.Dot(ruchZnormalizowany, transform.forward);
                float dotPrawo = Vector3.Dot(ruchZnormalizowany, transform.right);

                //float prog = 0.1f;

                if (Mathf.Abs(dotPrzod) > Mathf.Abs(dotPrawo) /*+ prog*/)
                {

                    if (dotPrzod >= 0f)
                        biegPrzod = true;
                    else
                        biegTyl = true;
                }
                else
                {
                    if (dotPrawo >= 0f)
                        biegPrawo = true;
                    else
                        biegLewo = true;
                }
                //Debug.Log("dotPrzod"+Mathf.Abs(dotPrzod));
                //Debug.Log("dotPrawo" + Mathf.Abs(dotPrawo));
            }

            animator.SetBool("biegPrzod", biegPrzod);
            animator.SetBool("biegTyl", biegTyl);
            animator.SetBool("biegLewo", biegLewo);
            animator.SetBool("biegPrawo", biegPrawo);

            transform.Translate(ruch * szybkoscGracza * Time.deltaTime, Space.World);

            animator.SetBool("shoot", false);

            ObrotdoKursora();


            if (Input.GetMouseButton(0))
            {
                animator.SetBool("shoot", true);
                strzelanie.Strzal();
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            unik.Unikanie();
            animator.SetBool("biegPrzod", false);
            animator.SetBool("biegTyl", false);
            animator.SetBool("biegLewo", false);
            animator.SetBool("biegPrawo", false);
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

    void OnAnimatorMove()
    {
        Vector3 aktualnaPozycja = animator.deltaPosition;

        transform.position += aktualnaPozycja * zasiegUnik;

        transform.rotation *= animator.deltaRotation;
    }



}
