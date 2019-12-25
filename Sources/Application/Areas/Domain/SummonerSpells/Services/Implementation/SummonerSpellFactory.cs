using System;
using Mmu.LolTimer.Areas.Domain.SummonerSpells.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.LolTimer.Areas.Domain.SummonerSpells.Services.Implementation
{
    public class SummonerSpellFactory : ISummonerSpellFactory
    {
        public SummonerSpell CreateFlash(string summonerName, int sortOrder)
        {
            var inputKey = MapInputKey(sortOrder);
            return new SummonerSpell(summonerName, inputKey, new TimeSpan(0, 5, 0));
        }

        private static KeyboardInputKey MapInputKey(int sortOrder)
        {
            switch (sortOrder)
            {
                case 0:
                {
                    return KeyboardInputKey.F1;
                }

                case 1:
                {
                    return KeyboardInputKey.F2;
                }

                case 2:
                {
                    return KeyboardInputKey.F3;
                }

                case 3:
                {
                    return KeyboardInputKey.F4;
                }

                case 4:
                {
                    return KeyboardInputKey.F5;
                }
            }

            throw new ArgumentException($"Sortorder {sortOrder} not valid.");
        }
    }
}