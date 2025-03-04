// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

#nullable disable

using osu.Framework.Allocation;
using osu.Framework.Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Game.Graphics;
using osu.Game.Graphics.Sprites;
using osu.Game.Rulesets.Scoring;
using osuTK;

namespace osu.Game.Rulesets.Judgements
{
    public partial class DefaultJudgementPiece : CompositeDrawable, IAnimatableJudgement
    {
        protected readonly HitResult Result;

        protected SpriteText JudgementText { get; private set; }

        [Resolved]
        private OsuColour colours { get; set; }

        public DefaultJudgementPiece(HitResult result)
        {
            Result = result;
            Origin = Anchor.Centre;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            AutoSizeAxes = Axes.Both;

            InternalChildren = new Drawable[]
            {
                JudgementText = new OsuSpriteText
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Text = Result.GetDescription().ToUpperInvariant(),
                    Colour = colours.ForHitResult(Result),
                    Font = OsuFont.Numeric.With(size: 20),
                    Scale = new Vector2(0.85f, 1),
                }
            };
        }

        /// <summary>
        /// Plays the default animation for this judgement piece.
        /// </summary>
        /// <remarks>
        /// The base implementation only handles fade (for all result types) and misses.
        /// Individual rulesets are recommended to implement their appropriate hit animations.
        /// </remarks>
        public virtual void PlayAnimation()
        {
            switch (Result)
            {
                case HitResult.Miss:
                    this.ScaleTo(1.6f);
                    this.ScaleTo(1, 100, Easing.In);

                    this.MoveTo(Vector2.Zero);
                    this.MoveToOffset(new Vector2(0, 100), 800, Easing.InQuint);

                    this.RotateTo(0);
                    this.RotateTo(40, 800, Easing.InQuint);
                    break;
            }

            this.FadeOutFromOne(800);
        }

        public Drawable GetAboveHitObjectsProxiedContent() => null;
    }
}
