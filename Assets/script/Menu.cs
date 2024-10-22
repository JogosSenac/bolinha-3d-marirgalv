using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
   public void Startjogo()
    {
        SceneManager.LoadScene("fase1");
    }

    // Update is called once per frame

 public void voltarMenu()
 {
    SceneManager.LoadScene("Menu");
 } 

 public void Replay()
 {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
 }  
}
