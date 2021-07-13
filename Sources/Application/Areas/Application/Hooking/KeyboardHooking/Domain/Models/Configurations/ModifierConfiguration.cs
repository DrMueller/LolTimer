using Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Models.Inputs;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Options;

namespace Mmu.LolTimer.Areas.Application.Hooking.KeyboardHooking.Domain.Models.Configurations
{
    public class ModifierConfiguration
    {
        public Option<bool> AltMustBePressed { get; }
        public Option<bool> CtrlMustBepressed { get; }
        public Option<bool> ShiftMustBePressed { get; }

        public ModifierConfiguration(Option<bool> ctrlMustBepressed, Option<bool> shiftMustBePressed, Option<bool> altMustBePressed)
        {
            Guard.ObjectNotNull(() => ctrlMustBepressed);
            Guard.ObjectNotNull(() => shiftMustBePressed);
            Guard.ObjectNotNull(() => altMustBePressed);

            CtrlMustBepressed = ctrlMustBepressed;
            ShiftMustBePressed = shiftMustBePressed;
            AltMustBePressed = altMustBePressed;
        }

        public static ModifierConfiguration CreateNotApplicable()
        {
            return new ModifierConfiguration(
                Option.CreateNotApplicable<bool>(true),
                Option.CreateNotApplicable<bool>(true),
                Option.CreateNotApplicable<bool>(true));
        }

        internal bool CheckIfApplicable(KeyboardInputModifiers inputModifiers)
        {
            return CtrlMustBepressed == inputModifiers.IsCtrlPressed &&
                ShiftMustBePressed == inputModifiers.IsShiftPressed &&
                AltMustBePressed == inputModifiers.IsAltPressed;
        }
    }
}