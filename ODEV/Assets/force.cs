using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class force : MonoBehaviour
{
    
    float speed;
    Vector3 position = new Vector3(0f,0f,0f);
    Vector3 old_position = new Vector3(0f, 0f, 0f);
    float distance;
    Vector3 direction_;
    string last_name;


    void Start()
    {
        position = transform.position;
        last_name = "Unnamed";
    }
 
 
    void Update()
    {
        //mevcut pozisyonu alıyorum
        position = transform.position;

        //onceki pozisyon ile aradaki mesafeyi alıyorum
        distance = Vector3.Distance(position, old_position);

        //mesafeyi zamana bolerek mevcut hızı buldum
        speed = distance / Time.deltaTime;

        //bu da gidilen mevcut yönü vektor olarak belirleyen kısım
        direction_ = (position-old_position).normalized;

        //Debug.Log("Direction: "+);


        old_position = position;
    }


    void OnCollisionEnter (Collision col)
    {



        Debug.Log("last name : "+last_name);


        if( (col.gameObject.name == "ball_left" && last_name == "ball_right") || (col.gameObject.name == "ball_right" && last_name == "ball_left") )
        {
            //burası da eğer toptan topa giderse geldiği yönün tersine hızını ikiyle çarpıp kuvvet uyguluyoruz hocam (tagına göre)
            //baştan kodu alttaki gibi yazdım ama sonra daha doğru bir yöntem aklıma geldi o yüzden son hali gibi yaptım
            //GetComponent<Rigidbody>().AddForce(-(GetComponent<Rigidbody>().velocity) * ( speed * 2f) );

            //burada kuvvet uygulamadan yapmayı  başardım sadece yönü ve hızı tersine çevirip ikiyle çarptım 
            GetComponent<Rigidbody>().velocity = -10*(GetComponent<Rigidbody>().velocity);

        }


        // son çarpılan nesneyi kontrol ediyoruz ancak sık sık ground'u alıp sorun çıkarttığı için sadece top adlarını alsın dedim


        if(col.gameObject.name == "ball_right"  ||  col.gameObject.name == "ball_left") last_name = col.gameObject.name;


    }




}