using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public float speed;
    bool turning = false;

    void Start()
    {
        speed = Random.Range(FlockManager.FM.minSpeed, FlockManager.FM.maxSpeed);
    }


    void Update()
    {
        /*
        Bounds b = new Bounds(FlockManager.FM.transform.position, new Vector3(FlockManager.FM.FlyLimit.x, FlockManager.FM.FlyLimit.y, 1) * 2);

        if (!b.Contains(transform.position))
        {
            turning = true;
        }
        else
            turning = false;
        
        if (turning)
        {
            //Vector2 direction = new Vector3(FlockManager.FM.goalPos.x, FlockManager.FM.goalPos.y, 0) - transform.position;
            Vector2 direction = new Vector3(FlockManager.FM.transform.position.x, FlockManager.FM.transform.position.y, 0) - transform.position;
            //Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, new Vector3(direction.x, direction.y, 0));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), FlockManager.FM.rotationSpeed * Time.deltaTime);
        }
        */
        
        if (Random.Range(0, 1000) < 10) // could * by dealta.time to make it fps independent
        {
            speed = Random.Range(FlockManager.FM.minSpeed, FlockManager.FM.maxSpeed);
        }
        if (Random.Range(0, 100) < 90)
        {
            ApplyRules();
        }
        
        this.transform.Translate(0, speed * Time.deltaTime, 0);
    }

    void ApplyRules()
    {
        float originalSpeed = speed;
        GameObject[] allBees;
        allBees = FlockManager.FM.allBees;

        Vector2 vcenter = Vector2.zero;
        Vector2 vavoid = Vector2.zero;
        float gSpeed = 0.01f;
        float nDistance;
        int groupSize = 0;

        foreach(GameObject bee in allBees)
        {
            if (bee != this.gameObject)
            {
                nDistance = Vector2.Distance(new Vector2(bee.transform.position.x, bee.transform.position.y), new Vector2(this.transform.position.x, this.transform.position.y));
                if (nDistance <= FlockManager.FM.neighbourDistance)
                {
                    vcenter += new Vector2(bee.transform.position.x, bee.transform.position.y);
                    //vcenter += bee.transform.position;
                    groupSize++;

                    if (nDistance < 1.0f)
                    {
                        vavoid = vavoid + (new Vector2(this.transform.position.x, this.transform.position.y) - new Vector2(bee.transform.position.x, bee.transform.position.y));
                    }
                    
                    Flock anotherFlock = bee.GetComponent<Flock>();
                    gSpeed = gSpeed + anotherFlock.speed;

                }
            }
        }
        
        if (groupSize > 0)
        {
            vcenter = vcenter / groupSize + (FlockManager.FM.goalPos - new Vector2(transform.position.x, transform.position.y));
            speed = speed / groupSize;

            Vector2 direction = (vcenter + vavoid) - new Vector2(transform.position.x, transform.position.y);
            if (direction != Vector2.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, new Vector3(direction.x, direction.y, 0));
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, FlockManager.FM.rotationSpeed * Time.deltaTime);
            }
            /*
                transform.rotation = Quaternion.Slerp(transform.rotation, 
                                                      Quaternion.LookRotation(direction),
                                                      FlockManager.FM.rotationSpeed * Time.deltaTime);
                                                      */
            // Restore the original speed after rotation calculation
            speed = originalSpeed;
        }
    }
}
