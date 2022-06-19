// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

#nullable disable

using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Taiko.Objects;
using osu.Game.Rulesets.Taiko.UI;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.Taiko.Mods
{
    public class TaikoModClassic : ModClassic, IApplicableToDrawableRuleset<TaikoHitObject>, IUpdatableByPlayfield, IApplicableToHitObject
    {
        private DrawableTaikoRuleset drawableTaikoRuleset;

        public void ApplyToDrawableRuleset(DrawableRuleset<TaikoHitObject> drawableRuleset)
        {
            drawableTaikoRuleset = (DrawableTaikoRuleset)drawableRuleset;
            drawableTaikoRuleset.LockPlayfieldAspect.Value = false;
        }

        public void ApplyToHitObject(HitObject hitObject)
        {
            if (hitObject is DrumRoll drumRoll)
                drumRoll.SetBonus(true);
            else if (hitObject is Swell swell)
                swell.SetBonus(true);
        }

        public void Update(Playfield playfield)
        {
            // Classic taiko scrolls at a constant 100px per 1000ms. More notes become visible as the playfield is lengthened.
            const float scroll_rate = 10;

            // Since the time range will depend on a positional value, it is referenced to the x480 pixel space.
            float ratio = drawableTaikoRuleset.DrawHeight / 480;

            drawableTaikoRuleset.TimeRange.Value = (playfield.HitObjectContainer.DrawWidth / ratio) * scroll_rate;
        }
    }
}
