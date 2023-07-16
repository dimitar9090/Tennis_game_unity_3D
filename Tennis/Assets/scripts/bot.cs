using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{
    float speed = 40;
    Animator animator;
    public Transform ball;
    public Transform aimTarget;

    public Transform[] targets;

    float force = 13;
    Vector3 targetPosition;

    ShotManager shotManager;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        animator = GetComponent<Animator>();
        shotManager = GetComponent<ShotManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        targetPosition.x = ball.position.x;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    Vector3 PickTarget()
    {
        int randomvalue = Random.Range(0, targets.Length);
        return targets[randomvalue].position;
    }

    Shot PickShot()
    {
        int randomvalue = Random.Range(0, 2);
        if (randomvalue == 0)
            return shotManager.topSpin;
        else 
            return shotManager.flat;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Shot currentshot = PickShot();

            Vector3 dir = PickTarget() - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * currentshot.hitForce + new Vector3(0, currentshot.upForce, 0);

            Vector3 ballDir = ball.position - transform.position;

            if (ballDir.x >= 0)
                animator.Play("forehand");
            else
                animator.Play("backhand");

        }
    }
}
