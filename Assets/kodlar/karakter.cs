using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class karakter : MonoBehaviour
{
    public Animator anim;
    public float speed = 2f;
    private Vector3 target;

    void Start()
    {
        anim = GetComponent<Animator>();
        target = transform.position;
    }

void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            speed = 2f;
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            anim.SetBool("IsRunning", true); // Koşma animasyonunu etkinleştir
        }

        if (transform.position == target)
        {
            anim.SetBool("IsRunning", false); // Hedefe ulaştığında koşma animasyonunu devre dışı bırak
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    // Çarpışma algılandığında çağrılır
    private void OnCollisionStay2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("girilmez"))
        {
            // Çarpıştığınız taglı objeyle çarpışıldığında hareketi duraklat
            speed = 0;
            anim.SetBool("IsRunning", false);
        }
    }
}


