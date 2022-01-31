using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Animations;

public class MindScript : MonoBehaviour
{
    public BodyScript MyBodyScript;
    public GameObject Brain;
    private CharacterController _controller;
    public bool Stuned;
    public bool Immune;
    public float StunTimer;
    public bool m_FacingRight = false;

    //public Animator MyAnimator;
    public void MoveBodyLeft()
    {
        if (MyBodyScript.xpos == 0)
        {
            MyBodyScript.WallHit();
        }
        else
        {
            var Nodes = GameObject.FindGameObjectsWithTag("Node");
            foreach (var node in Nodes)
            {
                if ((node.GetComponent<NodePos>().xpos == MyBodyScript.xpos - 1) && (node.GetComponent<NodePos>().ypos == MyBodyScript.ypos))
                {
                    MyBodyScript.MoveMan(node, node.GetComponent<NodePos>().xpos, node.GetComponent<NodePos>().ypos);
                    return;
                }
            }
        }
    }
    public void MoveBodyRight()
    {
        if (MyBodyScript.xpos == 5)
        {
            MyBodyScript.WallHit();
        }
        else
        {
            var Nodes = GameObject.FindGameObjectsWithTag("Node");
            foreach (var node in Nodes)
            {
                if ((node.GetComponent<NodePos>().xpos == MyBodyScript.xpos + 1) && (node.GetComponent<NodePos>().ypos == MyBodyScript.ypos))
                {
                    MyBodyScript.MoveMan(node, node.GetComponent<NodePos>().xpos, node.GetComponent<NodePos>().ypos);
                    return;
                }
            }
        }
    }
    public void MoveBodyDown()
    {
        if (MyBodyScript.ypos == 0)
        {
            MyBodyScript.WallHit();
        }
        else
        {
            var Nodes = GameObject.FindGameObjectsWithTag("Node");
            foreach (var node in Nodes)
            {
                if ((node.GetComponent<NodePos>().xpos == MyBodyScript.xpos) && (node.GetComponent<NodePos>().ypos == MyBodyScript.ypos - 1))
                {
                    MyBodyScript.MoveMan(node, node.GetComponent<NodePos>().xpos, node.GetComponent<NodePos>().ypos);
                    return;
                }
            }
        }
    }
    public void MoveBodyUp()
    {
        if (MyBodyScript.ypos == 1)
        {
            MyBodyScript.WallHit();
        }
        else
        {
            var Nodes = GameObject.FindGameObjectsWithTag("Node");
            foreach (var node in Nodes)
            {
                if ((node.GetComponent<NodePos>().xpos == MyBodyScript.xpos) && (node.GetComponent<NodePos>().ypos == MyBodyScript.ypos + 1))
                {
                    MyBodyScript.MoveMan(node, node.GetComponent<NodePos>().xpos, node.GetComponent<NodePos>().ypos);
                    return;
                }
            }
        }
    }
    public void Stun()
    {
        if (!Immune)
            Stuned = true;
    }
    public void Collide(string text)
    {
        print(text);
        if (text == "Left")
        {
            MoveBodyLeft();
        }
        else if (text == "Right")
        {
            MoveBodyRight();
        }
        else if (text == "Up")
        {
            MoveBodyUp();
        }
        else if (text == "Down")
        {
            MoveBodyDown();
        }
        else
        {
            Stun();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _controller = Brain.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetAxis("Horizontal") > 0)
        {
            Brain.gameObject.transform.position = new Vector3(Brain.gameObject.transform.position.x + .5f, Brain.gameObject.transform.position.y, Brain.gameObject.transform.position.z);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            Brain.gameObject.transform.position = new Vector3(Brain.gameObject.transform.position.x - .5f, Brain.gameObject.transform.position.y, Brain.gameObject.transform.position.z);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            Brain.gameObject.transform.position = new Vector3(Brain.gameObject.transform.position.x, Brain.gameObject.transform.position.y + .5f, Brain.gameObject.transform.position.z);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            Brain.gameObject.transform.position = new Vector3(Brain.gameObject.transform.position.x, Brain.gameObject.transform.position.y - .5f, Brain.gameObject.transform.position.z);
        }
        
        if (Brain.gameObject.transform.position.x > 650f)
        {
            Brain.gameObject.transform.position = new Vector3(650f, Brain.gameObject.transform.position.y, Brain.gameObject.transform.position.z);
        }
        /*
        if (Brain.gameObject.transform.position.x < -650f)
        {
            Brain.gameObject.transform.position = new Vector3(-650f, Brain.gameObject.transform.position.y, Brain.gameObject.transform.position.z);
        }
        if (Brain.gameObject.transform.position.y > 205f)
        {
            Brain.gameObject.transform.position = new Vector3(Brain.gameObject.transform.position.x, 205f, Brain.gameObject.transform.position.z);
        }
        if (Brain.gameObject.transform.position.y < -205f)
        {
            Brain.gameObject.transform.position = new Vector3(Brain.gameObject.transform.position.x, -205f, Brain.gameObject.transform.position.z);
        }
        */
        if (Immune)
        {
            StunTimer += Time.deltaTime;
            if (StunTimer >= 1.0f)
            {
                Immune = false;
                StunTimer = 0f;
            }
        }
        if (!Stuned)
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            _controller.Move(move * Time.deltaTime * 600f);
            if (Input.GetAxis("Horizontal") < 0)
            {
                m_FacingRight = false;
                Brain.transform.localRotation = Quaternion.Euler(0, 180, 0);
                //MyAnimator.Play(("Base Layer.TurnLeft"), 0, 0);
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                m_FacingRight = true;
                Brain.transform.localRotation = Quaternion.Euler(0, 0, 0);
                ///MyAnimator.Play(("Base Layer.TurnRight"), 0, 0);
            }
            else
            {
                Brain.transform.localRotation = Quaternion.Euler(0, 0, 0);
                //MyAnimator.Play(("Base Layer.StayStill"), 0, 0);
            }
        }
        else
        {
            StunTimer += Time.deltaTime;
            if (StunTimer >= 1.0f)
            {
                Immune = true;
                Stuned = false;
                StunTimer = 0f;
            }
        }
        if (Immune)
        {
            StunTimer += Time.deltaTime;
            if (StunTimer >= 1.0f)
            {
                Immune = false;
                StunTimer = 0f;
            }
        }
    }
}
