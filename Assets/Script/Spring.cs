using UnityEngine;
using UnityEngine.UI;

public class Spring : MonoBehaviour
{
    private Rigidbody rb;
    private float force;
    private int pinBallCount;

    public bool portReady;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > 22.2)
        {
            portReady = false;
            rb.linearVelocity = Vector3.zero;
            transform.position = new Vector3(transform.position.x, 22.2f, transform.position.z);
        }


        if (transform.position.y < 0.5f)
        {

            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }

        if (transform.position.y <= 2.2f && !portReady)
        {
            portReady = true;
            SpawnPinBall();
        }
    }

    public void Relord()
    {
        rb.isKinematic = true;

        transform.Translate(Vector3.down * 10f * Time.deltaTime);
    }

    public void Change(float nowChange)
    { 
        force = nowChange;

        if (force > 5000f)
        {
            force = 5000f;
        }
        Debug.Log("Change || " + force);
    }

    public void Shoot()
    {
        rb.isKinematic = false;
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    public void SpawnPinBall()
    {
        Debug.Log("Ready to shoot");
        GameObject pinBall = SpawnManager.sharedInStance.GetpooledObject();
        Rigidbody pinBallrb = pinBall.GetComponent<Rigidbody>();
            if (pinBall != null)
            {
                pinBall.SetActive(true);
                pinBallrb.linearVelocity = Vector3.zero;
                pinBall.transform.position = new Vector3(0f, 10.56f, 14.76f);
            }
        
    }

}
