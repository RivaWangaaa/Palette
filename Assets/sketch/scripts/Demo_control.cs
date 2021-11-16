using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EasyGameStudio.sketch
{
    public class Demo_control : MonoBehaviour
    {
        public static Demo_control instance;

        public AudioSource audio_source;
        public AudioClip ka;
        public AudioClip ka_1;

        public GameObject[] game_objects;

        private int index = 0;


        [Header("title")]
        public Text text_title;
        public string[] titles;

        void Awake()
        {
            Demo_control.instance = this;
        }

        void Start()
        {
            this.index = 0;

            for (int i = 0; i < this.game_objects.Length; i++)
            {
                if (i == this.index)
                {
                    this.game_objects[i].SetActive(true);
                }
                else
                {
                    this.game_objects[i].SetActive(false);
                }
            }

            this.text_title.text = this.titles[this.index] + " " + index;
        }

        public void on_previous_btn()
        {
            this.index--;
            if (this.index <= -1)
                this.index = (this.game_objects.Length - 1);


            for (int i = 0; i < this.game_objects.Length; i++)
            {
                if (i == this.index)
                {
                    this.game_objects[i].SetActive(true);
                }
                else
                {
                    this.game_objects[i].SetActive(false);
                }
            }

            this.audio_source.PlayOneShot(this.ka);
        }

        public void on_next_btn()
        {
            this.index++;
            if (this.index >= this.game_objects.Length)
                this.index = 0;

            for (int i = 0; i < this.game_objects.Length; i++)
            {
                if (i == this.index)
                {
                    this.game_objects[i].SetActive(true);
                }
                else
                {
                    this.game_objects[i].SetActive(false);
                }
            }

            this.audio_source.PlayOneShot(this.ka);
        }

        public void play_ka_1()
        {
            this.audio_source.PlayOneShot(this.ka_1);
        }

        public void change_title(int index)
        {
            this.text_title.text = this.titles[this.index] + " " + index;
        }
    }
}
