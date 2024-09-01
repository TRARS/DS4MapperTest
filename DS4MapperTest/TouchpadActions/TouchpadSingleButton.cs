﻿using DS4MapperTest.ButtonActions;
using DS4MapperTest.StickModifiers;
using System.Collections.Generic;
using System.Linq;

namespace DS4MapperTest.TouchpadActions
{
    public class TouchpadSingleButton : TouchpadMapAction
    {
        public class PropertyKeyStrings
        {
            public const string NAME = "Name";
            public const string FUNCTIONS = "Functions";
            public const string DEAD_ZONE = "DeadZone";
        }

        private HashSet<string> fullPropertySet = new HashSet<string>()
        {
            PropertyKeyStrings.NAME,
            PropertyKeyStrings.FUNCTIONS,
            PropertyKeyStrings.DEAD_ZONE,
        };

        private const double DEFAULT_DEAD_ZONE = 0.25;
        public const string ACTION_TYPE_NAME = "TouchSingleButtonAction";

        private bool inputStatus;

        private ButtonAction usedEventButton = new ButtonAction();
        private bool useParentActions;
        public bool UseParentActions
        {
            get => useParentActions;
            set => useParentActions = value;
        }

        public ButtonAction EventButton
        {
            get => usedEventButton;
            set => usedEventButton = value;
        }

        private StickDeadZone deadMod;
        public StickDeadZone DeadMod
        {
            get => deadMod;
        }

        private double xNorm = 0.0, yNorm = 0.0;

        public TouchpadSingleButton()
        {
            actionTypeName = ACTION_TYPE_NAME;
            deadMod = new StickDeadZone(DEFAULT_DEAD_ZONE, 1.0, 0.0);
        }

        public override void Prepare(Mapper mapper, ref TouchEventFrame touchFrame, bool alterState = true)
        {
            //active = touchFrame.Touch;
            //if (touchFrame.Touch != inputStatus)
            //{
            //    inputStatus = touchFrame.Touch;
            //    active = true;
            //}

            active = false;
            xNorm = 0.0; yNorm = 0.0;

            int axisXVal = touchFrame.X;
            int axisYVal = touchFrame.Y;
            int axisXMid = touchpadDefinition.xAxis.mid, axisYMid = touchpadDefinition.yAxis.mid;
            int axisXDir = axisXVal - axisXMid, axisYDir = axisYVal - axisYMid;
            bool xNegative = axisXDir < 0;
            bool yNegative = axisYDir < 0;
            int maxDirX = (!xNegative ? touchpadDefinition.xAxis.max : touchpadDefinition.xAxis.min) - axisXMid;
            int maxDirY = (!yNegative ? touchpadDefinition.yAxis.max : touchpadDefinition.yAxis.min) - axisYMid;
            deadMod.CalcOutValues(axisXDir, axisYDir, maxDirX, maxDirY, out xNorm, out yNorm);
            if (deadMod.inSafeZone)
            {
                inputStatus = true;
                active = true;
            }
            else if (inputStatus)
            {
                inputStatus = false;
                active = true;
            }

            activeEvent = true;
        }

        public override void Event(Mapper mapper)
        {
            usedEventButton.Prepare(mapper, inputStatus);
            usedEventButton.Event(mapper);
        }

        public override void Release(Mapper mapper, bool resetState = true, bool ignoreReleaseActions = false)
        {
            if (active)
            {
                usedEventButton.Prepare(mapper, false);
                usedEventButton.Event(mapper);
            }
        }

        public override void SoftRelease(Mapper mapper, MapAction checkAction, bool resetState = true)
        {
            if (!useParentActions && active)
            {
                usedEventButton.Prepare(mapper, false);
                usedEventButton.Event(mapper);
            }

            if (resetState)
            {
                stateData.Reset();
            }
        }

        public override void SoftCopyFromParent(TouchpadMapAction parentAction)
        {
            if (parentAction is TouchpadSingleButton tempButtonAct)
            {
                base.SoftCopyFromParent(parentAction);

                tempButtonAct.NotifyPropertyChanged += TempButtonAct_NotifyPropertyChanged;

                // Determine the set with properties that should inherit
                // from the parent action
                IEnumerable<string> useParentProList =
                    fullPropertySet.Except(changedProperties);

                foreach (string parentPropType in useParentProList)
                {
                    switch (parentPropType)
                    {
                        case PropertyKeyStrings.NAME:
                            name = tempButtonAct.name;
                            break;
                        case PropertyKeyStrings.FUNCTIONS:
                            useParentActions = true;
                            usedEventButton = tempButtonAct.usedEventButton;
                            break;
                        case PropertyKeyStrings.DEAD_ZONE:
                            deadMod.DeadZone = tempButtonAct.deadMod.DeadZone;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void TempButtonAct_NotifyPropertyChanged(object sender, NotifyPropertyChangeArgs e)
        {
            CascadePropertyChange(e.Mapper, e.PropertyName);
        }

        protected override void CascadePropertyChange(Mapper mapper, string propertyName)
        {
            if (changedProperties.Contains(propertyName))
            {
                // Property already overrridden in action. Leave
                return;
            }
            else if (parentAction == null)
            {
                // No parent action. Leave
                return;
            }

            TouchpadSingleButton tempButtonAct = parentAction as TouchpadSingleButton;

            switch (propertyName)
            {
                case PropertyKeyStrings.NAME:
                    name = tempButtonAct.name;
                    break;
                case PropertyKeyStrings.FUNCTIONS:
                    useParentActions = true;
                    usedEventButton = tempButtonAct.usedEventButton;
                    break;
                case PropertyKeyStrings.DEAD_ZONE:
                    deadMod.DeadZone = tempButtonAct.deadMod.DeadZone;
                    break;
                default:
                    break;
            }
        }
    }
}
