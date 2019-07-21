using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingPopup settingPopup;
    [SerializeField] private Slider speedSlider;
    private int _score;
    // add subscription for messedge from game to diaplay
    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit); // set this method will respons to "ENEMY_HIT" event
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit); // remove listener of destroy object
    }

    void Start()
    {
        _score = 0;
        scoreLabel.text = _score.ToString();
        settingPopup.Close();

        //for save data
        //speedSlider.value = PlayerPrefs.GetFloat("speed", 1);
    }

    private void OnEnemyHit()
    {
        _score += 1;
        scoreLabel.text = _score.ToString();
    }

    public void OnOpenSettings()
    {
        settingPopup.Open();
    }

    public void OnPointerDown()
    {
    }
}
