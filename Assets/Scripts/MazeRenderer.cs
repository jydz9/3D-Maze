using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField]
    [Range(1, 50)]
    private int height = 10;
    [SerializeField]
    [Range(1,50)]
    private int width = 10;
    [SerializeField]
    private float size = 1f;
    [SerializeField]
    private Transform wallPrefab = null;
    public static float getValue;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(SliderHeight.heightValue + " is Value");
        if (SliderHeight.heightValue == 0 && SliderWidth.widthValue == 0)
        {
            height = 10;
            width = 10;
        }
        else if (SliderHeight.heightValue != 0)
        {
            //Debug.Log(SliderHeight.heightValue + "Is the height");
            height = (int)SliderHeight.heightValue;

            if (SliderWidth.widthValue != 0)
            {
                //Debug.Log(SliderWidth.widthValue + "Is the width");
                width = (int)SliderWidth.widthValue;
            }
        }
       
        var maze = MazeGenerator.Generate(width, height);
        Draw(maze);        
    }

    private void Draw(WallState[,] maze) 
    {
        for (int i = 0; i < width; i++){
            for (int j = 0; j < height; j++){
                var cell = maze[i,j];
                var position = new Vector3(-width/2 + i, 0, -height/2 + j);

                if (cell.HasFlag(WallState.UP)){
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0, 0, size/2);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                }

                if (cell.HasFlag(WallState.LEFT)){
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size/2, 0, 0);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                }

                if (i == width - 1){
                    if (cell.HasFlag(WallState.RIGHT)){
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;
                        rightWall.position = position + new Vector3(+size/2, 0, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                    }
                }

                if (j == 0){
                    if (cell.HasFlag(WallState.DOWN)){
                        var bottomWall = Instantiate(wallPrefab.transform) as Transform;
                        bottomWall.position = position + new Vector3(0, 0, -size/2);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}