using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class edit_mode
{
    GameObject player, health;
    player pl;
    Image  health_bar;

    [SetUp]
    public void setup()
    {
        player = new GameObject();
        pl = player.AddComponent<player>();
        pl.die_prefabs = new GameObject();
        
        health = new GameObject();
        health_bar = health.AddComponent<Image>(); 
        
        pl.max_health = 100;
        pl.health_bar = health_bar;
        pl.current_health = pl.max_health;
    }
    // A Test behaves as an ordinary method
    [Test]
    public void test_heal1()
    {
        pl.take_damage(50);
        Assert.AreEqual(50, pl.current_health, "failed");
    }
    
    [Test]
    public void test_heal2()
    {
        pl.current_health = 50;
        pl.heal(40);
        Assert.AreEqual(90, pl.current_health, "failed");
    }
    
    [Test]
    public void test_heal3()
    {
        pl.current_health = 100;
        pl.heal(50);
        Assert.AreEqual(100, pl.current_health, "failed");
    }
    
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
