using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class play_mode
{
    GameObject _player;
    player pl;

    [SetUp]
    public void Setup()
    {
        _player = new GameObject();
        _player.AddComponent<player>();
        pl = _player.GetComponent<player>();
        pl.die_prefabs = new GameObject();
    }
    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator test_die1()
    {
        pl.die();
        
        yield return null;
        Assert.IsTrue(pl == null || !pl.gameObject, "failed");
    }
    
    [UnityTest]
    public IEnumerator test_die2()
    {
        pl.die();
        var spawned = GameObject.Find(pl.die_prefabs.name);
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator test_die3()
    {
        pl.die_prefabs = null;
        Assert.DoesNotThrow(() => pl.die(), "failed");
        yield return null;
    }
}
