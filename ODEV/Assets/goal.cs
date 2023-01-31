using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{

    [SerializeField] bool goal_right, goal_left;
    //iki kalede de aynı kod olduğu için doğru skor vermesi açısından hangi kale olduğunu işaretliyoruz 

    [SerializeField] score_manager score_manager_code;
    //diğer koda ulaşıp oradaki skorları değiştirmeyi amaçladım

    //topun yokken spawn olacağı noktayı karşılıyor
    [SerializeField] Transform middle_transform;

    //ana topumuzun prefabını aldık
    [SerializeField] GameObject main_ball;


    // Start is called before the first frame update
    void Start()
    {

        instantiate_ball();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter (Collision col)
    {
        //eğer topa çarparsa yok edip skor artırıp yeniden topu var ediyor

        if(col.gameObject.name == "main_ball(Clone)")
        {

            score_manager_code.goal_effect.Play();

            if(goal_left)
            {
                score_manager_code.score_right++;
            }
            if(goal_right)
            {
                score_manager_code.score_left++;
            }

            Destroy(col.gameObject);

            Instantiate(main_ball, middle_transform.position, middle_transform.rotation);

        }
    }


    public void instantiate_ball()
    {
        // bu kod iki topta da bulunması sebebiyle başlangıçta iki tane top oluşturmaması için burada sadece sol ise topu spawnlıyor

        if(goal_right)
        {
            Instantiate(main_ball, middle_transform.position, middle_transform.rotation);
        }
    }


}
