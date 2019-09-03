// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Audio.Sample;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Textures;
using osu.Game.Audio;

namespace osu.Game.Skinning
{
    /// <summary>
    /// Provides access to skinnable elements.
    /// </summary>
    public interface ISkin
    {
        Drawable GetDrawableComponent(ISkinComponent component);

        Texture GetTexture(string componentName);

        SampleChannel GetSample(ISampleInfo sampleInfo);

        IBindable<TValue> GetConfig<TLookup, TValue>(TLookup lookup);
    }
}
