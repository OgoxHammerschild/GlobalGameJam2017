using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rigid;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _rotationspeed;
    // Use this for initialization
    void Start()
    {
        this.rigid = GetComponent<Rigidbody>();
        _speed = 5;
        _rotationspeed = 0.05f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCharacter();
        RotateCamera();
    }

    void MoveCharacter()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime;

        this.rigid.MovePosition(this.transform.position + this.transform.rotation * new Vector3(horizontal, 0, vertical));
    }
    void RotateCamera()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Ground")
            {
                this.transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
                //float angle = Vector2.Angle(new Vector2(transform.position.x, transform.position.z), new Vector2(hit.point.x, hit.point.z));
                //this.transform.Rotate(Vector3.up, angle);
            }
        }

    }
}
