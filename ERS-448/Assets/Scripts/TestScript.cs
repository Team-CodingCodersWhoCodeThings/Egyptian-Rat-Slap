using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IngameDebugConsole;

public class TestScript : MonoBehaviour
{
    [ConsoleMethod( "test", "Runs test of game functions" )]
	public static void RunTest()
	{
		print("test");
	}
}
