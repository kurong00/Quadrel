using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace FrameWork
{
	public class GameColor
	{
        public Color colorOfTileOne, colorOfTileTwo, colorOfWall, colorOfMeshRenderOne, colorOfMeshRenderTwo, colorOfSpikes;
		public GameColor ()
		{
			colorOfTileOne = Color.white;
			colorOfTileTwo = Color.white;
			colorOfWall = Color.white;
			colorOfMeshRenderOne = Color.white;
			colorOfMeshRenderTwo = Color.white;
            colorOfSpikes = Color.white;
        }
	}
}

