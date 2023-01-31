using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class score_manager : MonoBehaviour
{


    [SerializeField] public AudioSource music, goal_effect;


    
    [SerializeField] private Slider sound_slider;

    [SerializeField] private GameObject pause_panel, main_menu_panel;
    //açılacak olan menumuz

    public int score_left, score_right;
    //puanlaır karşılıyor

    [SerializeField] private UnityEngine.UI.Text score_left_text, score_right_text;
    //UI kütüphanesi ile canvastaki skorlara ulaşıyorum böylece oyun içinde canlı olarak skoru göstermeyi hedefliyorum



    // Start is called before the first frame update
    void Start()
    {
        score_right = 0;
        score_left = 0;
    }

    // Update is called once per frame
    void Update()
    {




        if(Input.GetKeyDown(KeyCode.Escape))
        {

            if(pause_panel.activeSelf)
            {
                pause_panel.SetActive(false);
                Debug.Log("2");
            } 
            else 
            {
                pause_panel.SetActive(true);
                Debug.Log("1");
            }

        }






        //burada ana menu açıksa zamanı dondurdum kapalıysa otomatik zaman devam ediyor böylece oyun donuyor

        if(pause_panel.activeSelf || main_menu_panel.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else 
        {
            Time.timeScale = 1f;
        }

        //bunlar canlı olarak skoru canvasa bastırıyor
        score_right_text.text = score_right.ToString();
        score_left_text.text = score_left.ToString();



        //seslerimizin slider'a göre ayarlanma kismi
        goal_effect.volume = sound_slider.value;
        music.volume = sound_slider.value;


    }



    //pause butonuna basınca panelimizi aktif ediyorum
    public void pause()
    {
        pause_panel.SetActive(true);
    }

    //ana menuye gitmek istemeyenler için pause menusunu kapatıyoruz
    public void close_pause_menu()
    {
        pause_panel.SetActive(false);
    }

    public void main_menu_play_button()
    {
        pause_panel.SetActive(false);
        main_menu_panel.SetActive(false);


        // her şeyi sıfırlayıp tekrardan sahneyi başlatıyoruz


        goal_effect.volume = sound_slider.value;

        music.volume = sound_slider.value;


        score_left = 0;
        score_right = 0;

        Destroy(GameObject.Find("main_ball(Clone)"));

        GameObject.Find("goal_right").GetComponent<goal>().instantiate_ball();
    }

    public void pause_main_menu()
    {
        main_menu_panel.SetActive(true);
        pause_panel.SetActive(false);
    }

}
