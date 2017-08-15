using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollisionEvents : MonoBehaviour {



    public Transform[] makr_points;  /* = new Vector3[] {new Vector3(21.15491f, 2, 157.6867f) };*/
    public int point_index;
        
	// Use this for initialization
	void Start () {
        point_index = -1;  
    }
	
	// Update is called once per frame
	void Update () {

    }

    void UpScore()
    {
        //Quest quest_obj = GameObject.FindObjectOfType<Quest>();
        //if (quest_obj == null) return;
        point_index++;
        if (point_index == makr_points.Length)
        {            
            point_index = 0;
            SceneManager.LoadScene("test4");
        }
        if (point_index >= makr_points.Length) return;
        Transform Trnsf = makr_points[point_index];
        if (Trnsf == null) return;
        transform.position = Trnsf.position;
        transform.rotation = Trnsf.rotation;        
        
    }

    void OnTriggerEnter(Collider Coll)
    {        
        if (Coll.name != "ColliderBody") return;
        if (Coll.transform.parent == null) return;
        //if (Coll.transform.parent.gameObject == null) return;

        GameObject obj = Coll.transform.parent.gameObject;

        if (obj.transform.parent == null) return;
        //if (obj.transform.parent.gameObject == null) return;

        obj = obj.transform.parent.gameObject;
        if (obj.tag == "player_car") UpScore();
    }

}
