using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class PermanentUI : MonoBehaviour
{
    public int dia = 0;
    public float health = 5f;
    public TextMeshProUGUI diaText;
    public Image curHealth;
    public AudioMixer MainAudio;
    public AudioMixer SFXAudio;
    public Slider sliderMusic;
    public Slider sliderSFX;
    public static PermanentUI perm;
    public GameObject pauseMenu;
    public GameObject setting;
    public GameObject Score;
    public static bool isPaused = false;



    private void Start(){
        pauseMenu.SetActive(false);
        setting.SetActive(false);
        Score.SetActive(false);
        curHealth.fillAmount = health/10;
        DontDestroyOnLoad(gameObject);
        if(!perm)
            perm = this;
        else
        Destroy(gameObject);
    }
}
