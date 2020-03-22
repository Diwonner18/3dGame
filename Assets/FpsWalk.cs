    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsWalk : MonoBehaviour
{
    Vector3 playerAxis;
    Vector3 playerRotAxis;
    Vector3 headRotAxis;
    public CharacterController charac;
    public GameObject head;
    public GameObject [] prefabObjeto = new GameObject[9];
    public GameObject selected;
   
    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        playerAxis = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 globalmove = transform.TransformDirection(playerAxis);//local pra global 
        charac.SimpleMove(globalmove * 5);
        playerRotAxis = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        headRotAxis = new Vector3(-Input.GetAxis("Mouse Y"), 0, 0);

        transform.Rotate(playerRotAxis);//gira o corpo
        head.transform.Rotate(headRotAxis);//gira cabeca

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject ball = Instantiate(selected, transform.position+head.transform.forward, transform.rotation);
            ball.GetComponent<Rigidbody>().AddForce(head.transform.forward * 1000+ Vector3.up*200);
            ball.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.right*500, ForceMode.Impulse);
            Destroy(ball, 3);
        }

        if(Input.GetKey(KeyCode.Alpha1)) { selected = prefabObjeto[0]; }
        if (Input.GetKey(KeyCode.Alpha2)) { selected = prefabObjeto[1]; }
        if (Input.GetKey(KeyCode.Alpha3)) { selected = prefabObjeto[2]; }
        if (Input.GetKey(KeyCode.Alpha4)) { selected = prefabObjeto[3]; }
        if (Input.GetKey(KeyCode.Alpha5)) { selected = prefabObjeto[4]; }
        if (Input.GetKey(KeyCode.Alpha6)) { selected = prefabObjeto[5]; }
        if (Input.GetKey(KeyCode.Alpha7)) { selected = prefabObjeto[6]; }
        if (Input.GetKey(KeyCode.Alpha8)) { selected = prefabObjeto[7]; }
        if (Input.GetKey(KeyCode.Alpha9)) { selected = prefabObjeto[8]; }

    }
}
