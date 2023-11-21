using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    Vector3 angle; //각도 변수
    public float sensitivity = 200;
    public float move_sensitivity = 10;
    // Start is called before the first frame update
    void Start()
    {
        //시작할 때 현재 카메라의 각도를 적용
        angle.y = -Camera.main.transform.eulerAngles.x;
        angle.x = Camera.main.transform.eulerAngles.y;
        angle.z = Camera.main.transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        //<마우그에 따라 카메라 회전>

        //1. 마우스의 좌우 입력을 받아옴
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        //2. 방향

        angle.x += x * sensitivity * Time.deltaTime;
        angle.y += y * sensitivity * Time.deltaTime;

        //3. 회전    

        transform.eulerAngles = new Vector3(-angle.y, angle.x, angle.z);

        //<키보드 이동에 따른 시점 변화>

        //<왼쪽으로 이동
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-0.1f * move_sensitivity, 0.0f, 0.0f);
        }
        //<오른쪽으로 이동

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(0.1f * move_sensitivity, 0.0f, 0.0f);
        }
        //<전진>
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0.0f, 0.0f, 0.1f * move_sensitivity);
        }
        //<후진>
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0.0f, 0.0f, -0.1f * move_sensitivity);
        }
    }
}
