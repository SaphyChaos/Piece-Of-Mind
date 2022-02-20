using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyScript : MonoBehaviour
{
    public int xpos;
    public int ypos;
    private int HP;
    public GameObject Body;
    public GameObject GameOverScreen;
    public GameObject WinScreen;
    public Slider healthBar;
    public void DamageBody(int damage)
    {
        
        healthBar.value -= damage;
        HP = (int)healthBar.value;
        if(HP <= 0)
        {
            GameOverScreen.SetActive(true); ;
        }
    }
    public void MoveMan(GameObject TargetNode, int newx, int newy)
    {
        //1 0, 3 1
        if((newx == 1 && newy == 0) || (newx == 3) && (newy == 1))
        {
            DamageBody(1);
            return;
        }
        if(newx == 5 && newy == 0)
        {
            WinScreen.SetActive(true);
        }
        Body.gameObject.transform.position = new Vector3(TargetNode.transform.position.x, TargetNode.transform.position.y, TargetNode.transform.position.z);
        xpos = newx;
        ypos = newy;
    }
    public void WallHit()
    {
        DamageBody(1);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
