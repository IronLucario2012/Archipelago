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
    public int[] finalConnections;
    public int[] currentConnections;

    public Node(int[] positionXY, int[] connectionsNESW, params int[] current)
    {
        xy = positionXY;
        finalConnections = connectionsNESW;
        currentConnections = current;
    }

    override
    public string ToString()
    {
        string result = "";

        result += "Coordinates: (" + xy[0] + "," + xy[1] + ")\n";
        result += "Number of connections that should be north: " + finalConnections[0] + ", east: " + finalConnections[1] + ", south: " + finalConnections[2] + ", and west: " + finalConnections[3] + "\n";
        result += "Number of connections that are north: " + currentConnections[0] + ", east: " + currentConnections[1] + ", south: " + currentConnections[2] + ", and west: " + currentConnections[3] + "\n";

        return result;
    }
}
#endregion