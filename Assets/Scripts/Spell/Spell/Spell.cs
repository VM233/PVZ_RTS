﻿using System;
using VMFramework.GameLogicArchitecture;
using VMFramework.UI;
using FishNet.Connection;
using PVZRTS.Properties;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UIElements;
using VMFramework.Core;
using VMFramework.Network;
using VMFramework.Properties;
using VMFramework.Timers;

namespace TH.Spells
{
    public abstract partial class Spell : VisualGameItem, ISpell, ISlotProvider
    {
        protected SpellPreset spellPreset => (SpellPreset)gamePrefab;

        [ShowInInspector]
        public string uuid { get; private set; }

        [ShowInInspector]
        public ISpellOwner owner { get; private set; }
        
        #region Cooldown

        private double expectedTime;

        public float cooldown
        {
            get => (float)(expectedTime - TimerManager.currentTime).ClampMin(0);
            set
            {
                if (value <= 0)
                {
                    if (cooldown > 0)
                    {
                        TimerManager.Stop(this);
                    }
                    
                    return;
                }

                if (TimerManager.Contains(this))
                {
                    TimerManager.Stop(this);
                }
                
                TimerManager.Add(this, value);
            }
        }

        void ITimer.OnStart(double startedTime, double expectedTime)
        {
            this.expectedTime = expectedTime;
        }

        #endregion

        #region Set Owner

        public void SetOwner(ISpellOwner owner)
        {
            if (this.owner != null)
            {
                throw new InvalidOperationException("Spell already has an owner");
            }

            this.owner = owner;
        }

        #endregion

        #region Cast & Abort

        public abstract void Cast(SpellCastInfo spellCastInfo);

        public abstract void Abort(SpellAbortInfo spellAbortInfo);

        #endregion

        #region Slot Provider

        StyleBackground ISlotProvider.GetIconImage()
        {
            return new StyleBackground(spellPreset.icon);
        }

        string ISlotProvider.GetDescriptionText()
        {
            return string.Empty;
        }

        void ISlotProvider.HandleMouseEnterEvent(UIPanelController source)
        {
            if (isDebugging)
            {
                Debug.LogWarning($"{this}被鼠标进入");
            }

            TooltipManager.Open(this, source);
        }

        void ISlotProvider.HandleMouseLeaveEvent(UIPanelController source)
        {
            if (isDebugging)
            {
                Debug.LogWarning($"{this}被鼠标退出");
            }

            TooltipManager.Close(this);
        }

        #endregion

        #region Priority Queue Node

        double IGenericPriorityQueueNode<double>.Priority { get; set; }

        int IGenericPriorityQueueNode<double>.QueueIndex { get; set; }

        long IGenericPriorityQueueNode<double>.InsertionIndex { get; set; }

        #endregion
    }
}