using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody rigid;
    [SerializeField]
    private float _speed = 1;

    [SerializeField]
    private Animator animate;
    private bool hasMoved = false;
    private bool isSneaking;
    public bool UseSocks;
    public bool HasKeyCard;
    public bool HasKeyCard2;
    public bool HasKeyCard3;


    public GameObject WaveSpawn;
    // Use this for initialization
    void Start()
    {
        this.rigid = GetComponent<Rigidbody>();
        this.animate = GetComponent<Animator>();
        isSneaking = false;
        UseSocks = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCharacter();
        RotateCamera();
        Sneaking();
        CheckDoor();
        //Debug.Log(_speed);
        
    }

    void MoveCharacter()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * _speed;

        if (horizontal != 0 || vertical != 0)
        {
            hasMoved = true;
            this.animate.SetFloat("Speed", _speed);
        }
        else
        {
            this.animate.SetFloat("Speed", 0);
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

    void InstantiateSoundWave(int feet)
    {
        if (feet == 0 && isSneaking && !UseSocks || feet == 1 && isSneaking && !UseSocks)
        {
            GameObject temp = Instantiate(WaveSpawn, new Vector3(transform.position.x, transform.position.y - .20f, transform.position.z), Quaternion.Euler(90, 0, 0));
            temp.GetComponent<WaveExpander>().TotalExpansionTime = 0.5f;
            IngameUIEventhandler.F_OnMovementChange(temp.GetComponent<WaveExpander>().TotalExpansionTime * 100);
        }
        else if (feet == 0 && isSneaking && UseSocks || feet == 1 && isSneaking && UseSocks)
        {
            GameObject temp = Instantiate(WaveSpawn, new Vector3(transform.position.x, transform.position.y - .20f, transform.position.z), Quaternion.Euler(90, 0, 0));
            temp.GetComponent<WaveExpander>().TotalExpansionTime = 0.1f;
            IngameUIEventhandler.F_OnMovementChange(temp.GetComponent<WaveExpander>().TotalExpansionTime * 100);

        }
        else if (feet == 0 && UseSocks || feet == 1 && UseSocks)
        {
            GameObject temp = Instantiate(WaveSpawn, new Vector3(transform.position.x, transform.position.y - .20f, transform.position.z), Quaternion.Euler(90, 0, 0));
            temp.GetComponent<WaveExpander>().TotalExpansionTime = 0.4f;
            IngameUIEventhandler.F_OnMovementChange(temp.GetComponent<WaveExpander>().TotalExpansionTime * 100);

        }
        else
        {
            GameObject temp = Instantiate(WaveSpawn, new Vector3(transform.position.x, transform.position.y - .20f, transform.position.z), Quaternion.Euler(90, 0, 0));
            IngameUIEventhandler.F_OnMovementChange(temp.GetComponent<WaveExpander>().TotalExpansionTime * 100);
        }
    }

    void CheckDoor()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position,this.transform.up,out hit,2f))
        {
            if (hit.transform.tag == "Door" && HasKeyCard)
            {
                hit.transform.gameObject.GetComponent<Animator>().SetBool("IsOpened", true);
                hit.transform.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            if (hit.transform.tag == "Door2" && HasKeyCard2)
            {
                hit.transform.gameObject.GetComponent<Animator>().SetBool("IsOpened", true);
                hit.transform.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            if (hit.transform.tag == "Door3" && HasKeyCard2)
            {
                hit.transform.gameObject.GetComponent<Animator>().SetBool("IsOpened", true);
                hit.transform.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    void Sneaking()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSneaking = true;
            _speed = 0.5f;
        }
        else
        {
            isSneaking = false;
            _speed = 1;
        }
    }
}
