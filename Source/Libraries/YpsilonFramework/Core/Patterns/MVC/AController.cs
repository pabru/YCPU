﻿using Ypsilon.Core.Input;

namespace Ypsilon.Core.Patterns.MVC {
    /// <summary>
    /// Abstract Controller - receives input, interacts with state of model.
    /// </summary>
    public abstract class AController {
        protected AModel Model;

        public AController(AModel parentModel) {
            Model = parentModel;
        }

        public virtual void Update(float frameSeconds, InputManager input) {}
    }
}