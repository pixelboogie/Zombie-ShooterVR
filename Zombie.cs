using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public AudioSource source;
    public AudioClip growl;
    public AudioClip growl2;

    public float zSpeed = 1f;

    private float dissolveDelay = 1.5f;
    private bool alive = true;
    private bool destroyed = false;

    void Start()
    {
        source.PlayOneShot(growl);
        source.PlayOneShot(growl2);

        //On instatiation of class get all the rigidbody enabled children of the zombie and set theyr isKinematic field to true.
        RagDoll(true);
    }


    void Update()
    {
        if (this != null)
        {
            if (alive)
            {
                Run();
            }
            else
            {
                dissolveDelay -= Time.deltaTime;
                if (dissolveDelay < 0)
                {
                    if (destroyed == false)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    void Run()
    {
        transform.forward = Vector3.ProjectOnPlane((Camera.main.transform.position - transform.position), Vector3.up).normalized;
        transform.position += Time.deltaTime * transform.forward * zSpeed;
    }

    void RagDoll(bool value)
    {
        var bodyParts = GetComponentsInChildren<Rigidbody>();
        foreach (var bodyPart in bodyParts)
        {
            bodyPart.isKinematic = value;
        }
    }

    void KillZombie(RaycastHit hitLocationInfo)
    {
        GetComponent<Animator>().enabled = false;
        RagDoll(false);
        alive = false;
        Vector3 hitPoint = hitLocationInfo.point;

        var colliders = Physics.OverlapSphere(hitPoint, 0.5f);

        foreach (var collider in colliders)
        {
            var rigidBody = collider.GetComponent<Rigidbody>();
            if (rigidBody)
            {
                rigidBody.AddExplosionForce(1000, hitPoint, 0.5f);
            }

        }

    }

}