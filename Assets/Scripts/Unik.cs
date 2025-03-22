using UnityEngine;
using System.Collections;

public class Unik : MonoBehaviour
{

    public Animator animator;

    // public float silaUniku = 10f;
    public float czasUniku = 0.2f;

    public bool czyUnika = false;

    //  private Rigidbody rb;

    //  void Start()
    //  {
    //      rb = GetComponent<Rigidbody>();
    //  }

    public void Unikanie()
    {
        if (czyUnika)
            return;

        czyUnika = true;

        animator.SetBool("rollo", czyUnika);

      // rb.AddForce(transform.forward * silaUniku, ForceMode.Impulse);

        StartCoroutine(ResetUniku());
    }

    private IEnumerator ResetUniku()
    {
        yield return new WaitForSeconds(czasUniku);
    //    rb.linearVelocity = Vector3.zero;
        czyUnika = false;
        animator.SetBool("rollo", czyUnika);
    }
}
