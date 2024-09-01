﻿using System;

namespace DS4MapperTest.StickActions
{
    public abstract class StickMapAction : MapAction
    {
        public bool activeEvent;
        public bool active;
        protected StickDefinition stickDefinition;
        public StickDefinition StickDefinition { get => stickDefinition; set => stickDefinition = value; }

        protected event EventHandler<NotifyPropertyChangeArgs> NotifyPropertyChanged;

        public abstract void Prepare(Mapper mapper, int axisXVal, int axisYVal, bool alterState = true);

        public abstract StickMapAction DuplicateAction();

        public void CopyBaseMapProps(StickMapAction sourceAction)
        {
            mappingId = sourceAction.mappingId;
            stickDefinition = new StickDefinition(sourceAction.stickDefinition);
        }
        public virtual void SoftCopyFromParent(StickMapAction parentAction)
        {
        }

        protected virtual void CascadePropertyChange(Mapper mapper, string propertyName)
        {
        }

        public virtual void RaiseNotifyPropertyChange(Mapper mapper, string propertyName)
        {
            NotifyPropertyChanged?.Invoke(this,
                new NotifyPropertyChangeArgs(mapper, propertyName));
        }
    }
}
