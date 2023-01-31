using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_two : MonoBehaviour
{

    //topun hızını dışarıdan kolayca yönetebilmemiz için
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //input manager kısmına eklediğim girdileri burada aldım
        //bu girdilerin döndürdüğü değere göre topumuzun rigidbody'sine kuvvet uyguladım
        
        float horizontal_value = Input.GetAxisRaw("arrows_horizontal");
        float vertical_value = Input.GetAxisRaw("arrows_vertical");

        Vector3 force_to_ball = new Vector3(horizontal_value, 0 , vertical_value);


        GetComponent<Rigidbody>().AddForce(force_to_ball * speed);



    }




}
