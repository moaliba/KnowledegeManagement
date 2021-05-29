﻿using DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataSource
{
    public abstract class EntityTypeConfig<T> : IEntityTypeConfiguration<T> where T : AggregateRoot
    {
        protected abstract void Config(EntityTypeBuilder<T> builder);
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Ignore(a => a.Events);
            Config(builder);
        }
    }
}
