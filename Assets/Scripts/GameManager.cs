using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoretext;
    public int score;

    public Blade blade;
    public Spawner spawner;
    public Image go;

    private void Start()
    {
        NewGame();
    }

    private void Awake()
    {
        blade=FindObjectOfType<Blade>();
        spawner=FindObjectOfType<Spawner>();
    }

    private void NewGame()
    {
        score=0;
        scoretext.text=score.ToString();
    }

    public void IncreaseScore()
    {
        score++;
        scoretext.text=score.ToString();
    }

    public void Explode()
    {
        blade.enabled=false;
        spawner.enabled=false;
        go.gameObject.SetActive(true);
    }
}
