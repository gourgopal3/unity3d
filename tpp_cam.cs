using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpp_cam : MonoBehaviour
{

    float mousex;
    float mousey;

    public float mousesen = 20f;

    public Transform target;
    private float distance = 0f;

    public Transform target2;
    public float distance2 = 16f;
    //slllll
    int cammode;

    //camera min and max clamp variable
    public Vector2 pitchminmax = new Vector2(-40, 85);

    //smooth camera rotation
    public float smoothtime = 0.12f;
    Vector3 rotationsmoothvelocity;
    Vector3 currentrotation;
    

    //new own logic
    public Transform player;


    void Start()
    {
        curse();

        warp3();

    }

   
    // Update is called once per frame
    void LateUpdate()
    {
        tppcam();
        
    }



  







    void tppcam() {


        //getting mouse pointer input location
        mousex += (Input.GetAxis("Mouse X")) * mousesen;
        mousey -= (Input.GetAxis("Mouse Y")) * mousesen;

        //clam by y angel
        mousey = Mathf.Clamp(mousey, pitchminmax.x, pitchminmax.y);

        //smooth camera rotation

        currentrotation = Vector3.SmoothDamp(currentrotation, new Vector3(mousey, mousex), ref rotationsmoothvelocity, smoothtime);


        //********************************

        //here we have to rotate the playerbody only in x axes

        float mousexnew = (Input.GetAxis("Mouse X")) * mousesen;

        player.Rotate(Vector3.up * mousexnew);


        //camerat.eulerAngles.y

        //rotation of our camera
        //also can delete the first line below..because it is appliyed above 

        // Vector3 targetrotation = new Vector3(mousey, mousex);


        //transform.eulerAngles = targetrotation;

        //new code because we made new rotation 
        transform.eulerAngles = currentrotation;

        //moving the camera accroding to our target transform

        transform.position = target.position - transform.forward * distance;
        //my_warp();

        // wrap();
        warp3();

    }



    void wrap()
    {
        //#############################################
        //transform.position = target.position - transform.forward * distance;
        switchCamera();
        void switchCamera()
        {
            if (Input.GetButtonDown("test3"))
            {
                cameraChangeCounter();
            }
        }







        void cameraChangeCounter()
        {
            int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
            cameraPositionCounter++;
            cameraPositionChange(cameraPositionCounter);
        }







        void cameraPositionChange(int camPosition)
        {

            if (camPosition > 1)
            {
                camPosition = 0;
            }

            //Set camera position database
            PlayerPrefs.SetInt("CameraPosition", camPosition);
           
            //Set camera position 1
            if (camPosition == 0)
            {
                //set cam 1
                Debug.Log("cam one");
                transform.position = target2.position - transform.forward * distance2;
                
            }
            
            //Set camera position 2
            if (camPosition == 1)
            {
                //set cam 2
                Debug.Log("cam two");
                transform.position = target.position - transform.forward * distance;
            }

        }

        //#############################################
    }


    void my_warp() {


        if (Input.GetButtonDown("one"))
        {

            Debug.Log("pressed ONE");
            transform.position = target.position - transform.forward * distance;

        }

       


        if (Input.GetButtonDown("two")) {


            Debug.Log("pressed TWO");
            transform.position = target.position - transform.forward * distance2;

        }

       



    }

    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
  
    void warp3()
    {

        camtestupdate();
        void camtestupdate()
        {

            if (Input.GetButtonDown("camera"))
            {

                if (cammode == 1)
                {

                    cammode = 0;

                }
                else
                {

                    cammode += 1;

                }
                StartCoroutine(camcc());
            


            }




        }
        IEnumerator camcc()
        {
            yield return new WaitForSeconds(0.1f);
            if (cammode == 0)
            {

                distance = 0f;
                transform.position = target.position - transform.forward * distance;
                Debug.Log("cam 0");
            }

            if (cammode == 1)
            {
                distance = 10f;
                transform.position = target.position - transform.forward * distance;
                Debug.Log("cam 1");

            }



        }

    
    }

    //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>




    void curse() {

        Cursor.lockState = CursorLockMode.Locked;
    }
}
