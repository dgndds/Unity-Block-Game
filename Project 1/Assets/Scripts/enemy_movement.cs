using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    [SerializeField] float enemyspeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + enemyspeed * Time.deltaTime * -1);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "despawner"){
            Destroy(this.gameObject);
        }
    }
}
