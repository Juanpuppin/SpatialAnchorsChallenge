using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Zenject;

public class CheckRequiredComponents : MonoBehaviour
{
    [UnityTest]
    public IEnumerator LoadScene()
    {
        SceneManager.LoadScene("Main");
        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckFreeFlyCamera()
    {    
        var components = GameObject.FindObjectsByType<FreeFlyCamera>(FindObjectsSortMode.None);
        Assert.IsNotNull(components, "No FreeFlyCamera instance found.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckSceneContext()
    {
        var components = GameObject.FindObjectsByType<SceneContext>(FindObjectsSortMode.None);
        Assert.IsNotNull(components, "No SceneContext instance found.");

        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckSceneInstaller()
    {
        var components = GameObject.FindObjectsByType<SceneInstaller>(FindObjectsSortMode.None);
        Assert.IsNotNull(components, "No SceneInstaller instance found.");

        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckInputsHandler()
    {
        var components = GameObject.FindObjectsByType<InputsHandler>(FindObjectsSortMode.None);
        Assert.IsNotNull(components, "No InputsHandler instance found.");

        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckAnchorsHandler()
    {
        var components = GameObject.FindObjectsByType<AnchorsHandler>(FindObjectsSortMode.None);
        Assert.IsNotNull(components, "No AnchorsHandler instance found.");

        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckLabel()
    {
        var components = GameObject.FindObjectsByType<Label>(FindObjectsSortMode.None);
        Assert.IsNotNull(components, "No Label instance found.");

        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckRoom()
    {      
        var components = GameObject.FindObjectsByType<Room>(FindObjectsSortMode.None);
        Assert.IsNotNull(components, "No Room instance found.");

        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckCanvasHandler()
    {
        var components = GameObject.FindObjectsByType<CanvasHandler>(FindObjectsSortMode.None);
        Assert.IsNotNull(components, "No CanvasHandler instance found.");

        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckRoomDimensionsUI()
    {
        var components = GameObject.FindObjectsByType<RoomDimensionsUI>(FindObjectsSortMode.None);
        Assert.IsNotNull(components, "No RoomDimensionsUI instance found.");

        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckAnchorReachCanvas()
    {
        var components = GameObject.FindObjectsByType<AnchorReachCanvas>(FindObjectsSortMode.None);
        Assert.IsNotNull(components, "No AnchorReachCanvas instance found.");

        yield return null;
    }
}
