using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


    [Serializable()]
    public struct Decisions
    {

        [SerializeField] private string _stringI;
        public string stringI { get { return _stringI; } }

        [SerializeField] private string _stringF;
        public string stringF { get { return _stringF; } }

        [SerializeField] private int _alcoolD;
        public int alcoolD { get { return _alcoolD; } }

        [SerializeField] private int _funD;
        public int funD { get { return _funD; } }

        [SerializeField] private int _hungerD;
        public int hungerD { get { return _hungerD; } }

        [SerializeField] private int _socialD;
        public int socialD { get { return _socialD; } }

        [SerializeField] private int _moneyD;
        public int moneyD { get { return _moneyD; } }

}
[CreateAssetMenu(fileName = "New Event", menuName = "Events/new Event")]
    public class Events : ScriptableObject
    {

        //public enum AnswerType { Multi, Single }

        [SerializeField] private String _event = String.Empty;
        public String Event { get { return _event; } }

        [SerializeField] private Sprite _background = null;
        public Sprite background { get { return _background; } }

        [SerializeField] Decisions[] _decisions = null;
        public Decisions[] decisions { get { return _decisions; } }

        //Parameters

        //[SerializeField] private bool _useTimer = false;
        //public bool UseTimer { get { return _useTimer; } }

        //[SerializeField] private int _timer = 0;
        //public int Timer { get { return _timer; } }

        //[SerializeField] private AnswerType _answerType = AnswerType.Multi;
        //public AnswerType GetAnswerType { get { return _answerType; } }

        //[SerializeField] private int _addScore = 10;
        //public int AddScore { get { return _addScore; } }

        
        
       
    }
