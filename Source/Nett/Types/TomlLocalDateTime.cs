﻿using System;
using System.Globalization;
using Nett.Extensions;

namespace Nett
{
    public sealed class TomlLocalDateTime : TomlValue<DateTime>
    {
        internal TomlLocalDateTime(ITomlRoot root, DateTime dt)
            : base(root, dt)
        {
        }

        public override string ReadableTypeName
            => "Local date time";

        public override TomlObjectType TomlType
            => TomlObjectType.LocalDateTime;

        public override void Visit(ITomlObjectVisitor visitor)
            => visitor.Visit(this);

        internal static TomlLocalDateTime Parse(ITomlRoot root, string value)
        {
            return new TomlLocalDateTime(root, DateTime.Parse(value, CultureInfo.InvariantCulture));
        }

        internal override TomlObject CloneFor(ITomlRoot root)
            => this.CloneLocalDateTimeFor(root);

        internal TomlLocalDateTime CloneLocalDateTimeFor(ITomlRoot root)
            => CopyComments(this.NewLocalDateTimeWithRoot(root), this);

        internal override TomlValue ValueWithRoot(ITomlRoot root)
            => this.NewLocalDateTimeWithRoot(root);

        internal override TomlObject WithRoot(ITomlRoot root)
            => this.NewLocalDateTimeWithRoot(root);

        private TomlLocalDateTime NewLocalDateTimeWithRoot(ITomlRoot root)
        {
            root.CheckNotNull(nameof(root));
            return new TomlLocalDateTime(root, this.Value);
        }
    }
}