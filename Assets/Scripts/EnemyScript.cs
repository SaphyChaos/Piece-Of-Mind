using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private float deathClock;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Brain")
        {
            var mind = GameObject.Find("topScreen");
            mind.GetComponent<MindScript>().Collide(this.gameObject.GetComponentInChildren<Text>().text);
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - .5f, this.gameObject.transform.position.z);
        deathClock += Time.deltaTime;
        if(deathClock >= 20.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
