using UnityEngine;
using UnityStandardAssets.Cameras;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player_2 : MonoBehaviour {
    
    public GameObject obj_human;
    public GameObject obj_car;
    public GameObject obj_car2;

    public GameObject obj_ball;

    public Quest Quest;

    public PivotBasedCameraRig Camera;

    public float smth = 0.0000001f;

    public GameObject obj;
    

    public const int OBJ_CAR = 0;
    public const int OBJ_HUMAN = 1;

    public int obj_state = OBJ_HUMAN;
    
    public GameObject wall;
    public Vector3 velocity;

    public bool follow_flag = false;

    // Use this for initialization
    void Start () {

        //Destroy(obj_human);
        //Instantiate(obj_human);

        Camera.SetTarget(obj_human.transform);
        obj_car = Instantiate(obj_car);
        obj_car.tag = "player_car";
        obj_car.transform.position = obj_human.transform.position;
        obj_car.SetActive(false);
        obj = obj_human;
        //tag_name = tag_names[obj_state];
    }
	
    // Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("scene_menu");
        }

        if (obj_state == OBJ_CAR && follow_flag)
        {
            Vector3 pos1 = obj_car.transform.position;
            Vector3 pos2 = obj_car2.transform.forward + pos1*0.8f;


            //pos2.x = Mathf.SmoothDamp(pos1.x, pos2.x, ref velocity.x, smth);
            //pos2.z = Mathf.SmoothDamp(pos1.z, pos2.z, ref velocity.z, smth);
            
            //velocity.z = 0;
            //pos2.y = 0;

            obj_car2.transform.position = pos2;
            obj_car2.transform.rotation = Quaternion.Euler(obj_car.transform.eulerAngles);

            /*
    
        CurrentCoord.x = Mathf.SmoothDamp(CurrentCoord.x, NewCoord.x,ref vel.x, Smoothness/100); //Откуда и куда
        CurrentCoord.y = Mathf.SmoothDamp(CurrentCoord.y, NewCoord.y, ref vel.y, Smoothness/100);
        transform.rotation = Quaternion.Euler(CurrentCoord.x, CurrentCoord.y, 0);  // Вводим данные в ротейшн трансформ компонент камеры
     
            */

        }

        // keys handle

        if (Input.GetKeyDown("q"))
        {
            Debug.Log("teeeest");
            print("teeeest");
            Vector3 v = obj.transform.position;
            for (int i = 0; i < 3; i++)
            {
                v.y -= 0.1f;
                Instantiate(obj_ball, v, Quaternion.identity);
            }
          
        }
        if(Input.GetKeyDown("e"))
        {
            Vector3 v = obj.transform.position;
            float angle = Random.Range(0, 360);
            float dist = Random.Range(3,5);

            v.z += Mathf.Sin(angle) * 5;
            v.x += Mathf.Cos(angle) * 5;
            Instantiate(obj_ball, v, Quaternion.identity);

        }

        if (Input.GetKeyDown("g"))
        {
            if(obj_state == OBJ_HUMAN)
            {
                obj_car.SetActive(true);
                //obj_car = Instantiate(obj_car);
                obj_car.transform.position = obj_human.transform.position;
                obj_car.transform.localRotation = Quaternion.identity;
                obj_car.tag = "player_car";
                //obj_car.transform.eulerAngles.Set(0,0,0);

                obj = obj_car;

                obj_state = OBJ_CAR;

                Camera.SetTarget(obj_car.transform);
                obj_human.SetActive(false);
                  /*       
                Vector3 car2_pos = obj_car.transform.position;
                car2_pos.x += 10;
                car2_pos.z += 10;
                */
                //obj_car2 = (GameObject)Instantiate(obj_car, car2_pos, Quaternion.identity);

            }
            else
            {               
                obj_human.SetActive(true);
                obj_human.transform.position = obj_car.transform.position;
                obj = obj_human;

                obj_state = OBJ_HUMAN;

                Camera.SetTarget(obj_human.transform);

                obj_car.SetActive(false);

              
                if (follow_flag)
                {
                    Destroy(obj_car2);
                    follow_flag = false;
                }
            }            

        }

        if (Input.GetKeyDown("f"))
        {
            Transform car_transform = obj.transform;
            Vector3 v = car_transform.position;
            Vector3 a = car_transform.eulerAngles;

            //v.z += 5;
            //v.x += 5;
            v.y += 1f;
                        
            GameObject localWall = (GameObject)Instantiate(wall, v, Quaternion.identity);

            // направление по вектору: transform.position + transfotm.forward * 0.6f

            localWall.transform.position = car_transform.position + car_transform.forward * 2;

            localWall.transform.Rotate(a);
            localWall.transform.Rotate(60, 0, 0);
        }
        if (Input.GetKeyDown("v"))
        {
            follow_flag = !follow_flag;
            if (follow_flag)
            {
                Vector3 car2_pos = obj_car.transform.position;
                car2_pos.x += 10;
                car2_pos.z += 10;
                obj_car2 = (GameObject)Instantiate(obj_car, car2_pos, Quaternion.identity);
            }
            else
                Destroy(obj_car2);



        }       


    }


}


