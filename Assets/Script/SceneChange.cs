using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] string sceneName;
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player"){
            SceneManager.LoadScene(sceneName);
        }
    }
}

