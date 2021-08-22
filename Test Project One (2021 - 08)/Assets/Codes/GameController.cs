using System;
using System.Collections;
using System.Collections.Generic;
using TestProjectOne;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerType PlayerType = PlayerType.Ball;
    private ListExecuteObject _interactiveObject;
    private DisplayEndGame _displayEndGame;
    private DisplayBonuses _displayBonuses;
    private CameraController _cameraController;
    private InputController _inputController;
    private int _countBonuses;
    private Reference _reference;

    private void Awake()
    {
        _interactiveObject = new ListExecuteObject();
        _reference = new Reference();

        PlayerBase player = null;
        if (PlayerType == PlayerType.Ball)
        {
            player = _reference.PlayerBall;
        }

        _cameraController = new CameraController(player.transform, _reference.MainCamers.transform);
        _interactiveObject.AddExecuteObject(_cameraController);
        
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            _inputController = new InputController(player);
            _interactiveObject.AddExecuteObject(_inputController);
        }

        _displayEndGame = new DisplayEndGame(_reference.EndGame);
        _displayBonuses = new DisplayBonuses(_reference.Bonuse);
        foreach (var o in _interactiveObject)
        {
            if (o is BadBonus badBonus)
            {
                badBonus.OnCaughtPlayerChange += CaughtPlayer;
                badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
            }

            if (o is GoodBonus goodBonus)
            {
                goodBonus.OnPointChange += AddBonuse;
            }
        }
        _reference.RestartButton.onClick.AddListener(RestarGame);
        _reference.RestartButton.gameObject.SetActive(false);
    }

    private void RestarGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
        Time.timeScale = 1.0f;
    }
    
    private void CaughtPlayer(string value, Color args)
    {
        _reference.RestartButton.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void AddBonuse(int value)
    {
        _countBonuses += value;
        _displayBonuses.Display(_countBonuses);
    }

    private void Update()
    {
        for (var i = 0; i < _interactiveObject.Length; i++)
        {
            var interactiveObject = _interactiveObject[i];

            if (interactiveObject == null)
            {
                continue;
            }
            interactiveObject.Execute();
        }
    }

    public void Dispose()
    {
        foreach (var o in _interactiveObject)
        {
            if (o is BadBonus badBonus)
            {
                badBonus.OnCaughtPlayerChange -= CaughtPlayer;
                badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
            }

            if (o is GoodBonus goodBonus)
            {
                goodBonus.OnPointChange -= AddBonuse;
            }
        }
    }
}
