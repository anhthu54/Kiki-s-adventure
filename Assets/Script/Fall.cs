using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player"){
            PermanentUI.perm.dia=0;
            PermanentUI.perm.health=5f;
            PermanentUI.perm.diaText.SetText("X "+ PermanentUI.perm.dia);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
