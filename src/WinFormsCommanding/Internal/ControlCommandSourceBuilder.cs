using System.ComponentModel;
using JetBrains.Annotations;

namespace System.Windows.Forms.Input.Internal {
    /// <inheritdoc cref="CommandSourceBuilderBase"/>
    /// <summary>
    /// A <see cref="ICommandSourceBuilder"/> that creates <see cref="ICommandSource"/> from controls.
    /// </summary>
    internal sealed class ControlCommandSourceBuilder : CommandSourceBuilderBase {

        /// <summary>
        /// Creates a new <see cref="ControlCommandSourceBuilder"/>.
        /// </summary>
        /// <param name="control">The control used to create <see cref="ICommandSource"/>.</param>
        public ControlCommandSourceBuilder([NotNull] Component control) {
            if (control == null) {
                throw new ArgumentNullException(nameof(control));
            }

            _control = control;
        }

        protected override ICommandSource CreateCommandSource() {
            return new ControlCommandSource(_control);
        }

        [NotNull]
        private readonly Component _control;

    }
}
