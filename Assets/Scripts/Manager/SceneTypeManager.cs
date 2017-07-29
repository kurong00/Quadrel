using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

public class SceneTypeManager : Singleton<SceneTypeManager>
{

    GameColor colorList = new GameColor();

    public int GameMode = 0;


    public string playerName = "mushroom";

    public ScenesType currentType = ScenesType.MONDAY;
    public enum ScenesType
    {
        MONDAY = 1,
        TUESDAY,
        WENESDAY,
        THURSDAY,
        FRIDAY,
        SATERDAY,
        SUNDAY,
    }

    public GameColor SelectColor(ScenesType scene)
    {
        switch (scene)
        {
            case ScenesType.MONDAY:
                playerName = "mushroom";
                colorList.colorOfTileOne = new Color(140 / 255f, 126 / 255f, 120 / 255f);
                colorList.colorOfTileTwo = new Color(191 / 255f, 166 / 255f, 149 / 255f);
                colorList.colorOfWall = new Color(193 / 255f, 104 / 255f, 93 / 255f);
                colorList.colorOfMeshRenderOne = new Color(239 / 255f, 83 / 255f, 80 / 255f);
                colorList.colorOfMeshRenderTwo = new Color(239 / 255f, 154 / 255f, 154 / 255f);
                colorList.colorOfSpikes = new Color(255 / 255f, 67 / 255f, 70 / 255f);
                break;
            case ScenesType.TUESDAY:
                playerName = "cheese";
                colorList.colorOfTileOne = new Color(120 / 255f, 94 / 255f, 77 / 255f);
                colorList.colorOfTileTwo = new Color(188 / 255f, 157 / 255f, 137 / 255f);
                colorList.colorOfWall = new Color(255 / 255f, 146 / 255f, 52 / 255f);
                colorList.colorOfMeshRenderOne = new Color(111 / 255f, 56 / 255f, 38 / 255f);
                colorList.colorOfMeshRenderTwo = new Color(232 / 255f, 170 / 255f, 140 / 255f);
                colorList.colorOfSpikes = new Color(98 / 255f, 59 / 255f, 28 / 255f);
                break;
            case ScenesType.WENESDAY:
                playerName = "block";
                colorList.colorOfTileOne = new Color(173 / 255f, 172 / 255f, 167 / 255f);
                colorList.colorOfTileTwo = new Color(142 / 255f, 139 / 255f, 140 / 255f);
                colorList.colorOfWall = new Color(47 / 255f, 48 / 255f, 50 / 255f);
                colorList.colorOfMeshRenderOne = new Color(47 / 255f, 48 / 255f, 50 / 255f);
                colorList.colorOfMeshRenderTwo = new Color(140 / 255f, 126 / 255f, 120 / 255f);
                colorList.colorOfSpikes = new Color(255 / 255f, 11 / 255f, 67 / 255f);
                break;
            case ScenesType.THURSDAY:
                playerName = "cube_sushi";
                colorList.colorOfTileOne = new Color(56 / 255f, 68 / 255f, 56 / 255f);
                colorList.colorOfTileTwo =  new Color(204 / 255f, 187 / 255f, 161 / 255f);
                colorList.colorOfWall = new Color(0 / 255f, 0 / 255f, 0 / 255f);
                colorList.colorOfMeshRenderOne = new Color(114 / 255f, 126 / 255f, 107 / 255f);
                colorList.colorOfMeshRenderTwo = new Color(0 / 255f, 9 / 255f, 2 / 255f);
                colorList.colorOfSpikes = new Color(255 / 255f, 168 / 255f, 0 / 255f);
                break;
            case ScenesType.FRIDAY:
                playerName = "cube_brick";
                colorList.colorOfTileOne = new Color(206 / 255f, 136 / 255f, 136 / 255f);
                colorList.colorOfTileTwo = new Color(188 / 255f, 117 / 255f, 117 / 255f);
                colorList.colorOfWall = new Color(53 / 255f, 23 / 255f, 19 / 255f);
                colorList.colorOfMeshRenderOne = new Color(120 / 255f, 52 / 255f, 52 / 255f);
                colorList.colorOfMeshRenderTwo = new Color(68 / 255f, 11 / 255f, 12 / 255f);
                colorList.colorOfSpikes = new Color(60 / 255f, 0 / 255f, 0 / 255f);
                break;
            case ScenesType.SATERDAY:
                playerName = "cube_watermelon";
                colorList.colorOfTileOne = new Color(255 / 255f, 189 / 255f, 196 / 255f);
                colorList.colorOfTileTwo = new Color(227 / 255f, 102 / 255f, 102 / 255f);
                colorList.colorOfWall = new Color(6 / 255f, 79 / 255f, 30 / 255f);
                colorList.colorOfMeshRenderOne = new Color(120 / 255f, 52 / 255f, 52 / 255f);
                colorList.colorOfMeshRenderTwo = new Color(68 / 255f, 11 / 255f, 12 / 255f);
                colorList.colorOfSpikes = new Color(43 / 255f, 24 / 255f, 0 / 255f);
                break;
            case ScenesType.SUNDAY:
                playerName = "cube_bread";
                colorList.colorOfTileOne = new Color(140 / 255f, 126 / 255f, 120 / 255f);
                colorList.colorOfTileTwo = new Color(191 / 255f, 166 / 255f, 149 / 255f);
                colorList.colorOfWall = new Color(193 / 255f, 104 / 255f, 93 / 255f);
                colorList.colorOfMeshRenderOne = new Color(140 / 255f, 126 / 255f, 120 / 255f);
                colorList.colorOfMeshRenderTwo = new Color(140 / 255f, 126 / 255f, 120 / 255f);
                colorList.colorOfSpikes = new Color(255 / 255f, 67 / 255f, 70 / 255f);
                break;
        }
        return colorList;
    }
}
