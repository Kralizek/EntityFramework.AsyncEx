using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kralizek.EntityFramework;
using Moq;
using NUnit.Framework;

// ReSharper disable once InvokeAsExtensionMethod

namespace Tests
{
    public class DbSetExtensionsTests
    {
        public class ToAsyncDbSet : TestBase.TestBase
        {
            [Test, ExpectedException]
            public void Inner_DbSet_is_required()
            {
                DbSetExtensions.ToAsyncDbSet<TestEntity>(null);
            }

            [Test]
            public void Returns_a_DbSetAdapter()
            {
                var testDbSet = Mock.Of<DbSet<TestEntity>>();

                var actual = DbSetExtensions.ToAsyncDbSet(testDbSet);

                Assert.That(actual, Is.InstanceOf<DbSetAdapter<TestEntity>>().With.Property("Inner").EqualTo(testDbSet));
            }
        }

    }
}
