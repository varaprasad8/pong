using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

	
	public void changeScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
	
}
