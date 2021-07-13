using System;
using System.Threading.Tasks;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Models.Configurations
{
    public class KeyboardInputMap
    {
        private readonly KeyboardEventConfiguration _configuration;
        private readonly Func<KeyboardInput, Task> _onKeyboardInput;

        public KeyboardInputMap(KeyboardEventConfiguration configuration, Func<KeyboardInput, Task> onKeyboardInput)
        {
            _configuration = configuration;
            _onKeyboardInput = onKeyboardInput;
        }

        public async Task HandleAsync(KeyboardInput keyboardInput)
        {
            if (_configuration.CheckIfApplicable(keyboardInput))
            {
                await _onKeyboardInput(keyboardInput);
            }
        }
    }
}