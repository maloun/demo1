using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.visible = true;
    }	
	// Update is called once per frame
	void Update () {}
    
    public bool scene_test3 = false;
    public bool scene_test4 = false;

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    void OnMouseUp()
    {
        if (scene_test3)
            SceneManager.LoadScene("test3");
        

        if (scene_test4)
            SceneManager.LoadScene("test4");
        
    }
}
