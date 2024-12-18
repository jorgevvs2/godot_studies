﻿using DungeonRPG.General.Enums;
using Godot;
using Godot.NativeInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRPG.Scenes.Characters.Resources
{
    [GlobalClass]
    public partial class StatResource : Resource
    {
        public event Action OnZero;
        public event Action OnUpdate;

        [Export] public Stat StatType { get; private set; }

        private float _statValue;
        [Export] public float StatValue 
        { 
            get => _statValue;
            set {
                _statValue = Mathf.Clamp(value, 0, float.MaxValue);

                OnUpdate?.Invoke();

                if (_statValue == 0)
                {
                    OnZero?.Invoke();
                }
            }
        }
    }
}
