using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOutputMB : OutputDeviceMB
{
    TestOutput testOutput = new TestOutput();

	public override OutputDevice outputDevice => testOutput;
}
