using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody mech;
    public int speed = 5;
    public int rotationSpeed = 100;
    public float jumpforce = 50f;
    public int jumpcooldown = 1000;
    private Vector3 translationSpeed;
    private Vector3 jumpvector;
    private int functionaljumpcooldown = 0;
   

    //intializing variables
    void Start()
    {
        mech = GetComponent<Rigidbody>();
        jumpvector = new Vector3(0, jumpforce, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //gathering inputs
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        //adjusting inputs
        translationSpeed = new Vector3(0, 0, translation);
        rotation *= Time.deltaTime;

        //applying inputs
        transform.Rotate(0, rotation, 0);
        mech.MovePosition(transform.position + transform.TransformDirection(translationSpeed) * Time.fixedDeltaTime);

        //jumping
        if (Input.GetAxis("Jump") > 0)
        {
            if (functionaljumpcooldown == 0)
            {
                mech.AddForce(jumpvector, ForceMode.Impulse);
                functionaljumpcooldown = jumpcooldown;
            }
        }
        if (functionaljumpcooldown > 0) { functionaljumpcooldown--; }
        Debug.Log(functionaljumpcooldown);

    }
}

