using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
 
 	public int sceneNum;
    // Update is called once per frame
    void OnTriggerEnter()
    {
        SceneManager.LoadScene(sceneNum);
    }
}
