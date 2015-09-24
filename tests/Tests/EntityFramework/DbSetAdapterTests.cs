using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kralizek.EntityFramework;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using TestBase;

namespace Tests.EntityFramework
{
    public class DbSetAdapterTests : TestBase<DbSetAdapter<TestEntity>>
    {
        private Mock<DbSet<TestEntity>> mockDbSet;

        [SetUp]
        public void Initialize()
        {
            mockDbSet = new Mock<DbSet<TestEntity>>();
        }

        [Test, ExpectedException]
        public void Inner_DbSet_is_required()
        {
            new DbSetAdapter<TestEntity>(null);
        }

        protected override DbSetAdapter<TestEntity> CreateSystemUnderTest()
        {
            return new DbSetAdapter<TestEntity>(mockDbSet.Object);
        }

        [Test]
        public void Add_forwards_to_inner_DbSet()
        {
            TestEntity testItem = Fixture.Create<TestEntity>();

            var sut = CreateSystemUnderTest();

            sut.Add(testItem);

            mockDbSet.Verify(p => p.Add(testItem), Times.Once);
        }

        [Test]
        public void Attach_forwards_to_inner_DbSet()
        {
            TestEntity testItem = Fixture.Create<TestEntity>();

            var sut = CreateSystemUnderTest();

            sut.Attach(testItem);

            mockDbSet.Verify(p => p.Attach(testItem), Times.Once);
        }

        [Test]
        public void Create_forwards_to_inner_DbSet()
        {
            var sut = CreateSystemUnderTest();

            sut.Create();

            mockDbSet.Verify(p => p.Create(), Times.Once);
        }

        [Test]
        public void Create_TDerived_forwards_to_inner_DbSet()
        {
            var sut = CreateSystemUnderTest();

            ((IDbSet<TestEntity>)sut).Create<DerivedTestEntity>();

            mockDbSet.Verify(p => p.Create<DerivedTestEntity>());
        }

        [Test]
        public void Find_forwards_to_inner_DbSet()
        {
            var sut = CreateSystemUnderTest();

            var keys = Fixture.CreateMany<int>();

            sut.Find(keys);

            mockDbSet.Verify(p => p.Find(keys), Times.Once);
        }

        [Test]
        public async Task FindAsync_forwards_to_inner_DbSet()
        {
            var sut = CreateSystemUnderTest();

            var keys = Fixture.CreateMany<int>();

            await sut.FindAsync(keys);

            mockDbSet.Verify(p => p.FindAsync(keys), Times.Once);
        }

        [Test]
        public void Remove_forwards_to_inner_DbSet()
        {
            TestEntity testItem = Fixture.Create<TestEntity>();

            var sut = CreateSystemUnderTest();

            sut.Remove(testItem);

            mockDbSet.Verify(p => p.Remove(testItem), Times.Once);
        }

        [Test]
        public void Generic_GetEnumerator_forwards_to_inner_DbSet()
        {
            var sut = CreateSystemUnderTest();

            sut.GetEnumerator();

            mockDbSet.As<IEnumerable<TestEntity>>().Verify(p => p.GetEnumerator(), Times.Once);
        }

        [Test]
        public void GetEnumerator_forwards_to_inner_DbSet()
        {
            var sut = CreateSystemUnderTest();

            ((IEnumerable)sut).GetEnumerator();

            mockDbSet.As<IEnumerable<TestEntity>>().Verify(p => p.GetEnumerator(), Times.Once);
        }

        [Test]
        public void ElementType_forwards_to_inner_DbSet()
        {
            var sut = CreateSystemUnderTest();

            var value = sut.ElementType;

            mockDbSet.As<IQueryable<TestEntity>>().VerifyGet(p => p.ElementType, Times.Once);
        }

        [Test]
        public void Expression_forwards_to_inner_DbSet()
        {
            var sut = CreateSystemUnderTest();

            var value = sut.Expression;

            mockDbSet.As<IQueryable<TestEntity>>().VerifyGet(p => p.Expression, Times.Once);
        }

        [Test]
        public void Provider_forwards_to_inner_DbSet()
        {
            var sut = CreateSystemUnderTest();

            var value = sut.Provider;

            mockDbSet.As<IQueryable<TestEntity>>().VerifyGet(p => p.Provider, Times.Once);
        }

        [Test]
        public void Local_forwards_to_inner_DbSet()
        {
            var sut = CreateSystemUnderTest();

            var value = sut.Local;

            mockDbSet.VerifyGet(p => p.Local, Times.Once);
        }

        [Test]
        public void Inner_returns_inner_DbSet()
        {
            var sut = CreateSystemUnderTest();

            var actual = sut.Inner;

            Assert.That(actual, Is.SameAs(mockDbSet.Object));
        }
    }
}
