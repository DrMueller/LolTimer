using System.Linq;
using Mmu.LolTimer.Areas.Application.Hooking.Common.Models.Configurations;
using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Models.Inputs;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Models.Configurations
{
    public class KeyboardEventConfiguration : IEventConfiguration
    {
        public KeyboardInputKeyConfiguration InputKeyConfiguration { get; }
        public LockConfiguration LockConfiguration { get; }
        public ModifierConfiguration ModifierConfiguration { get; }

        public KeyboardEventConfiguration(KeyboardInputKeyConfiguration inputKeyConfiguration, ModifierConfiguration modifierConfiguration, LockConfiguration lockConfiguration)
        {
            Guard.ObjectNotNull(() => inputKeyConfiguration);
            Guard.ObjectNotNull(() => modifierConfiguration);
            Guard.ObjectNotNull(() => lockConfiguration);

            InputKeyConfiguration = inputKeyConfiguration;
            ModifierConfiguration = modifierConfiguration;
            LockConfiguration = lockConfiguration;
        }

        public static KeyboardEventConfiguration CreateForAllEvents()
        {
            return new KeyboardEventConfiguration(
                new KeyboardInputKeyConfiguration(KeyboardInputKey.AllKeys.ToArray()),
                ModifierConfiguration.CreateNotApplicable(),
                LockConfiguration.CreateNotApplicable());
        }

        public bool CheckIfApplicable(KeyboardInput input)
        {
            return InputKeyConfiguration.CheckIfApplicable(input.InputKey) &&
                ModifierConfiguration.CheckIfApplicable(input.Modifiers) &&
                LockConfiguration.CheckIfApplicable(input.Locks);
        }
    }
}