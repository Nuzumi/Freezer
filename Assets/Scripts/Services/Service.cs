using Fridge.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fridge.Services
{
    public abstract class Service
    {
        protected readonly IReferences references;
        protected readonly IServices services;

        public Service(IReferences references, IServices services)
        {
            this.references = references;
            this.services = services;
        }
    }
}

