using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Direction { Up, Right, Down, Left };

public class GlobalVariablesGame : MonoBehaviour {

    public int levelNumber = 0;
    public Level currentLevel;

    private void Start()
    {
        levelNumber = GlobalVariablesMenu.levelNumber;
        currentLevel = GlobalVariablesMenu.levelList.levels[levelNumber+1];
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("LevelSelectScene");
    }
    

}

#region Level Data Classes
[Serializable]
public class LevelList
{
    public List<Level> levels;

    public LevelList()
    {
        levels = new List<Level>();
    }
}

[Serializable]
public class Level
{
    public int id;
    public int[] sizeXY;
    public List<Node> nodes;

    public Level(int[] size)
    {
        sizeXY = size;
    }

    public Level(int ID, int[] size, List<Node> list)
    {
        id = ID;
        sizeXY = size;
        nodes = list;
    }

    public void AddNode(Node n)
    {
        nodes.Add(n);
    }

    override
    public string ToString()
    {
        string result = "";
        result += "Width: " + sizeXY[0] + ", Height: " + sizeXY[1];
        result += "\nNodes:";
        foreach(Node n in nodes)
        {
            result += "\n" + n.ToString();
        }

        return result;
    }
}

[Serializable]
public class Node
{
    public int[] xy;
    public int[] connections;

    public Node(int[] positionXY, int[] connectionsNESW)
    {
        xy = positionXY;
        connections = connectionsNESW;
    }

    override
    public string ToString()
    {
        string result = "";

        result += "Coordinates: (" + xy[0] + "," + xy[1] + ")\n";
        result += "Number of connections north: " + connections[0] + ", east: " + connections[1] + ", south: " + connections[2] + ", and west: " + connections[3];


        return result;
    }
}
#endregion