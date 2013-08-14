using System;
using GeneticSharp.Domain.Chromosomes;
using NUnit.Framework;
using Rhino.Mocks;
using TestSharp;

namespace GeneticSharp.Domain.UnitTests.Chromosomes
{
    [TestFixture]
    public class ChromosomeBaseTest
    {
        [Test]
        public void CompareTo_Others_DiffResults()
        {
            var target = MockRepository.GenerateMock<ChromosomeBase>(1);
            target.Fitness = 0.5;

            var other = MockRepository.GenerateMock<ChromosomeBase>(1);
            other.Fitness = 0.5;

            Assert.AreEqual(-1, target.CompareTo(null));
            Assert.AreEqual(0, target.CompareTo(other));            
            
            other.Fitness = 0.4;
            Assert.AreEqual(1, target.CompareTo(other));

            other.Fitness = 0.6;
            Assert.AreEqual(-1, target.CompareTo(other));
        }

		[Test]
		public void Fitness_AnyChange_Null()
		{
			var target = MockRepository.GenerateStub<ChromosomeBase>(1);
			Assert.IsFalse (target.Fitness.HasValue);
			target.Fitness = 0.5;
			Assert.IsTrue (target.Fitness.HasValue);

			target.Fitness = 0.5;
			target.ReplaceGene (0, new Gene());
			Assert.IsFalse (target.Fitness.HasValue);

			target.Fitness = 0.5;
			target.ReplaceGenes (0, new Gene[]{ new Gene() });
			Assert.IsFalse (target.Fitness.HasValue);

			target.Fitness = 0.5;
			target.GenerateGene (0);
			Assert.IsTrue (target.Fitness.HasValue);

			target.Fitness = 0.5;
			target.ReplaceGene (0, new Gene ());
			Assert.IsFalse (target.Fitness.HasValue);
		}

		[Test]
		public void ReplaceGene_InvalidIndex_Exception()
		{
			var target = MockRepository.GenerateStub<ChromosomeBase>(2);

			ExceptionAssert.IsThrowing (new ArgumentOutOfRangeException("index", "There is no Gene on index 2 to be replaced."), () => {
				target.ReplaceGene (2, new Gene ());
			});

			ExceptionAssert.IsThrowing (new ArgumentOutOfRangeException("index", "There is no Gene on index 3 to be replaced."), () => {
				target.ReplaceGene (3, new Gene ());
			});
		}

		[Test]
		public void ReplaceGene_ValidIndex_Replaced()
		{
			var target = MockRepository.GenerateStub<ChromosomeBase> (2);

			target.ReplaceGene (0, new Gene(2));
			target.ReplaceGene (1, new Gene(6));

			var actual = target.GetGenes ();
			Assert.AreEqual (2, actual.Length);
			Assert.AreEqual (2, actual [0].Value);
			Assert.AreEqual (6, actual [1].Value);
		}

		[Test]
		public void ReplaceGenes_InvalidIndex_Exception()
		{
			var target = MockRepository.GenerateStub<ChromosomeBase>(2);

			ExceptionAssert.IsThrowing (new ArgumentOutOfRangeException("index", "There is no Gene on index 2 to be replaced."), () => {
				target.ReplaceGenes (2, new Gene[0]);
			});

			ExceptionAssert.IsThrowing (new ArgumentOutOfRangeException("index", "There is no Gene on index 3 to be replaced."), () => {
				target.ReplaceGenes (3, new Gene[0]);
			});
		}

		[Test]
		public void ReplaceGenes_ValidIndex_Replaced()
		{
			var target = MockRepository.GenerateStub<ChromosomeBase> (4);

			target.ReplaceGenes (0, new Gene[] { new Gene(1), new Gene(2) });

			var actual = target.GetGenes ();
			Assert.AreEqual (4, actual.Length);
			Assert.AreEqual (1, actual [0].Value);
			Assert.AreEqual (2, actual [1].Value);

			target.ReplaceGenes (2, new Gene[] { new Gene(3), new Gene(4) });

			actual = target.GetGenes ();
			Assert.AreEqual (4, actual.Length);
			Assert.AreEqual (1, actual [0].Value);
			Assert.AreEqual (2, actual [1].Value);
			Assert.AreEqual (3, actual [2].Value);
			Assert.AreEqual (4, actual [3].Value);

			target.ReplaceGenes (3, new Gene[] { new Gene(5) } );

			actual = target.GetGenes ();
			Assert.AreEqual (4, actual.Length);
			Assert.AreEqual (1, actual [0].Value);
			Assert.AreEqual (2, actual [1].Value);
			Assert.AreEqual (3, actual [2].Value);
			Assert.AreEqual (5, actual [3].Value);
		}
    }
}