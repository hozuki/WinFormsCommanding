using System.Windows.Forms.Input.Internal;
using JetBrains.Annotations;

namespace System.Windows.Forms.Input {
    partial class CommandingExtensions {

        /// <summary>
        /// Creates a <see cref="ICommandSourceBuilder"/> from the control.
        /// </summary>
        /// <param name="button">The control.</param>
        /// <returns>Created <see cref="ICommandSourceBuilder"/>.</returns>
        [NotNull]
        public static ICommandSourceBuilder CreateCommandSourceBuilder([NotNull] this ButtonBase button) {
            return new ControlCommandSourceBuilder(button);
        }

        /// <summary>
        /// Creates a <see cref="ICommandSourceBuilder"/> from the control.
        /// </summary>
        /// <param name="menuItem">The control.</param>
        /// <returns>Created <see cref="ICommandSourceBuilder"/>.</returns>
        [NotNull]
        public static ICommandSourceBuilder CreateCommandSourceBuilder([NotNull] this MenuItem menuItem) {
            return new ControlCommandSourceBuilder(menuItem);
        }

        /// <summary>
        /// Creates a <see cref="ICommandSourceBuilder"/> from the control.
        /// </summary>
        /// <param name="button">The control.</param>
        /// <returns>Created <see cref="ICommandSourceBuilder"/>.</returns>
        [NotNull]
        public static ICommandSourceBuilder CreateCommandSourceBuilder([NotNull] this ToolStripButton button) {
            return new ControlCommandSourceBuilder(button);
        }

        /// <summary>
        /// Creates a <see cref="ICommandSourceBuilder"/> from the control.
        /// </summary>
        /// <param name="button">The control.</param>
        /// <returns>Created <see cref="ICommandSourceBuilder"/>.</returns>
        [NotNull]
        public static ICommandSourceBuilder CreateCommandSourceBuilder([NotNull] this ToolStripSplitButton button) {
            return new ControlCommandSourceBuilder(button);
        }

        /// <summary>
        /// Creates a <see cref="ICommandSourceBuilder"/> from the control.
        /// </summary>
        /// <param name="button">The control.</param>
        /// <returns>Created <see cref="ICommandSourceBuilder"/>.</returns>
        [NotNull]
        public static ICommandSourceBuilder CreateCommandSourceBuilder([NotNull] this ToolStripOverflowButton button) {
            return new ControlCommandSourceBuilder(button);
        }

        /// <summary>
        /// Creates a <see cref="ICommandSourceBuilder"/> from the control.
        /// </summary>
        /// <param name="menuItem">The control.</param>
        /// <returns>Created <see cref="ICommandSourceBuilder"/>.</returns>
        [NotNull]
        public static ICommandSourceBuilder CreateCommandSourceBuilder([NotNull] this ToolStripMenuItem menuItem) {
            return new ControlCommandSourceBuilder(menuItem);
        }

        /// <summary>
        /// Configures current <see cref="ICommandSourceBuilder"/> to use a <see cref="CommandBinding"/>.
        /// </summary>
        /// <param name="builder">Current <see cref="ICommandSourceBuilder"/>.</param>
        /// <param name="binding">The <see cref="CommandBinding"/> to use.</param>
        /// <returns>The original <see cref="ICommandSourceBuilder"/> as chained invocation.</returns>
        [NotNull]
        public static ICommandSourceBuilder WithCommandBinding([NotNull] this ICommandSourceBuilder builder, [NotNull] CommandBinding binding) {
            builder.WithCommand(binding.Command);
            return builder;
        }

    }
}
