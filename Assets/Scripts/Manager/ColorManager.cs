using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

public class ColorManager : Singleton<ColorManager>{

	Color colorOfTileOne,colorOfTileTwo,colorOfWall,colorOfMeshRenderOne,colorOfMeshRenderTwo;
	
	enum ScenesType
	{
		MONDAY = 1,
		TUESDAY,
		WENESDAY,
		THURSDAY,
		FRIDAY,
		SATERDAY,
	}
	ScenesType scene = ScenesType.MONDAY;

	public static void main(string[] arges)
	{
		ColorManager.Instance().
	}

	public void SelectColor()
	{
		switch(scene)
		{
		case ScenesType.MONDAY:
			{
				colorOfTileOne = new Color (140 / 255f, 126 / 255f, 120 / 255f);
				colorOfTileTwo = new Color (191 / 255f, 166 / 255f, 149 / 255f);
				colorOfWall = new Color (193 / 255f, 104 / 255f, 93 / 255f);
				colorOfMeshRenderOne = new Color (140 / 255f, 126 / 255f, 120 / 255f);
				colorOfMeshRenderTwo = new Color (140 / 255f, 126 / 255f, 120 / 255f);
			}
			break;
		case ScenesType.TUESDAY:
			{
				colorOfTileOne = new Color (140 / 255f, 126 / 255f, 120 / 255f);
				colorOfTileTwo = new Color (191 / 255f, 166 / 255f, 149 / 255f);
				colorOfWall = new Color (193 / 255f, 104 / 255f, 93 / 255f);
				colorOfMeshRenderOne = new Color (140 / 255f, 126 / 255f, 120 / 255f);
				colorOfMeshRenderTwo = new Color (140 / 255f, 126 / 255f, 120 / 255f);
			}
			break;
		case ScenesType.WENESDAY:
			{
				colorOfTileOne = new Color (140 / 255f, 126 / 255f, 120 / 255f);
				colorOfTileTwo = new Color (191 / 255f, 166 / 255f, 149 / 255f);
				colorOfWall = new Color (193 / 255f, 104 / 255f, 93 / 255f);
				colorOfMeshRenderOne = new Color (140 / 255f, 126 / 255f, 120 / 255f);
				colorOfMeshRenderTwo = new Color (140 / 255f, 126 / 255f, 120 / 255f);
			}
			break;
		case ScenesType.THURSDAY:
			{
				colorOfTileOne = new Color (140 / 255f, 126 / 255f, 120 / 255f);
				colorOfTileTwo = new Color (191 / 255f, 166 / 255f, 149 / 255f);
				colorOfWall = new Color (193 / 255f, 104 / 255f, 93 / 255f);
				colorOfMeshRenderOne = new Color (140 / 255f, 126 / 255f, 120 / 255f);
				colorOfMeshRenderTwo = new Color (140 / 255f, 126 / 255f, 120 / 255f);
			}
			break;
		case ScenesType.FRIDAY:
			{
				colorOfTileOne = new Color (140 / 255f, 126 / 255f, 120 / 255f);
				colorOfTileTwo = new Color (191 / 255f, 166 / 255f, 149 / 255f);
				colorOfWall = new Color (193 / 255f, 104 / 255f, 93 / 255f);
				colorOfMeshRenderOne = new Color (140 / 255f, 126 / 255f, 120 / 255f);
				colorOfMeshRenderTwo = new Color (140 / 255f, 126 / 255f, 120 / 255f);
			}
			break;
		case ScenesType.SATERDAY:
			{
				colorOfTileOne = new Color (140 / 255f, 126 / 255f, 120 / 255f);
				colorOfTileTwo = new Color (191 / 255f, 166 / 255f, 149 / 255f);
				colorOfWall = new Color (193 / 255f, 104 / 255f, 93 / 255f);
				colorOfMeshRenderOne = new Color (140 / 255f, 126 / 255f, 120 / 255f);
				colorOfMeshRenderTwo = new Color (140 / 255f, 126 / 255f, 120 / 255f);
			}
			break;
		}

	}
}
