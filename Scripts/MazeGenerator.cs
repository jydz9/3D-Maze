using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WallState
{
    LEFT = 1,
    RIGHT = 2,
    UP = 4,
    DOWN = 8,

    VISITED = 128,
}

public struct Position
{
    public int X;
    public int Y;
}
public struct Neighbor
{
    public Position Position;
    public WallState SharedWall;
}

public static class MazeGenerator
{
    private static WallState GetOppositeWall(WallState wall)
    {
        switch(wall)
        {
            case WallState.RIGHT: return WallState.LEFT;
            case WallState.LEFT: return WallState.RIGHT;
            case WallState.UP: return WallState.DOWN;
            case WallState.DOWN: return WallState.UP;
            default: return WallState.LEFT;
        }
    }

    private static WallState[,] ApplyRecursiveBacktracker(WallState[,] maze, int width, int height)
    {
        var rng = new System.Random();
        var positionStack = new Stack<Position>();
        var position = new Position {X = rng.Next(0, width), Y = rng.Next(0, height)};

        maze[position.X, position.Y] |= WallState.VISITED;
        positionStack.Push(position);

        while(positionStack.Count > 0){
            var current = positionStack.Pop();
            var neighbors = GetUnvisitedNeighbors(current, maze, width, height);

            if (neighbors.Count > 0){
                positionStack.Push(current);

                var randIndex = rng.Next(0, neighbors.Count);   
                var randomNeighbor = neighbors[randIndex];

                var nPosition = randomNeighbor.Position;
                maze[current.X, current.Y] &= ~randomNeighbor.SharedWall; //removes shared wall
                maze[nPosition.X, nPosition.Y] &= ~GetOppositeWall(randomNeighbor.SharedWall);

                maze[nPosition.X, nPosition.Y] |= WallState.VISITED;

                positionStack.Push(nPosition);
            }
        }

        return maze;
    }

    public static List<Neighbor> GetUnvisitedNeighbors(Position p, WallState[,] maze, int width, int height)
    {
        var list = new List<Neighbor>();
        if (p.X > 0){
            if (!maze[p.X - 1, p.Y].HasFlag(WallState.VISITED)){
                list.Add(new Neighbor {
                    Position = new Position
                    {
                        X = p.X - 1,
                        Y = p.Y
                    },
                    SharedWall = WallState.LEFT
                });
            }
        }
        if (p.Y > 0){
            if (!maze[p.X, p.Y - 1].HasFlag(WallState.VISITED)){
                list.Add(new Neighbor {
                    Position = new Position
                    {
                        X = p.X,
                        Y = p.Y - 1
                    },
                    SharedWall = WallState.DOWN
                });
            }
        }
        if (p.X < width - 1){
            if (!maze[p.X + 1, p.Y].HasFlag(WallState.VISITED)){
                list.Add(new Neighbor {
                    Position = new Position
                    {
                        X = p.X + 1,
                        Y = p.Y
                    },
                    SharedWall = WallState.RIGHT
                });
            }
        }
        if (p.Y < height - 1){
            if (!maze[p.X, p.Y + 1].HasFlag(WallState.VISITED)){
                list.Add(new Neighbor {
                    Position = new Position
                    {
                        X = p.X,
                        Y = p.Y + 1
                    },
                    SharedWall = WallState.UP
                });
            }
        }
        return list;
    }

    public static WallState[,] Generate(int width, int height)
    {
        WallState[,] maze = new WallState[width, height];
        WallState initial = WallState.RIGHT | WallState.LEFT | WallState.UP | WallState.DOWN;
        for (int i = 0; i < width; i++){
            for (int j = 0; j < height; j++){
                maze[i,j] = initial;
            }
        }
        return ApplyRecursiveBacktracker(maze, width, height);
    }
}
