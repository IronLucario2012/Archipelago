using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandScript : MonoBehaviour
{
    public Node INode;
    public GameObject Island;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToggleDirectionButtons()
    {
        //If (there are any D-Buttons up), put them all down
        //Else, for each direction
        //If (there is an island there to connect to), bring up that direction's button
        //Else, ignore it
        if (INode.buttonsUp)
        {
            PutButtonsDown();
        }
        else
        {
            foreach(Direction direction in Enum.GetValues(typeof(Direction)))
            {
                if(GetFirstNodeInDirection(direction) != null)
                {
                    //Put button up
                }
            }
        }


    }

    public void PutButtonsDown()
    {

    }

    public void ConnectIslands()
    {

    }

    public Node GetFirstNodeInDirection(Direction d)
    {
        return null;
    }
}
