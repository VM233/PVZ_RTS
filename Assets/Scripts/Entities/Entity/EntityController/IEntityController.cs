using UnityEngine;
using VMFramework.Core;

namespace PVZRTS.Entities
{
    public interface IEntityController : IController
    {
        public void Hide();
        
        public void Show();
    }
}