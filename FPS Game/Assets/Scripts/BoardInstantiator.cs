using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardInstantiator : MonoBehaviour
{
    public int Rows;
    public int columns;
    public GameObject squaresPrefaps;
    public GameObject triggersPrefaps;
    public GameObject ParentSquares;
    public GameObject Parenttriggers;
    public GameObject Player; 
    GameObject Instantiated;
    

    void Start()
    {
        BoardSpawn();
        var glref = Player.GetComponent<LogicScript>();


    }






    public void BoardSpawn()
    {
        Vector3 SquarePosition;
        Vector3 triggerPosition;
        float squarewidth = 2.05f;
        var glref = Player.GetComponent<LogicScript>();
        
        
        glref.maxX = Rows;
        glref.maxY = columns;
        glref.Board = new int[Rows, columns];
        
        for (int i =0;i<Rows;i++)
        {
            for (int y=0;y<columns;y++)
            {
                string namecoords = i.ToString() +"."+ y.ToString();
                SquarePosition = this.transform.position + new Vector3(squarewidth * i + 1.00400f, -squarewidth/2 + .228f, squarewidth * y + 1.00400f);
                Instantiated= Instantiate(squaresPrefaps, SquarePosition , Quaternion.Euler(-90, 0, 0));
                Instantiated.name = namecoords;
                Instantiated.transform.localScale=new Vector3(1, 1, 1);
                Instantiated.transform.parent = ParentSquares.transform;


                triggerPosition = this.transform.position + new Vector3(squarewidth * i + 1.00400f, +squarewidth/2-.228f, squarewidth * y + 1.00400f);
                Instantiated = Instantiate(triggersPrefaps, triggerPosition, Quaternion.Euler(0, 0, 0));
                Instantiated.name = namecoords;
                Instantiated.transform.localScale = new Vector3(1.2f, .1f, 1.2f);
                Instantiated.transform.parent = Parenttriggers.transform;
            }
        }
        
        
        
    }

}
