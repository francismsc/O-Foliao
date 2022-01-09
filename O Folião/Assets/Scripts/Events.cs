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

        [SerializeField] private int _energyD;
        public int energyD { get { return _energyD; } }

        [SerializeField] private int _random;
        public int random { get { return _random; } }

        [SerializeField] private Events[] _moreDecisionsStages;
        public Events[] moreDecisionsStages { get { return _moreDecisionsStages; } }


}
[CreateAssetMenu(fileName = "New Event", menuName = "Events/new Event")]
    public class Events : ScriptableObject
    {

        [SerializeField] private String _event = String.Empty;
        public String Event { get { return _event; } }

        [SerializeField] private Sprite _background = null;
        public Sprite background { get { return _background; } }

        [SerializeField] Decisions[] _decisions = null;
        public Decisions[] decisions { get { return _decisions; } }

        
        public enum Alcool { Low30, Normal, High80 };

        [SerializeField]
        private Alcool alcool;
        
        public enum Energy { Low30, Normal };

        [SerializeField]
        private Energy energy;

        public enum Tag { Night, Day, Bars, LowAlcool, LowEnergy };

        [SerializeField] private Tag[] _tags = null;
        public Tag[] tags { get { return _tags; } }



}
