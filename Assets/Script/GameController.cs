using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    void Update()
    {
        PauseMenu();
    }
    public void reduceHealth(){
        if(PermanentUI.perm.health>1.0f){
            PermanentUI.perm.health=PermanentUI.perm.health-1.0f;
        }
       
        else if(PermanentUI.perm.health ==1.0f){           
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            PermanentUI.perm.dia=0;
            PermanentUI.perm.health=5f;
        }
        PermanentUI.perm.curHealth.fillAmount = PermanentUI.perm.health/10;;
    }

    public void countDia(){
        PermanentUI.perm.dia++;
        PermanentUI.perm.diaText.SetText("x "+ PermanentUI.perm.dia);
    }

    public void PauseMenu(){
        if(Input.GetKey(KeyCode.Escape)){
            PermanentUI.perm.pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            PermanentUI.isPaused = true;
        }
    }

    public void SettingMenu(){
        PermanentUI.perm.pauseMenu.SetActive(false);
        PermanentUI.perm.setting.SetActive(true);
    }

    public void BackPauseMenu(){
        PermanentUI.perm.pauseMenu.SetActive(true);
        PermanentUI.perm.setting.SetActive(false);
    }

    public void Resume(){
        PermanentUI.perm.pauseMenu.SetActive(false);
        PermanentUI.perm.setting.SetActive(false);
        Time.timeScale = 1f;
        PermanentUI.isPaused = false;
    }

    public void setMainVolume()
    {
        float volume = PermanentUI.perm.sliderMusic.value;
        PermanentUI.perm.MainAudio.SetFloat("VolumeMusic",volume);
    }


    public void setSFXVolume(){
        float volume = PermanentUI.perm.sliderSFX.value;
        PermanentUI.perm.SFXAudio.SetFloat("VolumeSFX",volume);
    }

}
