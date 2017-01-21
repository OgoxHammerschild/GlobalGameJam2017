using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody rigid;
    [SerializeField]
    private float _speed = 1;

    private bool hasMoved = false;

    public GameObject WaveSpawn;
    // Use this for initialization
    void Start()
    {
        this.rigid = GetComponent<Rigidbody>();
        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCharacter();
        RotateCamera();
    }

    void MoveCharacter()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * _speed;

        if (horizontal != 0 || vertical != 0)
        {
            hasMoved = true;
        }

        this.rigid.MovePosition(this.transform.position + new Vector3(horizontal, 0, vertical));
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
                this.transform.Rotate(90, 0, 0);
            }
        }

    }

    IEnumerator SpawnWave()
    {
        if (hasMoved)
        {
            hasMoved = false;
            Instantiate(WaveSpawn, new Vector3(transform.position.x,transform.position.y - 0.01f,transform.position.z), Quaternion.Euler(90,0,0));
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(SpawnWave());
    }
}
