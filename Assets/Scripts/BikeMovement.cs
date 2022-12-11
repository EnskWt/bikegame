using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BikeMovement : MonoBehaviour
{
    public FixedJoystick Joystick;

    private Rigidbody rb3D;
    private Vector3 direction;

    public GameObject UILose;
    public GameObject UIWin;
    public GameObject UIJoystick;

    public GameObject loseRule;
    public GameObject winRule;

    public GameObject[] rotationObjects;

    public GameObject BicyclePizza;
    public GameObject pizzaPos;
    public GameObject pizza;
    public GameObject smokeParticle;

    public bool speedBool;

    [SerializeField] public float speed;
    [SerializeField] private float pedalsSpeed = 1;
    [SerializeField] public float drag;
    [SerializeField] public float velocity;
    public float force;
    public float repulsionRadius;
    void Start()
    {
        rb3D = GetComponent<Rigidbody>();
        UILose.SetActive(false);
        UIWin.SetActive(false);
        UIJoystick.SetActive(true);
        Time.timeScale = 1;
        speedBool = true;
    }


    void Update()
    {
        MovementDetails();
    }

    private void FixedUpdate()
    {
        Movement();
        WinOrLose();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Finish!")
        {
            LoseRule();
        }


        if (other.gameObject.tag == "Finish!")
        {
            WinRule();
        }

    }

    private void MovementDetails()
    {
        direction.x = Joystick.Horizontal;

        if (direction.x > 0 & speed <= 16)
        {
            speed += velocity * Time.deltaTime;
        }
        if (direction.x > 0 & speed < 0)
        {
            speed = 0;
        }
        if (direction.x < 0 & speed > -3)
        {
            speed -= velocity * drag * Time.deltaTime;
        }
        Inertion();
    }

    private void Movement()
    {
        if (direction.x > 0)
        {
            rb3D.MovePosition(rb3D.position + direction * speed * Time.fixedDeltaTime);
            RotationForward();
        }
        if (direction.x < 0 & speed > -3)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            NoRotation();
        }
        if (direction.x < 0 & speed < -3)
        {
            rb3D.MovePosition(rb3D.position + direction * (-speed) * Time.fixedDeltaTime);
            RotationBackward();
        }
        if (direction.x == 0 & speed > -3)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            RotationForward();
        }
        if (speedBool == false)
        {
            direction.x = 0;
            speed = 0;
            pedalsSpeed = 0;
        }
    }

    private void Inertion()
    {
        if (direction.x == 0 & speed > 0)
        {
            speed -= velocity * Time.deltaTime;
        }
    }

    private void RotationForward()
    {
        rotationObjects[0].transform.Rotate(new Vector3(1 * (speed * 0.8f), 0, 0));
        rotationObjects[1].transform.Rotate(new Vector3(1 * (speed * 0.8f), 0, 0));
        rotationObjects[2].transform.Rotate(new Vector3(2 * pedalsSpeed, 0, 0));
    }

    private void RotationBackward()
    {
        rotationObjects[0].transform.Rotate(new Vector3(1 * (speed * 0.8f), 0, 0));
        rotationObjects[1].transform.Rotate(new Vector3(1 * (speed * 0.8f), 0, 0));
        rotationObjects[2].transform.Rotate(new Vector3(-2 * pedalsSpeed, 0, 0));
    }

    private void NoRotation()
    {
        rotationObjects[0].transform.Rotate(new Vector3(-1 * (speed * 0.8f), 0, 0));
        rotationObjects[1].transform.Rotate(new Vector3(-1 * (speed * 0.8f), 0, 0));
        rotationObjects[2].transform.Rotate(new Vector3(-1 * pedalsSpeed, 0, 0));
    }



    private void LoseRule()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, repulsionRadius);
        foreach (Collider coll in colliders)
        {
            if (coll.tag != "Road" & coll.tag != "Finish!" & coll.tag != "SpawnedRoad")
            {
                coll.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, repulsionRadius);
                Destroy(loseRule, 1f);
            }
        }
    }

    private void WinRule()
    {
        speedBool = false;
        UIJoystick.SetActive(false);

        Instantiate(smokeParticle, BicyclePizza.transform.position, Quaternion.identity);
        Destroy(BicyclePizza, 0.1f);
        Instantiate(smokeParticle, pizzaPos.transform.position, Quaternion.identity);
        Instantiate(pizza, pizzaPos.transform.position, Quaternion.identity);
        Destroy(winRule, 2f);
    }

    private void WinOrLose()
    {
        if (loseRule == null)
        {
            UILose.SetActive(true);
            UIJoystick.SetActive(false);
            Time.timeScale = 0;
        }
        if (winRule == null)
        {
            UIWin.SetActive(true);
            Time.timeScale = 0;
        }
    }
}