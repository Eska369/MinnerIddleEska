using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    public void Scene4To2()
    {
        SceneManager.LoadScene(2);
    }
    public void Scene3To2()
    {
        SceneManager.LoadScene(2);
    }
    public void Scene2To4()
    {
        SceneManager.LoadScene(4);
    }
    public void Scene2To1()
    {
        SceneManager.LoadScene(1);
    }
    public void Scene2To3()
    {
        SceneManager.LoadScene(3);
    }
    public void Scene1To2()
    {
        SceneManager.LoadScene(2);
    }
    public void Scene0To1()
    {
        SceneManager.LoadScene(1);
    }



}
